using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyVanBan.Report
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public string labeltungay;
        public string labelthongke;
        public XtraReport1()
        {
            InitializeComponent();
        }

        private void labelThongke_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            labelThongke.Text = labelthongke;
        }

        private void LabelTuNgayDenNgay_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            LabelTuNgayDenNgay.Text = labeltungay;
        }
    }
}
