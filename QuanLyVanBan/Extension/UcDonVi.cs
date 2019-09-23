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
    public partial class UcDonVi : DevExpress.XtraEditors.XtraUserControl
    {
        QuanLyCongViecEntities quanLyCongViecEntities;
        private static UcDonVi _ucDonVi;
        public static UcDonVi ucDonVi
        {
            get
            {
                if (_ucDonVi == null)
                    _ucDonVi = new UcDonVi();
                return _ucDonVi;
            }
        }
        private bool edit = false;
        Guid guidEdit;
        public UcDonVi()
        {
            InitializeComponent();
        }
        private void GetAllDonVi()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var _GetAllDonVi = quanLyCongViecEntities.GetAllDonvi().ToList();
                    grcDonVi.DataSource = _GetAllDonVi;
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
            txt_kyhieudonvi.Text = null;
            txt_tendonvi.Text = null;
        }
        private void AddDonvi()
        {
            
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    if (edit == false) {
                        Guid Id = Guid.NewGuid();
                        quanLyCongViecEntities.AddDonVi(Id, txt_tendonvi.Text, txt_kyhieudonvi.Text,true,txt_PrintName.Text, DateTime.Now);
                    }
                    else
                    {
                        quanLyCongViecEntities.EditDonVi(guidEdit,txt_tendonvi.Text,txt_kyhieudonvi.Text,true,txt_PrintName.Text);
                    }
                    
                }
            }
            catch (Exception)
            {
                //throw;
                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }
        private void GetOneDonVi()
        {
            guidEdit = (Guid)grvDonVi.GetFocusedRowCellValue("Id");
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var edit=quanLyCongViecEntities.GetOneDonVi(guidEdit).Single();
                    txt_kyhieudonvi.EditValue = edit.MaDonVi;
                    txt_tendonvi.EditValue = edit.TenDonVi;
                    txt_PrintName.EditValue = edit.PrintName;
                }
                
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }
        private void UcDonVi_Load(object sender, EventArgs e)
        {
            GetAllDonVi();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllDonVi();
            GetAllNull();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllNull();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddDonvi();
            GetAllDonVi();
            edit = false;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid guid = (Guid)grvDonVi.GetFocusedRowCellValue("Id");
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    quanLyCongViecEntities.DeleteDonVi(guid);
                }
                GetAllDonVi();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = true;
            GetOneDonVi();
        }

        private void grvDonVi_DoubleClick(object sender, EventArgs e)
        {
            edit = true;
            GetOneDonVi();
        }

        private void grvDonVi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void txt_tendonvi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            txt_PrintName.Text = txt_kyhieudonvi.Text + " " + txt_tendonvi.Text;
        }
    }
}
