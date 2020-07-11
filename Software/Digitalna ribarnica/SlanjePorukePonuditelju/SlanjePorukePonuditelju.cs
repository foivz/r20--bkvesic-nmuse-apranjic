using INSform;
using Ponude;
using Prijava;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlanjePorukePonuditelju
{
    public partial class SlanjePorukePonuditelju : Form
    {
        Iform Iform;
        public int IDPonuditelja { get; set; }
        int IDPrimatelja = 0;
        
        public SlanjePorukePonuditelju(Iform novo, int IDponuditelja)
        {
            InitializeComponent();
            Iform = novo;
            IDPonuditelja = IDponuditelja;
        }

        private void SlanjePorukePonuditelju_Load(object sender, EventArgs e)
        {
            lblNaziv.Text = KorisnikRepository.DohvatiKorisnikaPoIDU(IDPonuditelja).Ime + " " + KorisnikRepository.DohvatiKorisnikaPoIDU(IDPonuditelja).Prezime;
            PrikaziPorukue(IDPonuditelja);
        }

        public void ObrisiPoruke()
        {
            flowLayoutPanel2.Controls.Clear();
        }

        private void DodajPoruke(IEnumerable<PorukeIzBaze> poruke, Iform iform)
        {
            foreach (var item in poruke)
            {
                bool zastava;
                Poruka poruka;
                if (item.ID == KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik))
                {
                    poruka = new Poruka(iform, -1);
                    zastava = true;
                }
                else
                {
                    poruka = new Poruka(iform, 0);
                    zastava = false;
                }
                poruka.IDKORISNIKA = item.ID;
                poruka.Opis = item.sadrzaj;
                poruka.Datum = item.datum;
                poruka.Profilna = KorisnikRepository.DohvatiProfilnu(item.ID);
                if (zastava)
                {
                    this.flowLayoutPanel2.Controls.Add(poruka.PrikazUC);
                    this.Controls.Remove(poruka.PrikazUC);
                }
                else
                {
                    this.flowLayoutPanel2.Controls.Add(poruka.SaljemUC);
                    this.Controls.Remove(poruka.SaljemUC);
                }
            }
        }

        public void PrikaziPorukue(int idPrimatelja)
        {
            int Posiljatelj = KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik);
            lblNaziv.Text = KorisnikRepository.DohvatiKorisnikaPoIDU(idPrimatelja).Ime + " " + KorisnikRepository.DohvatiKorisnikaPoIDU(idPrimatelja).Prezime;
            ObrisiPoruke();
            DodajPoruke(PorukeRepository.DohvatiPoruke(Posiljatelj, idPrimatelja), Iform);
            lblSadrzajPoruke.Visible = true;
            btnSalji.Visible = true;
            this.IDPrimatelja = idPrimatelja;
        }

        private void btnSalji_Click(object sender, EventArgs e)
        {
            if (lblSadrzajPoruke.Text != "")
            {
                List<string> mailovi = new List<string>();
                mailovi.Add(KorisnikRepository.DohvatiEmailKorisnika(IDPrimatelja));
                Mail mail = new Mail(mailovi);
                Korisnik korisnik = KorisnikRepository.DohvatiKorisnikaPoIDU(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
                mail.Title = "Korisnik " + korisnik.Ime + " " + korisnik.Prezime + " Vam šalje poruku!";
                mail.Text = lblSadrzajPoruke.Text;
                mail.RequireAutentication = true;
                mail.Send();
                mailovi.Clear();
                mailovi.Add(KorisnikRepository.DohvatiEmailKorisnika(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik)));
                Mail mail1 = new Mail(mailovi);
                Korisnik korisnik1 = KorisnikRepository.DohvatiKorisnikaPoIDU(IDPrimatelja);
                mail.Title = "Poslali ste korisniku " + korisnik1.Ime + " " + korisnik1.Prezime + " poruku!";
                mail.Text = lblSadrzajPoruke.Text;
                mail.RequireAutentication = true;
                mail.Send();
                if (PorukeRepository.DohvatiRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik)) != -1)
                {
                    int IDRazgovora = PorukeRepository.DohvatiRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
                    PorukeRepository.UnesiPoruku(lblSadrzajPoruke.Text, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), IDRazgovora);
                }
                else
                {
                    PorukeRepository.DodajRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
                    int IDRazgovora = PorukeRepository.DohvatiRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
                    PorukeRepository.UnesiPoruku(lblSadrzajPoruke.Text, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), IDRazgovora);
                }
                lblSadrzajPoruke.Text = "";
                PrikaziPorukue(IDPrimatelja);
            }
            else
                notifyIcon1.ShowBalloonTip(1000, "Chat", "Ne možemo poslati praznu poruku", ToolTipIcon.Warning);
        }
    }
}
