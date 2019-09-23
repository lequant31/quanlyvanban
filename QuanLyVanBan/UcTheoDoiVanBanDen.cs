using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyVanBan.Extension;
using System.Threading.Tasks;
using PagedList;

namespace QuanLyVanBan
{
    public partial class UcTheoDoiVanBanDen : DevExpress.XtraEditors.XtraUserControl
    {
        QuanLyCongViecEntities quanLyCongViecEntities;
        private static UcTheoDoiVanBanDen _ucTheoDoiVanBan;
        public static UcTheoDoiVanBanDen ucTheoDoiVanBan
        {
            get
            {
                if (_ucTheoDoiVanBan == null)
                    _ucTheoDoiVanBan = new UcTheoDoiVanBanDen();
                return _ucTheoDoiVanBan;
            }
        }
        public UcTheoDoiVanBanDen()
        {
            InitializeComponent();
        }
        
        private void GetAllGDVanBanDen()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var _GetAllGDVanBanDen = quanLyCongViecEntities.GetAllGDVanBanDen().ToList();
                    grcTienDoCongViec.DataSource = _GetAllGDVanBanDen;

                    //var _getall = quanLyCongViecEntities.GetAllTheoDoiVanBan1().ToList();
                    //grcYKienGiamDoc.DataSource = _getall;
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                TienDoCongViec frm = new TienDoCongViec();
                frm._Edit = false;
                frm.ShowDialog();
           
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid guid = (Guid)grvTienDoCongViec.GetFocusedRowCellValue("Id");
           
                TienDoCongViec frm = new TienDoCongViec();
                frm._Edit = true;
                frm.IdEdit = guid;
                frm.ShowDialog(); 
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllGDVanBanDen();
        }

        private void btnComment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid guid = (Guid)grvTienDoCongViec.GetFocusedRowCellValue("Id");
            try
            {
                YKienGiamDoc yKienGiamDoc = new YKienGiamDoc();
                yKienGiamDoc.IdGDVanBanDen=guid;
                yKienGiamDoc._Edit = false;
                yKienGiamDoc.ShowDialog();
             
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Kiểm tra lại thông tin đã nhập");
            }
           
        }

        private void UcTheoDoiVanBanDen_Load(object sender, EventArgs e)
        {
            GetAllGDVanBanDen();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid guid = (Guid)grvTienDoCongViec.GetFocusedRowCellValue("Id");
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    quanLyCongViecEntities.DeleteGDVanBanDen(guid);
                    XtraMessageBox.Show("Xóa thông tin thành công");
                }
                GetAllGDVanBanDen();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Vui lòng xóa ở bảng dưới trước khi xóa ở đây");
            }
        }

        private void grvTienDoCongViec_DoubleClick(object sender, EventArgs e)
        {
            Guid guid = (Guid)grvTienDoCongViec.GetFocusedRowCellValue("Id");
           
                TienDoCongViec frm = new TienDoCongViec();
                frm._Edit = true;
                frm.IdEdit = guid;
                frm.ShowDialog();
           
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            string tailieudinhkem = (string)grvTienDoCongViec.GetFocusedRowCellValue("tailieu");
            if (tailieudinhkem != null)
            {
                ViewPdf view = new ViewPdf();
                view.FileNamePdf = (string)grvTienDoCongViec.GetFocusedRowCellValue("tailieu");
                view.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Không có tài liệu đính kèm");
            }
        }

        private void grcTienDoCongViec_Click(object sender, EventArgs e)
        {
            try
            {
                int i = grvTienDoCongViec.FocusedRowHandle;
                if (i < 0)
                {
                    return;
                }
                Guid guid = (Guid)grvTienDoCongViec.GetFocusedRowCellValue("Id");
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var GetAllTheoDoivanBan = quanLyCongViecEntities.GetAllTheoDoiVanBan(guid).ToList();
                    grcYKienGiamDoc.DataSource = GetAllTheoDoivanBan;
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu");
            }
        }

        private void btnDeleteYKienGD_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa thông tin?", "Confirmation", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)

                return;
                Guid guid = (Guid)grvYKienGiamDoc.GetFocusedRowCellValue("Id");
                quanLyCongViecEntities = new QuanLyCongViecEntities();
                quanLyCongViecEntities.DeleteTheoDoiVanBan(guid);
                var GetAllTheoDoivanBan = quanLyCongViecEntities.GetAllTheoDoiVanBan(guid).ToList();
                grcYKienGiamDoc.DataSource = GetAllTheoDoivanBan;
                XtraMessageBox.Show("Xóa thông tin thành công");
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu");
            }
        }

        private void grvYKienGiamDoc_DoubleClick(object sender, EventArgs e)
        {
            Guid guid = (Guid)grvYKienGiamDoc.GetFocusedRowCellValue("Id");
            Guid guidGDVanBanDen = (Guid)grvTienDoCongViec.GetFocusedRowCellValue("Id");
            try
            {
                YKienGiamDoc frm = new YKienGiamDoc();
                frm._Edit = true;
                frm.IdEdit = guid;
                frm.IdGDVanBanDen = guidGDVanBanDen;
                frm.ShowDialog();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }

        private void grvTienDoCongViec_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void grvYKienGiamDoc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs f)
        {
            if (f.Info.IsRowIndicator && f.RowHandle >= 0)
            {
                f.Info.DisplayText = (f.RowHandle + 1).ToString();
            }
        }

    }
}
