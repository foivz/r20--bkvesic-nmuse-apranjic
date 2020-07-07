using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INSform;

namespace Ponude
{
    public partial class UCRezevacija : UserControl
    {
        private Rezervacija rezervacija = null;
        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }
        public int IDKupca { get; set; }
        Iform Iform;
        public UCRezevacija(Iform novo)
        {
            InitializeComponent();
            Iform = novo;
            Trenutna = Iform.nova;
            panelStranice = Iform.panel;
        }

        public void LoadPonuda(Rezervacija rezervacija)
        {
            this.rezervacija = rezervacija;
        }

        public void openChildForm(Form childForm)
        {
            if (Trenutna != null)
                Trenutna.Close();
            Trenutna = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelStranice.Controls.Add(childForm);
            panelStranice.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void zatvoriForme()
        {
            FormCollection fc = Application.OpenForms;
            List<Form> aktivne = new List<Form>();
            foreach (Form frm in fc)
            {
                if (frm.Name != "formPocetna")
                {
                    //frm.Close();
                    aktivne.Add(frm);
                }
            }

            foreach (var item in aktivne)
            {
                item.Close();
            }
        }

        private void btnPreuzeto_Click(object sender, EventArgs e)
        {
            PonudeRepozitory.RezervacijaDovrsena(Iform, rezervacija.ID);
            //zatvoriForme();
            openChildForm(new OcijeniKorisnika(Iform,rezervacija));
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            PonudeRepozitory.RezervacijaBlokirana(Iform, rezervacija.ID);
            //zatvoriForme();
            //openChildForm(new OcijeniKorisnika(Iform));
        }
    }
}
