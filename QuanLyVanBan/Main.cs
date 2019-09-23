using DevExpress.Skins;
using DevExpress.XtraBars;
using QuanLyVanBan.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyVanBan.Report;
using DevExpress.LookAndFeel;
using QuanLyVanBan.Properties;


namespace QuanLyVanBan
{
    public partial class Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Main()
        {
            InitializeComponent();

        }

        private void AccVanBanDen_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(UcTheoDoiVanBanDen.ucTheoDoiVanBan))
            {
                MainContainer.Controls.Add(UcTheoDoiVanBanDen.ucTheoDoiVanBan);
                UcTheoDoiVanBanDen.ucTheoDoiVanBan.Dock = DockStyle.Fill;
                UcTheoDoiVanBanDen.ucTheoDoiVanBan.BringToFront();
            }
            UcTheoDoiVanBanDen.ucTheoDoiVanBan.BringToFront();
            accVanBanDen.Appearance.Pressed.BackColor =System.Drawing.Color.AliceBlue;
        }

        private void AccGiamDocKyBanHanh_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(UcVanBanGiamDocKyBanHanh.ucVanBanGiamDoc))
            {
                MainContainer.Controls.Add(UcVanBanGiamDocKyBanHanh.ucVanBanGiamDoc);
                UcVanBanGiamDocKyBanHanh.ucVanBanGiamDoc.Dock = DockStyle.Fill;
                UcVanBanGiamDocKyBanHanh.ucVanBanGiamDoc.BringToFront();
            }
            UcVanBanGiamDocKyBanHanh.ucVanBanGiamDoc.BringToFront();
        }

        private void AccExportVanBanNoiBo_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(FormExport.formExport))
            {
                MainContainer.Controls.Add(FormExport.formExport);
                FormExport.formExport.Dock = DockStyle.Fill;
                FormExport.formExport.BringToFront();
            }
            FormExport.formExport.BringToFront();
        }

        private void AccExportVanBanNgoaiNganh_Click(object sender, EventArgs e)
        {
            
        }

        private void Main_Load(object sender, EventArgs e)
        {

            UserLookAndFeel.Default.SkinName = Properties.Settings.Default.skin;
            if (!MainContainer.Controls.Contains(UcTheoDoiVanBanDen.ucTheoDoiVanBan))
            {
                MainContainer.Controls.Add(UcTheoDoiVanBanDen.ucTheoDoiVanBan);
                UcTheoDoiVanBanDen.ucTheoDoiVanBan.Dock = DockStyle.Fill;
                UcTheoDoiVanBanDen.ucTheoDoiVanBan.BringToFront();
            }
            UcTheoDoiVanBanDen.ucTheoDoiVanBan.BringToFront();
        }

        private void AccordFaceChange_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(UcFaceChange.faceChange))
            {
                MainContainer.Controls.Add(UcFaceChange.faceChange);
                UcFaceChange.faceChange.Dock = DockStyle.Fill;
                UcFaceChange.faceChange.BringToFront();
            }
            UcFaceChange.faceChange.BringToFront();
        }

        private void AccordLinhVucBanHanh_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(UcLinhVucBanHanh.ucLinhVucBanHanh))
            {
                MainContainer.Controls.Add(UcLinhVucBanHanh.ucLinhVucBanHanh);
                UcLinhVucBanHanh.ucLinhVucBanHanh.Dock = DockStyle.Fill;
                UcLinhVucBanHanh.ucLinhVucBanHanh.BringToFront();
            }
            UcLinhVucBanHanh.ucLinhVucBanHanh.BringToFront();
        }

        private void AccordLoaiVanBan_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(UcLoaiVanBan.ucLoaiVanBan))
            {
                MainContainer.Controls.Add(UcLoaiVanBan.ucLoaiVanBan);
                UcLoaiVanBan.ucLoaiVanBan.Dock = DockStyle.Fill;
                UcLoaiVanBan.ucLoaiVanBan.BringToFront();
            }
            UcLoaiVanBan.ucLoaiVanBan.BringToFront();
        }

        private void AccordDonViThamMuu_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(UcDonVi.ucDonVi))
            {
                MainContainer.Controls.Add(UcDonVi.ucDonVi);
                UcDonVi.ucDonVi.Dock = DockStyle.Fill;
                UcDonVi.ucDonVi.BringToFront();
            }
            UcDonVi.ucDonVi.BringToFront();
        }

        private void AccordLanhDaoDonVi_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(UcLanhDaoDonVi.ucLanhDaoDonVi))
            {
                MainContainer.Controls.Add(UcLanhDaoDonVi.ucLanhDaoDonVi);
                UcLanhDaoDonVi.ucLanhDaoDonVi.Dock = DockStyle.Fill;
                UcLanhDaoDonVi.ucLanhDaoDonVi.BringToFront();
            }
            UcLanhDaoDonVi.ucLanhDaoDonVi.BringToFront();
        }

        private void accordCoQuanBanHanh_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(CoQuanBanHanh.ucCoQuanBanHanh))
            {
                MainContainer.Controls.Add(CoQuanBanHanh.ucCoQuanBanHanh);
                CoQuanBanHanh.ucCoQuanBanHanh.Dock = DockStyle.Fill;
                CoQuanBanHanh.ucCoQuanBanHanh.BringToFront();
            }
            CoQuanBanHanh.ucCoQuanBanHanh.BringToFront();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.skin = UserLookAndFeel.Default.SkinName;
            Properties.Settings.Default.Save();
        }

        private void accordionSapHetHan_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(UcTheoDoiVanBanDenSapHetHan.UcTheoDoiVanBanDenSapHet))
            {
                MainContainer.Controls.Add(UcTheoDoiVanBanDenSapHetHan.UcTheoDoiVanBanDenSapHet);
                UcTheoDoiVanBanDenSapHetHan.UcTheoDoiVanBanDenSapHet.Dock = DockStyle.Fill;
                UcTheoDoiVanBanDenSapHetHan.UcTheoDoiVanBanDenSapHet.BringToFront();
            }
            UcTheoDoiVanBanDenSapHetHan.UcTheoDoiVanBanDenSapHet.BringToFront();
        }

        private void accordionQuaHan_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(UcTheoDoiVanBanDenHetHan.ucTheoDoiVanBanDenHetHan))
            {
                MainContainer.Controls.Add(UcTheoDoiVanBanDenHetHan.ucTheoDoiVanBanDenHetHan);
                UcTheoDoiVanBanDenHetHan.ucTheoDoiVanBanDenHetHan.Dock = DockStyle.Fill;
                UcTheoDoiVanBanDenHetHan.ucTheoDoiVanBanDenHetHan.BringToFront();
            }
            UcTheoDoiVanBanDenHetHan.ucTheoDoiVanBanDenHetHan.BringToFront();
        }

        private void accordionGDNoComment_Click(object sender, EventArgs e)
        {
            if (!MainContainer.Controls.Contains(UcTheoDoiVanBanDenGDNoComment.ucTheoDoiVanBanGDNoComment))
            {
                MainContainer.Controls.Add(UcTheoDoiVanBanDenGDNoComment.ucTheoDoiVanBanGDNoComment);
                UcTheoDoiVanBanDenGDNoComment.ucTheoDoiVanBanGDNoComment.Dock = DockStyle.Fill;
                UcTheoDoiVanBanDenGDNoComment.ucTheoDoiVanBanGDNoComment.BringToFront();
            }
            UcTheoDoiVanBanDenGDNoComment.ucTheoDoiVanBanGDNoComment.BringToFront();
        }
    }
}
