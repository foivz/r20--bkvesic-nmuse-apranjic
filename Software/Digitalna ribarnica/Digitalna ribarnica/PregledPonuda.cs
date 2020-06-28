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
namespace Digitalna_ribarnica
{
    public partial class PregledPonuda : Form
    {
        public List<Ponuda> ponude = new List<Ponuda>();
        public PregledPonuda()
        {
            InitializeComponent();
            /*
            this.Controls.Add(artikl.PrikazUC);
            artikl.PrikazUC.Location = new Point(460, 225);
            
            this.flowLayoutPanel1.Controls.Add(artikl.PrikazUC);
            this.Controls.Remove(artikl.PrikazUC);

            Ponuda novi = new Ponuda();
            novi.Naziv = "Druga";
            this.flowLayoutPanel1.Controls.Add(novi.PrikazUC);
            this.Controls.Remove(novi.PrikazUC);

            Ponuda novi1 = new Ponuda();
            novi1.Naziv = "Treca";
            this.flowLayoutPanel1.Controls.Add(novi1.PrikazUC);
            this.Controls.Remove(novi1.PrikazUC);
            Ponuda novi2 = new Ponuda();
            novi2.Naziv = "4";
            this.flowLayoutPanel1.Controls.Add(novi2.PrikazUC);
            this.Controls.Remove(novi2.PrikazUC);

            Ponuda novi3 = new Ponuda();
            novi3.Naziv = "5";
            this.flowLayoutPanel1.Controls.Add(novi3.PrikazUC);
            this.Controls.Remove(novi3.PrikazUC);
            Ponuda novi4 = new Ponuda();
            novi4.Naziv = "6";
            this.flowLayoutPanel1.Controls.Add(novi4.PrikazUC);
            this.Controls.Remove(novi4.PrikazUC);
            Ponuda novi5 = new Ponuda();
            novi5.Naziv = "7";
            this.flowLayoutPanel1.Controls.Add(novi5.PrikazUC);
            this.Controls.Remove(novi5.PrikazUC);
            Ponuda novi6 = new Ponuda();
            novi6.Naziv = "8";
            this.flowLayoutPanel1.Controls.Add(novi6.PrikazUC);
            this.Controls.Remove(novi6.PrikazUC);
            Ponuda novi7 = new Ponuda();
            novi7.Naziv = "9";
            this.flowLayoutPanel1.Controls.Add(novi7.PrikazUC);
            this.Controls.Remove(novi7.PrikazUC);
            */
            ponude = PonudeRepozitory.DohvatiPonude();
            foreach (var item in ponude)
            {
                Ponuda ponuda = new Ponuda();
                ponuda.ID = item.ID;
                ponuda.Kolicina = item.Kolicina;
                ponuda.Mjerna = item.Mjerna;
                ponuda.Naziv = item.Naziv;
                ponuda.Fotografija = item.Fotografija;
                ponuda.Cijena = item.Cijena;
                this.flowLayoutPanel1.Controls.Add(ponuda.PrikazUC);
                this.Controls.Remove(ponuda.PrikazUC);
            }
        }
    }
}
