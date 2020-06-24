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
using Baza;
namespace Digitalna_ribarnica
{
    public partial class VerificationCode : Form
    {
        int code_number;
        string Ime;
        string Prezime;
        string Adresa;
        string Mjesto;
        string BrojMobitela;
        string Email;
        string KorIme;
        string Lozinka;
        Autentifikator autentifikator;
        Code Code; 
        public bool PrihvaceniUvjeti { get; set; }
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

        //TEST s istekom vremena
        public VerificationCode(string korime, string lozinka, Code broj, string email, Autentifikator autentifikator, string ime, string prezime, string adresa, string mjesto, string brojmobitela)
        {
            InitializeComponent();
            KorIme = korime;
            Lozinka = lozinka;
            Code = broj;
            Email = email;
            this.autentifikator = autentifikator;
            Ime = ime;
            Prezime = prezime;
            Adresa = adresa;
            Mjesto = mjesto;
            BrojMobitela = brojmobitela;
        }

        private void VerificationCode_Load(object sender, EventArgs e)
        {
            textBoxCode1.Focus();
            PrihvaceniUvjeti = false;
        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            //if ((textBoxCode1.Text == (code_number / 10000).ToString()) && (textBoxCode2.Text == ((code_number / 1000) % 10).ToString()) && (textBoxCode3.Text == ((code_number / 100) % 10).ToString()) && (textBoxCode4.Text == ((code_number % 100) / 10).ToString()) && (textBoxCode5.Text == (code_number % 10).ToString()))
            if ((textBoxCode1.Text == (Code.Broj / 10000).ToString()) && (textBoxCode2.Text == ((Code.Broj / 1000) % 10).ToString()) && (textBoxCode3.Text == ((Code.Broj / 100) % 10).ToString()) && (textBoxCode4.Text == ((Code.Broj % 100) / 10).ToString()) && (textBoxCode5.Text == (Code.Broj % 10).ToString()))
                {
                if (DateTime.Compare(DateTime.Now, Code.DatumIsteka) <= 0) //Ovdje provjervamo vrijedi li uneseni kod pomoću usporedbe trentunog datuma s datumom isteka koda
                {
                    //notifyVerification.ShowBalloonTip(1000, "Registration", "Kod jos vrijedi", ToolTipIcon.Info);
                    Terms_of_service terms_Of_Service = new Terms_of_service(PrihvaceniUvjeti);
                    terms_Of_Service.ShowDialog();
                    PrihvaceniUvjeti = terms_Of_Service.Prihvaceni;
                    if (PrihvaceniUvjeti)
                    {
                        //TODO: dodati autentifikator.DodajKorisnika koji prima sve property te ih sprema u listu registrirani korisnika
                        //autentifikator.DodajKorisnika(Ime, Lozinka,Email);
                        autentifikator.DodajKorisnika(Ime, Prezime, KorIme, Adresa, Mjesto, BrojMobitela, Lozinka, Email);
                        Korisnik korisnik = new Korisnik(Ime, Prezime, KorIme, Adresa, Mjesto, BrojMobitela, Lozinka, Email, 3);
                        KorisnikRepository.Spremi(korisnik);
                        formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
                        if (form != null)
                        {
                            form.labelOdjava.Text = "Uspješna registracija!";
                            form.labelOdjava.Visible = true;
                        }
                        notifyVerification.ShowBalloonTip(1000, "Registration", "Uspješno ste se registrirali!", ToolTipIcon.Info);
                        Close();
                    }
                    else
                    {
                        notifyVerification.ShowBalloonTip(1000, "Registration", "Morate prihvatiti uvjete korištenja, inače Vas ne možemo registrirati", ToolTipIcon.Error);
                    }
                }
                else
                {
                    notifyVerification.ShowBalloonTip(1000, "Registration", "Kod ne vrijedi", ToolTipIcon.Info);
                }
            }
            else
            {
                notifyVerification.ShowBalloonTip(1000, "Registration", "Unijeli ste krivi kod!!!", ToolTipIcon.Error);
            }
        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }
        // ovdje se nalazi funkcionalnost za ponovno slanje email koda
        private void buttonSaljiPonovno_Click(object sender, EventArgs e)
        {
            timerLabel.Interval = 5000;
            timerLabel.Enabled = true;
            labelObavijest.Visible = true;
            Random code = new Random();
            int broj = code.Next(10000, 99999);
            Code noviCode = new Code(broj);
            MailMessage msg = new MailMessage("eribarnica@gmail.com", Email, "Digitalna ribarnica", "<br>Vaš kod za aktivaciju računa je: </br>" + broj);
            msg.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
            sc.UseDefaultCredentials = false;
            NetworkCredential cre = new NetworkCredential("eribarnica@gmail.com", ">H3/Wr9H");//your mail password
            sc.Credentials = cre;
            sc.EnableSsl = true;
            sc.Send(msg);
            //MessageBox.Show("Mail Send");
            //code_number = broj;
            Code = noviCode;
            notifyVerification.ShowBalloonTip(1000, "Registration", "Kod za registraciju je ponovno poslan na Vaš mail!", ToolTipIcon.Info);
        }

        private void timerLabel_Tick(object sender, EventArgs e)
        {
            labelObavijest.Visible = false;
            timerLabel.Stop();
        }

        //Ovaj dio ispod služi za fokusiranje pojedinih textboxova prilikom unosa pojedinog broja za verifikaciju koda

        private void textBoxCode1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode1.Text.Length ==1)
            {
                textBoxCode2.Focus();
            }
        }

        private void textBoxCode2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode2.Text.Length == 1)
            {
                textBoxCode3.Focus();
            }
            else if (textBoxCode2.Text.Length == 0)
            {
                textBoxCode1.Focus();
            }
        }

        private void textBoxCode3_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode3.Text.Length == 1)
            {
                textBoxCode4.Focus();
            }
            else if (textBoxCode3.Text.Length == 0)
            {
                textBoxCode2.Focus();
            }
        }

        private void textBoxCode4_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode4.Text.Length == 1)
            {
                textBoxCode5.Focus();
            }
            else if (textBoxCode4.Text.Length == 0)
            {
                textBoxCode3.Focus();
            }
        }

        private void textBoxCode5_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode5.Text.Length == 1)
            {
                buttonPotvrdi.Focus();
            }
            else if (textBoxCode5.Text.Length == 0)
            {
                textBoxCode4.Focus();
            }
        }

 
    }
}
