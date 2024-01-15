using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace S_yanet_V1
{
    public partial class UnutulanAnahtar : Form
    {
        private string kullaniciAdi;

        SqlConnection baglan = new SqlConnection(@"Data Source = WIN10; Initial Catalog = Siyanet_V1; Integrated Security = True");
        public UnutulanAnahtar(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            BilgileriGetir();
        }

        private void UnutulanAnahtar_Load(object sender, EventArgs e)
        {
            label1.Text = "Tarama Sonuçları";
            label1.ForeColor = Color.DarkRed;
        }
        private void BilgileriGetir()
        {
            using (baglan)
            {
                baglan.Open();

                string sorgu = "SELECT username, [key], time , dosyaAdi FROM TBL_FORGET_KEY WHERE username = @KullaniciAdi";
                
                using (SqlCommand komut = new SqlCommand(sorgu, baglan))
                {
                    komut.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    using (SqlDataReader read = komut.ExecuteReader())
                    {
                        List<string> records = new List<string>();

                        while (read.Read())
                        {
                            string username = read["username"].ToString();
                            string key = read["key"].ToString();
                            string time = read["time"].ToString();
                            string dosyaAdi = read["dosyaAdi"].ToString();

                            string record = $"Kullanıcı adı: {username}{Environment.NewLine}Anahtar: {key}{Environment.NewLine}Zaman: {time}{Environment.NewLine}Dosya Adı: {dosyaAdi}";

                            records.Add(record);
                        }

                        textBox1.Text = string.Empty;

                        foreach (string record in records)
                        {
                            textBox1.AppendText(record + Environment.NewLine + Environment.NewLine);
                        }
                    }
                }

                baglan.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UnutulanAnahtar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form goster = new Form();
            goster.Show();
            this.Hide();
        }
    }
}
