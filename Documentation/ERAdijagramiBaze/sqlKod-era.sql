-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`tipovi_korisnika`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`tipovi_korisnika` (
  `id_tip` INT NOT NULL AUTO_INCREMENT,
  `naziv` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_tip`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`statusi`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`statusi` (
  `id_status` INT NOT NULL AUTO_INCREMENT,
  `naziv` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_status`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`korisnici`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`korisnici` (
  `id_korisnik` INT NOT NULL AUTO_INCREMENT,
  `ime` VARCHAR(45) NOT NULL,
  `prezime` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `korisnicko_ime` VARCHAR(45) NOT NULL,
  `broj_mobitela` VARCHAR(45) NOT NULL,
  `datum_rodenja` DATE NOT NULL,
  `lozinka` VARCHAR(100) NOT NULL,
  `mjesto` VARCHAR(45) NOT NULL,
  `slika` LONGBLOB NULL,
  `id_tip_korisnika` INT NOT NULL,
  `id_status` INT NOT NULL,
  PRIMARY KEY (`id_korisnik`),
  INDEX `fk_korisnik_tip_korisnika1_idx` (`id_tip_korisnika` ASC),
  INDEX `fk_korisnik_status1_idx` (`id_status` ASC),
  CONSTRAINT `fk_korisnik_tip_korisnika1`
    FOREIGN KEY (`id_tip_korisnika`)
    REFERENCES `mydb`.`tipovi_korisnika` (`id_tip`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_korisnik_status1`
    FOREIGN KEY (`id_status`)
    REFERENCES `mydb`.`statusi` (`id_status`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ribe`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`ribe` (
  `id_riba` INT NOT NULL AUTO_INCREMENT,
  `naziv` VARCHAR(45) NOT NULL,
  `slika` TEXT NOT NULL,
  `mjerna_jedinica` TINYINT NOT NULL,
  PRIMARY KEY (`id_riba`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`lokacije`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`lokacije` (
  `id_lokacija` INT NOT NULL AUTO_INCREMENT,
  `naziv` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_lokacija`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ponude`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`ponude` (
  `id_ponuda` INT NOT NULL AUTO_INCREMENT,
  `cijena` INT NOT NULL,
  `kolicina` INT NOT NULL,
  `opis` TEXT NULL,
  `dodatne_fotografije` TEXT NULL,
  `trajanje_rezervacije_u_satima` INT NOT NULL,
  `id_riba` INT NOT NULL,
  `id_lokacija` INT NOT NULL,
  `id_korisnik` INT NOT NULL,
  PRIMARY KEY (`id_ponuda`),
  INDEX `fk_ponude_riba_idx` (`id_riba` ASC),
  INDEX `fk_ponude_lokacije1_idx` (`id_lokacija` ASC),
  INDEX `fk_ponude_korisnik1_idx` (`id_korisnik` ASC),
  CONSTRAINT `fk_ponude_riba`
    FOREIGN KEY (`id_riba`)
    REFERENCES `mydb`.`ribe` (`id_riba`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ponude_lokacije1`
    FOREIGN KEY (`id_lokacija`)
    REFERENCES `mydb`.`lokacije` (`id_lokacija`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ponude_korisnik1`
    FOREIGN KEY (`id_korisnik`)
    REFERENCES `mydb`.`korisnici` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`tipovi_statusa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`tipovi_statusa` (
  `id_tip_statusa` INT NOT NULL,
  `opis_statusa` VARCHAR(45) NULL,
  PRIMARY KEY (`id_tip_statusa`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`rezervacije`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`rezervacije` (
  `id_rezervacije` INT NOT NULL AUTO_INCREMENT,
  `datum_i_vrijeme` DATETIME NOT NULL,
  `kolicina` INT NOT NULL,
  `status` TINYINT NULL,
  `id_kupac` INT NOT NULL,
  `id_ponuda` INT NOT NULL,
  `iid_tip_statusa` INT NOT NULL,
  PRIMARY KEY (`id_rezervacije`),
  INDEX `fk_rezervacije_korisnik1_idx` (`id_kupac` ASC),
  INDEX `fk_rezervacije_ponude1_idx` (`id_ponuda` ASC),
  INDEX `fk_rezervacije_tipovi_statusa1_idx` (`iid_tip_statusa` ASC),
  CONSTRAINT `fk_rezervacije_korisnik1`
    FOREIGN KEY (`id_kupac`)
    REFERENCES `mydb`.`korisnici` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_rezervacije_ponude1`
    FOREIGN KEY (`id_ponuda`)
    REFERENCES `mydb`.`ponude` (`id_ponuda`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_rezervacije_tipovi_statusa1`
    FOREIGN KEY (`iid_tip_statusa`)
    REFERENCES `mydb`.`tipovi_statusa` (`id_tip_statusa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ocjene`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`ocjene` (
  `id_ocjena` INT NOT NULL AUTO_INCREMENT,
  `ocjena` INT NOT NULL,
  `komentar` TEXT NULL,
  `tko_ocjenjuje` INT NOT NULL,
  `koga_ocjenjuje` INT NOT NULL,
  `id_rezervacije` INT NOT NULL,
  `nepreuzeto` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`id_ocjena`),
  INDEX `fk_ocjene_korisnik1_idx` (`tko_ocjenjuje` ASC),
  INDEX `fk_ocjene_korisnik2_idx` (`koga_ocjenjuje` ASC),
  INDEX `fk_ocjene_rezervacije1_idx` (`id_rezervacije` ASC),
  CONSTRAINT `fk_ocjene_korisnik1`
    FOREIGN KEY (`tko_ocjenjuje`)
    REFERENCES `mydb`.`korisnici` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ocjene_korisnik2`
    FOREIGN KEY (`koga_ocjenjuje`)
    REFERENCES `mydb`.`korisnici` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ocjene_rezervacije1`
    FOREIGN KEY (`id_rezervacije`)
    REFERENCES `mydb`.`rezervacije` (`id_rezervacije`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`tipovi_radnje`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`tipovi_radnje` (
  `id_tip_radnje` INT NOT NULL AUTO_INCREMENT,
  `naziv` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_tip_radnje`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`dnevnik`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`dnevnik` (
  `id_radnja` INT NOT NULL AUTO_INCREMENT,
  `datum_i_vrijeme_radnje` DATETIME NOT NULL,
  `radnja` VARCHAR(45) NOT NULL,
  `id_korisnik` INT NOT NULL,
  `id_tip_radnje` INT NOT NULL,
  PRIMARY KEY (`id_radnja`),
  INDEX `fk_dnevnik_korisnik1_idx` (`id_korisnik` ASC),
  INDEX `fk_dnevnik_tip_radnje1_idx` (`id_tip_radnje` ASC),
  CONSTRAINT `fk_dnevnik_korisnik1`
    FOREIGN KEY (`id_korisnik`)
    REFERENCES `mydb`.`korisnici` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_dnevnik_tip_radnje1`
    FOREIGN KEY (`id_tip_radnje`)
    REFERENCES `mydb`.`tipovi_radnje` (`id_tip_radnje`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`znacke`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`znacke` (
  `id_znacke` INT NOT NULL AUTO_INCREMENT,
  `naziv` VARCHAR(45) NOT NULL,
  `opis` TEXT NOT NULL,
  `slika` TEXT NOT NULL,
  PRIMARY KEY (`id_znacke`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`imaju_znacku`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`imaju_znacku` (
  `id_korisnik_znacka` INT NOT NULL AUTO_INCREMENT,
  `datum_i_vrijeme` DATETIME NOT NULL,
  `id_znacke` INT NOT NULL,
  `id_korisnik` INT NOT NULL,
  PRIMARY KEY (`id_korisnik_znacka`),
  INDEX `fk_ima_znacku_znacke1_idx` (`id_znacke` ASC),
  INDEX `fk_ima_znacku_korisnik1_idx` (`id_korisnik` ASC),
  CONSTRAINT `fk_ima_znacku_znacke1`
    FOREIGN KEY (`id_znacke`)
    REFERENCES `mydb`.`znacke` (`id_znacke`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ima_znacku_korisnik1`
    FOREIGN KEY (`id_korisnik`)
    REFERENCES `mydb`.`korisnici` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`razgovori`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`razgovori` (
  `id_razgovora` INT NOT NULL AUTO_INCREMENT,
  `korisnik1` INT NOT NULL,
  `korisnik2` INT NOT NULL,
  PRIMARY KEY (`id_razgovora`),
  INDEX `fk_razgovori_korisnici1_idx` (`korisnik1` ASC),
  INDEX `fk_razgovori_korisnici2_idx` (`korisnik2` ASC),
  CONSTRAINT `fk_razgovori_korisnici1`
    FOREIGN KEY (`korisnik1`)
    REFERENCES `mydb`.`korisnici` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_razgovori_korisnici2`
    FOREIGN KEY (`korisnik2`)
    REFERENCES `mydb`.`korisnici` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`poruke`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`poruke` (
  `id_poruka` INT NOT NULL AUTO_INCREMENT,
  `sadrzaj` TEXT NOT NULL,
  `vrijeme` DATETIME NOT NULL,
  `posiljatelj` INT NOT NULL,
  `id_razgovora` INT NOT NULL,
  PRIMARY KEY (`id_poruka`),
  INDEX `fk_poruke_korisnici1_idx` (`posiljatelj` ASC),
  INDEX `fk_poruke_razgovori1_idx` (`id_razgovora` ASC),
  CONSTRAINT `fk_poruke_korisnici1`
    FOREIGN KEY (`posiljatelj`)
    REFERENCES `mydb`.`korisnici` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_poruke_razgovori1`
    FOREIGN KEY (`id_razgovora`)
    REFERENCES `mydb`.`razgovori` (`id_razgovora`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`obavijesti`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`obavijesti` (
  `id_obavijest` INT NOT NULL AUTO_INCREMENT,
  `sadrzaj` TEXT NULL,
  PRIMARY KEY (`id_obavijest`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`imaju_obavijesti`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`imaju_obavijesti` (
  `obavijesti_id_obavijest` INT NOT NULL,
  `korisnici_id_korisnik` INT NOT NULL,
  `procitano` TINYINT NOT NULL DEFAULT 0,
  INDEX `fk_imaju_obavijesti_obavijesti1_idx` (`obavijesti_id_obavijest` ASC),
  INDEX `fk_imaju_obavijesti_korisnici1_idx` (`korisnici_id_korisnik` ASC),
  CONSTRAINT `fk_imaju_obavijesti_obavijesti1`
    FOREIGN KEY (`obavijesti_id_obavijest`)
    REFERENCES `mydb`.`obavijesti` (`id_obavijest`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_imaju_obavijesti_korisnici1`
    FOREIGN KEY (`korisnici_id_korisnik`)
    REFERENCES `mydb`.`korisnici` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
