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

        }

        //private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        //{
        //    listBox1.ScrollAlwaysVisible = true;
        //}
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
                        while (read.Read())
                        {
                            string username = read["username"].ToString();
                            string key = read["key"].ToString();
                            string time = read["time"].ToString();
                            string dosyaAdi = read["dosyaAdi"].ToString();

                            listView1.Items.Add($"Kullanıcı Adı: {username}, Anahtar: {key}, Zaman: {time}, Dosya Adı: {dosyaAdi}");
                        }
                    }
                }

                baglan.Close();
            }
        }
    }
}
