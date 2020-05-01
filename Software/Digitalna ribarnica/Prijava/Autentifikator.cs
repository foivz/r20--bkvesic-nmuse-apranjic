using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prijava
{
    public class Autentifikator
    {
        public List<Korisnik> registriraniKorisnici { get; set; }
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
            if (!registriraniKorisnici.Exists(p => p.KorIme == ime))
            {
                return null;
            }
            else
            {
                foreach (Korisnik pojedinikorisnik in registriraniKorisnici)
                {
                    if (pojedinikorisnik.KorIme == ime)
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
                if (korisnik.Lozinka != lozinka && korisnik.KorIme == ime)
                    return false;
                else
                    return true;
            }
            return false;
        }

        public int tipKorisnika(string ime)
        {
            return registriraniKorisnici.Find(p => p.KorIme == ime).Tip;
        }


        public void DodajKorisnika(string korime, string lozinka)
        {
                registriraniKorisnici.Add(new Korisnik(korime, lozinka, 3));
        }

       
        public void provjeriKorisnika(string korime)
        {
            if (korime.Length<5 || korime.Length>9)
                throw new PrijavaException("Korisničko ime treba sadržavati između 5 i 9 znakova");
        }
        public void provjeriKorisnika1(string korime)
        {
            if (dohvatiKorisnika(korime) != null)
                throw new PrijavaException("Korisnik s tim korisničkim imenom postoji");
        }


        public void provjeriKorisnika2(string korime)
        {
            if(!(korime.Contains('0') || korime.Contains('1')|| korime.Contains('2')|| korime.Contains('3')|| korime.Contains('4')|| korime.Contains('5')|| korime.Contains('6') || korime.Contains('7')|| korime.Contains('8') || korime.Contains('9')) || !korime.Any(x => char.IsLetter(x)))
                 throw new PrijavaException("Korisničko ime treba sadržavati barem jedno slovo i jedan broj!");
        }

    }
}
