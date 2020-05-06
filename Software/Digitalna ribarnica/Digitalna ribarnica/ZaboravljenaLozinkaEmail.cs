﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prijava;
using Registracija;
namespace Digitalna_ribarnica
{
    public partial class ZaboravljenaLozinkaEmail : Form
    {
        Autentifikator Autentifikator;
        public ZaboravljenaLozinkaEmail(Autentifikator autentifikator)
        {
            InitializeComponent();
            Autentifikator = autentifikator;
        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                Autentifikator.postojiEmail(textEmail.Text);
                Random verificationCode = new Random();
                int broj = verificationCode.Next(10000, 99999);
                Code code = new Code(broj);
                MailMessage msg = new MailMessage("eribarnica@gmail.com", textEmail.Text, "Digitalna ribarnica", "<br>Vaš kod za promjenu lozinke je: </br>" + broj);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("eribarnica@gmail.com", ">H3/Wr9H");//your mail password
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(msg);
                notifyZaboravljenaLozinka.ShowBalloonTip(1000, "Code", "Kod za promjenu lozinke je poslan na Vaš mail!", ToolTipIcon.Info);

                formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
                if (form != null)
                {
                    form.openChildForm(new PromijeniLozinku(Autentifikator, code,textEmail.Text));
                }

            }
            catch (PrijavaException ex)
            {
                notifyZaboravljenaLozinka.ShowBalloonTip(1000, "Zaboravljena lozinka", ex.Poruka, ToolTipIcon.Error);
            }
        }
    }
}
