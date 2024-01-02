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
    public partial class kayitOl : Form
    {
        public kayitOl()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection(@"Data Source = WIN10; Initial Catalog = Siyanet_V1; Integrated Security = True");
        private void kayitOl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNewUser.Text != "" && txtNewPass.Text != "")
            {
                if (txtNewPass.Text == txtPassConfirm.Text)
                {
                    Lisans_Kontrol frm = Application.OpenForms["Lisans_Kontrol"] as Lisans_Kontrol;
                    bool kontrolDegeri = frm.Kontrol;

                    if (kontrolDegeri)
                    {
                        if (KullaniciVarMi(txtNewUser.Text))
                        {
                            MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            try
                            {
                                using (baglan)
                                {
                                    baglan.Open();

                                    // Kayıt sorgusu
                                    string sorgu = "INSERT INTO TBL_LOGIN (username, password) VALUES (@username, @password)";
                                    using (var cmd = new SqlCommand(sorgu, baglan))
                                    {
                                       
                                        var hashedPassword = Sifrele(txtNewPass.Text);

                                        
                                        cmd.Parameters.AddWithValue("@username", txtNewUser.Text);
                                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                                        
                                        cmd.ExecuteNonQuery();

                                        MessageBox.Show("Kayıt başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        girisYap frm1 = new girisYap();
                                        frm1.Show();
                                        this.Close();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                
                                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler birbiriyle eşleşmiyor!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        byte[] GenerateSecureSalt()
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
        private bool KullaniciVarMi(string kullaniciAdi)
        {
            using (var baglan = new SqlConnection(@"Data Source=WIN10;Initial Catalog=Siyanet_V1;Integrated Security=True"))
            {
                baglan.Open();

                string query = "SELECT COUNT(*) FROM TBL_LOGIN WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, baglan);
                cmd.Parameters.AddWithValue("@username", kullaniciAdi);

                int kayitSayisi = (int)cmd.ExecuteScalar();

                return kayitSayisi > 0;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            girisYap frm1 = new girisYap();
            frm1.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtNewPass.PasswordChar = '\0';
            }
            else
            {
                txtNewPass.PasswordChar = '*';
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txtPassConfirm.PasswordChar = '\0';
            }
            else
            {
                txtPassConfirm.PasswordChar = '*';
            }
        }
    }
}
