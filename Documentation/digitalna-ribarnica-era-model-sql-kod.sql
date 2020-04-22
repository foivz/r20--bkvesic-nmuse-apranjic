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
-- Table `mydb`.`tip_korisnika`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`tip_korisnika` (
  `id_tip` INT NOT NULL AUTO_INCREMENT,
  `naziv` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_tip`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`korisnik`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`korisnik` (
  `id_korisnik` INT NOT NULL AUTO_INCREMENT,
  `ime` VARCHAR(45) NOT NULL,
  `prezime` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `korisnicko_ime` VARCHAR(45) NOT NULL,
  `status` INT NULL,
  `broj_mobitela` VARCHAR(45) NULL,
  `datum_rodenja` DATE NOT NULL,
  `slika` LONGBLOB NULL,
  `id_tip_korisnika` INT NOT NULL,
  PRIMARY KEY (`id_korisnik`),
  INDEX `fk_korisnik_tip_korisnika1_idx` (`id_tip_korisnika` ASC),
  CONSTRAINT `fk_korisnik_tip_korisnika1`
    FOREIGN KEY (`id_tip_korisnika`)
    REFERENCES `mydb`.`tip_korisnika` (`id_tip`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`riba`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`riba` (
  `id_riba` INT NOT NULL AUTO_INCREMENT,
  `naziv` VARCHAR(45) NOT NULL,
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
  `cijena` INT NULL,
  `opis` TEXT NULL,
  `dodatne_fotografije` TEXT NULL,
  `trajanje_rezervacije` VARCHAR(45) NULL,
  `id_riba` INT NOT NULL,
  `id_lokacija` INT NOT NULL,
  `id_korisnik` INT NOT NULL,
  PRIMARY KEY (`id_ponuda`),
  INDEX `fk_ponude_riba_idx` (`id_riba` ASC),
  INDEX `fk_ponude_lokacije1_idx` (`id_lokacija` ASC),
  INDEX `fk_ponude_korisnik1_idx` (`id_korisnik` ASC),
  CONSTRAINT `fk_ponude_riba`
    FOREIGN KEY (`id_riba`)
    REFERENCES `mydb`.`riba` (`id_riba`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ponude_lokacije1`
    FOREIGN KEY (`id_lokacija`)
    REFERENCES `mydb`.`lokacije` (`id_lokacija`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ponude_korisnik1`
    FOREIGN KEY (`id_korisnik`)
    REFERENCES `mydb`.`korisnik` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`rezervacije`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`rezervacije` (
  `id_rezervacije` INT NOT NULL AUTO_INCREMENT,
  `datum_i_vrijeme` DATETIME NULL,
  `potvrda_o_preuzimanju` TINYINT NULL,
  `ponuditelj_odobrio` TINYINT NULL,
  `id_kupac` INT NOT NULL,
  `id_ponuda` INT NOT NULL,
  PRIMARY KEY (`id_rezervacije`),
  INDEX `fk_rezervacije_korisnik1_idx` (`id_kupac` ASC),
  INDEX `fk_rezervacije_ponude1_idx` (`id_ponuda` ASC),
  CONSTRAINT `fk_rezervacije_korisnik1`
    FOREIGN KEY (`id_kupac`)
    REFERENCES `mydb`.`korisnik` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_rezervacije_ponude1`
    FOREIGN KEY (`id_ponuda`)
    REFERENCES `mydb`.`ponude` (`id_ponuda`)
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
  PRIMARY KEY (`id_ocjena`),
  INDEX `fk_ocjene_korisnik1_idx` (`tko_ocjenjuje` ASC),
  INDEX `fk_ocjene_korisnik2_idx` (`koga_ocjenjuje` ASC),
  INDEX `fk_ocjene_rezervacije1_idx` (`id_rezervacije` ASC),
  CONSTRAINT `fk_ocjene_korisnik1`
    FOREIGN KEY (`tko_ocjenjuje`)
    REFERENCES `mydb`.`korisnik` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ocjene_korisnik2`
    FOREIGN KEY (`koga_ocjenjuje`)
    REFERENCES `mydb`.`korisnik` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ocjene_rezervacije1`
    FOREIGN KEY (`id_rezervacije`)
    REFERENCES `mydb`.`rezervacije` (`id_rezervacije`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`tip_radnje`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`tip_radnje` (
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
  `radnja` VARCHAR(45) NULL,
  `id_korisnik` INT NOT NULL,
  `id_tip_radnje` INT NOT NULL,
  PRIMARY KEY (`id_radnja`),
  INDEX `fk_dnevnik_korisnik1_idx` (`id_korisnik` ASC),
  INDEX `fk_dnevnik_tip_radnje1_idx` (`id_tip_radnje` ASC),
  CONSTRAINT `fk_dnevnik_korisnik1`
    FOREIGN KEY (`id_korisnik`)
    REFERENCES `mydb`.`korisnik` (`id_korisnik`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_dnevnik_tip_radnje1`
    FOREIGN KEY (`id_tip_radnje`)
    REFERENCES `mydb`.`tip_radnje` (`id_tip_radnje`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
