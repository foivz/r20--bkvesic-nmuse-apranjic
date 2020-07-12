using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prijava
{
    public class Autentifikator
    {
        public List<Korisnik> registriraniKorisnici { get; set; }
        private Korisnik korisnik;
        public string AktivanKorisnik { get; set; }
        public int prijavljen { get; set; } = 0;
        public Autentifikator()
        {

            registriraniKorisnici = new List<Korisnik>();
            /*
            registriraniKorisnici.Add(new Korisnik("bkvesic", "12345",1, "bozo.kvesic1@gmail.com"));
            registriraniKorisnici.Add(new Korisnik("nmuse", "12345",2,"nmuse@foi.hr"));
            registriraniKorisnici.Add(new Korisnik("apranjic", "12345",3,"apranjic@foi.hr"));
            */
            registriraniKorisnici.Clear();
            registriraniKorisnici = KorisnikRepository.DohvatiSveKorisnike();
        }

        /// <summary>
        /// Ovdje dohvaćamo korisnika, odnosno provjeravamo postojanje korisničkog imena u bazi
        /// </summary>
        /// <param name="ime"></param>
        /// <returns></returns>

        private Korisnik dohvatiKorisnika(string ime)
        {
            //PROVJERA KORISNIKA 
            registriraniKorisnici.Clear();
            registriraniKorisnici = KorisnikRepository.DohvatiSveKorisnike();
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
                /*
                if (korisnik.Lozinka != lozinka && korisnik.KorIme == ime)
                    return false;
                else
                    return true;
                */
                return BCrypt.Net.BCrypt.Verify(lozinka, korisnik.Lozinka);
            }
            return false;
           
        }

        public int tipKorisnika(string ime)
        {
            return registriraniKorisnici.Find(p => p.KorIme == ime).Tip;
        }

        public Korisnik findKorisnik(string email)
        {
            return registriraniKorisnici.Find(p => p.Email == email);
        }

        public void postojiEmail(string email)
        {
            if(!registriraniKorisnici.Exists(p => p.Email == email))
                throw new PrijavaException("Korisnik s tim mailom ne postoji u bazi registriranih korisnika");
        }

        public void NePostojiEmail(string email)
        {
            if (registriraniKorisnici.Exists(p => p.Email == email))
                throw new PrijavaException("Korisnik s tim mailom je već registriran!");
        }

        /*
        public void DodajKorisnika(string korime, string lozinka, string email)
        {
                registriraniKorisnici.Add(new Korisnik(korime, lozinka, 3,email));
        }
        */
        public void DodajKorisnika(string ime, string prezime, string korime, string adresa, string mjesto, string brojmobitela, string lozinka, string mail)
        {
            registriraniKorisnici.Add(new Korisnik(ime, prezime, korime, adresa, mjesto, brojmobitela, lozinka, mail, 3));
        }
       
        public void provjeriKorisnika(string korime)
        {
            if (korime.Length<5 || korime.Length>15)
                throw new PrijavaException("Korisničko ime treba sadržavati između 5 i 15 znakova");
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
