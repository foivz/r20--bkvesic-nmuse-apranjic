namespace Digitalna_ribarnica
{
    partial class PromijeniLozinku
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromijeniLozinku));
            this.labelObavijest = new System.Windows.Forms.Label();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.buttonSaljiPonovno = new System.Windows.Forms.Button();
            this.buttonPotvrdi = new System.Windows.Forms.Button();
            this.lblIme = new System.Windows.Forms.Label();
            this.textCode4 = new System.Windows.Forms.TextBox();
            this.textCode5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textCode1 = new System.Windows.Forms.TextBox();
            this.textCode3 = new System.Windows.Forms.TextBox();
            this.textCode2 = new System.Windows.Forms.TextBox();
            this.timerPromjenaLozinke = new System.Windows.Forms.Timer(this.components);
            this.notifyUnesiKodZaPromjenu = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // labelObavijest
            // 
            this.labelObavijest.AutoSize = true;
            this.labelObavijest.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelObavijest.ForeColor = System.Drawing.Color.White;
            this.labelObavijest.Location = new System.Drawing.Point(274, 304);
            this.labelObavijest.Name = "labelObavijest";
            this.labelObavijest.Size = new System.Drawing.Size(177, 20);
            this.labelObavijest.TabIndex = 23;
            this.labelObavijest.Text = "Mail je ponovno poslan";
            this.labelObavijest.Visible = false;
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOdustani.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOdustani.ForeColor = System.Drawing.Color.White;
            this.buttonOdustani.Location = new System.Drawing.Point(424, 203);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(86, 40);
            this.buttonOdustani.TabIndex = 20;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            this.buttonOdustani.Click += new System.EventHandler(this.buttonOdustani_Click);
            // 
            // buttonSaljiPonovno
            // 
            this.buttonSaljiPonovno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaljiPonovno.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSaljiPonovno.ForeColor = System.Drawing.Color.White;
            this.buttonSaljiPonovno.Location = new System.Drawing.Point(133, 294);
            this.buttonSaljiPonovno.Name = "buttonSaljiPonovno";
            this.buttonSaljiPonovno.Size = new System.Drawing.Size(135, 40);
            this.buttonSaljiPonovno.TabIndex = 21;
            this.buttonSaljiPonovno.Text = "Pošalji ponovno";
            this.buttonSaljiPonovno.UseVisualStyleBackColor = true;
            this.buttonSaljiPonovno.Click += new System.EventHandler(this.buttonSaljiPonovno_Click);
            // 
            // buttonPotvrdi
            // 
            this.buttonPotvrdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPotvrdi.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPotvrdi.ForeColor = System.Drawing.Color.White;
            this.buttonPotvrdi.Location = new System.Drawing.Point(331, 203);
            this.buttonPotvrdi.Name = "buttonPotvrdi";
            this.buttonPotvrdi.Size = new System.Drawing.Size(86, 40);
            this.buttonPotvrdi.TabIndex = 19;
            this.buttonPotvrdi.Text = "Potvrdi";
            this.buttonPotvrdi.UseVisualStyleBackColor = true;
            this.buttonPotvrdi.Click += new System.EventHandler(this.buttonPotvrdi_Click);
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblIme.ForeColor = System.Drawing.Color.White;
            this.lblIme.Location = new System.Drawing.Point(210, 160);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(115, 20);
            this.lblIme.TabIndex = 22;
            this.lblIme.Text = "Password code";
            // 
            // textCode4
            // 
            this.textCode4.Location = new System.Drawing.Point(424, 160);
            this.textCode4.MaxLength = 1;
            this.textCode4.Name = "textCode4";
            this.textCode4.Size = new System.Drawing.Size(25, 20);
            this.textCode4.TabIndex = 17;
            this.textCode4.TextChanged += new System.EventHandler(this.textCode4_TextChanged);
            // 
            // textCode5
            // 
            this.textCode5.Location = new System.Drawing.Point(455, 160);
            this.textCode5.MaxLength = 1;
            this.textCode5.Name = "textCode5";
            this.textCode5.Size = new System.Drawing.Size(25, 20);
            this.textCode5.TabIndex = 18;
            this.textCode5.TextChanged += new System.EventHandler(this.textCode5_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(424, 160);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(25, 20);
            this.textBox3.TabIndex = 13;
            // 
            // textCode1
            // 
            this.textCode1.Location = new System.Drawing.Point(331, 160);
            this.textCode1.MaxLength = 1;
            this.textCode1.Name = "textCode1";
            this.textCode1.Size = new System.Drawing.Size(25, 20);
            this.textCode1.TabIndex = 14;
            this.textCode1.TextChanged += new System.EventHandler(this.textCode1_TextChanged);
            // 
            // textCode3
            // 
            this.textCode3.Location = new System.Drawing.Point(393, 160);
            this.textCode3.MaxLength = 1;
            this.textCode3.Name = "textCode3";
            this.textCode3.Size = new System.Drawing.Size(25, 20);
            this.textCode3.TabIndex = 16;
            this.textCode3.TextChanged += new System.EventHandler(this.textCode3_TextChanged);
            // 
            // textCode2
            // 
            this.textCode2.Location = new System.Drawing.Point(362, 160);
            this.textCode2.MaxLength = 1;
            this.textCode2.Name = "textCode2";
            this.textCode2.Size = new System.Drawing.Size(25, 20);
            this.textCode2.TabIndex = 15;
            this.textCode2.TextChanged += new System.EventHandler(this.textCode2_TextChanged);
            // 
            // timerPromjenaLozinke
            // 
            this.timerPromjenaLozinke.Tick += new System.EventHandler(this.timerPromjenaLozinke_Tick);
            // 
            // notifyUnesiKodZaPromjenu
            // 
            this.notifyUnesiKodZaPromjenu.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyUnesiKodZaPromjenu.Icon")));
            this.notifyUnesiKodZaPromjenu.Text = "notifyIcon1";
            this.notifyUnesiKodZaPromjenu.Visible = true;
            // 
            // PromijeniLozinku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelObavijest);
            this.Controls.Add(this.buttonOdustani);
            this.Controls.Add(this.buttonSaljiPonovno);
            this.Controls.Add(this.buttonPotvrdi);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.textCode4);
            this.Controls.Add(this.textCode5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textCode1);
            this.Controls.Add(this.textCode3);
            this.Controls.Add(this.textCode2);
            this.Name = "PromijeniLozinku";
            this.Text = "PromijeniLozinku";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelObavijest;
        private System.Windows.Forms.Button buttonOdustani;
        private System.Windows.Forms.Button buttonSaljiPonovno;
        private System.Windows.Forms.Button buttonPotvrdi;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.TextBox textCode4;
        private System.Windows.Forms.TextBox textCode5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textCode1;
        private System.Windows.Forms.TextBox textCode3;
        private System.Windows.Forms.TextBox textCode2;
        private System.Windows.Forms.Timer timerPromjenaLozinke;
        public System.Windows.Forms.NotifyIcon notifyUnesiKodZaPromjenu;
    }
}