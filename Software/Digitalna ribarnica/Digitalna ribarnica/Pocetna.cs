using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Prijava;
using Baza;
namespace Digitalna_ribarnica
{
    public partial class formPocetna : Form
    {
        Autentifikator autentifikator;
        

        public formPocetna()
        {
            InitializeComponent();
            autentifikator = new Autentifikator();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = true;
            buttonOdjava.Visible = false;
            buttonRegistracija.Visible = true;
            buttonNovosti.Visible = false;
            Profilna.Visible = false;
            pbxProfilna.Visible = false;        
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
            openChildForm(new Prijava(lblUsername,button1,buttonOdjava,buttonNovosti,buttonRegistracija,autentifikator,Profilna,pbxProfilna));
        }

        private void buttonOdjava_Click(object sender, EventArgs e)
        {
            lblUsername.Text = "";
            labelOdjava.Text = "Uspješno ste se odjavili";   
            labelOdjava.AutoSize = true;
            labelOdjava.Visible = true;
            button1.Visible = true;
            buttonOdjava.Visible = false;
            buttonRegistracija.Visible = true;
            buttonNovosti.Visible = false;
            Profilna.Visible = false;
            pbxProfilna.Visible = false;
            //openChildForm(new Prijava(lblUsername, button1, buttonOdjava, buttonNovosti, buttonRegistracija, autentifikator, Profilna,pbxProfilna));
        }

        private void timerPocetna_Tick(object sender, EventArgs e)
        {
            labelOdjava.Visible = false;
            timerPocetna.Stop();
        }

        private void buttonInstagram_Click(object sender, EventArgs e)
        {
            Process.Start("www.instagram.com/instagram/?hl=hr");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("www.facebook.com");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("www.twitter.com");
        }

        private void buttonRegistracija_Click(object sender, EventArgs e)
        {
            openChildForm(new Registracija(autentifikator));
        }

        private void labelOdjava_VisibleChanged(object sender, EventArgs e)
        {
            if (labelOdjava.Visible == true)
            {
                timerPocetna.Interval = 5000;
                timerPocetna.Enabled = true;
            }
        }

        private void formPocetna_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Instance.CloseConnection();
            //MessageBox.Show("Konekcija na bazu zatvorena!");
        }

        private void Profilna_Click(object sender, EventArgs e)
        {
            openChildForm(new Profil(autentifikator,pbxProfilna));
        }
    }
}
