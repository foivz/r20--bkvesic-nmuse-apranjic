﻿using System;
using System.Collections.Generic;
using System.Data.Common;
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
            if (dr != null)
            {
                while (dr.Read())
                {
                    Korisnik korisnik = DohvatiKorisnika(dr);
                    lista.Add(korisnik);
                }
                dr.Close();     //DataReader treba obavezno zatvoriti nakon uporabe.
            }
            return lista;
        }

        public static Image DohvatiProfilnu(int id)
        {
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT * FROM korisnici WHERE id_korisnik='{id}';");
            foreach (DbDataRecord item in rezultat)
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < item.FieldCount; i++)
                {
                    row.Add(item.GetName(i), item[i]);
                }
                returnMe.Add(row);
            }
            Image image = null;
            foreach (var item in returnMe)
            {
                if (item["slika"].ToString() != "")
                {
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    image = Image.FromStream(ms);
                }
            }
            rezultat.Close();
            return image;
        }

        public static int DohvatiIdKorisnika(string korime)
        {
            int id = 0;
            string sqlUpit = $"SELECT id_korisnik FROM korisnici WHERE korisnicko_ime='{korime}';";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlUpit);
            if (dr != null)
            {
                while (dr.Read())
                {
                    id = int.Parse(dr["id_korisnik"].ToString());
                }
                dr.Close(); 
            }
            return id;
        }

        public static string DohvatiEmailKorisnika(int id)
        {
            string emailKorisnika = "";
            string sqlUpit = $"SELECT email FROM korisnici WHERE id_korisnik='{id}';";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlUpit);
            if (dr != null)
            {
                while (dr.Read())
                {
                    emailKorisnika = (dr["email"].ToString());
                }
                dr.Close();
            }
            return emailKorisnika;
        }

        public static Korisnik DohvatiKorisnikaPoIDU(int id)
        {
            Korisnik korisnik = new Korisnik();
            string sqlUpit = $"select * from korisnici where id_korisnik='{id}';";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlUpit);
            if (dr != null)
            {
                while (dr.Read())
                {
                    korisnik = DohvatiKorisnika(dr);
                }
                dr.Close();
            }
            return korisnik;
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
            string sqlDelete = "DELETE FROM korisnici WHERE id_korisnik = " + korisnik.ID;
            return DB.Instance.IzvrsiUpit(sqlDelete);
        }

        public static int BlokirajKorisnika(int id, int uloga)
        {
            string sqlUpit = $"update korisnici set id_tip_korisnika='{uloga}' where id_korisnik='{id}'; ";
            return DB.Instance.IzvrsiUpit(sqlUpit);
        }
    }
}
