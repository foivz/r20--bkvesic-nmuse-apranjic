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
        public OcjeneKorisnika(Iform nova)
        {
            InitializeComponent();
            Iform = nova;
            ocjene = OcjeneRepozitory.DohvatiOcjene(nova,KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
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
    }
}
