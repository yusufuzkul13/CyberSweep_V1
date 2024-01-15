using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S_yanet_V1
{
    public partial class icerik : Form
    {
        private string kullaniciAdi;

        private Form aktifForm;

        public icerik(string kullaniciAdi)
        {
            InitializeComponent();

            // this.IsMdiContainer = true;

            this.kullaniciAdi = kullaniciAdi;
            lblKullaniciAdi.Text = "Hoş Geldiniz, " + kullaniciAdi;
        }

        public icerik()
        {
            
        }

        private void icerik_Load(object sender, EventArgs e)
        {
            GosterForm(new Baslangic());
        }

        private void GosterForm(Form form)
        {
            if (aktifForm != null)
            {
                aktifForm.Close();
            }

            aktifForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GosterForm(new subdomainTarama());
        }

        private void btn_PortTarama_Click(object sender, EventArgs e)
        {
            GosterForm(new portTarama());
        }

        private void btn_XssTarama_Click(object sender, EventArgs e)
        {
           GosterForm(new xssTarama());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_DosyaTarama_Click(object sender, EventArgs e)
        {
            GosterForm(new fileUrlScan());
        }

        private void btn_DosyaSifreleme_Click(object sender, EventArgs e)
        {
            GosterForm(new fileEncryption1(kullaniciAdi));
        }

        private void btn_Cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GosterForm(new fileScan());
        }
    }
}
