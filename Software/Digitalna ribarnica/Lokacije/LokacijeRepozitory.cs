using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza;
namespace Lokacije
{
    public class LokacijeRepozitory
    {
        public static List<Lokacije> _lokacije { get; set; }
        public static List<Lokacije> dohvatiLokacije()
        {
            _lokacije = new List<Lokacije>();
            _lokacije.Clear();
            string sqlUpit= $"SELECT * FROM lokacije;";
            SqlDataReader rezultat = DB.Instance.DohvatiDataReader(sqlUpit);
            if (rezultat != null)
            {
                while (rezultat.Read())
                {
                    Lokacije lokacija = new Lokacije();
                    lokacija.id = int.Parse(rezultat["id_lokacija"].ToString());
                    lokacija.Naziv = rezultat["naziv"].ToString();
                    _lokacije.Add(lokacija);

                }

                rezultat.Close();
            }
            return _lokacije;
        }

        public static void dodajLokacij(string naziv)
        {
            DB.Instance.IzvrsiUpit($"INSERT INTO lokacije (naziv) VALUES ('{naziv}');");
        }

        public static void obrisiLokaciju(Lokacije lokacije)
        {
            DB.Instance.IzvrsiUpit($"DELETE FROM lokacije WHERE id_lokacija = '{lokacije.id}'; ");
        }

        public static void azurirajLokaciju(Lokacije lokacije,string naziv)
        {
            DB.Instance.IzvrsiUpit($"UPDATE lokacije SET naziv='{naziv}' WHERE id_lokacija='{lokacije.id}';");
        }
    }
}
