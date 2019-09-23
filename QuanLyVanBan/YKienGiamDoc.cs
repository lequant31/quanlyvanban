using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyVanBan
{
    public partial class YKienGiamDoc : DevExpress.XtraEditors.XtraForm
    {
        QuanLyCongViecEntities quanLyCongViecEntities;
        public YKienGiamDoc()
        {
            InitializeComponent();
        }
        private Guid IdSearch;
        public Guid IdGDVanBanDen;
        public Guid IdEdit;
        private Guid IdDonVi;
        private Guid IdLanhDao;
        public bool _Edit=false;
        private void GetAllItem()
        {
            using (quanLyCongViecEntities = new QuanLyCongViecEntities())
            {
                var ListDonVi = quanLyCongViecEntities.GetAllDonvi().ToList();
                var ListLanhDaoPhuTrach = quanLyCongViecEntities.GetAllLanhDaoDonvi().ToList();
                var ListGDVanBanDen= quanLyCongViecEntities.GetOneGDVanBanDen(IdGDVanBanDen).Single();

                searchDonVi.Properties.DataSource = ListDonVi;
                searchDonVi.Properties.DisplayMember = "TenDonVi";
                searchDonVi.Properties.ValueMember = "Id";

                searchLanhDao.Properties.DataSource = ListLanhDaoPhuTrach;
                searchLanhDao.Properties.DisplayMember = "TenLanhDao";
                searchLanhDao.Properties.ValueMember = "Id";

                memoGhiChu.Text = ListGDVanBanDen.CommentGD;
            }

        }
        private void SearchLanhDaoDonVi()
        {

            using (quanLyCongViecEntities = new QuanLyCongViecEntities())
            {

                var ListLanhDaoDonVi = quanLyCongViecEntities.searchlanhdaodonvi(IdSearch).ToList();
                searchLanhDao.Properties.DataSource = ListLanhDaoDonVi;
                searchLanhDao.Properties.DisplayMember = "TenLanhDao";
                searchLanhDao.Properties.ValueMember = "Id";

            }

        }
        private void AddYKienGD()
        {
            
            using (quanLyCongViecEntities = new QuanLyCongViecEntities())
            {
                if (searchDonVi.EditValue == null)
                {
                    IdDonVi = Guid.Parse(Enum.IdDonVi);
                }
                else
                {
                    IdDonVi = (Guid)searchDonVi.EditValue;
                }
                if (searchLanhDao.EditValue == null)
                {
                    IdLanhDao = Guid.Parse(Enum.IdLanhDao);
                }
                else
                {
                    IdLanhDao = (Guid)searchLanhDao.EditValue;
                }
                if (_Edit == false)
                {
                    Guid id = Guid.NewGuid();
                    quanLyCongViecEntities.AddTheoDoiVanBan(id,IdGDVanBanDen,txtCanBoThuLy.Text,memoGhiChu.Text,comboPGD.Text,
                        IdDonVi,IdLanhDao,"",txtSoNgay.Text,"",DateTime.Now);
                    XtraMessageBox.Show("Lưu thông tin thành công");
                }
                if (_Edit == true)
                {
                    quanLyCongViecEntities.EditTheoDoiVanBan(IdEdit, txtCanBoThuLy.Text, memoGhiChu.Text, comboPGD.Text,
                        IdDonVi, IdLanhDao, "", txtSoNgay.Text, "");
                    _Edit = false;
                    XtraMessageBox.Show("Lưu thông tin thành công");
                }
            }
            
        }
        private void GetOneYKienGD()
        {
            using (quanLyCongViecEntities = new QuanLyCongViecEntities())
            {
                var getone = quanLyCongViecEntities.GetOneTheoDoiVanBanDen(IdEdit).Single();
                comboPGD.EditValue = getone.PGDPhuTrach;
                searchDonVi.EditValue = getone.IdDonViChucNang;
                searchLanhDao.EditValue = getone.IdLanhDaoPhuTrach;
                txtCanBoThuLy.EditValue = getone.CanBoThuLy;
                txtSoNgay.EditValue = getone.NumberDate;
                btnUpload.EditValue = getone.TaiLieuDinhKem;
                memoGhiChu.EditValue = getone.CommentGD;
            }
        }
        private void GetAllNull()
        {
            _Edit = false;
            txtCanBoThuLy.Text = null;
            txtSoNgay.Text = null;
            btnUpload.Text = null;
            memoGhiChu.Text = null;
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllNull();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void btnReNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllNull();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddYKienGD();
        }

        private void searchDonVi_Leave(object sender, EventArgs e)
        {
            #region phải chọn đơn vị
            if (searchDonVi.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn tên đơn vị");
                return;
            }
            #endregion
            IdSearch = (Guid)searchDonVi.EditValue;
            SearchLanhDaoDonVi();
        }

        private void YKienGiamDoc_Load(object sender, EventArgs e)
        {
            GetAllItem();
            if(_Edit==true){ GetOneYKienGD(); }
        }
    }
}