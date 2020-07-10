﻿using INSform;
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

namespace Ponude
{
    public partial class OdobreneRezervacije : Form
    {
        List<Rezervacija> rezervacije = new List<Rezervacija>();
        Iform Iform;
        public OdobreneRezervacije(Iform Iform)
        {
            InitializeComponent();
            ObrisiRezervacije();
            this.Iform = Iform;
            rezervacije = PonudeRepozitory.DohvatiOdobreneRezervacije(Iform, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
            DodajPonude(rezervacije, Iform);
        }


        private void DodajPonude(IEnumerable<Rezervacija> rezervacije, Iform iform)
        {
            foreach (var item in rezervacije)
            {
                Rezervacija rezervacija = new Rezervacija(iform);
                rezervacija.ID = item.ID;
                rezervacija.Kolicina = item.Kolicina;
                rezervacija.Mjerna = item.Mjerna;
                rezervacija.Naziv = item.Naziv;
                rezervacija.Fotografija = item.Fotografija;
                rezervacija.Cijena = item.Cijena;
                rezervacija.Ime = item.Ime;
                rezervacija.Lokacija = item.Lokacija;
                rezervacija.Kupac = "Kupac";
                rezervacija.GotovaRezervacija();
                rezervacija.IDkupca = item.IDkupca;
                this.flowLayoutPanel1.Controls.Add(rezervacija.PrikazUC);
                this.Controls.Remove(rezervacija.PrikazUC);
            }
        }

        private void ObrisiRezervacije()
        {
            List<int> index = new List<int>();
            int brojac = 0;
            foreach (UCRezevacija item in flowLayoutPanel1.Controls)
            {
                index.Add(flowLayoutPanel1.Controls.GetChildIndex(item));
            }

            foreach (var item in index)
            {
                flowLayoutPanel1.Controls.RemoveAt(item - brojac);
                brojac++;
            }
        }
    }
}