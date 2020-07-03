using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocjene
{
    public class Ocjena
    {
        public UCOcjena PrikazUC = null;
        private int id;
        private string komentar;
        private int ocjena;
        private Image profilna;
        private Image slikaOcjene;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                PrikazUC.ucID.Text = id.ToString();
            }
        }

        public string Komentar
        {
            get { return komentar; }
            set
            {
                komentar = value;
                PrikazUC.rtbxOpis.Text = komentar.ToString();
            }
        }

        public int Ocjenaa
        {
            get { return ocjena; }
            set
            {
                ocjena = value;
                PrikazUC.ucNaziv.Text = ocjena.ToString();
            }
        }
        public Image Profilna
        {
            get { return profilna; }
            set
            {

                profilna = value;
                PrikazUC.ucProfilna.Image = profilna;

            }
        }

        public Image SlikaOcjene
        {
            get { return slikaOcjene; }
            set
            {

                slikaOcjene = value;
                PrikazUC.ucOcjenaSlike.Image = slikaOcjene;

            }
        }

        public Ocjena(INSform.Iform iform)
        {
            PrikazUC = new UCOcjena(iform);
            PrikazUC.LoadPonuda(this);
        }
    }
}
