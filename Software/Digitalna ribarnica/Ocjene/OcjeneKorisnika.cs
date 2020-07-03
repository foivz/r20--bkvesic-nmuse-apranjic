using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INSform;
using Prijava;
namespace Ocjene
{
    public partial class OcjeneKorisnika : Form
    {
        public List<Ocjena> ocjene = new List<Ocjena>();
        Iform Iform;
        public OcjeneKorisnika(Iform nova,int id)
        {
            InitializeComponent();
            Iform = nova;
            //ocjene = OcjeneRepozitory.DohvatiOcjene(nova,KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
            ocjene = OcjeneRepozitory.DohvatiOcjene(nova, id);
            ObrisiPonude();
            DodajPonude(ocjene, nova);
        }


        private void DodajPonude(IEnumerable<Ocjena> ocjene, Iform iform)
        {
            foreach (var item in ocjene)
            {
                Ocjena ocjena = new Ocjena(Iform);
                ocjena.Komentar = item.Komentar;
                ocjena.Ocjenaa = item.Ocjenaa;
                ocjena.ID = item.ID;
                ocjena.Profilna = item.Profilna;
                ocjena.SlikaOcjene = item.SlikaOcjene;
                this.flowLayoutPanel1.Controls.Add(ocjena.PrikazUC);
                this.Controls.Remove(ocjena.PrikazUC);
            }
        }


        private void ObrisiPonude()
        {
            List<int> index = new List<int>();
            int brojac = 0;
            foreach (UCOcjena item in flowLayoutPanel1.Controls)
            {
                index.Add(flowLayoutPanel1.Controls.GetChildIndex(item));
            }

            foreach (var item in index)
            {
                flowLayoutPanel1.Controls.RemoveAt(item - brojac);
                brojac++;
            }
        }
    }
}
