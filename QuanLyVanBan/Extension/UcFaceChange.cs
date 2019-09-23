using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;
using QuanLyVanBan.Properties;

namespace QuanLyVanBan.Extension
{
    public partial class UcFaceChange : UserControl
    {
        public UcFaceChange()
        {
            InitializeComponent();
        }
        private static UcFaceChange _faceChange;
        public static UcFaceChange faceChange
        {
            get
            {
                if (_faceChange == null)
                    _faceChange = new UcFaceChange();
                return _faceChange;
            }
        }

        private void FaceChange_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //try
            //{
            //    //System.Net.WebClient client = new System.Net.WebClient();
            //    //var Version = client.DownloadString("http://18.220.41.128/Version.txt").Trim();
            //    ////string str = "1.0.0.1";
            //    ////var Version = str.Trim();
            //    //if (Version != Properties.Settings.Default.Version)
            //    //{
            //    //    if (MessageBox.Show("Đã có phiên bản mới. Bạn có muốn cập nhật không?", "Confirmation", MessageBoxButtons.YesNo) ==
            //    //     DialogResult.Yes)
            //    //    {
            //    //        System.Diagnostics.Process.Start(Application.StartupPath + "\\updater.exe");
            //    //        Properties.Settings.Default.Version = Version.Trim();
            //    //        Properties.Settings.Default.Save();
            //    //        return;
            //    //    }
            //    //}
            //    System.Net.WebClient client = new System.Net.WebClient();
            //    string Version = client.DownloadString("http://18.220.41.128/Version.txt").Trim();
            //    var oldVersion = "";
            //    try
            //    {
            //        oldVersion = System.IO.File.ReadAllText(Application.StartupPath + "\\Version.txt").Replace("\r\n", "");
            //    }
            //    catch { }
            //    if (Version != oldVersion)
            //    {
            //        System.Diagnostics.Process.Start(Application.StartupPath + "\\updater.exe");
            //        Properties.Settings.Default.Version = Version.Trim();
            //        Properties.Settings.Default.Save();
            //        return;
            //    }
            //}
            //catch { }
        }
    }
}
