using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace S_yanet_V1
{

    public partial class fileUrlScan : Form
    {
        private string selectedFilePath; 

        private readonly VirusTotalScanner scanner;

        public fileUrlScan()
        {
            InitializeComponent();
            scanner = new VirusTotalScanner("973ec7087e1dfa305bc618fc7de486da52834578f646bf74a40c9733fb42707b");
        }

        private async void btnTaraDosya_Click(object sender, EventArgs e)
        {
            if (File.Exists(selectedFilePath))
            {
                string fileIDResult = await scanner.ScanFileAsync(selectedFilePath);

                listBox1.Items.Add("File Scan Result:");

                JObject scanIDResult = (JObject)JObject.Parse(fileIDResult)["data"];
                string scanID = (string)scanIDResult["id"];

                string urlResultList = await scanner.GetURLIDResults(scanID);

                JObject resultsObject = JObject.Parse(urlResultList);
                foreach (JProperty obj in resultsObject["data"]["attributes"]["results"])
                {
                    foreach (var childToken in obj)
                    {
                        JObject resultTokenAsObject = (JObject)childToken;

                        foreach (var childPair in resultTokenAsObject)
                        {
                            listBox1.Items.Add($"{childPair.Key} : {(string)childPair.Value}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("File not found. Please select a valid file.");
            }
        }
        private async void btnUrlScan_Click(object sender, EventArgs e)
        {
            string targetUrl = textBox1.Text;

            if (Uri.IsWellFormedUriString(targetUrl, UriKind.Absolute))
            {
                string urlIDResult = await scanner.ScanUrlAsync(targetUrl);

                listBox1.Items.Clear();
                listBox1.Items.Add("URL Scan Result:");

                JObject scanIDResult = (JObject)JObject.Parse(urlIDResult)["data"];
                string scanID = (string)scanIDResult["id"];

                string urlResultList = await scanner.GetURLIDResults(scanID);

                JObject resultsObject = JObject.Parse(urlResultList);
                foreach (JProperty obj in resultsObject["data"]["attributes"]["results"])
                {
                    foreach (var childToken in obj)
                    {
                        JObject resultTokenAsObject = (JObject)childToken;

                        foreach (var childPair in resultTokenAsObject)
                        {
                            listBox1.Items.Add($"{childPair.Key} : {(string)childPair.Value}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("URL Invalid. Please type a correct URL.");
            }
        }

        private void fileUrlScan_Load(object sender, EventArgs e)
        {
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "All Files|*.*",
                Title = "Select a file to scan"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName; // Seçilen dosyanın yolu alınır
                label2.Text = Path.GetFileName(selectedFilePath); // Label kontrolüne dosya adı yazdırılır
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            listBox1.ScrollAlwaysVisible = true;
        }
    }
}