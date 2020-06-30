﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSform;
namespace Ponude
{
    public class Ponuda
    {
		public UCPonuda PrikazUC = null;
		private string naziv;
		private Image fotografija;
		private float cijena;
		private int kolicina;
		private string mjerna;
		private string id;
		private string ime;
		private string lokacija;

		public string Lokacija
		{
			get { return lokacija; }
			set
			{
				lokacija = value;
				PrikazUC.ucLokacija.Text = lokacija;
			}
		}

		public string Ime
		{
			get { return ime; }
			set
			{
				ime = value;
				PrikazUC.ucPonuditelj.Text = ime;
			}
		}
		public string ID
		{
			get { return id; }
			set
			{
				id = value;
				PrikazUC.ucID.Text = id;
			}
		}

		public string Mjerna
		{
			get { return mjerna; }
			set
			{
				mjerna = value;
				PrikazUC.ucMjerna.Text = mjerna;
			}
		}
		public float Cijena
		{
			get { return cijena; }
			set 
			{ 
				cijena = value;
				PrikazUC.ucCijena.Text = cijena.ToString();
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

		public string Naziv
		{
			get { return naziv; }
			set
			{
				naziv = value;
				PrikazUC.ucNaziv.Text = naziv;

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
		/*
		public Ponuda()
		{
			PrikazUC = new UCPonuda();
			PrikazUC.LoadPonuda(this);
		}
		*/
		public Ponuda(Iform iform)
		{
			PrikazUC = new UCPonuda(iform);
			PrikazUC.LoadPonuda(this);
		}
	}
}