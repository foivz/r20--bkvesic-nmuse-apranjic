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
namespace Ocjene
{
    public partial class UCOcjena : UserControl
    {
        private Ocjena ocjena = null;
        INSform.Iform Iform;

        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }
        public UCOcjena(INSform.Iform nova)
        {
            InitializeComponent();
            Iform = nova;
            Trenutna = Iform.nova;
            panelStranice = Iform.panel;
        }

        public void LoadPonuda(Ocjena ocjena)
        {
            this.ocjena = ocjena;
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
