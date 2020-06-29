using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ponude;
using Lokacije;
namespace Digitalna_ribarnica
{
    public partial class PregledPonuda : Form
    {
        public List<Ponuda> ponude = new List<Ponuda>();
        public PregledPonuda()
        {
            InitializeComponent();
            ponude = PonudeRepozitory.DohvatiPonude();
            DodajPonude(ponude);
        }

        private void txtFiltriraj_TextChanged(object sender, EventArgs e)
        {
            List<Ponuda> svePonude = PonudeRepozitory.DohvatiPonude();
            string filter = txtFiltriraj.Text.ToLower();
            double broj = 0;
            if (filter != null)
            {
                if (double.TryParse(filter, out broj))
                {
                    var result = from ponude in svePonude
                                 where ponude.Cijena==broj || ponude.Kolicina==broj || ponude.ID==filter
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result);
                }
                else
                {
                    var result = from ponude in svePonude
                                 where ponude.Naziv.ToLower().Contains(filter) || ponude.Ime.ToLower().Contains(filter) || ponude.Lokacija.ToLower().Contains(filter) || ponude.Mjerna.ToLower().Contains(filter)
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result);
                }

            }
            else
            {
                var result = from ponude in svePonude
                             select ponude;
                ObrisiPonude();
                DodajPonude(result);
            }
        }

        private void DodajPonude(IEnumerable<Ponuda> ponude)
        {
            foreach (var item in ponude)
            {
                Ponuda ponuda = new Ponuda();
                ponuda.ID = item.ID;
                ponuda.Kolicina = item.Kolicina;
                ponuda.Mjerna = item.Mjerna;
                ponuda.Naziv = item.Naziv;
                ponuda.Fotografija = item.Fotografija;
                ponuda.Cijena = item.Cijena;
                ponuda.Ime = item.Ime;
                ponuda.Lokacija = item.Lokacija;
                this.flowLayoutPanel1.Controls.Add(ponuda.PrikazUC);
                this.Controls.Remove(ponuda.PrikazUC);
            }
        }

        private void ObrisiPonude()
        {
            List<int> index = new List<int>();
            int brojac = 0;
            foreach (UCPonuda item in flowLayoutPanel1.Controls)
            {
               index.Add(flowLayoutPanel1.Controls.GetChildIndex(item));
            }

            foreach (var item in index)
            {
                flowLayoutPanel1.Controls.RemoveAt(item - brojac);
                brojac++;
            }
        }

        private void btnSortiraj_Click(object sender, EventArgs e)
        {
            List<Ponuda> svePonude = PonudeRepozitory.DohvatiPonude();
            string lokacije = cmbLokacije.SelectedItem.ToString();
            double cijenaMin = -1;
            double cijenaMax = -1;
            bool radioButtonAscending = radioButton1.Checked;
            bool radioButtonDescending = radioButton2.Checked;
            if (txtMin.Text != "")
                cijenaMin = double.Parse(txtMin.Text);
            if (txtMax.Text != "")
                cijenaMax = double.Parse(txtMax.Text);
            if(lokacije!=null && cijenaMax!=-1 && cijenaMin!=-1)
            {
                if (radioButtonAscending && lokacije!="Sve lokacije")
                {
                    var result = from ponude in svePonude
                                 where ponude.Lokacija == lokacije && ponude.Cijena >= cijenaMin && ponude.Cijena <= cijenaMax
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result);
                }
                else if(lokacije=="Sve lokacije" && radioButtonAscending)
                {
                    var result = from ponude in svePonude
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result);
                }
                else if(lokacije == "Sve lokacije" && radioButtonDescending)
                {
                    var result = from ponude in svePonude
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result);
                }
                else
                {
                    var result = from ponude in svePonude
                                 where ponude.Lokacija == lokacije && ponude.Cijena >= cijenaMin && ponude.Cijena <= cijenaMax
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result);
                }
            }
            else if(lokacije!=null && (cijenaMin==-1 || cijenaMax==-1))
            {
                if (radioButtonAscending && lokacije!="Sve lokacije")
                {
                    var result = from ponude in svePonude
                                 where ponude.Lokacija == lokacije
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result);
                }
                else if (lokacije == "Sve lokacije" && radioButtonAscending)
                {
                    var result = from ponude in svePonude
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result);
                }
                else if (lokacije == "Sve lokacije" && radioButtonDescending)
                {
                    var result = from ponude in svePonude
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result);
                }
                else
                {
                    var result = from ponude in svePonude
                                 where ponude.Lokacija == lokacije
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result);
                }
            }
        }

        private void PregledPonuda_Load(object sender, EventArgs e)
        {
            List<Lokacije.Lokacije> lokacije = new List<Lokacije.Lokacije>();
            lokacije.Add(new Lokacije.Lokacije("Sve lokacije"));    
            foreach (var item in LokacijeRepozitory.dohvatiLokacije())
            {
                lokacije.Add(item);
            }
          
            cmbLokacije.DataSource = lokacije;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                radioButton1.Checked = false;
        }
    }
}
