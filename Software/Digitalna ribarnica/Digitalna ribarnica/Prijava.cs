using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Prijava;

namespace Digitalna_ribarnica
{
    public partial class Prijava : Form
    {
        public Label label_prijava;
        public Button prijava_prijava;
        public Button odjava_prijava;
        public Button novosti;
        public Prijava()
        {
            InitializeComponent();
        }

        public Prijava(Label label,Button prijava, Button odjava,Button novosti)
        {
            InitializeComponent();
            label_prijava = label;
            prijava_prijava = prijava;
            odjava_prijava = odjava;
            this.novosti = novosti;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPrijavi_Click(object sender, EventArgs e)
        {
            if(txtKorIme.TextLength!=0 && txtLozinka.TextLength != 0)
            {
                Autentifikator autentifikator = new Autentifikator();
                if (autentifikator.prijava(txtKorIme.Text, txtLozinka.Text))
                {

                    switch (autentifikator.tipKorisnika(txtKorIme.Text))
                    {
                        case 1:
                            MessageBox.Show("Uspješna prijava ADMIN");
                            label_prijava.Text = "Dobro došli " + txtKorIme.Text;
                            prijava_prijava.Visible = false;
                            odjava_prijava.Visible = true;
                            novosti.Visible = true;
                            Close();
                            break;
                        case 2:
                            MessageBox.Show("Uspješna prijava KORISNIK");
                            label_prijava.Text = "Dobro došli " + txtKorIme.Text;
                            prijava_prijava.Visible = false;
                            odjava_prijava.Visible = true;
                            novosti.Visible = true;
                            Close();
                            break;
                        case 3:
                            MessageBox.Show("Uspješna prijava KUPAC");
                            label_prijava.Text = "Dobro došli " + txtKorIme.Text;
                            prijava_prijava.Visible = false;
                            odjava_prijava.Visible = true;
                            novosti.Visible = true;
                            Close();
                            break;
                        default:
                            MessageBox.Show("Blokiran račun");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Pogrešna lozinka ili korisničko ime");
                }
            }
            else {
                MessageBox.Show("Ostavili ste prazno polje");
            }
            
        }
        private void labelRegistracija_Click(object sender, EventArgs e)
        {
            /*
            //this.Hide();
            Registracija registracija = new Registracija();   
            registracija.ShowDialog();
            */
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                form.openChildForm(new Registracija());
            }
        }

        private void Prijava_Load(object sender, EventArgs e)
        {
            txtLozinka.PasswordChar = '\u25CF';
            
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                labelCapsLock.Text = "Uključeno je pisanje VELIKIM SLOVIMA!";
                labelCapsLock.Visible = true;
            }
            else
            {
                labelCapsLock.Visible = false;
            }
            
        }

        private void txtKorIme_KeyUp(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                labelCapsLock.Text = "Uključeno je pisanje VELIKIM SLOVIMA!";
                labelCapsLock.Visible = true;
            }
            else
            {
                labelCapsLock.Visible = false;
            }
        }

        private void txtLozinka_KeyUp(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                labelCapsLock.Text = "Uključeno je pisanje VELIKIM SLOVIMA!";
                labelCapsLock.Visible = true;
            }
            else
            {
                labelCapsLock.Visible = false;
            }
        }
    }
}
