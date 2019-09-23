using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace QuanLyVanBan
{
    public partial class FormVanBanGiamDocKyBanHanh : DevExpress.XtraEditors.XtraForm
    {
        QuanLyCongViecEntities quanLyCongViecEntities;
        private Guid IdSearch;
        public Guid IdEdit;
        public bool _edit = false;
        private Guid IdDonVi;
        private Guid IdLanhDao;
        private Guid IdLoaiVanBan;
        private Guid IdLinhVucBanHanh;
        private string patition;
        private string pathfile;
        public FormVanBanGiamDocKyBanHanh()
        {
            InitializeComponent();
        }
        private void GetAllItem()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var ListLinhVucBanHanh = quanLyCongViecEntities.GetAllLinhVucBanHanh().ToList();
                    var ListloaiVanBan = quanLyCongViecEntities.GetAllLoaiVanBan().ToList();
                    var ListDonViThamMuu = quanLyCongViecEntities.GetAllDonvi().ToList();
                    var ListLanhDaoPhuTrach = quanLyCongViecEntities.GetAllLanhDaoDonvi().ToList();
                    //search lĩnh vực
                    searchLinhVucBanHanh.Properties.DataSource = ListLinhVucBanHanh;
                    searchLinhVucBanHanh.Properties.DisplayMember = "NameLinhVuc";
                    searchLinhVucBanHanh.Properties.ValueMember = "Id";
                    // search đơn vị tham muu
                    searchDonViThamMuu.Properties.DataSource = ListDonViThamMuu;
                    searchDonViThamMuu.Properties.DisplayMember = "TenDonVi";
                    searchDonViThamMuu.Properties.ValueMember = "Id";
                    //search loại văn bản
                    searchLoaivanBan.Properties.DataSource = ListloaiVanBan;
                    searchLoaivanBan.Properties.DisplayMember = "NameVanBan";
                    searchLoaivanBan.Properties.ValueMember = "Id";
                    //search lãnh đạo phụ trách
                    searchLanhDaoPhuTrach.Properties.DataSource = ListLanhDaoPhuTrach;
                    searchLanhDaoPhuTrach.Properties.DisplayMember = "TenLanhDao";
                    searchLanhDaoPhuTrach.Properties.ValueMember = "Id";

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void SearchLanhDaoDonVi()
        {

                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {

                        var ListLanhDaoDonVi = quanLyCongViecEntities.searchlanhdaodonvi(IdSearch).ToList();
                        searchLanhDaoPhuTrach.Properties.DataSource = ListLanhDaoDonVi;
                        searchLanhDaoPhuTrach.Properties.DisplayMember = "TenLanhDao";
                        searchLanhDaoPhuTrach.Properties.ValueMember = "Id";

                }
  
        }
        private void GetAllGDKyBanHanh()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var getall = quanLyCongViecEntities.GetAllGDKyBanHanh().ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void AddGDKyBanHanh()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    SubtringString();
                    if (searchDonViThamMuu.EditValue == null)
                    {
                        IdDonVi = Guid.Parse(Enum.IdDonVi);
                    }
                    else
                    {
                        IdDonVi = (Guid)searchDonViThamMuu.EditValue;
                    }
                    if (searchLanhDaoPhuTrach.EditValue == null)
                    {
                        IdLanhDao = Guid.Parse(Enum.IdLanhDao);
                    }
                    else
                    {
                        IdLanhDao = (Guid)searchLanhDaoPhuTrach.EditValue;
                    }
                    if (searchLinhVucBanHanh.EditValue == null)
                    {
                        IdLinhVucBanHanh = Guid.Parse(Enum.IdLinhVucBanHanh);
                    }
                    else
                    {
                        IdLinhVucBanHanh = (Guid)searchLinhVucBanHanh.EditValue;
                    }
                    if (searchLoaivanBan.EditValue == null)
                    {
                        IdLoaiVanBan = Guid.Parse(Enum.IdLoaiVanBan);
                    }
                    else
                    {

                        IdLoaiVanBan = (Guid)searchLoaivanBan.EditValue;
                    }
                    if (_edit == false)
                    {
                        Guid Id = Guid.NewGuid();
                        Guid idnhap = Guid.Empty;
                        Guid.TryParse("b10bb1ad-f494-4854-8726-a7d9601379bb", out idnhap);
                        quanLyCongViecEntities.AddGDKyBanHanh(Id, IdLinhVucBanHanh, IdLoaiVanBan, IdDonVi,
                            IdLanhDao, txtCanBoThamMuu.Text, (DateTime?)dateNgayTrinhVanBan.EditValue, (DateTime?)dateNgayKyVanBan.EditValue,
                            txtSoVanBan.Text, (DateTime?)dateNgayVanBan.EditValue, memoTrichYeuVanBan.Text, patition, pathfile, idnhap, DateTime.Now);
                        XtraMessageBox.Show("Lưu thông tin thành công");
                    }
                    if (_edit==true)
                    {
                        quanLyCongViecEntities.EditGDKyBanHanh(IdEdit, IdLinhVucBanHanh, IdLoaiVanBan, IdDonVi,
                            IdLanhDao, txtCanBoThamMuu.Text, (DateTime?)dateNgayTrinhVanBan.EditValue, (DateTime?)dateNgayKyVanBan.EditValue,
                            txtSoVanBan.Text, (DateTime?)dateNgayVanBan.EditValue, memoTrichYeuVanBan.Text, patition, pathfile);
                        XtraMessageBox.Show("Lưu thông tin thành công");
                    }
                    GetAllNull();
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Kiểm tra thông tin đang nhập");
            }
        }
        private void GetAllNull()
        {
            _edit = false;
            IdEdit = Guid.NewGuid();
            txtCanBoThamMuu.Text = null;
            txtSoVanBan.Text = null;
            btnUpload.Text = null;
        }
        private void GetOneGDKyBanHanh()
        {
            try
            {
                GetAllItem();
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var GetGDKyBanHanh = quanLyCongViecEntities.GetOneGDKyBanHanh(IdEdit).Single();
                    searchLinhVucBanHanh.EditValue = GetGDKyBanHanh.IdLinhVucBanHanh;
                    searchLoaivanBan.EditValue = GetGDKyBanHanh.IdLoaiVanBan;
                    searchDonViThamMuu.EditValue = GetGDKyBanHanh.IdDonViThamMuu;
                    searchLanhDaoPhuTrach.EditValue = GetGDKyBanHanh.IdLanhDaoPhuTrach;
                    txtCanBoThamMuu.Text = GetGDKyBanHanh.CanBoThamMuu;
                    dateNgayTrinhVanBan.EditValue = GetGDKyBanHanh.DateTrinhVanBan;
                    dateNgayKyVanBan.EditValue = GetGDKyBanHanh.DateKyVanBan;
                    txtSoVanBan.Text = GetGDKyBanHanh.NumberVanBan;
                    dateNgayVanBan.EditValue = GetGDKyBanHanh.DateVanBan;
                    memoTrichYeuVanBan.EditValue = GetGDKyBanHanh.TrichYeuVanBan;
                    string pathfile = GetGDKyBanHanh.Partitons +":\\" + GetGDKyBanHanh.TaiLieuDinhKem;
                    if (pathfile ==":\\")
                    {
                        btnUpload.Text = "";
                    }
                    else
                    {
                        btnUpload.Text = pathfile;
                    }
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void SubtringString()
        {
            string _pathfile = btnUpload.Text.Trim();
            if (_pathfile !="" )
            {
                if (_pathfile != ":\\")
                {
                    
                        patition = _pathfile.Substring(0, 1).Trim();
                        pathfile = _pathfile.Substring(3, _pathfile.Length - 3).Trim();
                    
                }
                return;
            }
            return;

        }
        private void FormVanBanGiamDocKyBanHanh_Load(object sender, EventArgs e)
        {
            
            try
            {

                if (_edit == true)
                {
                    GetOneGDKyBanHanh();
                }
                if (_edit==false)
                {
                    GetAllItem();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void searchDonViThamMuu_Leave(object sender, EventArgs e)
        {
            #region phải chọn đơn vị
            if (searchDonViThamMuu.EditValue ==null)
            {
                XtraMessageBox.Show("Vui lòng chọn tên đơn vị");
                return;
            }
            #endregion
            IdSearch = (Guid)searchDonViThamMuu.EditValue;
            SearchLanhDaoDonVi();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddGDKyBanHanh();
        }

        private void btnUpload_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "Files pdf|*.pdf*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName); 
                    btnUpload.Text = fi.FullName;
                }
            }
        }

        private void btnReNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllNull();
        }

        private void btndelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    quanLyCongViecEntities.DeleteGDKyBanHanh(IdEdit);
                }
                XtraMessageBox.Show("Xóa thông tin thành công");
                GetAllNull();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu");
            }
        }
    }
}