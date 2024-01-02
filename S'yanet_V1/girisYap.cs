using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace S_yanet_V1
{
    public partial class girisYap : Form
    {
        public girisYap()
        {
            InitializeComponent();
        }
        private string guncelKullaniciAdi;

        SqlConnection baglan = new SqlConnection(@"Data Source = WIN10; Initial Catalog = Siyanet_V1; Integrated Security = True");
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBoxUser.Text == "" || txtBoxPass.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz!");
                return;
            }

            using (baglan)
            {
                baglan.Open();

                string query = "SELECT * FROM TBL_LOGIN WHERE username = @username";
                using (SqlCommand cmd = new SqlCommand(query, baglan))
                {
                    cmd.Parameters.AddWithValue("@username", txtBoxUser.Text);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string HashlenmisSifre = reader["password"].ToString();

                            string girilenSifre = Sifrele(txtBoxPass.Text);

                            if (string.Equals(girilenSifre, HashlenmisSifre, StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                                guncelKullaniciAdi = txtBoxUser.Text;
                                var frm = new icerik(guncelKullaniciAdi);
                                frm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı bulunamadı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bulunamadı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                baglan.Close();
            }
        }
        string Sifrele(string sifre)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
             
                byte[] passwordBytes = Encoding.UTF8.GetBytes(sifre);

                
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

              
                return Convert.ToBase64String(hashedBytes);
            }
        }
        private void label4_Click_1(object sender, EventArgs e)
        {
            Lisans_Kontrol kontrol = new Lisans_Kontrol();
            kontrol.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtBoxPass.PasswordChar = '\0';
            }
            else
            {
                txtBoxPass.PasswordChar = '*';
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
