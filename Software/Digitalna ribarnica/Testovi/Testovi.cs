using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prijava;
using Registracija;

namespace Testovi
{
    [TestClass]
    public class Testovi
    {
        [TestMethod]
        public void Provjera_prijave_korisnika_test()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsTrue(autentifikator.prijava("bkvesic7", "bozo123"));
        }
        [TestMethod]
        public void Provjera_prijave_korisnika_test_nije_ispravno()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsFalse(autentifikator.prijava("bkvesic7", "bozo1234"));
        }
        [TestMethod]
        public void Provjera_uloge_korisnika()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsFalse(autentifikator.tipKorisnika("bkvesic7") == 3);
        }

        [TestMethod]
        public void Provjera_uloge_korisnika_valja()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsTrue(autentifikator.tipKorisnika("bkvesic7")==1);
        }

        [TestMethod]
        public void Provjera_postojanja_korisnika()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsNull(autentifikator.findKorisnik("bkvesic7"));
        }

        [TestMethod]
        public void Provjera_postojanja_korisnika_ne_postoji()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsNotNull(autentifikator.findKorisnik("bozo.kvesic1@gmail.com"));
        }

        [TestMethod]
        public void Provjera_korime_izmedu_5_i_15()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.ThrowsException<PrijavaException>(() => autentifikator.provjeriKorisnika("111"));
        }

        [TestMethod]
        public void Provjera_korime_postoji_u_bazi()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.ThrowsException<PrijavaException>(() => autentifikator.provjeriKorisnika1("bkvesic7"));
        }

        [TestMethod]
        public void Provjera_korime_sadrži_slovo_i_broj()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.ThrowsException<PrijavaException>(() => autentifikator.provjeriKorisnika2("bkvesic"));
        }

        [TestMethod]
        public void Provjera_email_postoji_u_bazi()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.ThrowsException<PrijavaException>(() => autentifikator.postojiEmail("bozo.kvesic@gmail.com"));
        }

        [TestMethod]
        public void Provjera_email_ne_postoji_u_bazi()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.ThrowsException<PrijavaException>(() => autentifikator.NePostojiEmail("bozo.kvesic1@gmail.com"));
        }

        [TestMethod]
        public void Provjera_mobilnog_broja()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsFalse(autentifikator.IsMobilePhoneCorrect("094m4m44343443"));
        }

        [TestMethod]
        public void Provjera_mobilnog_broja2()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsTrue(autentifikator.IsMobilePhoneCorrect("098644646464"));
        }

        [TestMethod]
        public void Provjera_imena()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsFalse(autentifikator.IsNameSurnameValid("n3dsaamd331"));
        }

        [TestMethod]
        public void Provjera_imena_ispravno()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsTrue(autentifikator.IsNameSurnameValid("Ivan"));
        }

        [TestMethod]
        public void Provjera_dvije_lozinke()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsTrue(autentifikator.IsPasswordsSame("ivan1233","ivan1233"));
        }

        [TestMethod]
        public void Provjera_dvije_lozinke_neispravno()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsFalse(autentifikator.IsPasswordsSame("ivan1233", "ivan564"));
        }

        [TestMethod]
        public void Provjera_emaila()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsTrue(autentifikator.IsValidEmail("bozo.kvesic@gmail.com"));
        }
    }
}
