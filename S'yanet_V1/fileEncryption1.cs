using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace S_yanet_V1
{
    public partial class fileEncryption1 : Form
    {
        private string KullaniciAdi;
        private string secilenDosyaYolu = ""; 
        private string secilenSifrelenmisDosyaYolu = "";

        SqlConnection baglan = new SqlConnection(@"Data Source = WIN10; Initial Catalog = Siyanet_V1; Integrated Security = True");
        public fileEncryption1(string kullaniciAdi)
        {
            InitializeComponent();
            InitializeUI();

            this.KullaniciAdi = kullaniciAdi;
        }
        private void InitializeUI()
        {
    
        }

        private void fileEncryption1_Load(object sender, EventArgs e)
        {
            // label5.Text = KullaniciAdi; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                secilenDosyaYolu = openFileDialog.FileName;
                lblDosyaSec10.Text = Path.GetFileName(secilenDosyaYolu);
            }
        }

        
        private void btnSifrele1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(secilenDosyaYolu))
            {
                MessageBox.Show("Lütfen bir dosya seçin.");
                return;
            }

            DateTime zaman = DateTime.Now;

            try
            {
                byte[] dosyaIcerigi = File.ReadAllBytes(secilenDosyaYolu);

                using (Aes aes = Aes.Create())
                {
                    aes.GenerateKey();
                    aes.GenerateIV();

                    string combinedKey = Convert.ToBase64String(aes.Key) + ";" + Convert.ToBase64String(aes.IV);
                    txtbxAnahtar10.Text = combinedKey;
                   
                    baglan.Open();
                    string sorgu = "INSERT INTO TBL_FORGET_KEY(username , [key] , time , dosyaAdi) VALUES(@username, @key, @time , @dosyaAdi)";

                    SqlCommand komut = new SqlCommand(sorgu, baglan);

                    komut.Parameters.AddWithValue("@key", combinedKey);
                    komut.Parameters.AddWithValue("username", KullaniciAdi);
                    komut.Parameters.AddWithValue("@time", zaman);
                    komut.Parameters.AddWithValue("@dosyaAdi", lblDosyaSec10.Text);

                    komut.ExecuteNonQuery();
                 
                    baglan.Close();

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(dosyaIcerigi, 0, dosyaIcerigi.Length);
                        }

                        byte[] sifrelenmisVeri = ms.ToArray();
                        File.WriteAllBytes(secilenDosyaYolu, sifrelenmisVeri);
                    }

                    MessageBox.Show("Dosya başarıyla şifrelendi.");
                    progressBar10.Value = progressBar10.Maximum;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Şifreleme sırasında bir hata oluştu: " + ex.Message);
            }
        }
        private void btnDosyaSec20_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                secilenSifrelenmisDosyaYolu = openFileDialog.FileName;
                lblSecilenDosya20.Text = Path.GetFileName(secilenSifrelenmisDosyaYolu);                                                   
            }
        }

        private void btnCoz2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(secilenSifrelenmisDosyaYolu))
            {
                MessageBox.Show("Lütfen bir dosya seçin.");
                return;
            }
            if (string.IsNullOrEmpty(txtbxAnahtar.Text))
            {
                MessageBox.Show("Lütfen şifreleme anahtarını girin.");
                return;
            }


            try
            {
                byte[] sifrelenmisVeri = File.ReadAllBytes(secilenSifrelenmisDosyaYolu);

                string[] keys = txtbxAnahtar.Text.Split(';');
                if (keys.Length != 2)
                {
                    MessageBox.Show("Anahtar veya IV formatı yanlış.");
                    return;
                }

                byte[] anahtar = Convert.FromBase64String(keys[0]);
                byte[] iv = Convert.FromBase64String(keys[1]);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = anahtar;
                    aes.IV = iv;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (MemoryStream ms = new MemoryStream(sifrelenmisVeri))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (MemoryStream originalMemoryStream = new MemoryStream())
                            {
                                cs.CopyTo(originalMemoryStream);
                                byte[] decryptedData = originalMemoryStream.ToArray();
                                File.WriteAllBytes(secilenSifrelenmisDosyaYolu, decryptedData);
                            }
                        }
                    }

                    MessageBox.Show("Dosya başarıyla şifresi çözüldü.");
                    progressBar20.Value = progressBar20.Maximum;
                }
            }
            catch (CryptographicException)
            {
                MessageBox.Show("Bu dosya şifreli değil veya yanlış anahtar girildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void lblUnutulanAnahtar_Click(object sender, EventArgs e)
        {
            string akullaniciAdi = KullaniciAdi;

            UnutulanAnahtar getir = new UnutulanAnahtar(akullaniciAdi);
            getir.Show();
            this.Hide();
        }
    }
}
