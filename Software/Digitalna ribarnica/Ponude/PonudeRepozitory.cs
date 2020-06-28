using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza;
namespace Ponude
{
    public class PonudeRepozitory
    {
        public static List<Ponuda> _ponude = new List<Ponuda>();
        public static List<Ponuda> DohvatiPonude()
        {

            _ponude.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select ponude.*, ribe.mjerna_jedinica, ribe.naziv, ribe.slika from ponude, ribe WHERE ponude.id_riba=ribe.id_riba AND ponude.status=1");
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
                Ponuda ponuda = new Ponuda();

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
                _ponude.Add(ponuda);
            }
            rezultat.Close();
            return _ponude;
        }
    }
}
