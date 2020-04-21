using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prijava
{
    public class Autentifikator
    {
        List<Korisnik> registriraniKorisnici;
        private Korisnik korisnik;

        public Autentifikator()
        {
            registriraniKorisnici = new List<Korisnik>();
            registriraniKorisnici.Add(new Korisnik("bkvesic", "12345",1));
            registriraniKorisnici.Add(new Korisnik("nmuse", "12345",2));
            registriraniKorisnici.Add(new Korisnik("apranjic", "12345",3));
        }

        /// <summary>
        /// Ovdje dohvaćamo korisnika, odnosno provjeravamo postojanje korisničkog imena u bazi
        /// </summary>
        /// <param name="ime"></param>
        /// <returns></returns>

        private Korisnik dohvatiKorisnika(string ime)
        {
            //Ovdje treba dodati čitanje iz tablice "Korisnici" kada se Baza podataka napravi
            if (!registriraniKorisnici.Exists(p => p.Ime == ime))
            {
                return null;
            }
            else
            {
                foreach (Korisnik pojedinikorisnik in registriraniKorisnici)
                {
                    if (pojedinikorisnik.Ime == ime)
                    {
                        korisnik = pojedinikorisnik;
                        break;
                    }
                }
            }
            return korisnik;
        }

        /// <summary>
        /// Ova funkcija provjerava ispravnost unesenih podataka za korisnika, te vraća True ako je uspješna prijava, odnosno false ako nije
        /// </summary>
        /// <param name="ime"></param>
        /// <param name="lozinka"></param>
        /// <returns></returns>
        public bool prijava(string ime, string lozinka)
        {
            if (dohvatiKorisnika(ime) != null)
            {
                if (korisnik.Lozinka != lozinka && korisnik.Ime == ime)
                    return false;
                else
                    return true;
            }
            return false;
        }

        public int tipKorisnika(string ime)
        {
            return registriraniKorisnici.Find(p => p.Ime == ime).Tip;
        }


    }
}
