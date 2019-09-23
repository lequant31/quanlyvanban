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

namespace QuanLyVanBan
{
    public partial class UcVanBanGiamDocKyBanHanh : DevExpress.XtraEditors.XtraUserControl
    {
        QuanLyCongViecEntities quanLyCongViecEntities;
        private static UcVanBanGiamDocKyBanHanh _ucVanBanGiamDoc;
        public static UcVanBanGiamDocKyBanHanh ucVanBanGiamDoc
        {
            get
            {
                if (_ucVanBanGiamDoc == null)
                    _ucVanBanGiamDoc = new UcVanBanGiamDocKyBanHanh();
                return _ucVanBanGiamDoc;
            }
        }
        public UcVanBanGiamDocKyBanHanh()
        {
            InitializeComponent();
        }
        private void GetAllGDKyBanHanh()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var getall = quanLyCongViecEntities.GetAllGDKyBanHanh().ToList();
                    grcVanbanGDKy.DataSource = getall;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void barBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormVanBanGiamDocKyBanHanh frm = new FormVanBanGiamDocKyBanHanh();
            frm._edit = false;
            frm.ShowDialog();
        }

        private void UcVanBanGiamDocKyBanHanh_Load(object sender, EventArgs e)
        {
            GetAllGDKyBanHanh();
        }

        private void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllGDKyBanHanh();
        }

        private void barBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid guid = (Guid)grvVanbanGDKy.GetFocusedRowCellValue("Id");
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    quanLyCongViecEntities.DeleteGDKyBanHanh(guid);
                }
                XtraMessageBox.Show("Xóa thông tin thành công");
                GetAllGDKyBanHanh();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu");
            }
        }

        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


                FormVanBanGiamDocKyBanHanh f = new FormVanBanGiamDocKyBanHanh();
                f._edit = true;
                f.IdEdit = (Guid)grvVanbanGDKy.GetFocusedRowCellValue("Id");
                f.ShowDialog();
            
        }

        private void grvVanbanGDKy_DoubleClick(object sender, EventArgs e)
        {
                FormVanBanGiamDocKyBanHanh f = new FormVanBanGiamDocKyBanHanh();
                f._edit = true;
                f.IdEdit = (Guid)grvVanbanGDKy.GetFocusedRowCellValue("Id");
                f.ShowDialog();

        }

        private void LinkView_Click(object sender, EventArgs e)
        {
            string tailieudinhkem= (string)grvVanbanGDKy.GetFocusedRowCellValue("TaiLieuDinhKem");
            if (tailieudinhkem !=null)
            {
                ViewPdf view = new ViewPdf();
                view.FileNamePdf = (string)grvVanbanGDKy.GetFocusedRowCellValue("TaiLieuDinhKem");
                view.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Không có tài liệu đính kèm");
            }
        }

        private void grvVanbanGDKy_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
