namespace Digitalna_ribarnica
{
    partial class Prijava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prijava));
            this.lblUsername1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKorIme = new System.Windows.Forms.TextBox();
            this.txtLozinka = new System.Windows.Forms.TextBox();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.buttonPrijavi = new System.Windows.Forms.Button();
            this.labelRegistracija = new System.Windows.Forms.Label();
            this.labelCapsLock = new System.Windows.Forms.Label();
            this.notifyPrijava = new System.Windows.Forms.NotifyIcon(this.components);
            this.labelZaboravljenaLozinka = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsername1
            // 
            this.lblUsername1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername1.AutoSize = true;
            this.lblUsername1.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUsername1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(132)))), ((int)(((byte)(121)))));
            this.lblUsername1.Location = new System.Drawing.Point(157, 52);
            this.lblUsername1.Name = "lblUsername1";
            this.lblUsername1.Size = new System.Drawing.Size(115, 20);
            this.lblUsername1.TabIndex = 0;
            this.lblUsername1.Text = "Korisničko ime";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(145)))), ((int)(((byte)(112)))));
            this.label1.Location = new System.Drawing.Point(207, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lozinka";
            // 
            // txtKorIme
            // 
            this.txtKorIme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKorIme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(132)))), ((int)(((byte)(121)))));
            this.txtKorIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtKorIme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(240)))), ((int)(((byte)(201)))));
            this.txtKorIme.Location = new System.Drawing.Point(278, 52);
            this.txtKorIme.Name = "txtKorIme";
            this.txtKorIme.Size = new System.Drawing.Size(169, 21);
            this.txtKorIme.TabIndex = 0;
            this.txtKorIme.Text = "pperic13";
            this.txtKorIme.Enter += new System.EventHandler(this.txtKorIme_Enter);
            this.txtKorIme.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKorIme_KeyUp);
            this.txtKorIme.Leave += new System.EventHandler(this.txtKorIme_Leave);
            // 
            // txtLozinka
            // 
            this.txtLozinka.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLozinka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(145)))), ((int)(((byte)(112)))));
            this.txtLozinka.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(240)))), ((int)(((byte)(201)))));
            this.txtLozinka.Location = new System.Drawing.Point(278, 87);
            this.txtLozinka.Name = "txtLozinka";
            this.txtLozinka.Size = new System.Drawing.Size(169, 20);
            this.txtLozinka.TabIndex = 1;
            this.txtLozinka.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLozinka_KeyUp);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdustani.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOdustani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(153)))), ((int)(((byte)(106)))));
            this.btnOdustani.Location = new System.Drawing.Point(361, 176);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(86, 40);
            this.btnOdustani.TabIndex = 2;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // buttonPrijavi
            // 
            this.buttonPrijavi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPrijavi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrijavi.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPrijavi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(153)))), ((int)(((byte)(106)))));
            this.buttonPrijavi.Location = new System.Drawing.Point(249, 176);
            this.buttonPrijavi.Name = "buttonPrijavi";
            this.buttonPrijavi.Size = new System.Drawing.Size(102, 40);
            this.buttonPrijavi.TabIndex = 2;
            this.buttonPrijavi.Text = "Prijavi se";
            this.buttonPrijavi.UseVisualStyleBackColor = true;
            this.buttonPrijavi.Click += new System.EventHandler(this.buttonPrijavi_Click);
            // 
            // labelRegistracija
            // 
            this.labelRegistracija.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelRegistracija.AutoSize = true;
            this.labelRegistracija.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(203)))), ((int)(((byte)(132)))));
            this.labelRegistracija.Location = new System.Drawing.Point(371, 219);
            this.labelRegistracija.Name = "labelRegistracija";
            this.labelRegistracija.Size = new System.Drawing.Size(67, 13);
            this.labelRegistracija.TabIndex = 3;
            this.labelRegistracija.Text = "Registriraj se";
            this.labelRegistracija.Click += new System.EventHandler(this.labelRegistracija_Click);
            // 
            // labelCapsLock
            // 
            this.labelCapsLock.AutoSize = true;
            this.labelCapsLock.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCapsLock.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelCapsLock.Location = new System.Drawing.Point(207, 110);
            this.labelCapsLock.Name = "labelCapsLock";
            this.labelCapsLock.Size = new System.Drawing.Size(0, 22);
            this.labelCapsLock.TabIndex = 4;
            this.labelCapsLock.Visible = false;
            // 
            // notifyPrijava
            // 
            this.notifyPrijava.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyPrijava.Icon")));
            this.notifyPrijava.Text = "notifyIcon1";
            this.notifyPrijava.Visible = true;
            // 
            // labelZaboravljenaLozinka
            // 
            this.labelZaboravljenaLozinka.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelZaboravljenaLozinka.AutoSize = true;
            this.labelZaboravljenaLozinka.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(203)))), ((int)(((byte)(132)))));
            this.labelZaboravljenaLozinka.Location = new System.Drawing.Point(246, 219);
            this.labelZaboravljenaLozinka.Name = "labelZaboravljenaLozinka";
            this.labelZaboravljenaLozinka.Size = new System.Drawing.Size(105, 13);
            this.labelZaboravljenaLozinka.TabIndex = 3;
            this.labelZaboravljenaLozinka.Text = "Zaboravljena lozinka";
            this.labelZaboravljenaLozinka.Click += new System.EventHandler(this.labelZaboravljenaLozinka_Click);
            // 
            // Prijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(669, 271);
            this.Controls.Add(this.labelCapsLock);
            this.Controls.Add(this.labelZaboravljenaLozinka);
            this.Controls.Add(this.labelRegistracija);
            this.Controls.Add(this.buttonPrijavi);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.txtLozinka);
            this.Controls.Add(this.txtKorIme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUsername1);
            this.Name = "Prijava";
            this.Text = "Prijava";
            this.Load += new System.EventHandler(this.Prijava_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Prijava_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKorIme;
        private System.Windows.Forms.TextBox txtLozinka;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button buttonPrijavi;
        private System.Windows.Forms.Label labelRegistracija;
        private System.Windows.Forms.Label labelCapsLock;
        private System.Windows.Forms.NotifyIcon notifyPrijava;
        private System.Windows.Forms.Label labelZaboravljenaLozinka;
    }
}