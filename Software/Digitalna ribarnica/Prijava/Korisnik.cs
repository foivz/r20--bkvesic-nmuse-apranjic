using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prijava
{
    public class Korisnik
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorIme { get; set; }

        public string Adresa { get; set; }

        public string Mjesto { get; set; }

        public string BrojMobitela { get; set; }
        public string Lozinka { get; set; }

        public int Tip { get; set; }

        public string Email { get; set; }

        public Korisnik(string korime, string lozinka, int tip, string email)
        {
            KorIme = korime;
            Lozinka = lozinka;
            Tip = tip;
            Email = email;
        }

        public Korisnik(string ime, string prezime, string korime, string adresa, string mjesto, string brojmobitela, string lozinka, string mail, int tip)
        {
            Ime = ime;
            Prezime = prezime;
            KorIme = korime;
            Adresa = adresa;
            Mjesto = mjesto;
            BrojMobitela = brojmobitela;
            Lozinka = lozinka;
            Email = mail;
            Tip = tip;
        }
    }
}
