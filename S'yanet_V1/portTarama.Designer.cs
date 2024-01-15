
namespace S_yanet_V1
{
    partial class portTarama
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Tara = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Temizle = new System.Windows.Forms.Button();
            this.btn_TaramayıDurdur = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(47, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btn_Tara
            // 
            this.btn_Tara.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_Tara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tara.Location = new System.Drawing.Point(250, 69);
            this.btn_Tara.Name = "btn_Tara";
            this.btn_Tara.Size = new System.Drawing.Size(117, 30);
            this.btn_Tara.TabIndex = 1;
            this.btn_Tara.Text = "Taramayı Başlat";
            this.btn_Tara.UseVisualStyleBackColor = false;
            this.btn_Tara.Click += new System.EventHandler(this.btn_Tara_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "Port Tarama";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(390, 261);
            this.dataGridView1.TabIndex = 7;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(383, 147);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 261);
            this.vScrollBar1.TabIndex = 8;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Hostname veya ip adresi giriniz: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 11;
            // 
            // btn_Temizle
            // 
            this.btn_Temizle.BackColor = System.Drawing.Color.Yellow;
            this.btn_Temizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Temizle.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_Temizle.Location = new System.Drawing.Point(295, 414);
            this.btn_Temizle.Name = "btn_Temizle";
            this.btn_Temizle.Size = new System.Drawing.Size(106, 26);
            this.btn_Temizle.TabIndex = 12;
            this.btn_Temizle.Text = "Temizle";
            this.btn_Temizle.UseVisualStyleBackColor = false;
            this.btn_Temizle.Click += new System.EventHandler(this.btn_Temizle_Click);
            // 
            // btn_TaramayıDurdur
            // 
            this.btn_TaramayıDurdur.BackColor = System.Drawing.Color.Red;
            this.btn_TaramayıDurdur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaramayıDurdur.Location = new System.Drawing.Point(250, 106);
            this.btn_TaramayıDurdur.Name = "btn_TaramayıDurdur";
            this.btn_TaramayıDurdur.Size = new System.Drawing.Size(117, 29);
            this.btn_TaramayıDurdur.TabIndex = 13;
            this.btn_TaramayıDurdur.Text = "Taramayı Durdur";
            this.btn_TaramayıDurdur.UseVisualStyleBackColor = false;
            this.btn_TaramayıDurdur.Click += new System.EventHandler(this.btn_TaramayıDurdur_Click);
            // 
            // portTarama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(435, 470);
            this.Controls.Add(this.btn_TaramayıDurdur);
            this.Controls.Add(this.btn_Temizle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Tara);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "portTarama";
            this.Text = "portTarama";
            this.Load += new System.EventHandler(this.portTarama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Tara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Temizle;
        private System.Windows.Forms.Button btn_TaramayıDurdur;
    }
}