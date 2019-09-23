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
    public partial class UcLanhDaoDonVi : DevExpress.XtraEditors.XtraUserControl
    {
        private static UcLanhDaoDonVi _ucLanhDaoDonVi;
        public static UcLanhDaoDonVi ucLanhDaoDonVi
        {
            get
            {
                if (_ucLanhDaoDonVi == null)
                    _ucLanhDaoDonVi = new UcLanhDaoDonVi();
                return _ucLanhDaoDonVi;
            }
        }
        QuanLyCongViecEntities quanLyCongViecEntities;
        private bool active;
        private bool edit = false;
        Guid guidId;
        public UcLanhDaoDonVi()
        {
            InitializeComponent();
        }
        private void AddLanhDaoDonVi()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    if (radioActive.SelectedIndex == 0)
                    {
                        active = true;
                    }
                    if (radioActive.SelectedIndex == 1)
                    {
                        active = false;
                    }
                    if (edit == false)
                    {
                        guidId = Guid.NewGuid();
                        quanLyCongViecEntities.AddLanhDaoDonVi(guidId, txtTenLanhDao.Text, comboChucVu.Text, (Guid)searchDonVi.EditValue, DateTime.Now, active);
                        edit = false;
                    }
                    if (edit==true)
                    {
                        quanLyCongViecEntities.EditLanhDaoDonVi(guidId, txtTenLanhDao.Text, comboChucVu.Text, active);
                        edit = false;
                    }
                    
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi không kết nối được với cơ sở dữ liệu");
                //throw;
            }
        }
        private void GetAllLanhDaoDonVi()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var _GetAllLanhDaoDonVi = quanLyCongViecEntities.GetAllLanhDaoDonvi().ToList();
                    grcLanhDaoDonVi.DataSource = _GetAllLanhDaoDonVi;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void GetAllNull()
        {
            edit = false;
            txtTenLanhDao.Text = null;
            comboChucVu.Text = null;
        }
        private void GetAllDonVi()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var _GetAllDonVi = quanLyCongViecEntities.GetDonViSearch().ToList();
                    searchDonVi.Properties.DataSource = _GetAllDonVi;
                    searchDonVi.Properties.DisplayMember = "TenDonVi";
                    searchDonVi.Properties.ValueMember = "Id";
                }

            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi không thể kết nối được cơ sở dữ liệu");
            }
        }
        private void GetOneLanhDaoDonVi()
        {
            guidId = (Guid)grvLanhDaoDonVi.GetFocusedRowCellValue("Id");
            GetAllDonVi();
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var edit = quanLyCongViecEntities.GetOneLanhDaoDonVi(guidId).SingleOrDefault();
                    searchDonVi.EditValue = edit.IdDonVi;
                    txtTenLanhDao.EditValue = edit.TenLanhDao;
                    comboChucVu.EditValue = edit.ChucVu;
                    radioActive.EditValue = edit.Actived;
                }

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi không thể kết nối được cơ sở dữ liệu");
            }
        }

        private void UcLanhDaoDonVi_Load(object sender, EventArgs e)
        {
            GetAllDonVi();
            GetAllLanhDaoDonVi();
        }
        private void btnsave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddLanhDaoDonVi();
            GetAllLanhDaoDonVi();
        }
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllLanhDaoDonVi();
        }
        private void grvLanhDaoDonVi_DoubleClick(object sender, EventArgs e)
        {
            GetOneLanhDaoDonVi();
            edit = true;
        }
        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            {
                GetOneLanhDaoDonVi();
                edit = true;
            }
        }
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid guid = (Guid)grvLanhDaoDonVi.GetFocusedRowCellValue("Id");
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    quanLyCongViecEntities.DeleteLanhDaoDonVi(guid);
                }
                GetAllLanhDaoDonVi();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            searchDonVi.EditValue = null;
            GetAllNull();
        }

        private void grvLanhDaoDonVi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
