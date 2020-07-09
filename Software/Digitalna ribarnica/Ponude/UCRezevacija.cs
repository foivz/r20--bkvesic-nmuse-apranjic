using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INSform;
using Prijava;
namespace Ponude
{
    public partial class UCRezevacija : UserControl
    {
        private Rezervacija rezervacija = null;
        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }
        public int IDKupca { get; set; }
        Iform Iform;
        public UCRezevacija(Iform novo)
        {
            InitializeComponent();
            Iform = novo;
            Trenutna = Iform.nova;
            panelStranice = Iform.panel;
        }

        public void LoadPonuda(Rezervacija rezervacija)
        {
            this.rezervacija = rezervacija;
        }

        public void openChildForm(Form childForm)
        {
            if (Trenutna != null)
                Trenutna.Close();
            Trenutna = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelStranice.Controls.Add(childForm);
            panelStranice.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void zatvoriForme()
        {
            FormCollection fc = Application.OpenForms;
            List<Form> aktivne = new List<Form>();
            foreach (Form frm in fc)
            {
                if (frm.Name != "formPocetna")
                {
                    //frm.Close();
                    aktivne.Add(frm);
                }
            }

            foreach (var item in aktivne)
            {
                item.Close();
            }
        }

        private void btnPreuzeto_Click(object sender, EventArgs e)
        {
            PonudeRepozitory.RezervacijaDovrsena(Iform, rezervacija.ID);
            //zatvoriForme();
            KorisnikRepository.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), "Korisnik " + Iform.autentifikator.AktivanKorisnik + " je proglasio rezervaciju " + rezervacija.ID + " izvšenom", 14);
            List<string> email = new List<string>();
            email.Add(KorisnikRepository.DohvatiEmailKorisnika(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik)));
            email.Add(KorisnikRepository.DohvatiEmailKorisnika(IDKupca));
            Mail mail = new Mail(email);
            mail.Text = "Poštovani\nKorisnik " + Iform.autentifikator.AktivanKorisnik + " je potvrdio da je rezervacija dovršena. Molimo ocijenite korisnika!\nLijep pozdrav!";
            mail.Title = "Rezervacija dovršena";
            mail.RequireAutentication = true;
            mail.Send();
            openChildForm(new OcijeniKorisnika(Iform, rezervacija));
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            PonudeRepozitory.RezervacijaBlokirana(Iform, rezervacija.ID);
            KorisnikRepository.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), "Korisnik " + Iform.autentifikator.AktivanKorisnik + " je otkazao rezervaciju " + rezervacija.ID + " na količinu " + rezervacija.Kolicina +" kod ponude " + rezervacija.Ime, 13);
            //openChildForm(new OcijeniKorisnika(Iform));
            List<string> email = new List<string>();
            email.Add(KorisnikRepository.DohvatiEmailKorisnika(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik)));
            email.Add(KorisnikRepository.DohvatiEmailKorisnika(IDKupca));
            Mail mail = new Mail(email);
            mail.Text = "Poštovani\nKorisnik " + Iform.autentifikator.AktivanKorisnik + " je otkazao rezervaciju. Molimo ocijenite korisnika!\nLijep pozdrav!";
            mail.Title = "Rezervacija dovršena";
            mail.RequireAutentication = true;
            mail.Send();
            zatvoriForme();
        }
    }
}
