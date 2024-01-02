
namespace S_yanet_V1
{
    partial class icerik
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cikis = new System.Windows.Forms.Button();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_DosyaSifreleme = new System.Windows.Forms.Button();
            this.btn_SubDomainTarama = new System.Windows.Forms.Button();
            this.btn_PortTarama = new System.Windows.Forms.Button();
            this.btn_DosyaTarama = new System.Windows.Forms.Button();
            this.btn_XssTarama = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.btn_Cikis);
            this.panel1.Controls.Add(this.lblKullaniciAdi);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btn_DosyaSifreleme);
            this.panel1.Controls.Add(this.btn_SubDomainTarama);
            this.panel1.Controls.Add(this.btn_PortTarama);
            this.panel1.Controls.Add(this.btn_DosyaTarama);
            this.panel1.Controls.Add(this.btn_XssTarama);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 498);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_Cikis
            // 
            this.btn_Cikis.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cikis.BackgroundImage = global::S_yanet_V1.Properties.Resources.exit_icon_png_201;
            this.btn_Cikis.Location = new System.Drawing.Point(103, 444);
            this.btn_Cikis.Name = "btn_Cikis";
            this.btn_Cikis.Size = new System.Drawing.Size(49, 51);
            this.btn_Cikis.TabIndex = 7;
            this.btn_Cikis.UseVisualStyleBackColor = false;
            this.btn_Cikis.Click += new System.EventHandler(this.btn_Cikis_Click);
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(29, 127);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(35, 13);
            this.lblKullaniciAdi.TabIndex = 2;
            this.lblKullaniciAdi.Text = "label1";
            this.lblKullaniciAdi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::S_yanet_V1.Properties.Resources.user_logo3;
            this.pictureBox2.Location = new System.Drawing.Point(32, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 93);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // btn_DosyaSifreleme
            // 
            this.btn_DosyaSifreleme.BackgroundImage = global::S_yanet_V1.Properties.Resources.filencrypt;
            this.btn_DosyaSifreleme.Location = new System.Drawing.Point(12, 385);
            this.btn_DosyaSifreleme.Name = "btn_DosyaSifreleme";
            this.btn_DosyaSifreleme.Size = new System.Drawing.Size(140, 41);
            this.btn_DosyaSifreleme.TabIndex = 6;
            this.btn_DosyaSifreleme.UseVisualStyleBackColor = true;
            this.btn_DosyaSifreleme.Click += new System.EventHandler(this.btn_DosyaSifreleme_Click);
            // 
            // btn_SubDomainTarama
            // 
            this.btn_SubDomainTarama.BackgroundImage = global::S_yanet_V1.Properties.Resources.webscan;
            this.btn_SubDomainTarama.Location = new System.Drawing.Point(12, 214);
            this.btn_SubDomainTarama.Name = "btn_SubDomainTarama";
            this.btn_SubDomainTarama.Size = new System.Drawing.Size(140, 41);
            this.btn_SubDomainTarama.TabIndex = 3;
            this.btn_SubDomainTarama.UseVisualStyleBackColor = true;
            this.btn_SubDomainTarama.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_PortTarama
            // 
            this.btn_PortTarama.BackColor = System.Drawing.Color.Transparent;
            this.btn_PortTarama.BackgroundImage = global::S_yanet_V1.Properties.Resources.Port_Scan;
            this.btn_PortTarama.Location = new System.Drawing.Point(12, 157);
            this.btn_PortTarama.Name = "btn_PortTarama";
            this.btn_PortTarama.Size = new System.Drawing.Size(140, 41);
            this.btn_PortTarama.TabIndex = 2;
            this.btn_PortTarama.UseVisualStyleBackColor = false;
            this.btn_PortTarama.Click += new System.EventHandler(this.btn_PortTarama_Click);
            // 
            // btn_DosyaTarama
            // 
            this.btn_DosyaTarama.BackgroundImage = global::S_yanet_V1.Properties.Resources.filescan;
            this.btn_DosyaTarama.Location = new System.Drawing.Point(12, 328);
            this.btn_DosyaTarama.Name = "btn_DosyaTarama";
            this.btn_DosyaTarama.Size = new System.Drawing.Size(140, 38);
            this.btn_DosyaTarama.TabIndex = 5;
            this.btn_DosyaTarama.UseVisualStyleBackColor = true;
            this.btn_DosyaTarama.Click += new System.EventHandler(this.btn_DosyaTarama_Click);
            // 
            // btn_XssTarama
            // 
            this.btn_XssTarama.BackgroundImage = global::S_yanet_V1.Properties.Resources.xssscan5;
            this.btn_XssTarama.Location = new System.Drawing.Point(12, 271);
            this.btn_XssTarama.Name = "btn_XssTarama";
            this.btn_XssTarama.Size = new System.Drawing.Size(140, 40);
            this.btn_XssTarama.TabIndex = 4;
            this.btn_XssTarama.UseVisualStyleBackColor = true;
            this.btn_XssTarama.Click += new System.EventHandler(this.btn_XssTarama_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(182, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 498);
            this.panel2.TabIndex = 2;
            // 
            // icerik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImage = global::S_yanet_V1.Properties.Resources.Adsız_tasarım__1_;
            this.ClientSize = new System.Drawing.Size(648, 499);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "icerik";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.icerik_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_PortTarama;
        private System.Windows.Forms.Button btn_DosyaSifreleme;
        private System.Windows.Forms.Button btn_SubDomainTarama;
        private System.Windows.Forms.Button btn_DosyaTarama;
        private System.Windows.Forms.Button btn_XssTarama;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Cikis;
    }
}