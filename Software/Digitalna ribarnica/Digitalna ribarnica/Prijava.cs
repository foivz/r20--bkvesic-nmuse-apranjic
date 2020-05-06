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
        public Button Registracija;
        Autentifikator autentifikator;
        //bool focus = false;
        public Prijava()
        {
            InitializeComponent();
        }

        public Prijava(Label label,Button prijava, Button odjava,Button novosti,Button registracija,Autentifikator korisnici)
        {
            InitializeComponent();
            label_prijava = label;
            prijava_prijava = prijava;
            odjava_prijava = odjava;
            this.novosti = novosti;
            Registracija = registracija;
            autentifikator = korisnici;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPrijavi_Click(object sender, EventArgs e)
        {
            if(txtKorIme.TextLength!=0 && txtLozinka.TextLength != 0)
            {
                if (autentifikator.prijava(txtKorIme.Text, txtLozinka.Text))
                {
                    /*
                    if (autentifikator.tipKorisnika(txtKorIme.Text) == 1)
                    {
                        notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava ADMIN", ToolTipIcon.Info);
                    }
                    else if (autentifikator.tipKorisnika(txtKorIme.Text) == 2)
                    {
                        notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava KORISNIK", ToolTipIcon.Info);
                    }
                    else if (autentifikator.tipKorisnika(txtKorIme.Text) == 3)
                    {
                        notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava KUPAC", ToolTipIcon.Info);
                    }
                    else
                    {
                        notifyPrijava.ShowBalloonTip(1000, "Prijava", "Vaš račun je blokiran", ToolTipIcon.Error);
                    }
                    */
                    switch (autentifikator.tipKorisnika(txtKorIme.Text))
                    {
                        case 1:
                            //MessageBox.Show("Uspješna prijava ADMIN");
                            notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava ADMIN", ToolTipIcon.Info);
                            label_prijava.Text = "Dobro došli " + txtKorIme.Text;
                            prijava_prijava.Visible = false;
                            odjava_prijava.Visible = true;
                            novosti.Visible = true;
                            Registracija.Visible = false;
                            Close();
                            break;
                        case 2:
                            //MessageBox.Show("Uspješna prijava KORISNIK");
                            notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava KORISNIK", ToolTipIcon.Info);
                            label_prijava.Text = "Dobro došli " + txtKorIme.Text;
                            prijava_prijava.Visible = false;
                            odjava_prijava.Visible = true;
                            novosti.Visible = true;
                            Registracija.Visible = false;
                            Close();
                            break;
                        case 3:
                            //MessageBox.Show("Uspješna prijava KUPAC");
                            notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava KUPAC", ToolTipIcon.Info);
                            label_prijava.Text = "Dobro došli " + txtKorIme.Text;
                            prijava_prijava.Visible = false;
                            odjava_prijava.Visible = true;
                            novosti.Visible = true;
                            Registracija.Visible = false;
                            Close();
                            break;
                        default:
                            //MessageBox.Show("Blokiran račun");
                            notifyPrijava.ShowBalloonTip(1000, "Prijava", "Vaš račun je blokiran", ToolTipIcon.Error);
                            break;
                    }
                    
                }
                else
                {
                    //MessageBox.Show("Pogrešna lozinka ili korisničko ime");
                    notifyPrijava.ShowBalloonTip(1000, "Prijava", "Pogrešna lozinka ili korisničko ime", ToolTipIcon.Error);
                }
            }
            else {
                notifyPrijava.ShowBalloonTip(1000, "Prijava", "Ostavili ste prazno polje", ToolTipIcon.Error);
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
        
        private void Prijava_Paint(object sender, PaintEventArgs e)
        {
            /*
            if (focus)
            {
                txtKorIme.BorderStyle = BorderStyle.None;
                Pen p = new Pen(Color.Red);
                Graphics g = e.Graphics;
                int variance = 3;
                g.DrawRectangle(p, new Rectangle(txtKorIme.Location.X - variance, txtKorIme.Location.Y - variance, txtKorIme.Width + variance, txtKorIme.Height + variance));
            }
            else
            {
                txtKorIme.BorderStyle = BorderStyle.FixedSingle;
            }
            */
        }

        private void txtKorIme_Enter(object sender, EventArgs e)
        {
            /*
            focus = true;
            this.Refresh();
            */
        }

        private void txtKorIme_Leave(object sender, EventArgs e)
        {
            /*
            focus = false;
            this.Refresh();
            */
        }

        private void labelZaboravljenaLozinka_Click(object sender, EventArgs e)
        {
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                form.openChildForm(new ZaboravljenaLozinkaEmail(autentifikator));
            }
        }
    }
}
