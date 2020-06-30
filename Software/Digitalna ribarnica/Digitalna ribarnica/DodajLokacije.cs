﻿using System;
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
        private bool azuriraj = false;
        public DodajLokacije()
        {
            InitializeComponent();
        }

        private void DodajLokacije_Load(object sender, EventArgs e)
        {
            this.dgvLokacije.DefaultCellStyle.ForeColor = Color.FromArgb(1, 131, 131);
            this.dgvLokacije.DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dgvLokacije.DefaultCellStyle.SelectionForeColor = Color.FromArgb(66, 230, 164);
            this.dgvLokacije.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 57, 63);
            this.dgvLokacije.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dgvLokacije.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            this.dgvLokacije.EnableHeadersVisualStyles = false;
            this.dgvLokacije.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dgvLokacije.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            Osjezi();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (txtDodaj.Text.ToString() != "")
            {
                LokacijeRepozitory.dodajLokacij(txtDodaj.Text);
                notifyLokacija.ShowBalloonTip(1000, "Lokacije u sustavu", "Uspješno ste dodali novu lokaciju!", ToolTipIcon.Info);
            }
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
                notifyLokacija.ShowBalloonTip(1000, "Lokacije u sustavu", "Uspješno ste obrisali odabranu lokaciju!", ToolTipIcon.Info);
            }
            Osjezi();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            azuriraj = false;
            Lokacije.Lokacije odabranaLokacija = dgvLokacije.CurrentRow.DataBoundItem as Lokacije.Lokacije;
            if (odabranaLokacija != null)
            {
                azuriraj = true;
                LokacijeRepozitory.azurirajLokaciju(odabranaLokacija,txtDodaj.Text);
            }
            else
            {
                azuriraj = false;
            }

            if (azuriraj)
                notifyLokacija.ShowBalloonTip(1000, "Lokacije u sustavu", "Uspješno ste ažurirali lokaciju!", ToolTipIcon.Info);
            else
                notifyLokacija.ShowBalloonTip(1000, "Lokacije u sustavu", "Neuspješno ažuriranje", ToolTipIcon.Error);

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
            this.dgvLokacije.DefaultCellStyle.ForeColor = Color.FromArgb(1, 131, 131);
            this.dgvLokacije.DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dgvLokacije.DefaultCellStyle.SelectionForeColor = Color.FromArgb(66, 230, 164);
            this.dgvLokacije.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 57, 63);
            this.dgvLokacije.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dgvLokacije.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            this.dgvLokacije.EnableHeadersVisualStyles = false;
            this.dgvLokacije.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dgvLokacije.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
        }

        private void txtDodaj_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
