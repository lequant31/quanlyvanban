using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyVanBan.Extension
{
    public partial class UcLinhVucBanHanh : DevExpress.XtraEditors.XtraUserControl
    {
        QuanLyCongViecEntities quanLyCongViecEntities;
        private static UcLinhVucBanHanh _ucLinhVucBanHanh;
        public static UcLinhVucBanHanh ucLinhVucBanHanh
        {
            get
            {
                if (_ucLinhVucBanHanh == null)
                    _ucLinhVucBanHanh = new UcLinhVucBanHanh();
                return _ucLinhVucBanHanh;
            }
        }
        private bool edit = false;
        Guid guidEdit;

        private void GetAllLinhVucBanHanh()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var _GetAllLinhVucBanHanh = quanLyCongViecEntities.GetAllLinhVucBanHanh().ToList();
                    grcLinhVuc.DataSource = _GetAllLinhVucBanHanh;
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
            txtCodeLinhVuc.Text = null;
            txtNameLinhVuc.Text = null;
        }
        private void AddLinhVucBanHanh()
        {

            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    if (edit == false)
                    {
                        Guid Id = Guid.NewGuid();
                        quanLyCongViecEntities.AddLinhVucBanHanh(Id, txtCodeLinhVuc.Text, txtNameLinhVuc.Text, DateTime.Now);
                    }
                    else
                    {
                        quanLyCongViecEntities.EditLinhVucBanHanh(guidEdit, txtCodeLinhVuc.Text, txtNameLinhVuc.Text);
                    }

                }
            }
            catch (Exception)
            {
                //throw;
                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }
        private void GetOneLinhVucBanHanh()
        {
            guidEdit = (Guid)grvLinhVuc.GetFocusedRowCellValue("Id");
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var edit = quanLyCongViecEntities.GetOneLinhVucBanHanh(guidEdit).Single();
                    txtCodeLinhVuc.EditValue = edit.CodeLinhVuc;
                    txtNameLinhVuc.EditValue = edit.NameLinhVuc;
                }

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }
        public UcLinhVucBanHanh()
        {
            InitializeComponent();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllNull();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = true;
            GetOneLinhVucBanHanh();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid guid = (Guid)grvLinhVuc.GetFocusedRowCellValue("Id");
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    quanLyCongViecEntities.DeleteLinhVucBanHanh(guid);
                }
                GetAllLinhVucBanHanh();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = false;
            GetAllLinhVucBanHanh();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddLinhVucBanHanh();
            GetAllNull();
            edit = false;
            GetAllLinhVucBanHanh();
        }

        private void grvLinhVuc_DoubleClick(object sender, EventArgs e)
        {
            edit = true;
            GetOneLinhVucBanHanh();
        }

        private void grvLinhVuc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
