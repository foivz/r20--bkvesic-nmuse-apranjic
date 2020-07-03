using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza;
using INSform;
namespace Ponude
{
    public class PonudeRepozitory
    {
        public static List<Ponuda> _ponude = new List<Ponuda>();

        public static List<Zahtjev> _zahtjevi = new List<Zahtjev>();
        static Iform Iform;
        public static List<Ponuda> DohvatiPonude(Iform nova)
        {
            Iform = nova;
            _ponude.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader("select ponude.*, ribe.mjerna_jedinica, ribe.naziv, ribe.slika, lokacije.naziv AS lokacija, korisnici.ime, korisnici.prezime from ponude, ribe, lokacije, korisnici WHERE ponude.id_riba = ribe.id_riba AND ponude.id_lokacija = lokacije.id_lokacija AND ponude.id_korisnik = korisnici.id_korisnik AND ponude.status = 1");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            foreach (var item in returnMe)
            {
                
                Ponuda ponuda = new Ponuda(nova);

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["dodatna_fotografija"]);
                    ponuda.Fotografija = Image.FromStream(ms);
                }
                catch (Exception)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                        ponuda.Fotografija = Image.FromStream(ms);
                    }
                    catch (Exception)
                    {
                        ponuda.Fotografija = null;
                    }
                }

                ponuda.ID = item["id_ponuda"].ToString();
                ponuda.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    ponuda.Mjerna = "kg";
                else
                    ponuda.Mjerna = "kom";
                ponuda.Kolicina = int.Parse(item["kolicina"].ToString());
                ponuda.Cijena = float.Parse(item["cijena"].ToString());
                ponuda.Ime = item["ime"] + " " + item["prezime"];
                ponuda.Lokacija = item["lokacija"].ToString();
                ponuda.IDKORISNIKA = int.Parse(item["id_korisnik"].ToString());
              
                _ponude.Add(ponuda);
            }
            if(rezultat!=null)
                rezultat.Close();
            return _ponude;
        }


        public static List<Ponuda> DohvatiPonudePoID(Iform nova,int id)
        {
            Iform = nova;
            _ponude.Clear();
            System.Data.SqlClient.SqlDataReader rezultat = null;
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            if (id!=-1)
                rezultat = DB.Instance.DohvatiDataReader($"select ponude.*, ribe.mjerna_jedinica, ribe.naziv, ribe.slika, lokacije.naziv AS lokacija, korisnici.ime, korisnici.prezime from ponude, ribe, lokacije, korisnici WHERE ponude.id_riba = ribe.id_riba AND ponude.id_lokacija = lokacije.id_lokacija AND ponude.id_korisnik = korisnici.id_korisnik AND ponude.status = 1 AND korisnici.id_korisnik={id}");
            else
                rezultat = DB.Instance.DohvatiDataReader($"select ponude.*, ribe.mjerna_jedinica, ribe.naziv, ribe.slika, lokacije.naziv AS lokacija, korisnici.ime, korisnici.prezime from ponude, ribe, lokacije, korisnici WHERE ponude.id_riba = ribe.id_riba AND ponude.id_lokacija = lokacije.id_lokacija AND ponude.id_korisnik = korisnici.id_korisnik AND ponude.status = 1");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            foreach (var item in returnMe)
            {

                Ponuda ponuda = new Ponuda(nova);

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["dodatna_fotografija"]);
                    ponuda.Fotografija = Image.FromStream(ms);
                }
                catch (Exception)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                        ponuda.Fotografija = Image.FromStream(ms);
                    }
                    catch (Exception)
                    {
                        ponuda.Fotografija = null;
                    }
                }

                ponuda.ID = item["id_ponuda"].ToString();
                ponuda.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    ponuda.Mjerna = "kg";
                else
                    ponuda.Mjerna = "kom";
                ponuda.Kolicina = int.Parse(item["kolicina"].ToString());
                ponuda.Cijena = float.Parse(item["cijena"].ToString());
                ponuda.Ime = item["ime"] + " " + item["prezime"];
                ponuda.Lokacija = item["lokacija"].ToString();
                _ponude.Add(ponuda);
            }
            if (rezultat != null)
                rezultat.Close();
            return _ponude;
        }


        public static string DohvatiOpisPonude(int id)
        {
            var rezultat = DB.Instance.DohvatiDataReader($"select ponude.opis FROM ponude WHERE ponude.id_ponuda={id}");
            string opis="";
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            foreach (DbDataRecord item in rezultat)
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < item.FieldCount; i++)
                {
                    row.Add(item.GetName(i), item[i]);
                }
                returnMe.Add(row);
            }
            foreach (var item in returnMe)
            {
                opis = item["opis"].ToString();
            }
            rezultat.Close();
            return opis;
        }


        public static void UnesiZahtjevZaRezervaciju(int idKorisnika, int idPonuda, int kolicina)
        {
            string sqlUpit = "";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@idKorisnika", idKorisnika);
            parameters.Add("@idponuda", idPonuda);
            parameters.Add("@kolicina", kolicina);
            parameters.Add("@datum", DateTime.Now);
            DB.Instance.ExecuteParamQuery("INSERT INTO [zahtjevi] ([id_korisnik], [id_ponuda], [kolicina], [datum_vrijeme]) VALUES((@idKorisnika), (@idponuda), (@kolicina), (@datum));", parameters);
        }

        public static void ObrisiPonudu(int id)
        {
            string sqlUpit = $"DELETE FROM ponude WHERE id_ponuda={id};";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }

        public static int ProvjeriKorisnikaIZahtjev(int idKorisnika, int idPonuda)
        {
            int id = 0;
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat=DB.Instance.DohvatiDataReader($"SELECT * FROM zahtjevi WHERE id_korisnik='{idKorisnika}' AND id_ponuda='{idPonuda}';");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }

            foreach (var item in returnMe)
            {
                id= int.Parse(item["id_zahtjev"].ToString());
            }
            rezultat.Close();
            return id;
        }


        public static void AzurirajZahtjev(int idKorisnika, int idPonuda, int kolicina)
        {
            string sqlUpit = "";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@idKorisnika", idKorisnika);
            parameters.Add("@idponuda", idPonuda);
            parameters.Add("@kolicina", kolicina);
            parameters.Add("@datum", DateTime.Now);
            parameters.Add("@status", 1);
            DB.Instance.ExecuteParamQuery("UPDATE [zahtjevi] SET [kolicina] = (@kolicina), datum_vrijeme = (@datum), status = (@status) WHERE [id_korisnik] = (@idKorisnika) AND [id_ponuda] = (@idponuda);", parameters);
        }

        public static List<Zahtjev> DohvatiZahtjeve(Iform nova,int id)
        {
            Iform = nova;
            _zahtjevi.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT zahtjevi.id_korisnik,zahtjevi.id_ponuda, korisnici.slika, korisnici.ime, korisnici.prezime, zahtjevi.kolicina, ponude.kolicina AS MAX, ponude.trajanje_rezervacije_u_satima, zahtjevi.id_zahtjev FROM korisnici, zahtjevi, ponude WHERE korisnici.id_korisnik = zahtjevi.id_korisnik AND ponude.id_ponuda = zahtjevi.id_ponuda AND ponude.id_ponuda = {id} AND zahtjevi.status = 1 AND ponude.status = 1");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            foreach (var item in returnMe)
            {

                Zahtjev zahtjev = new Zahtjev(nova);

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    zahtjev.Fotografija = Image.FromStream(ms);
                }
                catch (Exception)
                {
                    zahtjev.Fotografija = null;
                }
                zahtjev.IDKORISNIKA =int.Parse(item["id_korisnik"].ToString());
                zahtjev.Ime = item["ime"] + " " + item["prezime"];
                zahtjev.Kolicina = int.Parse(item["kolicina"].ToString());
                zahtjev.Max = item["MAX"].ToString();
                zahtjev.BrojSatiDana = item["trajanje_rezervacije_u_satima"].ToString();
                zahtjev.ID = int.Parse(item["id_zahtjev"].ToString());
                zahtjev.IDPONUDE= int.Parse(item["id_ponuda"].ToString());
                _zahtjevi.Add(zahtjev);
            }
            if (rezultat != null)
                rezultat.Close();
            return _zahtjevi;
        }

        public static void AzurirajZahtjeveNakonBrisanja(Iform nova,int id)
        {
            string sqlUpit = $"UPDATE zahtjevi set status = 0 WHERE id_ponuda={id};";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }

        public static void OdbaciZahtjev(Iform nova, int id)
        {
            string sqlUpit = $"UPDATE zahtjevi set status = 0 WHERE id_zahtjev={id};";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        public static void KreirajRezervaciju(Iform nova, Zahtjev zahtjev,int idPonude)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@datum", DateTime.Now.AddHours(double.Parse(zahtjev.BrojSatiDana)));
            parameters.Add("@kolicina", zahtjev.Kolicina);
            parameters.Add("@idKupca", zahtjev.IDKORISNIKA);
            parameters.Add("@idPonude", idPonude);
            parameters.Add("@tip", 1);
            DB.Instance.ExecuteParamQuery("INSERT INTO [rezervacije]([datum_i_vrijeme], [kolicina], [id_kupac], [id_ponuda], [id_tip_statusa]) VALUES((@datum), (@kolicina), (@idKupca), (@idPonude), (@tip)); ", parameters);
        }

        public static void AzurirajPonuduKolicine(Iform nova, Zahtjev zahtjev, int idPonude)
        {
            string sqlUpit = $"UPDATE ponude SET kolicina=kolicina-{zahtjev.Kolicina} WHERE id_ponuda={idPonude};";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }

        public static void ObrisiZahtjev(Iform nova, Zahtjev zahtjev)
        {
            string sqlUpit = $"delete from zahtjevi where id_zahtjev={zahtjev.ID}";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }


    }


}
