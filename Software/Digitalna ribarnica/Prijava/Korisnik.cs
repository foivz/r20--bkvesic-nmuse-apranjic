using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prijava
{
    public class Korisnik
    {
        public string KorIme { get; set; }

        public string Lozinka { get; set; }

        public int Tip { get; set; }

        public Korisnik(string korime, string lozinka, int tip)
        {
            KorIme = korime;
            Lozinka = lozinka;
            Tip = tip;
        }
    }
}
