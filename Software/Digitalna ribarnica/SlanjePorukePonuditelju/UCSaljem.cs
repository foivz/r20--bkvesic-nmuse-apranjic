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

namespace SlanjePorukePonuditelju
{
    public partial class UCSaljem : UserControl
    {
        Iform Iform;
        private Poruka poruka = null;
        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }

        public int IDkorisnika { get; set; }
        public UCSaljem(Iform iform)
        {
            InitializeComponent();
            Iform = iform;
            Trenutna = Iform.nova;
            panelStranice = Iform.panel;
        }


        public void LoadPonuda(Poruka poruka)
        {
            this.poruka = poruka;
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
    }
}
