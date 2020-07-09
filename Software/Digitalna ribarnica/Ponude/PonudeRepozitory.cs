using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
        public static List<Rezervacija> _rezervacije = new List<Rezervacija>();
        public static List<Rezervacija> _rezervacije1 = new List<Rezervacija>();
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
            if (rezultat != null)
                rezultat.Close();
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
                if (DohvatiSlikuZnackePonuditelja(ponuda.IDKORISNIKA) != null)
                    ponuda.Znacka = DohvatiSlikuZnackePonuditelja(ponuda.IDKORISNIKA);
                _ponude.Add(ponuda);
            }
          
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
            if (rezultat != null)
                rezultat.Close();
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
                if (DohvatiSlikuZnackePonuditelja(int.Parse(item["id_korisnik"].ToString())) != null)
                    ponuda.Znacka = DohvatiSlikuZnackePonuditelja(int.Parse(item["id_korisnik"].ToString()));
                _ponude.Add(ponuda);
            }
           
            return _ponude;
        }

        public static Image DohvatiSlikuZnackePonuditelja(int id)
        {
            Image znacka = null;
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select slikeZnackePonuditelj.slika from slikeZnackePonuditelj, korisnici, imaju_znacku_ponuditelj where slikeZnackePonuditelj.id_Znacke = imaju_znacku_ponuditelj.id_znacke and imaju_znacku_ponuditelj.id_korisnik = korisnici.id_korisnik and korisnici.id_korisnik = {id}");
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

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    znacka = Image.FromStream(ms);
                }
                catch (Exception)
                {
                    znacka = null;
                }

            }
            if (rezultat != null)
                rezultat.Close();
            return znacka;
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

        public static PonudeIzvjesca DohvatiPonuduIzvjesca(int id)
        {
            var rezultat = $"select ribe.naziv, ribe.mjerna_jedinica, ponude.cijena from ribe, ponude where ponude.id_ponuda = {id} and ponude.id_riba=ribe.id_riba";
            PonudeIzvjesca ponuda=null;
            SqlDataReader dr = DB.Instance.DohvatiDataReader(rezultat);
            if (dr != null)
            {
                while (dr.Read())
                {
                    string mjerna = "";
                    string naziv = (dr["naziv"].ToString());
                    if (dr["mjerna_jedinica"].ToString() == "1")
                        mjerna = "kom";
                    else
                        mjerna = "kg";
                    double cijena = double.Parse(dr["cijena"].ToString());
                    ponuda = new PonudeIzvjesca(naziv, cijena, mjerna);
                }
                dr.Close();
            }
            dr.Close();
            return ponuda;
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

        public static void IDRezervacijeZaProvjeruRoka()
        {
            var rezultat = DB.Instance.DohvatiDataReader($"select id_rezervacija FROM rezervacije");
            int id = 0;
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
            rezultat.Close();
            foreach (var item in returnMe)
            {
                id =int.Parse(item["id_rezervacija"].ToString());
                ProvjeriRokRezervacija(id);
            }
          
        }

        private static void ProvjeriRokRezervacija(int id)
        {
            string sqlUpit = $"update rezervacije set kolicina=kolicina+0 where id_rezervacija={id};";
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
            if (rezultat != null)
                rezultat.Close();
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
                if (DohvatiSlikuZnackeKupca(zahtjev.IDKORISNIKA) != null)
                    zahtjev.Znacka = DohvatiSlikuZnackeKupca(zahtjev.IDKORISNIKA);
                _zahtjevi.Add(zahtjev);
            }
       
            return _zahtjevi;
        }

        public static Image DohvatiSlikuZnackeKupca(int id)
        {
            Image znacka = null;
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select slikeZnackeKupac.slika from slikeZnackeKupac, korisnici, imaju_znacku_kupac where slikeZnackeKupac.id_Znacke = imaju_znacku_kupac.id_znacke and imaju_znacku_kupac.id_korisnik = korisnici.id_korisnik and korisnici.id_korisnik = {id}");
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

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    znacka = Image.FromStream(ms);
                }
                catch (Exception)
                {
                    znacka = null;
                }

            }
            if (rezultat != null)
                rezultat.Close();
            return znacka;
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

        public static List<Rezervacija> DohvatiRezervacije(Iform nova,int id)
        {
            Iform = nova;
            _rezervacije.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select ribe.*,ponude.cijena, rezervacije.id_rezervacija, korisnici.ime, korisnici.prezime, lokacije.naziv as lokacija, ponude.dodatna_fotografija, rezervacije.kolicina from rezervacije, ribe, korisnici, lokacije, ponude where rezervacije.id_ponuda = ponude.id_ponuda and ponude.id_korisnik = korisnici.id_korisnik and rezervacije.id_kupac = {id} and ponude.id_lokacija = lokacije.id_lokacija and ponude.id_riba = ribe.id_riba and rezervacije.id_tip_statusa=1");
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

                Rezervacija rezervacija = new Rezervacija(nova);

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["dodatna_fotografija"]);
                    rezervacija.Fotografija = Image.FromStream(ms);
                }
                catch (Exception)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                        rezervacija.Fotografija = Image.FromStream(ms);
                    }
                    catch (Exception)
                    {
                        rezervacija.Fotografija = null;
                    }
                }

                rezervacija.ID = int.Parse(item["id_rezervacija"].ToString());
                rezervacija.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    rezervacija.Mjerna = "kg";
                else
                    rezervacija.Mjerna = "kom";
                rezervacija.Kolicina = int.Parse(item["kolicina"].ToString());
                rezervacija.Cijena = float.Parse(item["cijena"].ToString());
                rezervacija.Ime = item["ime"] + " " + item["prezime"];
                rezervacija.Lokacija = item["lokacija"].ToString();
                _rezervacije.Add(rezervacija);
            }
            if (rezultat != null)
                rezultat.Close();
            return _rezervacije;
        }

        public static List<Rezervacija> DohvatiOdobreneRezervacije(Iform nova, int id)
        {
            Iform = nova;
            _rezervacije.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select  ribe.*, rezervacije.id_rezervacija,korisnici.id_korisnik, korisnici.ime, korisnici.prezime, lokacije.naziv as lokacija, ponude.dodatna_fotografija, rezervacije.kolicina, ponude.cijena from rezervacije, ribe, korisnici, lokacije, ponude where korisnici.id_korisnik = rezervacije.id_kupac and rezervacije.id_ponuda = ponude.id_ponuda and ponude.id_korisnik = {id} and ponude.id_lokacija = lokacije.id_lokacija and ponude.id_riba = ribe.id_riba and rezervacije.id_tip_statusa=1");
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

                Rezervacija rezervacija = new Rezervacija(nova);

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["dodatna_fotografija"]);
                    rezervacija.Fotografija = Image.FromStream(ms);
                }
                catch (Exception)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                        rezervacija.Fotografija = Image.FromStream(ms);
                    }
                    catch (Exception)
                    {
                        rezervacija.Fotografija = null;
                    }
                }

                rezervacija.ID = int.Parse(item["id_rezervacija"].ToString());
                rezervacija.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    rezervacija.Mjerna = "kg";
                else
                    rezervacija.Mjerna = "kom";
                rezervacija.Kolicina = int.Parse(item["kolicina"].ToString());
                rezervacija.Cijena = float.Parse(item["cijena"].ToString());
                rezervacija.Ime = item["ime"] + " " + item["prezime"];
                rezervacija.Lokacija = item["lokacija"].ToString();
                rezervacija.IDkupca =int.Parse( item["id_korisnik"].ToString());
                _rezervacije.Add(rezervacija);
            }
            if (rezultat != null)
                rezultat.Close();
            return _rezervacije;
        }

        public static List<Rezervacija> GotoveRezervacije(Iform nova, int id)
        {
            Iform = nova;
            _rezervacije.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select ribe.naziv, ribe.mjerna_jedinica,rezervacije.datum_i_vrijeme, rezervacije.id_rezervacija, korisnici.id_korisnik, korisnici.ime, korisnici.prezime, lokacije.naziv as lokacija, rezervacije.kolicina, ponude.cijena, rezervacije.id_tip_statusa from rezervacije, ribe, korisnici, lokacije, ponude where korisnici.id_korisnik = rezervacije.id_kupac and rezervacije.id_ponuda = ponude.id_ponuda and ponude.id_korisnik = {id} and ponude.id_lokacija = lokacije.id_lokacija and ponude.id_riba = ribe.id_riba and(rezervacije.id_tip_statusa = 2 or rezervacije.id_tip_statusa = 3 or rezervacije.id_tip_statusa = 4)");
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

                Rezervacija rezervacija = new Rezervacija(nova);

                rezervacija.ID = int.Parse(item["id_rezervacija"].ToString());
                rezervacija.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    rezervacija.Mjerna = "kg";
                else
                    rezervacija.Mjerna = "kom";
                rezervacija.Kolicina = int.Parse(item["kolicina"].ToString());
                rezervacija.Cijena = float.Parse(item["cijena"].ToString());
                rezervacija.Ime = item["ime"] + " " + item["prezime"];
                rezervacija.Lokacija = item["lokacija"].ToString();
                rezervacija.IDkupca = int.Parse(item["id_korisnik"].ToString());
                rezervacija.Datum = DateTime.Parse(item["datum_i_vrijeme"].ToString());
                _rezervacije.Add(rezervacija);
            }
            if (rezultat != null)
                rezultat.Close();
            return _rezervacije;
        }

        public static List<Rezervacija> GotoveRezeracijePonuditelj(Iform nova, int id)
        {
            Iform = nova;
            _rezervacije1.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select ribe.naziv, ribe.mjerna_jedinica,rezervacije.datum_i_vrijeme, rezervacije.id_rezervacija,korisnici.id_korisnik, korisnici.ime, korisnici.prezime, lokacije.naziv as lokacija, ponude.dodatna_fotografija, ponude.cijena, rezervacije.kolicina, rezervacije.id_tip_statusa from rezervacije, ribe, korisnici, lokacije, ponude where rezervacije.id_ponuda = ponude.id_ponuda and ponude.id_korisnik = korisnici.id_korisnik and rezervacije.id_kupac = {id} and ponude.id_lokacija = lokacije.id_lokacija and ponude.id_riba = ribe.id_riba and(rezervacije.id_tip_statusa = 2 or rezervacije.id_tip_statusa = 3 or rezervacije.id_tip_statusa = 4)");
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

                Rezervacija rezervacija = new Rezervacija(nova);

                rezervacija.ID = int.Parse(item["id_rezervacija"].ToString());
                rezervacija.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    rezervacija.Mjerna = "kg";
                else
                    rezervacija.Mjerna = "kom";
                rezervacija.Kolicina = int.Parse(item["kolicina"].ToString());
                rezervacija.Cijena = float.Parse(item["cijena"].ToString());
                rezervacija.Ime = item["ime"] + " " + item["prezime"];
                rezervacija.Lokacija = item["lokacija"].ToString();
                rezervacija.IDkupca = int.Parse(item["id_korisnik"].ToString());
                rezervacija.Datum = DateTime.Parse(item["datum_i_vrijeme"].ToString());
                _rezervacije1.Add(rezervacija);
            }
            if (rezultat != null)
                rezultat.Close();
            return _rezervacije1;
        }

        public static void RezervacijaDovrsena(Iform nova, int id)
        {
            string sqlUpit = $"update rezervacije set id_tip_statusa=3 where id_rezervacija={id}";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        public static void RezervacijaBlokirana(Iform nova, int id)
        {
            string sqlUpit = $"update rezervacije set id_tip_statusa=2 where id_rezervacija={id}";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }

        public static void UnesiOcjenu(Iform nova, int ocjena,string komentar, int tkoocjenjuje,int kogaocjenjuje, int idrezervacije)
        {
            string sqlUpit = $"insert into ocjene(ocjena, komentar, tko_ocjenjuje, koga_ocjenjuje, id_rezervacije)values('{ocjena}','{komentar}','{tkoocjenjuje}','{kogaocjenjuje}','{idrezervacije}')";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }

        public static void AzurirajOcjenu(Iform nova, int ocjena, string komentar, int idocjene)
        {
            string sqlUpit = $"update ocjene set ocjena='{ocjena}', komentar='{komentar}' where id_ocjena='{idocjene}'";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }

        public static Ocjena ProvjeriOcjene(Iform nova, int tkoocjenjuje, int kogaocjenjuje, int idrezervacije)
        {
            Ocjena ocjena = new Ocjena();
            ocjena.Id = -1;
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            string sqlUpit = $"select * from ocjene where tko_ocjenjuje='{tkoocjenjuje}' and koga_ocjenjuje='{kogaocjenjuje}' and id_rezervacije='{idrezervacije}';";
            var rezultat = DB.Instance.DohvatiDataReader(sqlUpit);
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
                ocjena.Id = int.Parse(item["id_ocjena"].ToString());
                ocjena.Komentar = item["komentar"].ToString();
                ocjena.ocjena = int.Parse(item["ocjena"].ToString()); 

            }
            if (rezultat != null)
                rezultat.Close();
            return ocjena;
        }

        public static PredefiniranePostavke PredefiniranePostavke()
        {
            PredefiniranePostavke predefiniranePostavke = new PredefiniranePostavke();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            string sqlUpit = $"select * from postavke;";
            var rezultat = DB.Instance.DohvatiDataReader(sqlUpit);
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
                predefiniranePostavke.Cijena = float.Parse(item["min_cijena"].ToString());
                predefiniranePostavke.Kolicina = int.Parse(item["min_kolicina"].ToString());

            }
            if (rezultat != null)
                rezultat.Close();
            return predefiniranePostavke;
        }

        public static void AzurirajPredefirniranePostavke(float cijena, int kolicina)
        {
            string sqlUpit = $"update postavke set min_cijena={cijena}, min_kolicina={kolicina}";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
    }


}
