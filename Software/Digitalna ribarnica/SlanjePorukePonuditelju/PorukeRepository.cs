﻿using Baza;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlanjePorukePonuditelju
{
    public class PorukeRepository
    {
        public static List<PorukeIzBaze> DohvatiPoruke(int idAktivan, int idPrimatelj)
        {
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select poruke.sadrzaj, poruke.vrijeme, poruke.posiljatelj from poruke, razgovori where razgovori.id_razgovora = poruke.id_razgovora and ((razgovori.korisnik1 = {idAktivan} or razgovori.korisnik1 = {idPrimatelj}) and(razgovori.korisnik2 = {idAktivan} or razgovori.korisnik2 = {idPrimatelj}))");
            foreach (DbDataRecord item in rezultat)
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < item.FieldCount; i++)
                {
                    row.Add(item.GetName(i), item[i]);
                }
                returnMe.Add(row);
            }
            rezultat.Close();
            List<PorukeIzBaze> _poruke = new List<PorukeIzBaze>();
            foreach (var item in returnMe)
            {
                PorukeIzBaze poruka = new PorukeIzBaze();
                poruka.ID = int.Parse(item["posiljatelj"].ToString());
                poruka.sadrzaj = item["sadrzaj"].ToString();
                poruka.datum = DateTime.Parse(item["vrijeme"].ToString());
                _poruke.Add(poruka);
            }
            return _poruke;
        }

        public static int DodajRazgovor(int idPrimatelj, int idPosiljate)
        {
            string sqlUpit = "";
            sqlUpit = $"insert into razgovori(korisnik1, korisnik2) values({idPrimatelj},{idPosiljate})";
            int insertUBazu = DB.Instance.IzvrsiUpit(sqlUpit);
            return insertUBazu;
        }

        public static int DohvatiRazgovor(int idPrimatelj, int idPosiljate)
        {
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select id_razgovora from razgovori where (korisnik1 = {idPrimatelj} or korisnik1 = {idPosiljate}) and(korisnik2 = {idPrimatelj} or korisnik2 = {idPosiljate}); ");
            foreach (DbDataRecord item in rezultat)
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < item.FieldCount; i++)
                {
                    row.Add(item.GetName(i), item[i]);
                }
                returnMe.Add(row);
            }
            rezultat.Close();
            int IDRazgovora = -1;
            if (returnMe != null)
            {
                foreach (var item in returnMe)
                {
                    IDRazgovora = int.Parse(item["id_razgovora"].ToString());
                }
            }

            return IDRazgovora;
        }

        public static void UnesiPoruku(string sadrzaj, int posiljatelj, int idRazgovora)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("@sadrzaj", sadrzaj);
            parameters.Add("@datum", DateTime.Now);
            parameters.Add("@posiljatelj", posiljatelj);
            parameters.Add("@idRazgovora", idRazgovora);
            DB.Instance.ExecuteParamQuery("insert into [poruke]([sadrzaj], [vrijeme], [posiljatelj], [id_razgovora]) values((@sadrzaj),(@datum),(@posiljatelj),(@idRazgovora));", parameters);
        }
    }
}