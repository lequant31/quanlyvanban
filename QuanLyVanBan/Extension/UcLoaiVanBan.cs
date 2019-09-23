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
    public partial class UcLoaiVanBan : DevExpress.XtraEditors.XtraUserControl
    {
        QuanLyCongViecEntities quanLyCongViecEntities;
        private static UcLoaiVanBan _ucLoaiVanBan;
        public static UcLoaiVanBan ucLoaiVanBan
        {
            get
            {
                if (_ucLoaiVanBan == null)
                    _ucLoaiVanBan = new UcLoaiVanBan();
                return _ucLoaiVanBan;
            }
        }
        private bool edit = false;
        Guid guidEdit;

        private void GetAllLoaiVanBan()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var _GetAllLoaiVanBan = quanLyCongViecEntities.GetAllLoaiVanBan().ToList();
                    grcLoaiVanBan.DataSource = _GetAllLoaiVanBan;
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
            txtMaVanBan.Text = null;
            txtTenLoaiVanBan.Text = null;
        }
        private void AddLoaiVanBan()
        {

            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    if (edit == false)
                    {
                        Guid Id = Guid.NewGuid();
                        quanLyCongViecEntities.AddLoaiVanBan(Id, txtMaVanBan.Text, txtTenLoaiVanBan.Text, DateTime.Now);
                    }
                    else
                    {
                        quanLyCongViecEntities.EditLoaiVanBan(guidEdit, txtMaVanBan.Text, txtTenLoaiVanBan.Text);
                    }

                }
            }
            catch (Exception)
            {
                //throw;
                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }
        private void GetOneLoaiVanBan()
        {
            guidEdit = (Guid)grvLoaiVanBan.GetFocusedRowCellValue("Id");
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var edit = quanLyCongViecEntities.GetOneLoaiVanBan(guidEdit).Single();
                    txtMaVanBan.EditValue = edit.CodeVanBan;
                    txtTenLoaiVanBan.EditValue = edit.NameVanBan;
                }

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }
        public UcLoaiVanBan()
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
            GetOneLoaiVanBan();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            guidEdit = (Guid)grvLoaiVanBan.GetFocusedRowCellValue("Id");
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    quanLyCongViecEntities.DeleteLoaiVanBan(guidEdit);
                }
                GetAllLoaiVanBan();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = false;
            GetAllLoaiVanBan();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddLoaiVanBan();
            GetAllLoaiVanBan();
            edit = false;
        }

        private void grvLoaiVanBan_DoubleClick(object sender, EventArgs e)
        {
            edit = true;
            GetOneLoaiVanBan();
        }

        private void UcLoaiVanBan_Load(object sender, EventArgs e)
        {
            GetAllLoaiVanBan();
        }

        private void grvLoaiVanBan_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
