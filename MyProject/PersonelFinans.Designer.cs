namespace MyProject
{
    partial class PersonelFinans
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelFinans));
            this.Panel4 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnKclt3 = new System.Windows.Forms.Button();
            this.BtnKpt3 = new System.Windows.Forms.Button();
            this.bunifuGradientPanel2 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LblKayitId = new System.Windows.Forms.Label();
            this.TxtKayitId = new System.Windows.Forms.TextBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.LblMaasOdemesi = new System.Windows.Forms.Label();
            this.TxtMaasOdemesi = new System.Windows.Forms.TextBox();
            this.MaasOdemesi = new System.Windows.Forms.Label();
            this.DateTimePickerMaasOdeme = new System.Windows.Forms.DateTimePicker();
            this.BtnGuncelle1 = new System.Windows.Forms.Button();
            this.BtnKydt1 = new System.Windows.Forms.Button();
            this.LblPersonelId = new System.Windows.Forms.Label();
            this.LblAylikMaas = new System.Windows.Forms.Label();
            this.TxtAylikMaas = new System.Windows.Forms.TextBox();
            this.TxtPersonelId = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.bunifuGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel4
            // 
            this.Panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel4.BackgroundImage")));
            this.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel4.Controls.Add(this.pictureBox1);
            this.Panel4.Controls.Add(this.BtnKclt3);
            this.Panel4.Controls.Add(this.BtnKpt3);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Panel4.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Panel4.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Panel4.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Quality = 10;
            this.Panel4.Size = new System.Drawing.Size(800, 40);
            this.Panel4.TabIndex = 1;
            this.Panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel4_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // BtnKclt3
            // 
            this.BtnKclt3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.BtnKclt3.FlatAppearance.BorderSize = 0;
            this.BtnKclt3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKclt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKclt3.Location = new System.Drawing.Point(723, 0);
            this.BtnKclt3.Name = "BtnKclt3";
            this.BtnKclt3.Size = new System.Drawing.Size(40, 40);
            this.BtnKclt3.TabIndex = 3;
            this.BtnKclt3.Text = "-";
            this.BtnKclt3.UseVisualStyleBackColor = false;
            this.BtnKclt3.Click += new System.EventHandler(this.BtnKclt_Click);
            // 
            // BtnKpt3
            // 
            this.BtnKpt3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.BtnKpt3.FlatAppearance.BorderSize = 0;
            this.BtnKpt3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKpt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKpt3.ForeColor = System.Drawing.Color.Black;
            this.BtnKpt3.Location = new System.Drawing.Point(760, 0);
            this.BtnKpt3.Name = "BtnKpt3";
            this.BtnKpt3.Size = new System.Drawing.Size(40, 40);
            this.BtnKpt3.TabIndex = 2;
            this.BtnKpt3.Text = "X";
            this.BtnKpt3.UseVisualStyleBackColor = false;
            this.BtnKpt3.Click += new System.EventHandler(this.BtnKpt3_Click);
            this.BtnKpt3.MouseLeave += new System.EventHandler(this.BtnKpt3_MouseLeave);
            this.BtnKpt3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnKpt3_MouseMove);
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel2.Controls.Add(this.dataGridView1);
            this.bunifuGradientPanel2.Controls.Add(this.LblKayitId);
            this.bunifuGradientPanel2.Controls.Add(this.TxtKayitId);
            this.bunifuGradientPanel2.Controls.Add(this.dataGridView4);
            this.bunifuGradientPanel2.Controls.Add(this.LblMaasOdemesi);
            this.bunifuGradientPanel2.Controls.Add(this.TxtMaasOdemesi);
            this.bunifuGradientPanel2.Controls.Add(this.MaasOdemesi);
            this.bunifuGradientPanel2.Controls.Add(this.DateTimePickerMaasOdeme);
            this.bunifuGradientPanel2.Controls.Add(this.BtnGuncelle1);
            this.bunifuGradientPanel2.Controls.Add(this.BtnKydt1);
            this.bunifuGradientPanel2.Controls.Add(this.LblPersonelId);
            this.bunifuGradientPanel2.Controls.Add(this.LblAylikMaas);
            this.bunifuGradientPanel2.Controls.Add(this.TxtAylikMaas);
            this.bunifuGradientPanel2.Controls.Add(this.TxtPersonelId);
            this.bunifuGradientPanel2.Controls.Add(this.pictureBox2);
            this.bunifuGradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.Gray;
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(0, 40);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(800, 410);
            this.bunifuGradientPanel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(300, 352);
            this.dataGridView1.TabIndex = 81;
            // 
            // LblKayitId
            // 
            this.LblKayitId.AutoSize = true;
            this.LblKayitId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblKayitId.Location = new System.Drawing.Point(635, 30);
            this.LblKayitId.Name = "LblKayitId";
            this.LblKayitId.Size = new System.Drawing.Size(50, 16);
            this.LblKayitId.TabIndex = 80;
            this.LblKayitId.Text = "Kayıt Id";
            // 
            // TxtKayitId
            // 
            this.TxtKayitId.Location = new System.Drawing.Point(697, 26);
            this.TxtKayitId.Name = "TxtKayitId";
            this.TxtKayitId.Size = new System.Drawing.Size(100, 20);
            this.TxtKayitId.TabIndex = 79;
            this.TxtKayitId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKayitId_KeyPress);
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(306, 248);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(494, 150);
            this.dataGridView4.TabIndex = 78;
            // 
            // LblMaasOdemesi
            // 
            this.LblMaasOdemesi.AutoSize = true;
            this.LblMaasOdemesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblMaasOdemesi.Location = new System.Drawing.Point(588, 104);
            this.LblMaasOdemesi.Name = "LblMaasOdemesi";
            this.LblMaasOdemesi.Size = new System.Drawing.Size(99, 16);
            this.LblMaasOdemesi.TabIndex = 77;
            this.LblMaasOdemesi.Text = "Maaş Ödemesi";
            // 
            // TxtMaasOdemesi
            // 
            this.TxtMaasOdemesi.Location = new System.Drawing.Point(697, 104);
            this.TxtMaasOdemesi.Name = "TxtMaasOdemesi";
            this.TxtMaasOdemesi.Size = new System.Drawing.Size(100, 20);
            this.TxtMaasOdemesi.TabIndex = 76;
            this.TxtMaasOdemesi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMaasOdemesi_KeyPress);
            // 
            // MaasOdemesi
            // 
            this.MaasOdemesi.AutoSize = true;
            this.MaasOdemesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MaasOdemesi.Location = new System.Drawing.Point(446, 155);
            this.MaasOdemesi.Name = "MaasOdemesi";
            this.MaasOdemesi.Size = new System.Drawing.Size(126, 16);
            this.MaasOdemesi.TabIndex = 74;
            this.MaasOdemesi.Text = "Maaş Ödeme Tarihi";
            // 
            // DateTimePickerMaasOdeme
            // 
            this.DateTimePickerMaasOdeme.Location = new System.Drawing.Point(600, 155);
            this.DateTimePickerMaasOdeme.Name = "DateTimePickerMaasOdeme";
            this.DateTimePickerMaasOdeme.Size = new System.Drawing.Size(200, 20);
            this.DateTimePickerMaasOdeme.TabIndex = 73;
            // 
            // BtnGuncelle1
            // 
            this.BtnGuncelle1.BackColor = System.Drawing.Color.White;
            this.BtnGuncelle1.Location = new System.Drawing.Point(719, 200);
            this.BtnGuncelle1.Name = "BtnGuncelle1";
            this.BtnGuncelle1.Size = new System.Drawing.Size(75, 23);
            this.BtnGuncelle1.TabIndex = 71;
            this.BtnGuncelle1.Text = "Güncelle";
            this.BtnGuncelle1.UseVisualStyleBackColor = false;
            this.BtnGuncelle1.Click += new System.EventHandler(this.BtnGuncelle1_Click);
            // 
            // BtnKydt1
            // 
            this.BtnKydt1.BackColor = System.Drawing.Color.White;
            this.BtnKydt1.Location = new System.Drawing.Point(627, 200);
            this.BtnKydt1.Name = "BtnKydt1";
            this.BtnKydt1.Size = new System.Drawing.Size(75, 23);
            this.BtnKydt1.TabIndex = 69;
            this.BtnKydt1.Text = "Kaydet";
            this.BtnKydt1.UseVisualStyleBackColor = false;
            this.BtnKydt1.Click += new System.EventHandler(this.BtnKydt1_Click);
            // 
            // LblPersonelId
            // 
            this.LblPersonelId.AutoSize = true;
            this.LblPersonelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPersonelId.Location = new System.Drawing.Point(610, 56);
            this.LblPersonelId.Name = "LblPersonelId";
            this.LblPersonelId.Size = new System.Drawing.Size(75, 16);
            this.LblPersonelId.TabIndex = 68;
            this.LblPersonelId.Text = "Personel Id";
            // 
            // LblAylikMaas
            // 
            this.LblAylikMaas.AutoSize = true;
            this.LblAylikMaas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAylikMaas.Location = new System.Drawing.Point(612, 78);
            this.LblAylikMaas.Name = "LblAylikMaas";
            this.LblAylikMaas.Size = new System.Drawing.Size(73, 16);
            this.LblAylikMaas.TabIndex = 67;
            this.LblAylikMaas.Text = "Aylık Maaş";
            // 
            // TxtAylikMaas
            // 
            this.TxtAylikMaas.Location = new System.Drawing.Point(697, 78);
            this.TxtAylikMaas.Name = "TxtAylikMaas";
            this.TxtAylikMaas.Size = new System.Drawing.Size(100, 20);
            this.TxtAylikMaas.TabIndex = 62;
            this.TxtAylikMaas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAylikMaas_KeyPress);
            // 
            // TxtPersonelId
            // 
            this.TxtPersonelId.Location = new System.Drawing.Point(697, 52);
            this.TxtPersonelId.Name = "TxtPersonelId";
            this.TxtPersonelId.Size = new System.Drawing.Size(100, 20);
            this.TxtPersonelId.TabIndex = 61;
            this.TxtPersonelId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPersonelId_KeyPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // PersonelFinans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.Controls.Add(this.Panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PersonelFinans";
            this.Load += new System.EventHandler(this.PersonelFinans_Load);
            this.Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.bunifuGradientPanel2.ResumeLayout(false);
            this.bunifuGradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel Panel4;
        private System.Windows.Forms.Button BtnKclt3;
        private System.Windows.Forms.Button BtnKpt3;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label MaasOdemesi;
        private System.Windows.Forms.DateTimePicker DateTimePickerMaasOdeme;
        private System.Windows.Forms.Button BtnGuncelle1;
        private System.Windows.Forms.Button BtnKydt1;
        private System.Windows.Forms.Label LblPersonelId;
        private System.Windows.Forms.Label LblAylikMaas;
        private System.Windows.Forms.TextBox TxtAylikMaas;
        private System.Windows.Forms.TextBox TxtPersonelId;
        private System.Windows.Forms.Label LblMaasOdemesi;
        private System.Windows.Forms.TextBox TxtMaasOdemesi;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label LblKayitId;
        private System.Windows.Forms.TextBox TxtKayitId;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}