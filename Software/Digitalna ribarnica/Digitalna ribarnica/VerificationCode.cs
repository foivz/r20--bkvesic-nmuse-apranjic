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
    public partial class VerificationCode : Form
    {
        int code_number;
        string Email;
        string Ime;
        string Lozinka;
        Autentifikator autentifikator;
        public VerificationCode()
        {
            InitializeComponent();
            
        }

        public VerificationCode(string ime, string lozinka,int broj, string email, Autentifikator autentifikator)
        {
            InitializeComponent();
            Ime = ime;
            Lozinka = lozinka;
            code_number = broj;
            Email = email;
            this.autentifikator = autentifikator;
        }

        private void VerificationCode_Load(object sender, EventArgs e)
        {

        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            if ((textBoxCode1.Text == (code_number / 10000).ToString()) && (textBoxCode2.Text == ((code_number / 1000) % 10).ToString()) && (textBoxCode3.Text == ((code_number / 100) % 10).ToString()) && (textBoxCode4.Text == ((code_number % 100) / 10).ToString()) && (textBoxCode5.Text == (code_number % 10).ToString()))
            {
                autentifikator.DodajKorisnika(Ime, Lozinka);
            }
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                form.labelOdjava.Text = "Uspješna registracija!";
                form.labelOdjava.Visible = true;
            }
            notifyVerification.ShowBalloonTip(1000, "Registration", "Uspješno ste se registrirali!", ToolTipIcon.Info);
            Close();

        }
    }
}
