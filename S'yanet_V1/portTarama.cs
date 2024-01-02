using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace S_yanet_V1
{
    public partial class portTarama : Form
    {
        private bool taramaDurumu = false;
      //private CancellationTokenSource taramaİptal;


        public portTarama()
        {
            InitializeComponent();
            InitializeDataGridView();
          //taramaİptal = new CancellationTokenSource();
        }
        private void InitializeDataGridView()
        {

        }
        private void portTarama_Load(object sender, EventArgs e)
        {

        }
        private void Temizle()
        {
            if (dataGridView1.DataSource != null)
            {
                if (dataGridView1.DataSource is DataTable dataTable)
                {
                    dataTable.Rows.Clear();
                }
                else if (dataGridView1.DataSource is BindingSource bindingSource)
                {
                    if (bindingSource.DataSource is DataTable sourceDataTable)
                    {
                        sourceDataTable.Rows.Clear();
                    }
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }
        private void btn_Tara_Click(object sender, EventArgs e)
        {
            Temizle();

            if (taramaDurumu)
            {
                MessageBox.Show("Tarama zaten devam ediyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TaramayiBaslat();
        }

        private void TaramayiBaslat()
        {
            taramaDurumu = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("Port", typeof(int));
            dt.Columns.Add("Durum", typeof(string));
            dt.Columns.Add("Servis", typeof(string));

            DurumuGuncelle("Taraniyor...");

            string hostname = textBox1.Text;
            int[] ports = { 20, 21, 22, 23, 25, 53, 67, 68, 80, 88, 110, 115, 135, 137, 138, 139, 140, 143, 161, 194, 443, 445, 465, 514, 520, 587, 1433, 1723, 3306, 3389, 5432 };

            IPAddress ipAddress;
            if (!IPAddress.TryParse(hostname, out ipAddress))
            {
                try
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
                    ipAddress = hostEntry.AddressList[0];
                }
                catch
                {
                    MessageBox.Show("Geçersiz IP adresi veya Host adı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    taramaDurumu = false;
                    DurumuGuncelle("");
                    return;
                }
            }
            else if (ipAddress.AddressFamily != AddressFamily.InterNetwork)
            {
                MessageBox.Show("Geçersiz IP adresi veya Host adı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                taramaDurumu = false;
                DurumuGuncelle("");
                return;
            }

            Thread scanningThread = new Thread(() =>
            {
                var options = new ParallelOptions { MaxDegreeOfParallelism = 10 }; 
                Parallel.ForEach(ports, options, port =>
                {
                    if (!taramaDurumu) return;

                    try
                    {
                        using (TcpClient client = new TcpClient())
                        {
                            client.Connect(ipAddress, port);
                            lock (dt)
                            {
                                dt.Rows.Add(port, "Açık", GetServiceName(port));
                            }
                        }
                    }
                    catch
                    {
                        lock (dt)
                        {
                            dt.Rows.Add(port, "Kapalı", "");
                        }
                    }
                });

                DurumuGuncelle("Tarama Tamamlandı");
                taramaDurumu = false;
                DataViewGuncelle(dt);
            });

            scanningThread.Start();
        }
        private void DurumuGuncelle(string message)
        {
            if (label3.InvokeRequired)
            {
                label3.Invoke(new Action(() => label3.Text = message));
                label3.ForeColor = Color.Green;
            }
            else
            {
                label3.Text = message;
                label3.ForeColor = Color.Green;
            }
        }

        private void DataViewGuncelle(DataTable dt)

        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(() => dataGridView1.DataSource = dt));
            }
            else
            {
                dataGridView1.DataSource = dt;
            }
        }

        private string GetServiceName(int port)
        {
            // Servis adını döndür
            switch (port)
            {
                case 20:
                    return "FTP Data (File Transfer Protocol)";
                case 21:
                    return "FTP Control (File Transfer Protocol)";
                case 22:
                    return "SSH (Secure Shell)";
                case 23:
                    return "Telnet";
                case 25:
                    return "SMTP (Simple Mail Transfer Protocol)";
                case 53:
                    return "DNS (Domain Name System)";
                case 67:
                    return "DHCP (Dynamic Host Configuration Protocol) Server";
                case 68:
                    return "DHCP (Dynamic Host Configuration Protocol) Client";
                case 80:
                    return "HTTP (HyperText Transfer Protocol)";
                case 88:
                    return "Kerberos - Authentication System";
                case 110:
                    return "POP3 (Post Office Protocol version 3)";
                case 115:
                    return "SFTP (Simple File Transfer Protocol)";
                case 135:
                    return "Microsoft EPMAP (End Point Mapper), also known as DCE/RPC Locator service";
                case 137:
                    return "NetBIOS Name Service";
                case 138:
                    return "NetBIOS Datagram Service";
                case 139:
                    return "NetBIOS Session Service";
                case 143:
                    return "IMAP (Internet Message Access Protocol)";
                case 161:
                    return "SNMP (Simple Network Management Protocol)";
                case 194:
                    return "IRC (Internet Relay Chat)";
                case 443:
                    return "HTTPS (Hypertext Transfer Protocol Secure)";
                case 445:
                    return "Microsoft-DS (Microsoft Directory Services)";
                case 465:
                    return "SMTPS (Secure SMTP over SSL)";
                case 514:
                    return "Syslog - used for system logging";
                case 520:
                    return "RIP (Routing Information Protocol)";
                case 587:
                    return "SMTP (Simple Mail Transfer Protocol) over TLS/SSL";
                case 1433:
                    return "Microsoft SQL Server database management system (MSSQL) server";
                case 1723:
                    return "PPTP (Point-to-Point Tunneling Protocol)";
                case 3306:
                    return "MySQL Database Server";
                case 3389:
                    return "RDP (Remote Desktop Protocol)";
                case 5432:
                    return "PostgreSQL Database Server";
                default:
                    return "";
            }
        }

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue >= 0 && e.NewValue < dataGridView1.RowCount)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
        }

        private void btn_TaramayıDurdur_Click(object sender, EventArgs e)
        {
            if (taramaDurumu)
            {
                taramaDurumu = false;

                DurumuGuncelle("Tarama Durduruldu");
            }
        }
    }
}


