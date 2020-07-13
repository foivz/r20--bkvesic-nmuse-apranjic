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
using Prijava;
using SlanjePorukePonuditelju;
using Ocjene;

namespace Ponude
{
    public partial class UCPonuda : UserControl
    {
        private Ponuda ponuda = null;
        Iform Iform;

        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }

        public int IDkorisnika { get; set; }
        public UCPonuda(Iform novo)
        {
            InitializeComponent();
            Iform = novo;
            Trenutna = Iform.nova;
            panelStranice = Iform.panel;
        }

        public void LoadPonuda(Ponuda ponuda)
        {
            this.ponuda = ponuda;
 
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

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            openChildForm(new DetaljiPonude(ponuda, Iform));
        }

        private void btnKontaktirajKupca_Click(object sender, EventArgs e)
        {
            openChildForm(new SlanjePorukePonuditelju.SlanjePorukePonuditelju(Iform,IDkorisnika));
        }

        private void ucPogledajOcjene_Click(object sender, EventArgs e)
        {
            openChildForm(new OcjeneKorisnika(Iform, IDkorisnika));
        }
    }
}
