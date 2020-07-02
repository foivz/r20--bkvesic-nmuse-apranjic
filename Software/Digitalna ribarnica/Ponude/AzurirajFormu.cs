﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INSform;
using Lokacije;
using RibeUSustavu;
using Prijava;
using Baza;
namespace Ponude
{
    public partial class AzurirajFormu : Form
    {
        Iform Iform;
        Ponuda ponuda;
        string extension = "";
        public AzurirajFormu(Ponuda ponuda,Iform novo)
        {
            InitializeComponent();
            this.ponuda = ponuda;
            Iform = novo;
        }

        private void AzurirajFormu_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            pictureBox1.Visible = false;
            btnUcitaj.Visible = false;
            cmbLokacija.DataSource = LokacijeRepozitory.dohvatiLokacije();
            cmbRiba.DataSource = RibeRepository.DohvatiNaziveRibe();
            cmbLokacija.SelectedIndex = cmbLokacija.FindString(ponuda.Lokacija);
            cmbRiba.SelectedIndex = cmbRiba.FindString(ponuda.Naziv);
            txtCijena.Text = ponuda.Cijena.ToString();
            txtKolicina.Text = ponuda.Kolicina.ToString();
            rtbxOpis.Text = PonudeRepozitory.DohvatiOpisPonude(int.Parse(ponuda.ID));
            lblMjerna.Text = ponuda.Mjerna;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                pictureBox1.Visible = true;
                btnUcitaj.Visible = true;
                btnKreiraj.Enabled = false;
            }
            else
            {
                pictureBox1.Visible = false;
                btnUcitaj.Visible = false;
                btnKreiraj.Enabled = true;
            }
        }

        private void cmbRiba_SelectedIndexChanged(object sender, EventArgs e)
        {
            Riba riba = cmbRiba.SelectedValue as Riba;
            lblMjerna.Text = riba.MjernaJedinica;
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "images|*.png;*.jpg;*jpeg";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.CheckFileExists)
                {
                    pictureBox1.Load(openFileDialog1.FileName);
                }
                extension = Path.GetExtension(openFileDialog1.FileName);
                btnKreiraj.Enabled = true;
            }
            catch (Exception)
            {

                //MessageBox.Show("Slika nije odabrana!");
            }
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            
            MemoryStream ms = new MemoryStream();
            var photo = pictureBox1.Image;

            var parameters = new Dictionary<string, object>();
            if (float.TryParse(txtCijena.Text, out float cijena))
                parameters.Add("@cijena", cijena);
            else
                MessageBox.Show("Niste unije broj kod cijene");

            if (int.TryParse(txtKolicina.Text, out int kolicina))
                parameters.Add("@kolicina", kolicina);
            else
                MessageBox.Show("Niste unijeli broj kod količine");

            parameters.Add("@opis", rtbxOpis.Text);
            if (int.TryParse(txtSati.Text, out int sati))
                parameters.Add("@sati", sati);
            else
                MessageBox.Show("Niste unijeli broj kod sati");
            if (extension != "")
            {
                switch (extension)
                {
                    case ".jpeg":
                        {
                            photo.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        break;
                    case ".jpg":
                        {
                            photo.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        break;
                    case ".png":
                        {
                            photo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        break;
                    default:
                        MessageBox.Show("Format nije podržan!");
                        break;
                }
                parameters.Add("@slika", ms.ToArray());
            }
            parameters.Add("@idriba", (cmbRiba.SelectedValue as Riba).id);
            parameters.Add("@idlokacija", (cmbLokacija.SelectedValue as Lokacije.Lokacije).id);
            parameters.Add("@idkorisnika", KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
            parameters.Add("@idponuda", int.Parse(ponuda.ID));


            if ((float.TryParse(txtCijena.Text, out float cijena2)) && (int.TryParse(txtKolicina.Text, out int kolicina2)) && (int.TryParse(txtSati.Text, out int sati2)))
            {
                if (extension != "")
                    DB.Instance.ExecuteParamQuery("UPDATE [ponude] SET [cijena]=(@cijena), [kolicina]=(@kolicina), [opis]=(@opis), [trajanje_rezervacije_u_satima]=(@sati), [dodatna_fotografija]=(@slika), [id_riba]=(@idriba), [id_lokacija]=(@idlokacija), [id_korisnik]=(@idkorisnika) WHERE [id_ponuda]=(@idponuda); ", parameters);
                else
                    DB.Instance.ExecuteParamQuery("UPDATE [ponude] SET [cijena]=(@cijena), [kolicina]=(@kolicina), [opis]=(@opis), [trajanje_rezervacije_u_satima]=(@sati), [id_riba]=(@idriba), [id_lokacija]=(@idlokacija), [id_korisnik]=(@idkorisnika) WHERE [id_ponuda]=(@idponuda);", parameters);
                notifyPonuda.ShowBalloonTip(1000, "Kreiranje ponude", "Uspješno ste kreirali ponudu", ToolTipIcon.Info);
                UrediPonudu form = Application.OpenForms.OfType<UrediPonudu>().FirstOrDefault();
                if (form != null)
                    form.zatvoriForme();
                Close();
            }
        }
    }
}
