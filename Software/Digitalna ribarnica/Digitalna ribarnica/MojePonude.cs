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
using Ponude;
using Prijava;
namespace Digitalna_ribarnica
{
    public partial class MojePonude : Form
    {
        public List<Ponuda> ponude = new List<Ponuda>();
        Iform Iform;
        public MojePonude(Iform novi)
        {
            InitializeComponent();
            if(novi.autentifikator.tipKorisnika(novi.autentifikator.AktivanKorisnik)==1)
                ponude= PonudeRepozitory.DohvatiPonudePoID(novi, -1);
            else
                ponude = PonudeRepozitory.DohvatiPonudePoID(novi, KorisnikRepository.DohvatiIdKorisnika(novi.autentifikator.AktivanKorisnik));
            DodajPonude(ponude, novi);
            Iform = novi;
        }


        private void DodajPonude(IEnumerable<Ponuda> ponude, Iform iform)
        {
            foreach (var item in ponude)
            {
                Ponuda ponuda = new Ponuda(iform,0);
                ponuda.ID = item.ID;
                ponuda.Kolicina = item.Kolicina;
                ponuda.Mjerna = item.Mjerna;
                ponuda.Naziv = item.Naziv;
                ponuda.Fotografija = item.Fotografija;
                ponuda.Cijena = item.Cijena;
                ponuda.Ime = item.Ime;
                ponuda.Lokacija = item.Lokacija;
                this.flowLayoutPanel1.Controls.Add(ponuda.PrikaziUrediPonudeUC);
                this.Controls.Remove(ponuda.PrikaziUrediPonudeUC);
            }
        }

        private void MojePonude_Load(object sender, EventArgs e)
        {
        }
    }
}
