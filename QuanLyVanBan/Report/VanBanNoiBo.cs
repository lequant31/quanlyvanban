using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;

namespace QuanLyVanBan.Report
{
    public partial class VanBanNoiBo : DevExpress.XtraReports.UI.XtraReport
    {
        public VanBanNoiBo()
        {
            InitializeComponent();
        }
        public string labeltungay;
        public string labelthongke;
        private GridControl control;
        public GridControl GridControl
        {
            get
            {
                return control;
            }
            set
            {
                control = value;
                pccReport.PrintableComponent = control;
            }
        }

        private void LabelTuNgayDenNgay_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            LabelTuNgayDenNgay.Text = labeltungay;
        }

        private void labelThongke_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            labelThongke.Text = labelthongke;
        }

        private void pccReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }
    }
}
