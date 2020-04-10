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

        public string Lozinka { get; set; }

        public Korisnik(string ime, string lozinka)
        {
            Ime = ime;
            Lozinka = lozinka;
        }
    }
}
