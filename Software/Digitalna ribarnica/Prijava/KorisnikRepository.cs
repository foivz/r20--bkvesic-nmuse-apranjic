using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza;
namespace Prijava
{
    public class KorisnikRepository
    {
        
        public static Korisnik DohvatiKorisnika(SqlDataReader dr)
        {
            Korisnik korisnik = null;
            if (dr != null)
            {
                korisnik = new Korisnik();
                korisnik.ID = int.Parse(dr["id_korisnik"].ToString());
                korisnik.Ime = dr["ime"].ToString();
                korisnik.Prezime = dr["prezime"].ToString();
                korisnik.Email = dr["email"].ToString();
                korisnik.KorIme = dr["korisnicko_ime"].ToString();
                korisnik.BrojMobitela = dr["broj_mobitela"].ToString();
                if(dr["datum_rodenja"].ToString()!="")
                    korisnik.DatumRodenja = DateTime.Parse(dr["datum_rodenja"].ToString());
                korisnik.Lozinka = dr["lozinka"].ToString();
                korisnik.Adresa = dr["adresa"].ToString();
                korisnik.Mjesto = dr["mjesto"].ToString();
                korisnik.Tip = int.Parse(dr["id_tip_korisnika"].ToString());
                korisnik.Status = int.Parse(dr["id_status"].ToString());      
            }
            return korisnik;
        }


        public static List<Korisnik> DohvatiSveKorisnike()
        {
            List<Korisnik> lista = new List<Korisnik>();
            string sqlUpit = $"SELECT * FROM korisnici";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlUpit);
            while (dr.Read())
            {
                Korisnik korisnik = DohvatiKorisnika(dr);
                lista.Add(korisnik);
            }
            dr.Close();     //DataReader treba obavezno zatvoriti nakon uporabe.
            return lista;
        }
        

        public static int Spremi(Korisnik korisnik)
        {
            string sqlUpit = "";
            if (korisnik.ID == 0)
            {
                sqlUpit = $"INSERT INTO korisnici(ime, prezime, email, korisnicko_ime, broj_mobitela, datum_rodenja, lozinka, mjesto, slika, id_tip_korisnika, id_status) VALUES('{korisnik.Ime}', '{korisnik.Prezime}', '{korisnik.Email}', '{korisnik.KorIme}', '{korisnik.BrojMobitela}', NULL, '{korisnik.Lozinka}', '{korisnik.Mjesto}', NULL,2, 2); ";
            }
            int insertUBazu= DB.Instance.IzvrsiUpit(sqlUpit);
            return insertUBazu;
        }

        public static int PromjeniLozinku(string lozinka,string email)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(lozinka, BCrypt.Net.BCrypt.GenerateSalt(12));
            string sqlUpit = $"UPDATE korisnici SET lozinka = '{hash}' WHERE email = '{email}'; ";
            return DB.Instance.IzvrsiUpit(sqlUpit);
        }

        public static int Obrisi(Korisnik korisnik)
        {
            string sqlDelete = "DELETE FROM korisnici WHERE Id = " + korisnik.ID;
            return DB.Instance.IzvrsiUpit(sqlDelete);
        }
    }
}
