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
    public partial class Lisans_Kontrol : Form
    {
        public bool Kontrol = false;

        SqlConnection baglan = new SqlConnection(@"Data Source = WIN10; Initial Catalog = Siyanet_V1; Integrated Security = True");
        public Lisans_Kontrol()
        {
            InitializeComponent();
        }

        private void LisansKontrol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();

            string anahtar = "SELECT COUNT(*) FROM TBL_KEYS WHERE [key] = @key";

            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen lisans anahtarını giriniz!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand(anahtar, baglan))
                {
                    cmd.Parameters.AddWithValue("@key", textBox1.Text);

                    int anahtarCount = (int)cmd.ExecuteScalar();

                    if (anahtarCount > 0)
                    {
                        string sil = "DELETE FROM TBL_KEYS WHERE [key] = @key";
                        using (SqlCommand komut = new SqlCommand(sil, baglan))
                        {
                            komut.Parameters.AddWithValue("@key", textBox1.Text);
                            komut.ExecuteNonQuery();
                        }
                        Kontrol = true;

                        kayitOl kayit = new kayitOl();
                        kayit.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı anahtar girdiniz. Lütfen tekrar deneyiniz!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            baglan.Close();
        }
    }
}

