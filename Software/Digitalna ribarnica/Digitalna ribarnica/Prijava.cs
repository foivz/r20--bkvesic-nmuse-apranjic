using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    //MessageBox.Show("Uspješna prijava");
                    label_prijava.Text = "Dobro došli " + txtKorIme.Text;
                    prijava_prijava.Visible = false;
                    odjava_prijava.Visible = true;
                    novosti.Visible = true;
                    Close();
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

            //this.Hide();
            Registracija registracija = new Registracija();   
            registracija.ShowDialog();
       
        }
    }
}
