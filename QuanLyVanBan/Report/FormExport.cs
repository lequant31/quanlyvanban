using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLyVanBan.Report
{
    public partial class FormExport : DevExpress.XtraEditors.XtraUserControl
    {
        QuanLyCongViecEntities quanLyCongViecEntities;
        private static FormExport _formExport;
        public static FormExport formExport
        {
            get
            {
                if (_formExport == null)
                    _formExport = new FormExport();
                return _formExport;
            }
        }
        private Guid IdDonvi;
        public FormExport()
        {
            InitializeComponent();
        }
        public void searchgridview()
        {
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    IdDonvi = (Guid)searchDonVi.EditValue;

                    var _getall = quanLyCongViecEntities.ExportVanBan(IdDonvi,DateTuNgay.DateTime,DateDenNgay.DateTime).ToList();
                    grcExport.DataSource = _getall;
                    gridColumn11.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                    gridColumn11.VisibleIndex = 0;
                    grvExport.CustomUnboundColumnData += grvExport_CustomUnboundColumnData;
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi kết nối với cơ sở dữ liệu");
            }
        }
        private void DateTuNgay_EditValueChanged(object sender, EventArgs e)
      {
            #region MyRegion
            if (DateTuNgay.DateTime == null)
            {
                XtraMessageBox.Show("Chọn ngày bắt đầu thống kê");
                return;
            }
                
            if (DateDenNgay.DateTime == null)
            {
                XtraMessageBox.Show("Chọn ngày kết thúc thống kê");
                return;
            }
            #endregion
            searchgridview();
        }
        private void DateDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            #region MyRegion
            if (DateTuNgay.DateTime == null)
            {
                XtraMessageBox.Show("Chọn ngày bắt đầu thống kê");
                return;
            }

            if (DateDenNgay.DateTime == null)
            {
                XtraMessageBox.Show("Chọn ngày kết thúc thống kê");
                return;
            }
            #endregion
            searchgridview();
        }
        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grvExport.OptionsSelection.MultiSelectMode = default;
            var volumnValue = this.searchDonVi.Properties.View.GetFocusedRowCellValue("InOrOut");
           
            grvExport.BestFitColumns();
            
            VanBanNoiBo vanBanNoiBo = new VanBanNoiBo();
            if ((bool)volumnValue == true)
            {
                vanBanNoiBo.labelthongke = "THỐNG KÊ VĂN BẢN NỘI BỘ NHẬN ĐƯỢC";
            }
            else
            {
                vanBanNoiBo.labelthongke = "THỐNG KÊ VĂN BẢN NGOÀI NGÀNH NHẬN ĐƯỢC";
            }
           
            vanBanNoiBo.labeltungay = "Từ ngày " + DateTuNgay.DateTime.ToShortDateString() + " đến ngày " + DateDenNgay.DateTime.ToShortDateString();
            vanBanNoiBo.GridControl = grcExport;
            ReportPrintTool printTool = new ReportPrintTool(vanBanNoiBo);
            printTool.ShowPreviewDialog();


        }
        private void grvExport_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            e.Value = grvExport.GetRowHandle(e.ListSourceRowIndex) + 1;
        }
        private void grvExport_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void BtnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            object volumnValue = this.searchDonVi.Properties.View.GetFocusedRowCellValue("InOrOut");
            VanBanNoiBo vanBanNoiBo = new VanBanNoiBo();
            grvExport.BestFitColumns();
            //if (radioChonNoiBanHanh.SelectedIndex == 0)
            //{
            //    report1.labelthongke = "THỐNG KÊ VĂN BẢN NỘI BỘ NHẬN ĐƯỢC";
            //}
            //if (radioChonNoiBanHanh.SelectedIndex == 1)
            //{
            vanBanNoiBo.labelthongke = "THỐNG KÊ VĂN BẢN NGOÀI NGÀNH NHẬN ĐƯỢC";
            //}
            vanBanNoiBo.labeltungay = "Từ ngày " + DateTuNgay.DateTime.ToShortDateString() + " đến ngày " + DateDenNgay.DateTime.ToShortDateString();
            vanBanNoiBo.GridControl = grcExport;
            ReportPrintTool printTool = new ReportPrintTool(vanBanNoiBo);
            printTool.ShowPreviewDialog();
        }
        private void FormExport_Load(object sender, EventArgs e)
        {
            
            try
            {
                using (quanLyCongViecEntities = new QuanLyCongViecEntities())
                {
                    var _GetAllDonVi = quanLyCongViecEntities.GetAllCoQuanVaDonVi().ToList();
                    searchDonVi.Properties.DataSource = _GetAllDonVi;
                    searchDonVi.Properties.DisplayMember = "TenCoQuan";
                    searchDonVi.Properties.ValueMember = "Id";
                }
                
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi không thể kết nối được cơ sở dữ liệu");
            }
        }
        private void DeleteRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //grvExport.DeleteRow(grvExport.FocusedRowHandle);
            grvExport.DeleteSelectedRows();
        }
        private void Print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (GridColumn column in grvExport.Columns)
            {
                //make all export columns visible
                column.Visible = true;
            }
            grvExport.ExportToXls(@"C:\cadobongda\test.xls");
        }
        private void btn_refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            #region MyRegion
            if (DateTuNgay.DateTime == null)
            {
                XtraMessageBox.Show("Chọn ngày bắt đầu thống kê");
                return;
            }

            if (DateDenNgay.DateTime == null)
            {
                XtraMessageBox.Show("Chọn ngày kết thúc thống kê");
                return;
            }
            #endregion
            searchgridview();
            grvExport.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
        }
    }
}
