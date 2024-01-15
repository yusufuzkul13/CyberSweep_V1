using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace S_yanet_V1
{
    public partial class fileScan : Form
    {
        SqlConnection baglan = new SqlConnection(@"Data Source = WIN10; Initial Catalog = Siyanet_V1; Integrated Security = True");
        public fileScan()
        {
            InitializeComponent();
        }

        private void fileScan_Load(object sender, EventArgs e)
        {

        }

        private void btn_DosyaSec_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Text = "Seçilen Dosya: " + openFileDialog1.FileName;
            }
        }

        private void btn_Tara_Click(object sender, EventArgs e)
        {
            string dosyaYolu = openFileDialog1.FileName;
            string dosyaHash = HesaplaSHA256(dosyaYolu);

            if (DosyaVirusluMu(dosyaHash))
            {
                textBox1.AppendText($"Dosya Hash: {dosyaHash}  - Virüs Tespit Edildi!");
                textBox1.ForeColor = Color.Red;
            }
            else
            {
                textBox1.AppendText($"Dosya Hash: {dosyaHash}  - Dosya Güvenli");
                textBox1.ForeColor = Color.Green;
            }
        }
        //private string HesaplaMD5(string filename)
        //{
        //    using (var md5 = MD5.Create())
        //    {
        //        using (var stream = File.OpenRead(filename))
        //        {
        //            var hash = md5.ComputeHash(stream);
        //            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        //        }
        //    }
        //}
        private string HesaplaSHA256(string filename)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    // Dosyanın SHA-256 hash değerini hesapla
                    var hash = sha256.ComputeHash(stream);
                    // Byte dizisini hexadecimal stringe çevir
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        private bool DosyaVirusluMu(string dosyaHash)
        {
            try
            {
                // Veritabanı bağlantısını aç
                baglan.Open();

                // SQL sorgusunu oluştur
                string sorgu = "SELECT COUNT(*) FROM TBL_VIRUS_DB WHERE hash = @hash";
                SqlCommand komut = new SqlCommand(sorgu, baglan);
                komut.Parameters.AddWithValue("@hash", dosyaHash);

                // Sorguyu çalıştır ve sonucu al
                int count = Convert.ToInt32(komut.ExecuteScalar());

                // Bağlantıyı kapat
                baglan.Close();

                // Eğer count 1 veya daha fazla ise, hash veritabanında bulunmuş demektir.
                return count > 0;
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda konsola hata mesajını yaz
                Console.WriteLine("Bir hata meydana geldi: " + ex.Message);

                // Bağlantıyı kapat
                if (baglan.State == System.Data.ConnectionState.Open)
                    baglan.Close();

                // Hata durumunda false döndür
                return false;
            }
        }
    }
}
