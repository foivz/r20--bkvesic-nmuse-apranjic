﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using Prijava;

namespace Digitalna_ribarnica
{
    public partial class VerificationCode : Form
    {
        int code_number;
        string Email;
        string Ime;
        string Lozinka;
        Autentifikator autentifikator;
        public VerificationCode()
        {
            InitializeComponent();
            
        }

        public VerificationCode(string ime, string lozinka,int broj, string email, Autentifikator autentifikator)
        {
            InitializeComponent();
            Ime = ime;
            Lozinka = lozinka;
            code_number = broj;
            Email = email;
            this.autentifikator = autentifikator;
        }

        private void VerificationCode_Load(object sender, EventArgs e)
        {

        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            if ((textBoxCode1.Text == (code_number / 10000).ToString()) && (textBoxCode2.Text == ((code_number / 1000) % 10).ToString()) && (textBoxCode3.Text == ((code_number / 100) % 10).ToString()) && (textBoxCode4.Text == ((code_number % 100) / 10).ToString()) && (textBoxCode5.Text == (code_number % 10).ToString()))
            {
                autentifikator.DodajKorisnika(Ime, Lozinka);
            }
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                form.labelOdjava.Text = "Uspješna registracija!";
                form.labelOdjava.Visible = true;
            }
            notifyVerification.ShowBalloonTip(1000, "Registration", "Uspješno ste se registrirali!", ToolTipIcon.Info);
            Close();

        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSaljiPonovno_Click(object sender, EventArgs e)
        {
            Random code = new Random();
            int broj = code.Next(10000, 99999);
            MailMessage msg = new MailMessage("eribarnica@gmail.com", Email, "Digitalna ribarnica", "<br>Vaš kod za aktivaciju računa je: </br>" + broj);
            msg.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
            sc.UseDefaultCredentials = false;
            NetworkCredential cre = new NetworkCredential("eribarnica@gmail.com", ">H3/Wr9H");//your mail password
            sc.Credentials = cre;
            sc.EnableSsl = true;
            sc.Send(msg);
            //MessageBox.Show("Mail Send");
            code_number = broj;
            notifyVerification.ShowBalloonTip(1000, "Registration", "Kod za registraciju je ponovno poslan na Vaš mail!", ToolTipIcon.Info);
        }
    }
}
