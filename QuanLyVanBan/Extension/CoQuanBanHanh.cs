using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyVanBan.Extension
{
    public partial class CoQuanBanHanh : DevExpress.XtraEditors.XtraUserControl
    {
        private static CoQuanBanHanh _ucCoQuanBanHanh;
        public static CoQuanBanHanh ucCoQuanBanHanh
        {
            get
            {
                if (_ucCoQuanBanHanh == null)
                    _ucCoQuanBanHanh = new CoQuanBanHanh();
                return _ucCoQuanBanHanh;
            }
        }
        QuanLyCongViecEntities quanLyCongViecEntities;
        private bool active;
        private bool edit = false;
        Guid guidEdit;
        private void GetAllCoQuanBanHanh()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var _GetAllCoQuanBanHanh = quanLyCongViecEntities.GetAllCoQuanBanhanhVanBan().ToList();
                    grcCoQuanBanHanh.DataSource = _GetAllCoQuanBanHanh;
                }
            }
            catch (Exception)
            {
                //throw;
                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");

            }
        }
        private void GetAllNull()
        {
            edit = false;
            txtSoHieu.Text = null;
            txtTenCoQuan.Text = null;
            txt_PrintName.Text = null;
        }
        private void AddCoQuanbanHanh()
        {

            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    if (radioInOrOut.SelectedIndex == 0)
                    {
                        active = true;
                    }
                    if (radioInOrOut.SelectedIndex == 1)
                    {
                        active = false;
                    }
                    if (edit == false)
                    {
                        Guid Id = Guid.NewGuid();
                        quanLyCongViecEntities.AddCoQuanBanHanhVanBan(Id, txtTenCoQuan.Text, txtSoHieu.Text,active,txt_PrintName.Text, DateTime.Now);
                    }
                    else
                    {
                        quanLyCongViecEntities.EditCoQuanBanHanhVanBan(guidEdit, txtTenCoQuan.Text, txtSoHieu.Text,active,txt_PrintName.Text);
                    }

                }
            }
            catch (Exception)
            {
                //throw;
                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }
        private void GetOneCoQuanBanHanh()
        {
            guidEdit = (Guid)grvCoQuanBanHanh.GetFocusedRowCellValue("Id");
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var edit = quanLyCongViecEntities.GetOneCoQuanbanHanhVanBan(guidEdit).Single();
                    txtSoHieu.EditValue = edit.KyHieu;
                    txtTenCoQuan.EditValue = edit.TenCoQuan;
                    radioInOrOut.EditValue = edit.InOrOut;
                    txt_PrintName.Text = edit.PrintName;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public CoQuanBanHanh()
        {
            InitializeComponent();
        }

        private void CoQuanBanHanh_Load(object sender, EventArgs e)
        {
            GetAllCoQuanBanHanh();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllNull();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = true;
            GetOneCoQuanBanHanh();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid guid = (Guid)grvCoQuanBanHanh.GetFocusedRowCellValue("Id");
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    quanLyCongViecEntities.DeleteCoQuanBanHanhVanBan(guid);
                }
                GetAllCoQuanBanHanh();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllCoQuanBanHanh();
            GetAllNull();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddCoQuanbanHanh();
            GetAllCoQuanBanHanh();
        }

        private void grvCoQuanBanHanh_DoubleClick(object sender, EventArgs e)
        {
            edit = true;
            GetOneCoQuanBanHanh();
        }

        private void grvCoQuanBanHanh_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void radioInOrOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioInOrOut.SelectedIndex==0)
            {
                txt_PrintName.Text = txtSoHieu.Text;
            }
            else
            {
                txt_PrintName.Text = txtTenCoQuan.Text;
            }
        }

        private void txtTenCoQuan_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (radioInOrOut.SelectedIndex == 0)
            {
                txt_PrintName.Text = txtSoHieu.Text;
            }
            else
            {
                txt_PrintName.Text = txtTenCoQuan.Text;
            }
        }
    }
}
