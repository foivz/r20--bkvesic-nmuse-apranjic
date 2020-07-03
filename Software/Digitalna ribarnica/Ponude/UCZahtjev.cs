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
using Ocjene;

namespace Ponude
{
    public partial class UCZahtjev : UserControl
    {
        private Zahtjev zahtjev = null;
        Iform iform;
        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }

        public int IDKorisnika { get; set; }
        public int IDponude { get; set; }
        public UCZahtjev(Iform novo)
        {
            InitializeComponent();
            iform = novo;
            Trenutna = iform.nova;
            panelStranice = iform.panel;
        }

        public void LoadPonuda(Zahtjev zahtjev)
        {
            this.zahtjev = zahtjev;
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

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new OcjeneKorisnika(iform,zahtjev.IDKORISNIKA));
        }

        private void button3_Click(object sender, EventArgs e)
        {

            UrediPonudu form = Application.OpenForms.OfType<UrediPonudu>().FirstOrDefault();
            if (form != null)
                form.zatvoriForme();
        }

        private void ucOdbaci_Click(object sender, EventArgs e)
        {
            PonudeRepozitory.OdbaciZahtjev(iform, zahtjev.ID);
            zatvoriForme();
        }

        public void zatvoriForme()
        {
            FormCollection fc = Application.OpenForms;
            List<Form> aktivne = new List<Form>();
            foreach (Form frm in fc)
            {
                if (frm.Name != "formPocetna" && frm.Name!= "PregledPonuda")
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

        private void ucPrihvati_Click(object sender, EventArgs e)
        {
            PonudeRepozitory.OdbaciZahtjev(iform, zahtjev.ID);
            PonudeRepozitory.KreirajRezervaciju(iform, zahtjev, zahtjev.IDPONUDE);
            PonudeRepozitory.AzurirajPonuduKolicine(iform, zahtjev, zahtjev.IDPONUDE);
            zatvoriForme();
        }
    }
}
