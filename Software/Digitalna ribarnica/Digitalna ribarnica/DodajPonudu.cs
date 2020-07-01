using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lokacije;
using RibeUSustavu;
using Baza;
using INSform;
using Prijava;
using System.Data.SqlClient;

namespace Digitalna_ribarnica
{
    public partial class DodajPonudu : Form
    {
        string extension = "";
        Iform iform;
        public DodajPonudu(Iform nova)
        {
            InitializeComponent();
            iform = nova;
        }

        private void DodajPonudu_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            pictureBox1.Visible = false;
            btnUcitaj.Visible = false;
            cmbLokacija.DataSource = LokacijeRepozitory.dohvatiLokacije();
            cmbRiba.DataSource = RibeRepository.DohvatiNaziveRibe();
            Riba riba = cmbRiba.SelectedValue as Riba;
            lblMjerna.Text = riba.MjernaJedinica;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
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
                parameters.Add("@cijena", float.TryParse(txtCijena.Text, out float cijena1));
            else
                MessageBox.Show("Niste unije broj kod cijene");

            if (int.TryParse(txtKolicina.Text, out int kolicina))
                parameters.Add("@kolicina", int.TryParse(txtKolicina.Text, out int kolicina1));
            else
                MessageBox.Show("Niste unijeli broj kod količine");

            parameters.Add("@opis", rtbxOpis.Text);
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
            parameters.Add("@idkorisnika", KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik));



            if ((float.TryParse(txtCijena.Text, out float cijena2)) && (int.TryParse(txtKolicina.Text, out int kolicina2))) 
            {
                //DB.Instance.ExecuteParamQuery("INSERT INTO [Slika_test] ([slika]) VALUES (@slika);", parameters);
                if (extension != "")
                    DB.Instance.ExecuteParamQuery("INSERT INTO [ponude]([cijena], [kolicina], [opis], [dodatna_fotografija], [id_riba], [id_lokacija], [id_korisnik]) VALUES((@cijena), (@kolicina), (@opis), (@slika), (@idriba), (@idlokacija), (@idkorisnika)); ", parameters);
                else
                    DB.Instance.ExecuteParamQuery("INSERT INTO [ponude]([cijena], [kolicina], [opis], [id_riba], [id_lokacija], [id_korisnik]) VALUES((@cijena), (@kolicina), (@opis), (@idriba), (@idlokacija), (@idkorisnika)); ", parameters);

                Close();
            }

            
        }
    }
}
