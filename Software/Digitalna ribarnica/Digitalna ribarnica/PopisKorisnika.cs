﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INSform;
using Prijava;
namespace Digitalna_ribarnica
{
    public partial class PopisKorisnika : Form
    {
        Iform iform;
        public List<Korisnik> korisnici { get; set; } = new List<Korisnik>();
        public PopisKorisnika(Iform novo)
        {
            InitializeComponent();
            iform = novo;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(1, 131, 131);
            this.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 57, 63);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
        }

        private void PopisKorisnika_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(1, 131, 131);
            this.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 57, 63);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            dataGridView1.DataSource = null;
            korisnici = KorisnikRepository.DohvatiSveKorisnike();
            foreach (var item in korisnici)
            {
                item.ProfilnaSlika = KorisnikRepository.DohvatiProfilnu(item.ID);
            }
            Korisnik aktivni = new Korisnik();
            foreach (var item in korisnici)
            {
                if(item.ID==KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik))
                    aktivni = item;
            }
            korisnici.Remove(aktivni);
            dataGridView1.DataSource = korisnici;
            kalibrirajSlike();
        }

        public void kalibrirajSlike()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox1.Text.ToLower();
            int broj = 0;
            if (filter != null)
            {
                if (int.TryParse(filter, out broj))
                {
                    var result = from korisnik in korisnici
                                 where korisnik.ID == broj || korisnik.KorIme.Contains(broj.ToString()) || korisnik.Status == broj || korisnik.Mjesto.Contains(broj.ToString()) || korisnik.Tip == broj || korisnik.Lozinka.Contains(broj.ToString()) || korisnik.BrojMobitela.Contains(broj.ToString()) || korisnik.Email.Contains(broj.ToString()) || korisnik.DatumRodenja.ToString().Contains(broj.ToString()) || korisnik.Adresa.Contains(broj.ToString())
                                 select korisnik;

                    dataGridView1.DataSource = result.ToList();
                    kalibrirajSlike();
                }
                else
                {
                    var result = from korisnik in korisnici
                                 where korisnik.Ime.ToLower().Contains(filter) || korisnik.KorIme.ToLower().Contains(filter) || korisnik.Prezime.ToLower().Contains(filter) || korisnik.Email.ToLower().Contains(filter) || korisnik.Lozinka.ToLower().Contains(filter) || korisnik.Mjesto.ToLower().Contains(filter) || korisnik.Adresa.ToLower().Contains(filter)
                                 select korisnik;
                    dataGridView1.DataSource = result.ToList();
                    kalibrirajSlike();
                }

            }
            else
            {
                var result = from korisnik in korisnici
                             select korisnik;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result;
                kalibrirajSlike();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = dataGridView1.CurrentRow.DataBoundItem as Korisnik;
            if (korisnik != null)
            {
                KorisnikRepository.Obrisi(korisnik);
            }
            notifyIcon1.ShowBalloonTip(1000, "Obrisan korisnik", "Uspješno ste obrisali korisnika", ToolTipIcon.Info);
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
                form.openChildForm(new PopisKorisnika(iform));
        }

        private void btnOcijeniKupca_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = dataGridView1.CurrentRow.DataBoundItem as Korisnik;
            if (korisnik != null)
            {
                KorisnikRepository.BlokirajKorisnika(korisnik.ID,4);
            }
            notifyIcon1.ShowBalloonTip(1000, "Blokiran korisnik", "Uspješno ste blokirali korisnika", ToolTipIcon.Info);
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
                form.openChildForm(new PopisKorisnika(iform));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = dataGridView1.CurrentRow.DataBoundItem as Korisnik;
            if (korisnik != null)
            {
                KorisnikRepository.BlokirajKorisnika(korisnik.ID, 2);
            }
            notifyIcon1.ShowBalloonTip(1000, "Odblokiran korisnik", "Uspješno ste odblokirali korisnika", ToolTipIcon.Info);
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
                form.openChildForm(new PopisKorisnika(iform));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
                form.openChildForm(new NoviKorisnik(iform));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = dataGridView1.CurrentRow.DataBoundItem as Korisnik;
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null && korisnik!=null)
                form.openChildForm(new NoviKorisnik(iform,korisnik));
        }
    }
}
