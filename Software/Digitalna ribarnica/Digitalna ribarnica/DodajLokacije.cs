using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lokacije;
namespace Digitalna_ribarnica
{
    public partial class DodajLokacije : Form
    {
        public DodajLokacije()
        {
            InitializeComponent();
        }

        private void DodajLokacije_Load(object sender, EventArgs e)
        {
            this.dgvLokacije.DefaultCellStyle.ForeColor = Color.FromArgb(0, 62, 87);
            this.dgvLokacije.DefaultCellStyle.BackColor = Color.FromArgb(225, 245, 254);
            this.dgvLokacije.DefaultCellStyle.SelectionForeColor = Color.DarkBlue;
            this.dgvLokacije.DefaultCellStyle.SelectionBackColor = Color.AntiqueWhite;
            this.dgvLokacije.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 141, 217);
            this.dgvLokacije.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(179, 229, 252);
            this.dgvLokacije.EnableHeadersVisualStyles = false;
            this.dgvLokacije.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 141, 217);
            Osjezi();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (txtDodaj.Text.ToString() != "")
                LokacijeRepozitory.dodajLokacij(txtDodaj.Text);
            Osjezi();
        }

        private void Osjezi()
        {
            dgvLokacije.DataSource = null;
            dgvLokacije.DataSource = LokacijeRepozitory.dohvatiLokacije();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Lokacije.Lokacije odabranaLokacija = dgvLokacije.CurrentRow.DataBoundItem as Lokacije.Lokacije;
            if (odabranaLokacija != null)
            {
                LokacijeRepozitory.obrisiLokaciju(odabranaLokacija);
            }
            Osjezi();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            Lokacije.Lokacije odabranaLokacija = dgvLokacije.CurrentRow.DataBoundItem as Lokacije.Lokacije;
            if (odabranaLokacija != null)
            {
                LokacijeRepozitory.azurirajLokaciju(odabranaLokacija,txtDodaj.Text);
            }
            Osjezi();
        }

        private void txtFiltriraj_TextChanged(object sender, EventArgs e)
        {
            List<Lokacije.Lokacije> sveLokacije = LokacijeRepozitory.dohvatiLokacije();
            string filter = txtFiltriraj.Text.ToLower();
            int broj = 0;
            if (filter != null)
            {
                if (int.TryParse(filter, out broj))
                {
                    var result = from lokacija in sveLokacije
                                 where lokacija.id == broj
                                 select lokacija;

                    dgvLokacije.DataSource = result.ToList();
                }
                else
                {
                    var result = from Lokacije in sveLokacije
                                 where Lokacije.Naziv.ToLower().Contains(filter)
                                 select Lokacije;
                    dgvLokacije.DataSource = result.ToList();
                }

            }
            else
            {
                var result = from lokacije in sveLokacije
                             select lokacije;
                dgvLokacije.DataSource = result;
            }
        }

        private void btnSortiraj_Click(object sender, EventArgs e)
        {
            List<Lokacije.Lokacije> sveLokacije = LokacijeRepozitory.dohvatiLokacije();
            var result = from lokacija in sveLokacije
                         orderby lokacija.Naziv ascending
                         select lokacija;

            dgvLokacije.DataSource = result.ToList();
        }

        private void dgvLokacije_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvLokacije.DefaultCellStyle.ForeColor = Color.FromArgb(0, 62, 87);
            this.dgvLokacije.DefaultCellStyle.BackColor = Color.FromArgb(225, 245, 254);
            this.dgvLokacije.DefaultCellStyle.SelectionForeColor = Color.DarkBlue;
            this.dgvLokacije.DefaultCellStyle.SelectionBackColor = Color.AntiqueWhite;
            this.dgvLokacije.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 141, 217);
            this.dgvLokacije.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(179, 229, 252);
            this.dgvLokacije.EnableHeadersVisualStyles = false;
            this.dgvLokacije.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 141, 217);
        }
    }
}
