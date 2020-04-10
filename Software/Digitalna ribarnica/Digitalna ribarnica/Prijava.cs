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
        public Prijava()
        {
            InitializeComponent();
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
                    MessageBox.Show("Uspješna prijava");
                    Close();
                }
                else
                {
                    MessageBox.Show("Pogrešna lozinka ili korisničko ime");
                    Close();
                }
            }
            else {
                MessageBox.Show("Ostavili ste prazno polje");
            }
            
        }
    }
}
