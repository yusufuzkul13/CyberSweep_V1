
namespace S_yanet_V1
{
    partial class fileScan
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_DosyaSec = new System.Windows.Forms.Button();
            this.btn_Tara = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dosya Tarama";
            // 
            // btn_DosyaSec
            // 
            this.btn_DosyaSec.Location = new System.Drawing.Point(91, 109);
            this.btn_DosyaSec.Name = "btn_DosyaSec";
            this.btn_DosyaSec.Size = new System.Drawing.Size(75, 23);
            this.btn_DosyaSec.TabIndex = 1;
            this.btn_DosyaSec.Text = "Dosya Seç";
            this.btn_DosyaSec.UseVisualStyleBackColor = true;
            this.btn_DosyaSec.Click += new System.EventHandler(this.btn_DosyaSec_Click);
            // 
            // btn_Tara
            // 
            this.btn_Tara.BackColor = System.Drawing.Color.Lime;
            this.btn_Tara.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_Tara.Location = new System.Drawing.Point(199, 109);
            this.btn_Tara.Name = "btn_Tara";
            this.btn_Tara.Size = new System.Drawing.Size(110, 24);
            this.btn_Tara.TabIndex = 2;
            this.btn_Tara.Text = "Taramayı Başlat";
            this.btn_Tara.UseVisualStyleBackColor = false;
            this.btn_Tara.Click += new System.EventHandler(this.btn_Tara_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 179);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 219);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(435, 470);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_Tara);
            this.Controls.Add(this.btn_DosyaSec);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fileScan";
            this.Text = "fileScan";
            this.Load += new System.EventHandler(this.fileScan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_DosyaSec;
        private System.Windows.Forms.Button btn_Tara;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}