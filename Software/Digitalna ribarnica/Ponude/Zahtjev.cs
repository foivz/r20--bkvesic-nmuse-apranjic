using INSform;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponude
{
    public class Zahtjev
    {
		public UCZahtjev PrikazUC = null;
		private Image fotografija;
		private int kolicina;
		private string brojSatiDana;
		private string ime;
		private string max;
		private int Id;

		public int ID
		{
			get { return Id; }
			set
			{
				Id = value;
				PrikazUC.ucID.Text = Id.ToString();
			}
		}
		public string Max
		{
			get { return max; }
			set
			{
				max = value;
				PrikazUC.ucMax.Text = max;
			}
		}
		public string Ime
		{
			get { return ime; }
			set
			{
				ime = value;
				PrikazUC.ucIme.Text = ime;
			}
		}

		public int Kolicina
		{
			get { return kolicina; }
			set
			{
				kolicina = value;
				PrikazUC.ucKolicina.Text = kolicina.ToString();
			}
		}

		public Image Fotografija
		{
			get { return fotografija; }
			set
			{
				fotografija = value;
				PrikazUC.ucFotografija.Image = fotografija;
			}
		}

		public string BrojSatiDana
		{
			get { return brojSatiDana; }
			set
			{
				brojSatiDana = value;
				PrikazUC.ucSati.Text = brojSatiDana;
			}
		}


		public Zahtjev(Iform iform)
		{		
			PrikazUC = new UCZahtjev(iform);
			PrikazUC.LoadPonuda(this);

		}
	}
}
