﻿using System;
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
    public partial class UCUrediPonude : UserControl
    {
        private Ponuda ponuda = null;
        Iform Iform;

        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }
        public int IDKorisnika { get; set; }
        public UCUrediPonude(Iform nova)
        {
            InitializeComponent();
            Iform = nova;
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
            openChildForm(new UrediPonudu(ponuda, Iform));
        }
    }
}