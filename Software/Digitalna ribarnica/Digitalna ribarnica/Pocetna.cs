﻿using System;
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
using INSform;
namespace Digitalna_ribarnica
{
    public partial class formPocetna : Form, Iform
    {
        public Autentifikator autentifikator { get; set; }
        public Form nova { get; set; }
        public Panel panel { get; set; }
        public Form activeForm = null;
        bool podizbronik = true;

        bool podizbornikPonude = true;
        bool podizbornikPonude1 = true;
        public formPocetna()
        {
            InitializeComponent();
            autentifikator = new Autentifikator();
            nova = activeForm;
            panel = panelStranice;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = true;
            buttonOdjava.Visible = false;
            buttonRegistracija.Visible = true;
            buttonNovosti.Visible = false;
            Profilna.Visible = false;
            pbxProfilna.Visible = false;
            pbxLogo.Visible = true;
            btnRibe.Visible = false;
            btnLokacija.Visible = false;
            buttonOdjava.ForeColor = Color.FromArgb(4, 136, 133);
            panel7.Visible = false;
            btnMojePonude.Visible = false;
            btnMojeRezervacije.Visible = false;
            btnOdobrene.Visible = false;
        }
     

    

        public void openChildForm(Form childForm)
        {
            if (nova != null)
                nova.Close();
            nova = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel.Controls.Add(childForm);
            panel.Tag = childForm;
            childForm.BringToFront();
            if(childForm!=null)
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
            zatvoriForme();
            labelOdjava.Visible = false;
            openChildForm(new Prijava(lblUsername,button1,buttonOdjava,buttonNovosti,buttonRegistracija,autentifikator,Profilna,pbxProfilna,btnRibe,btnLokacija,btnMojeRezervacije,btnMojePonude,btnOdobrene));
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
            btnRibe.Visible = false;
            btnLokacija.Visible = false;
            btnMojePonude.Visible = false;
            btnMojeRezervacije.Visible = false;
            btnOdobrene.Visible = false;
            //openChildForm(new Prijava(lblUsername, button1, buttonOdjava, buttonNovosti, buttonRegistracija, autentifikator, Profilna,pbxProfilna));
            if (activeForm != null)
                activeForm.Close();
            autentifikator.AktivanKorisnik = null;
            zatvoriForme();

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
            zatvoriForme();
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

        private void btnRibe_Click(object sender, EventArgs e)
        {
            openChildForm(new RibeUSustavu());
        }

        private void btnLokacija_Click(object sender, EventArgs e)
        {
            openChildForm(new DodajLokacije());
        }

        private void buttonPonude_Click(object sender, EventArgs e)
        {
            openChildForm(new PregledPonuda(this));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (podizbornikPonude)
            {
                panel7.Visible = true;
                podizbornikPonude = false;
            }
            else
            {
                panel7.Visible = false;
                podizbornikPonude = true;
            }
        }

        private void btnMojePonude_Click(object sender, EventArgs e)
        {
            openChildForm(new MojePonude(this));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zatvoriForme();
        }

        private void btnMojeRezervacije_Click(object sender, EventArgs e)
        {
            openChildForm(new Ponude.MojeRezervacije(this));
        }

        private void buttonNovosti_Click(object sender, EventArgs e)
        {

        }

        private void btnOdobrene_Click(object sender, EventArgs e)
        {
            openChildForm(new Ponude.OdobreneRezervacije(this));
        }
    }
}
