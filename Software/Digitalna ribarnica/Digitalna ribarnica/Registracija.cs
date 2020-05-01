using System;
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
using Registracija;

namespace Digitalna_ribarnica
{
    public partial class Registracija : Form
    {
        Autentifikator autentifikator;
        AutentifikacijaRegistracije AutentifikacijaRegistracije;
        public Registracija()
        {
            InitializeComponent();
        }

        public Registracija(Autentifikator autentifikator)
        {
            InitializeComponent();
            this.autentifikator = autentifikator;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRegistracija_Click(object sender, EventArgs e)
        {
            try
            {
                    AutentifikacijaRegistracije = new AutentifikacijaRegistracije(txtIme.Text, txtPrezime.Text, txtKorIme.Text, txtAdresa.Text, txtMjesto.Text, txtMobitel.Text, textEmail.Text, txtLozinka.Text, txtPonoviLozinku.Text);
                    autentifikator.provjeriKorisnika(txtKorIme.Text);
                    autentifikator.provjeriKorisnika1(txtKorIme.Text);
                    autentifikator.provjeriKorisnika2(txtKorIme.Text);
                    Random verificationCode = new Random();
                    int broj = verificationCode.Next(10000, 99999);
                    Code code = new Code(broj);
                    MailMessage msg = new MailMessage("eribarnica@gmail.com", textEmail.Text, "Digitalna ribarnica", "<br>Vaš kod za aktivaciju računa je: </br>" + broj);
                    msg.IsBodyHtml = true;
                    SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                    sc.UseDefaultCredentials = false;
                    NetworkCredential cre = new NetworkCredential("eribarnica@gmail.com", ">H3/Wr9H");//your mail password
                    sc.Credentials = cre;
                    sc.EnableSsl = true;
                    sc.Send(msg);
                    //MessageBox.Show("Mail Send");
                    notifyRegistracija.ShowBalloonTip(1000, "Code", "Kod za registraciju je poslan na Vaš mail!", ToolTipIcon.Info);

                    formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
                    if (form != null)
                    {
                        //TODO dodati kontruktor VerificationCode koji prima sve podatke (ime, prezime, korime, adresa, mjesto, mobitel, email..)
                        //form.openChildForm(new VerificationCode(txtKorIme.Text, txtLozinka.Text, broj, textEmail.Text, autentifikator));
                        form.openChildForm(new VerificationCode(txtKorIme.Text, txtLozinka.Text, code, textEmail.Text, autentifikator));
                    }
            }
            catch (RegistrationException ex)
            {
                //MessageBox.Show(ex.Poruka);
                notifyRegistracija.ShowBalloonTip(1000, "Registracija", ex.Poruka, ToolTipIcon.Warning);
            }
            catch (PrijavaException ex)
            {
                //MessageBox.Show(ex.Poruka);
                notifyRegistracija.ShowBalloonTip(1000, "Registracija", ex.Poruka, ToolTipIcon.Warning);
            }
            
           
        }

        private void Registracija_Load(object sender, EventArgs e)
        {
            txtLozinka.PasswordChar = '\u25CF';
            txtPonoviLozinku.PasswordChar ='\u25CF';
        }
    }
}
