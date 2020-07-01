using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prijava;
using INSform;
using Baza;
namespace Ponude
{
    public partial class DetaljiPonude : Form
    {
        Ponuda Ponuda;
        Iform iform;
        public DetaljiPonude(Ponuda ponuda, Iform novo)
        {
            InitializeComponent();
            Ponuda = ponuda;
            pbxSlika.Image = Ponuda.Fotografija;
            ucNaziv.Text = Ponuda.Naziv;
            ucMjerna.Text = Ponuda.Mjerna;
            ucLokacija.Text = Ponuda.Lokacija;
            ucKolicina.Text = Ponuda.Kolicina.ToString();
            ucCijena.Text = Ponuda.Cijena.ToString();
            ucPonuditelj.Text = Ponuda.Ime;
            rtbxOpis.Text = PonudeRepozitory.DohvatiOpisPonude(int.Parse(Ponuda.ID));
            iform = novo;
        }

        private void DetaljiPonude_Load(object sender, EventArgs e)
        {
            if(iform.autentifikator.AktivanKorisnik!=null)
            {
                hSbKolicina.Visible = true;
                txtKolicina.Visible = true;
                buttonRezerviraj.Visible = true;
                hSbKolicina.Maximum = Ponuda.Kolicina+9;
                hSbKolicina.Minimum = 1;
                hSbKolicina.Value = 1;
                txtKolicina.Text = hSbKolicina.Value.ToString();
                hSbKolicina.SmallChange = 1;
            }
            else
            {
                hSbKolicina.Visible = false;
                txtKolicina.Visible = false;
                buttonRezerviraj.Visible = false;
            }
            
        }

        private void hSbKolicina_ValueChanged(object sender, EventArgs e)
        {
            this.txtKolicina.Multiline = true;
            this.txtKolicina.WordWrap = false;
            this.txtKolicina.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            txtKolicina.Text = hSbKolicina.Value.ToString();
        }

        private void buttonRezerviraj_Click(object sender, EventArgs e)
        {
            if ((PonudeRepozitory.ProvjeriKorisnikaIZahtjev(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), int.Parse(Ponuda.ID))) == 0)
            {
                PonudeRepozitory.UnesiZahtjevZaRezervaciju(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), int.Parse(Ponuda.ID), int.Parse(txtKolicina.Text));
                notifyRezerviraj.ShowBalloonTip(1000, "Zahtjev za rezervacijom", "Uspješno ste kreirali zahtjev za rezervacijom", ToolTipIcon.Info);
            } 
            else
            {
                PonudeRepozitory.AzurirajZahtjev(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), int.Parse(Ponuda.ID), int.Parse(txtKolicina.Text));
                notifyRezerviraj.ShowBalloonTip(1000, "Zahtjev za rezervacijom", "Uspješno ste ažurirali zahtjev za rezervacijom", ToolTipIcon.Info);
            }
            Close();
        }
    }
}
