﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INSform;
using Prijava;
using Ponude;
namespace Chat
{
    public partial class Chat : Form
    {
        Iform Iform;
        List<Korisnik> korisnici = new List<Korisnik>();
        int IDPrimatelja = 0;
        public Chat(Iform iform)
        {
            InitializeComponent();
            Iform = iform;
            ObrisiKontake();
            korisnici = KorisnikRepository.DohvatiSveKorisnike();
            Korisnik aktivan = new Korisnik();
            foreach (var item in korisnici)
            {
                if (item.KorIme == Iform.autentifikator.AktivanKorisnik)
                    aktivan = item;

            }
            korisnici.Remove(aktivan);
            DodajKorisnika(korisnici, Iform);

        }

        private void DodajKorisnika(IEnumerable<Korisnik> korisnici, Iform iform)
        {
            foreach (var item in korisnici)
            {
                User user = new User(Iform);
                user.IDKORISNIKA = item.ID;
                user.Naziv = item.Ime + " " + item.Prezime;
                user.Profilna = KorisnikRepository.DohvatiProfilnu(item.ID);
                user.Status = KorisnikRepository.DohvatiSlikuStatusa(item.Status);
                this.flowLayoutPanel1.Controls.Add(user.PrikazUC);
                this.Controls.Remove(user.PrikazUC);
            }
        }

        private void ObrisiKontake()
        {
            List<int> index = new List<int>();
            int brojac = 0;
            foreach (UCKorisnik item in flowLayoutPanel1.Controls)
            {
                index.Add(flowLayoutPanel1.Controls.GetChildIndex(item));
            }

            foreach (var item in index)
            {
                flowLayoutPanel1.Controls.RemoveAt(item - brojac);
                brojac++;
            }
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
            int Posiljatelj =KorisnikRepository.DohvatiIdKorisnika( Iform.autentifikator.AktivanKorisnik);
            lblNaziv.Text = KorisnikRepository.DohvatiKorisnikaPoIDU(idPrimatelja).Ime + " " + KorisnikRepository.DohvatiKorisnikaPoIDU(idPrimatelja).Prezime;
            ObrisiPoruke();
            DodajPoruke(ChatRepository.DohvatiPoruke(Posiljatelj, idPrimatelja), Iform);
            lblSadrzajPoruke.Visible = true;
            btnSalji.Visible = true;
            this.IDPrimatelja = idPrimatelja;
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            lblSadrzajPoruke.Visible = false;
            btnSalji.Visible = false;
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
                mail.Title = "Poslali ste korisniku "+ korisnik1.Ime + " " + korisnik1.Prezime +" poruku!";
                mail.Text = lblSadrzajPoruke.Text;
                mail.RequireAutentication = true;
                mail.Send();
                if(ChatRepository.DohvatiRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik)) != -1)
                {
                    int IDRazgovora=ChatRepository.DohvatiRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
                    ChatRepository.UnesiPoruku(lblSadrzajPoruke.Text, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik),IDRazgovora);
                }
                else
                {
                    ChatRepository.DodajRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
                    int IDRazgovora=ChatRepository.DohvatiRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
                    ChatRepository.UnesiPoruku(lblSadrzajPoruke.Text, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), IDRazgovora);
                }
                lblSadrzajPoruke.Text = "";
                PrikaziPorukue(IDPrimatelja);
            }
            else
                notifyIcon1.ShowBalloonTip(1000, "Chat", "Ne možemo poslati praznu poruku", ToolTipIcon.Warning);
        }
    }
}