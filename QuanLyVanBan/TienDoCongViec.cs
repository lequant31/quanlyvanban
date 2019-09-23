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
    public partial class TienDoCongViec : DevExpress.XtraEditors.XtraForm
    {
        QuanLyCongViecEntities quanLyCongViecEntities;
        public Guid IdEdit;
        public bool _Edit = false;
        private bool MustReport;
        private string HoanThanh;
        private string ChuaHoanThanh;
        private string DangThucHien;
        private string ChuaThucHien;
        private string ThucHienCham;
        private string KetThucCongViec;
        private Guid IdLinhVucBanHanh;
        private Guid IdDonVi;
        private Guid IdDonViPhoiHop;
        private Guid IdLoaiVanBan;
        private Guid IdCoquanBanhanh;
        private string patition;
        private string pathfile;
        public TienDoCongViec()
        {
            InitializeComponent();
        }
        private void GetAllItem()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var _GetAllCoQuanBanHanh = quanLyCongViecEntities.GetAllCoQuanVaDonVi().ToList();
                    var _GetAllLoaiVanBan = quanLyCongViecEntities.GetAllLoaiVanBan().ToList();
                    var _GetAllLinhVucVanBan = quanLyCongViecEntities.GetAllLinhVucBanHanh().ToList();
                    var _GetAllDonVi = quanLyCongViecEntities.GetAllDonvi().ToList();

                    SearchCoQuanBanHanh.Properties.DataSource = _GetAllCoQuanBanHanh;
                    SearchCoQuanBanHanh.Properties.DisplayMember = "TenCoQuan";
                    SearchCoQuanBanHanh.Properties.ValueMember = "Id";
                    //SearchCoQuanBanHanh.EditValue =Enum.IdCoQuanbanHanh;

                    SearchLoaiVanBan.Properties.DataSource = _GetAllLoaiVanBan;
                    SearchLoaiVanBan.Properties.DisplayMember = "NameVanBan";
                    SearchLoaiVanBan.Properties.ValueMember = "Id";
                    //SearchLoaiVanBan.EditValue = Enum.IdLoaiVanBan;

                    searchLinhVucVanBan.Properties.DataSource = _GetAllLinhVucVanBan;
                    searchLinhVucVanBan.Properties.DisplayMember = "NameLinhVuc";
                    searchLinhVucVanBan.Properties.ValueMember = "Id";
                    //searchLinhVucVanBan.EditValue = Enum.IdLinhVucBanHanh;

                    SearchDonVi.Properties.DataSource = _GetAllDonVi;
                    SearchDonVi.Properties.DisplayMember = "TenDonVi";
                    SearchDonVi.Properties.ValueMember = "Id";
                    //SearchDonVi.EditValue = Enum.IdDonVi;

                    SearchDonViPhoiHop.Properties.DataSource = _GetAllDonVi;
                    SearchDonViPhoiHop.Properties.DisplayMember = "TenDonVi";
                    SearchDonViPhoiHop.Properties.ValueMember = "Id";
                    //SearchDonViPhoiHop.EditValue = Enum.IdDonVi;
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu");
            }
        }
        private void SubtringString()
        {
            string _pathfile = btnTaiLieuDinhKem.Text.Trim();
            if (_pathfile != "")
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
        private void GetAllNull()
        {
            txtSoVanBan.Text = null;

            txtSoGhiSoCongVan.Text = null;
            txtNguoiNhanVanBan.Text = null;
            memoTomTatKetQua.Text = null;
            memoTrichYeuVanBan.Text = null;
            btnTaiLieuDinhKem.Text = null;
            _Edit = false;
        }
        private void AddGDVanBanDen()
        {
            try
            {

                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    //#region kiểm tra ngày phải hoàn thành
                    //if(dateNgayPhaiHoanThanh.EditValue == null)
                    //{
                    //    XtraMessageBox.Show("Phải nhập ngày phải hoàn thành");
                    //    return;
                    //}

                    //#endregion
                    if (radioPhaiBaoCao.SelectedIndex == 0)
                    {
                        MustReport = true;
                    }
                    if (radioPhaiBaoCao.SelectedIndex == 1)
                    {
                        MustReport = false;
                    }
                    if (checkHoanThanh.Checked == true)
                    {
                        HoanThanh = "Hoàn thành";
                    }
                    else
                    {
                        HoanThanh = null;
                    }
                    if (checkChuaHoanThanh.Checked == true)
                    {
                        ChuaHoanThanh = "Chưa hoàn thành";
                    }
                    else
                    {
                        ChuaHoanThanh = null;
                    }
                    if (checkDangThucHien.Checked == true)
                    {
                        DangThucHien = "Đang thực hiện";
                    }
                    else
                    {
                        DangThucHien = null;
                    }
                    if (checkChuaThucHien.Checked == true)
                    {
                        ChuaThucHien = "Chưa thực hiện";
                    }
                    else
                    {
                        ChuaThucHien = null;
                    }
                    if (checkThucHienCham.Checked == true)
                    {
                        ThucHienCham = "Thực hiện chậm";
                    }
                    else
                    {
                        ThucHienCham = null;
                    }
                    if (checkKetThucCongViec.Checked == true)
                    {
                        KetThucCongViec = "Kết thúc công việc";
                    }
                    else
                    {
                        KetThucCongViec = null;
                    }
                    if (searchLinhVucVanBan.EditValue==null)
                    {
                        IdLinhVucBanHanh = Guid.Parse(Enum.IdLinhVucBanHanh);
                    }
                    else
                    {
                        IdLinhVucBanHanh = (Guid)searchLinhVucVanBan.EditValue;
                    }
                    if (SearchLoaiVanBan.EditValue == null)
                    {
                        IdLoaiVanBan = Guid.Parse(Enum.IdLoaiVanBan);
                    }
                    else
                    {
                        
                        IdLoaiVanBan = (Guid)SearchLoaiVanBan.EditValue;
                    }
                    if (SearchDonVi.EditValue == null)
                    {
                        IdDonVi = Guid.Parse(Enum.IdDonVi);
                    }
                    else
                    {
                        IdDonVi = (Guid)SearchDonVi.EditValue;
                    }
                    if (SearchDonViPhoiHop.EditValue == null)
                    {
                        IdDonViPhoiHop = Guid.Parse(Enum.IdDonVi);
                    }
                    else
                    {
                        IdDonViPhoiHop = (Guid)SearchDonViPhoiHop.EditValue;
                    }
                    if (SearchCoQuanBanHanh.EditValue == null)
                    {
                        IdCoquanBanhanh = Guid.Parse(Enum.IdCoQuanbanHanh);
                    }
                    else
                    {
                        IdCoquanBanhanh = (Guid)SearchCoQuanBanHanh.EditValue;
                    }
                    SubtringString();
                    if (_Edit == false)
                    {
                        Guid Id = Guid.NewGuid();
                        Guid idnhap = Guid.Empty;
                        Guid.TryParse("b10bb1ad-f494-4854-8726-a7d9601379bb", out idnhap);
                        quanLyCongViecEntities.AddGDVanBanDen(Id, (DateTime?)dateNgayNhanVanBan.EditValue, IdCoquanBanhanh, IdLoaiVanBan,
                        IdLinhVucBanHanh, txtSoVanBan.Text, (DateTime?)dateNgayPhatHanh.EditValue, memoTrichYeuVanBan.Text, memoCommentGD.Text, txtSoGhiSoCongVan.Text, IdDonVi,
                        IdDonViPhoiHop, (DateTime?)dateNgayChiDao.EditValue, (DateTime?)dateNgayPhaiHoanThanh.EditValue, MustReport,
                        txtNguoiNhanVanBan.Text, (DateTime?)dateNgayChuyenVanBan.EditValue, HoanThanh, ChuaHoanThanh, DangThucHien, ChuaThucHien, ThucHienCham,
                        KetThucCongViec, memoTomTatKetQua.Text, patition, pathfile, idnhap,(DateTime?)DateHoanThanh.EditValue, DateTime.Now);

                        XtraMessageBox.Show("Lưu thông tin thành công");
                    }
                    if (_Edit == true)
                    {
                        quanLyCongViecEntities.EditGDVanBanDen(IdEdit, (DateTime?)dateNgayNhanVanBan.EditValue, IdCoquanBanhanh, IdLoaiVanBan,
                            IdLinhVucBanHanh, txtSoVanBan.Text, (DateTime?)dateNgayPhatHanh.EditValue, memoTrichYeuVanBan.Text, memoCommentGD.Text, txtSoGhiSoCongVan.Text, IdDonVi,
                            IdDonViPhoiHop, (DateTime?)dateNgayChiDao.EditValue, (DateTime?)dateNgayPhaiHoanThanh.EditValue, MustReport,
                            txtNguoiNhanVanBan.Text, (DateTime?)dateNgayChuyenVanBan.EditValue, HoanThanh, ChuaHoanThanh, DangThucHien, ChuaThucHien, ThucHienCham,
                            KetThucCongViec, memoTomTatKetQua.Text, patition, pathfile, (DateTime?)DateHoanThanh.EditValue);
                        XtraMessageBox.Show("Lưu thông tin thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                //throw;
                XtraMessageBox.Show(ex.Message);
            }    
        }
        private void GetOneGDVanBanDen()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var _GetOne = quanLyCongViecEntities.GetOneGDVanBanDen(IdEdit).Single();
                    dateNgayNhanVanBan.EditValue = _GetOne.DateNgayNhan;
                    SearchCoQuanBanHanh.EditValue = _GetOne.IdCoQuanBanHanhVanBan;
                    SearchLoaiVanBan.EditValue = _GetOne.IdLoaiVanBan;
                    searchLinhVucVanBan.EditValue = _GetOne.IdLinhVucBanHanh;
                    txtSoVanBan.EditValue = _GetOne.SoVanBan;
                    dateNgayPhatHanh.EditValue = _GetOne.DateNgayPhatHanh;
                    txtSoGhiSoCongVan.EditValue = _GetOne.NumberSoCongVan;
                    memoTrichYeuVanBan.EditValue = _GetOne.TrichYeuVanBan;
                    memoCommentGD.EditValue = _GetOne.CommentGD;
                    SearchDonVi.EditValue = _GetOne.IDDonViChuTri;
                    SearchDonViPhoiHop.EditValue = _GetOne.IDDonVIPhoiHop;
                    dateNgayChiDao.EditValue = _GetOne.DateNgayChiDao;
                    dateNgayPhaiHoanThanh.EditValue = _GetOne.DateNgayPhaiHoanThanh;
                    radioPhaiBaoCao.EditValue = _GetOne.PhaiBaoCao;
                    txtNguoiNhanVanBan.EditValue = _GetOne.NguoiNhanVanBan;
                    dateNgayChuyenVanBan.EditValue = _GetOne.DateChuyenVanBanToiDonVi;
                    btnTaiLieuDinhKem.EditValue = _GetOne.Patition + ":\\" + _GetOne.TaiLIeuDinhKem;
                    DateHoanThanh.EditValue = _GetOne.DateHoanThanh;
                    if(_GetOne.HoanThanh != null)
                    {
                        checkHoanThanh.Checked = true;
                    }
                    if (_GetOne.ChuaHoanThanh != null)
                    {
                        checkChuaHoanThanh.Checked = true;
                    }
                    if (_GetOne.DangThucHien != null)
                    {
                        checkDangThucHien.Checked = true;
                    }
                    if (_GetOne.ChuaThucHien != null)
                    {
                        checkChuaThucHien.Checked = true;
                    }
                    if (_GetOne.ThucHienCham != null)
                    {
                        checkThucHienCham.Checked = true;
                    }
                    if (_GetOne.KetThucCongViec != null)
                    {
                        checkKetThucCongViec.Checked = true;
                    }
                    memoTomTatKetQua.EditValue = _GetOne.TomTatKetQua;
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }
        private void TienDoCongViec_Load(object sender, EventArgs e)
        {
            
            GetAllItem();
            if (_Edit == true)
            {
                GetOneGDVanBanDen();
            }
        }

        private void btnTaiLieuDinhKem_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "Files pdf|*.pdf*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    btnTaiLieuDinhKem.Text = fi.FullName;
                }
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddGDVanBanDen();
            GetAllNull();
            
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllNull();
        }

        private void btnReNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllNull();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    quanLyCongViecEntities.DeleteGDVanBanDen(IdEdit);
                    XtraMessageBox.Show("Xóa thông tin thành công");
                }
                GetAllNull();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Thông tin không có trong cơ sở dữ liệu");
            }
        }

        private void txtSoVanBan_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateNgayPhatHanh_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dateNgayPhatHanh_Leave(object sender, EventArgs e)
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var status = quanLyCongViecEntities.CheckExistVanBanDen(txtSoVanBan.Text, (DateTime?)dateNgayPhatHanh.EditValue).ToList();
                    if (status.Count() > 0)
                    {
                        XtraMessageBox.Show("Văn bản đến đã được nhận");
                    }

                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu");
            }
        }

        private void txtSoVanBan_Leave(object sender, EventArgs e)
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    if (txtSoVanBan.Text != null && dateNgayPhatHanh.EditValue != null)
                    {
                        var status = quanLyCongViecEntities.CheckExistVanBanDen(txtSoVanBan.Text, (DateTime?)dateNgayPhatHanh.EditValue).ToList();
                        if (status.Count() > 0)
                        {
                            XtraMessageBox.Show("Văn bản đến đã được nhận");
                        }
                    }

                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu");
            }
        }
    }
}