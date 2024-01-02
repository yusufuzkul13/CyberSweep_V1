using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;

namespace S_yanet_V1
{
     public partial class subdomainTarama : Form
     {
        private HttpClient httpClient;
        private bool taramaDurumu = false;

        public subdomainTarama()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private void subdomainTarama_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (taramaDurumu)
            {
                MessageBox.Show("Tarama zaten devam ediyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string dosyaYolu = "C:\\Users\\vboxuser\\Desktop\\subdomain.txt";
            string domainName = textBox1.Text;
            TaramayiBaslat(dosyaYolu,domainName);
        }
        
        private async void TaramayiBaslat(string path, string domainName)
        {
            taramaDurumu = true;
            listBox1.Items.Clear();

            for(int i = 0; i < File.ReadAllLines(path).Length; i++)
            {
                if (!taramaDurumu) break;
                try
                {
                    string[] subDomains = File.ReadAllLines(path);
                    progressBar1.Maximum = subDomains.Length;
                    progressBar1.Value = 0;

                    label3.Text = "Taranıyor...";
                    foreach (string subDomain in subDomains)
                    {
                        string url = $"https://{subDomain}.{domainName}";

                        try
                        {
                            HttpResponseMessage response = await httpClient.GetAsync(url);

                            if (response.IsSuccessStatusCode)
                            {
                                listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(url); });
                            }
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show($"Hata: {ex.Message}");
                        }
                        finally
                        {
                            progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value++; }); // Her denemeden sonra progressBar'ı arttır
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Dosya okuma hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                httpClient?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void btn_TaramayiDurdur_Click(object sender, EventArgs e)
        {
            if (taramaDurumu)
            {
                taramaDurumu = false;
                label3.Text = "İptal edildi";
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            listBox1.ScrollAlwaysVisible = true;
        }
    }
}

