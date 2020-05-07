namespace Digitalna_ribarnica
{
    partial class Registracija
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registracija));
            this.buttonRegistracija = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.lblIme = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKorIme = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLozinka = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPonoviLozinku = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMjesto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMobitel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.notifyRegistracija = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // buttonRegistracija
            // 
            this.buttonRegistracija.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistracija.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRegistracija.ForeColor = System.Drawing.Color.White;
            this.buttonRegistracija.Location = new System.Drawing.Point(318, 350);
            this.buttonRegistracija.Name = "buttonRegistracija";
            this.buttonRegistracija.Size = new System.Drawing.Size(128, 40);
            this.buttonRegistracija.TabIndex = 9;
            this.buttonRegistracija.Text = "Registriraj se";
            this.buttonRegistracija.UseVisualStyleBackColor = true;
            this.buttonRegistracija.Click += new System.EventHandler(this.buttonRegistracija_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdustani.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOdustani.ForeColor = System.Drawing.Color.White;
            this.btnOdustani.Location = new System.Drawing.Point(455, 350);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(86, 40);
            this.btnOdustani.TabIndex = 10;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // txtPrezime
            // 
            this.txtPrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPrezime.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPrezime.Location = new System.Drawing.Point(422, 67);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(145, 21);
            this.txtPrezime.TabIndex = 1;
            this.txtPrezime.Text = "Perić";
            this.txtPrezime.Enter += new System.EventHandler(this.txtPrezime_Enter);
            this.txtPrezime.Leave += new System.EventHandler(this.txtPrezime_Leave);
            // 
            // txtIme
            // 
            this.txtIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtIme.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIme.Location = new System.Drawing.Point(422, 36);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(145, 21);
            this.txtIme.TabIndex = 0;
            this.txtIme.Text = "Pero";
            this.txtIme.Enter += new System.EventHandler(this.txtIme_Enter);
            this.txtIme.Leave += new System.EventHandler(this.txtIme_Leave);
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblIme.ForeColor = System.Drawing.Color.White;
            this.lblIme.Location = new System.Drawing.Point(361, 34);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(37, 20);
            this.lblIme.TabIndex = 11;
            this.lblIme.Text = "Ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(283, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Korisničko ime";
            // 
            // txtKorIme
            // 
            this.txtKorIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtKorIme.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtKorIme.Location = new System.Drawing.Point(422, 99);
            this.txtKorIme.Name = "txtKorIme";
            this.txtKorIme.Size = new System.Drawing.Size(145, 21);
            this.txtKorIme.TabIndex = 2;
            this.txtKorIme.Text = "pperic13";
            this.txtKorIme.Enter += new System.EventHandler(this.txtKorIme_Enter);
            this.txtKorIme.Leave += new System.EventHandler(this.txtKorIme_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(333, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Lozinka";
            // 
            // txtLozinka
            // 
            this.txtLozinka.Location = new System.Drawing.Point(422, 257);
            this.txtLozinka.Name = "txtLozinka";
            this.txtLozinka.Size = new System.Drawing.Size(145, 20);
            this.txtLozinka.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(283, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Ponovi lozinku";
            // 
            // txtPonoviLozinku
            // 
            this.txtPonoviLozinku.Location = new System.Drawing.Point(422, 290);
            this.txtPonoviLozinku.Name = "txtPonoviLozinku";
            this.txtPonoviLozinku.Size = new System.Drawing.Size(145, 20);
            this.txtPonoviLozinku.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(339, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Adresa";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtAdresa.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAdresa.Location = new System.Drawing.Point(422, 130);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(145, 21);
            this.txtAdresa.TabIndex = 3;
            this.txtAdresa.Text = "ulica Pere Perica 30";
            this.txtAdresa.Enter += new System.EventHandler(this.txtAdresa_Enter);
            this.txtAdresa.Leave += new System.EventHandler(this.txtAdresa_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(331, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Prezime";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(340, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Mjesto";
            // 
            // txtMjesto
            // 
            this.txtMjesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtMjesto.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMjesto.Location = new System.Drawing.Point(422, 161);
            this.txtMjesto.Name = "txtMjesto";
            this.txtMjesto.Size = new System.Drawing.Size(145, 21);
            this.txtMjesto.TabIndex = 4;
            this.txtMjesto.Text = "Staro Petrovo selo 10000";
            this.txtMjesto.Enter += new System.EventHandler(this.txtMjesto_Enter);
            this.txtMjesto.Leave += new System.EventHandler(this.txtMjesto_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(292, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Broj mobitela";
            // 
            // txtMobitel
            // 
            this.txtMobitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtMobitel.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMobitel.Location = new System.Drawing.Point(422, 193);
            this.txtMobitel.Name = "txtMobitel";
            this.txtMobitel.Size = new System.Drawing.Size(145, 21);
            this.txtMobitel.TabIndex = 5;
            this.txtMobitel.Text = "+38599123456789";
            this.txtMobitel.Enter += new System.EventHandler(this.txtMobitel_Enter);
            this.txtMobitel.Leave += new System.EventHandler(this.txtMobitel_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(350, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Email";
            // 
            // textEmail
            // 
            this.textEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textEmail.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textEmail.Location = new System.Drawing.Point(422, 224);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(145, 21);
            this.textEmail.TabIndex = 6;
            this.textEmail.Text = "pperic@gmail.com";
            this.textEmail.Enter += new System.EventHandler(this.textEmail_Enter);
            this.textEmail.Leave += new System.EventHandler(this.textEmail_Leave);
            // 
            // notifyRegistracija
            // 
            this.notifyRegistracija.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyRegistracija.Icon")));
            this.notifyRegistracija.Text = "notifyIcon1";
            this.notifyRegistracija.Visible = true;
            // 
            // Registracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(942, 497);
            this.Controls.Add(this.buttonRegistracija);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.txtMobitel);
            this.Controls.Add(this.txtMjesto);
            this.Controls.Add(this.txtAdresa);
            this.Controls.Add(this.txtPonoviLozinku);
            this.Controls.Add(this.txtLozinka);
            this.Controls.Add(this.txtKorIme);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblIme);
            this.Name = "Registracija";
            this.Text = "Registracija";
            this.Load += new System.EventHandler(this.Registracija_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRegistracija;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKorIme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLozinka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPonoviLozinku;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMjesto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMobitel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.NotifyIcon notifyRegistracija;
    }
}