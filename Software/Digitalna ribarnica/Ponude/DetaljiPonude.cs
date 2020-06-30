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
    public partial class DetaljiPonude : Form
    {
        Ponuda Ponuda;
        public DetaljiPonude(Ponuda ponuda)
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
        }


    }
}
