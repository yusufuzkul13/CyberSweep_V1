using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S_yanet_V1
{
    public partial class xssTarama : Form
    {
        public xssTarama()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string payloadsPath = "C:\\Users\\vboxuser\\Desktop\\xss_payload.txt"; // Payload dosyanızın tam yolu

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Lütfen bir URL girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(payloadsPath))
                {
                    label3.Text = "Taranıyor...";
                    label3.ForeColor = Color.Green;
                    string payload;
                    while ((payload = sr.ReadLine()) != null)
                    {
                        string fullUrl = url + payload;
                        bool xssVulnerability = await XssScanner(fullUrl);

                        if (xssVulnerability)
                        {
                            //listBox1.Items.Add("XSS açığı tespit edildi: " + payload);
                            richTextBox1.SelectionColor = Color.Red;
                            richTextBox1.AppendText("XSS açığı tespit edildi: " + payload + Environment.NewLine);
                        }
                        else
                        {
                            //listBox1.Items.Add("XSS açığı tespit edilemedi: " + payload);
                            richTextBox1.SelectionColor = Color.Green;
                            richTextBox1.AppendText("XSS açığı tespit edilemedi: " + payload + Environment.NewLine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<bool> XssScanner(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private void xssTarama_Load(object sender, EventArgs e)
        {

        }
    }
}
