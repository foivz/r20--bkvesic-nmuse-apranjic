using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digitalna_ribarnica
{
    public partial class formPocetna : Form
    {

        public formPocetna()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = true;
            buttonOdjava.Visible = false;
            buttonNovosti.Visible = false;
        }
        public Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelStranice.Controls.Add(childForm);
            panelStranice.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            formPocetna pocetna = new formPocetna();
            this.Hide();
            Prijava prijava = new Prijava();
            prijava.ShowDialog();
            pocetna.ShowDialog();
            */
            labelOdjava.Visible = false;
            openChildForm(new Prijava(lblUsername,button1,buttonOdjava,buttonNovosti));
        }

        private void buttonOdjava_Click(object sender, EventArgs e)
        {
            lblUsername.Text = "";
            labelOdjava.Text = "Uspješno ste se odjavili";
            labelOdjava.AutoSize = true;
            labelOdjava.Visible = true;
            button1.Visible = true;
            buttonOdjava.Visible = false;
            buttonNovosti.Visible = false;

        }
    }
}
