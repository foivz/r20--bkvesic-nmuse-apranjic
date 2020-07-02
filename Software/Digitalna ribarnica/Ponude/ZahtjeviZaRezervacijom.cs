using INSform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponude
{
    public partial class ZahtjeviZaRezervacijom : Form
    {
        public List<Zahtjev> zahtjevi = new List<Zahtjev>();
        Iform Iform;
        Ponuda ponuda;
        public ZahtjeviZaRezervacijom(Iform novi,Ponuda ponuda)
        {
            InitializeComponent();
            zahtjevi = PonudeRepozitory.DohvatiZahtjeve(novi,int.Parse(ponuda.ID));
            DodajPonude(zahtjevi, novi);
            Iform = novi;
            this.ponuda = ponuda;
        }


        private void DodajPonude(IEnumerable<Zahtjev> zahtjevi, Iform iform)
        {
            foreach (var item in zahtjevi)
            {
                Zahtjev zahtjev = new Zahtjev(iform);
                zahtjev.ID = item.ID;
                zahtjev.Ime = item.Ime;
                zahtjev.Kolicina = item.Kolicina;
                zahtjev.Max = item.Max;
                zahtjev.Fotografija = item.Fotografija;
                zahtjev.BrojSatiDana = item.BrojSatiDana;
                this.flowLayoutPanel1.Controls.Add(zahtjev.PrikazUC);
                this.Controls.Remove(zahtjev.PrikazUC);
            }
        }
    }
}
