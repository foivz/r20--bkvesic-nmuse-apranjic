﻿namespace Digitalna_ribarnica
{
    partial class DodajPonudu
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtbxOpis = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKreiraj = new System.Windows.Forms.Button();
            this.cmbRiba = new System.Windows.Forms.ComboBox();
            this.cmbLokacija = new System.Windows.Forms.ComboBox();
            this.txtKolicina = new System.Windows.Forms.TextBox();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.btnUcitaj = new System.Windows.Forms.Button();
            this.ucKolicina = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMjerna = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(334, 268);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rtbxOpis
            // 
            this.rtbxOpis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.rtbxOpis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.rtbxOpis.Location = new System.Drawing.Point(334, 172);
            this.rtbxOpis.Name = "rtbxOpis";
            this.rtbxOpis.Size = new System.Drawing.Size(279, 67);
            this.rtbxOpis.TabIndex = 2;
            this.rtbxOpis.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.checkBox1.Location = new System.Drawing.Point(334, 245);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Dodatna slika";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblMjerna);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ucKolicina);
            this.groupBox1.Controls.Add(this.txtCijena);
            this.groupBox1.Controls.Add(this.txtKolicina);
            this.groupBox1.Controls.Add(this.cmbLokacija);
            this.groupBox1.Controls.Add(this.cmbRiba);
            this.groupBox1.Controls.Add(this.btnUcitaj);
            this.groupBox1.Controls.Add(this.btnKreiraj);
            this.groupBox1.Controls.Add(this.rtbxOpis);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1051, 486);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnKreiraj
            // 
            this.btnKreiraj.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnKreiraj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKreiraj.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKreiraj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(153)))), ((int)(((byte)(106)))));
            this.btnKreiraj.Location = new System.Drawing.Point(419, 433);
            this.btnKreiraj.Name = "btnKreiraj";
            this.btnKreiraj.Size = new System.Drawing.Size(102, 40);
            this.btnKreiraj.TabIndex = 24;
            this.btnKreiraj.Text = "Kreiraj";
            this.btnKreiraj.UseVisualStyleBackColor = true;
            this.btnKreiraj.Click += new System.EventHandler(this.btnKreiraj_Click);
            // 
            // cmbRiba
            // 
            this.cmbRiba.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.cmbRiba.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.cmbRiba.FormattingEnabled = true;
            this.cmbRiba.Location = new System.Drawing.Point(415, 19);
            this.cmbRiba.Name = "cmbRiba";
            this.cmbRiba.Size = new System.Drawing.Size(121, 21);
            this.cmbRiba.TabIndex = 25;
            this.cmbRiba.SelectedIndexChanged += new System.EventHandler(this.cmbRiba_SelectedIndexChanged);
            // 
            // cmbLokacija
            // 
            this.cmbLokacija.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.cmbLokacija.ForeColor = System.Drawing.SystemColors.Menu;
            this.cmbLokacija.FormattingEnabled = true;
            this.cmbLokacija.Location = new System.Drawing.Point(415, 63);
            this.cmbLokacija.Name = "cmbLokacija";
            this.cmbLokacija.Size = new System.Drawing.Size(121, 21);
            this.cmbLokacija.TabIndex = 25;
            // 
            // txtKolicina
            // 
            this.txtKolicina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.txtKolicina.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtKolicina.Location = new System.Drawing.Point(415, 146);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(121, 20);
            this.txtKolicina.TabIndex = 26;
            // 
            // txtCijena
            // 
            this.txtCijena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.txtCijena.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtCijena.Location = new System.Drawing.Point(415, 106);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(121, 20);
            this.txtCijena.TabIndex = 27;
            // 
            // btnUcitaj
            // 
            this.btnUcitaj.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUcitaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUcitaj.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUcitaj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(153)))), ((int)(((byte)(106)))));
            this.btnUcitaj.Location = new System.Drawing.Point(419, 387);
            this.btnUcitaj.Name = "btnUcitaj";
            this.btnUcitaj.Size = new System.Drawing.Size(102, 40);
            this.btnUcitaj.TabIndex = 24;
            this.btnUcitaj.Text = "Učitaj sliku";
            this.btnUcitaj.UseVisualStyleBackColor = true;
            this.btnUcitaj.Click += new System.EventHandler(this.btnUcitaj_Click);
            // 
            // ucKolicina
            // 
            this.ucKolicina.AutoSize = true;
            this.ucKolicina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(161)))), ((int)(((byte)(141)))));
            this.ucKolicina.Location = new System.Drawing.Point(355, 22);
            this.ucKolicina.Name = "ucKolicina";
            this.ucKolicina.Size = new System.Drawing.Size(54, 13);
            this.ucKolicina.TabIndex = 28;
            this.ucKolicina.Text = "Naziv ribe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(161)))), ((int)(((byte)(141)))));
            this.label1.Location = new System.Drawing.Point(362, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Lokacija";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(161)))), ((int)(((byte)(141)))));
            this.label2.Location = new System.Drawing.Point(373, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Cijena";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(161)))), ((int)(((byte)(141)))));
            this.label3.Location = new System.Drawing.Point(542, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "kn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(161)))), ((int)(((byte)(141)))));
            this.label4.Location = new System.Drawing.Point(366, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Količina";
            // 
            // lblMjerna
            // 
            this.lblMjerna.AutoSize = true;
            this.lblMjerna.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(161)))), ((int)(((byte)(141)))));
            this.lblMjerna.Location = new System.Drawing.Point(542, 149);
            this.lblMjerna.Name = "lblMjerna";
            this.lblMjerna.Size = new System.Drawing.Size(0, 13);
            this.lblMjerna.TabIndex = 28;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(161)))), ((int)(((byte)(141)))));
            this.label5.Location = new System.Drawing.Point(285, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Opis";
            // 
            // DodajPonudu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1087, 623);
            this.Controls.Add(this.groupBox1);
            this.Name = "DodajPonudu";
            this.Text = "DodajPonudu";
            this.Load += new System.EventHandler(this.DodajPonudu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rtbxOpis;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.TextBox txtKolicina;
        private System.Windows.Forms.Button btnUcitaj;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblMjerna;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label ucKolicina;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button btnKreiraj;
        public System.Windows.Forms.ComboBox cmbLokacija;
        public System.Windows.Forms.ComboBox cmbRiba;
        public System.Windows.Forms.Label label5;
    }
}