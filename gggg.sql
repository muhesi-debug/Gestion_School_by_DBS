-- MySqlBackup.NET 2.0.4
-- Dump Time: 2024-02-03 18:11:28
-- --------------------------------------
-- Server version 5.7.10-log MySQL Community Server (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of aff_depenses
-- 

DROP TABLE IF EXISTS `aff_depenses`;
CREATE TABLE IF NOT EXISTS `aff_depenses` (
  `id_AffD` int(11) NOT NULL AUTO_INCREMENT,
  `Date_AffD` date DEFAULT NULL,
  `montant_affectD` decimal(65,3) NOT NULL,
  `id_anneeS` int(11) DEFAULT NULL,
  `id_catF` int(11) DEFAULT NULL,
  `id_semestre` int(11) DEFAULT NULL,
  `id_mois` int(11) DEFAULT NULL,
  `id_depense` int(11) NOT NULL,
  PRIMARY KEY (`id_AffD`),
  KEY `id_anneeS` (`id_anneeS`),
  KEY `id_catF` (`id_catF`),
  KEY `id_semestre` (`id_semestre`),
  KEY `id_mois` (`id_mois`),
  KEY `id_depense` (`id_depense`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table aff_depenses
-- 

/*!40000 ALTER TABLE `aff_depenses` DISABLE KEYS */;
INSERT INTO `aff_depenses`(`id_AffD`,`Date_AffD`,`montant_affectD`,`id_anneeS`,`id_catF`,`id_semestre`,`id_mois`,`id_depense`) VALUES
(8,'2024-02-02 00:00:00',200.000,2,3,2,2,411235098),
(10,'2024-02-02 00:00:00',50.000,2,4,2,2,562958614),
(9,'2024-02-02 00:00:00',100.000,2,4,2,2,1749161781),
(11,'2024-02-03 00:00:00',100.000,3,3,3,2,790771876);
/*!40000 ALTER TABLE `aff_depenses` ENABLE KEYS */;

-- 
-- Definition of aff_frais
-- 

DROP TABLE IF EXISTS `aff_frais`;
CREATE TABLE IF NOT EXISTS `aff_frais` (
  `id_Aff` int(11) NOT NULL AUTO_INCREMENT,
  `Date_Aff` date DEFAULT NULL,
  `montant_affect` decimal(65,3) NOT NULL,
  `id_anneeS` int(11) DEFAULT NULL,
  `id_catF` int(11) DEFAULT NULL,
  `id_semestre` int(11) DEFAULT NULL,
  `id_mois` int(11) DEFAULT NULL,
  `id_payement_frais` int(11) NOT NULL,
  PRIMARY KEY (`id_Aff`),
  KEY `id_anneeS` (`id_anneeS`),
  KEY `id_catF` (`id_catF`),
  KEY `id_semestre` (`id_semestre`),
  KEY `id_mois` (`id_mois`),
  KEY `id_payement_frais` (`id_payement_frais`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table aff_frais
-- 

/*!40000 ALTER TABLE `aff_frais` DISABLE KEYS */;
INSERT INTO `aff_frais`(`id_Aff`,`Date_Aff`,`montant_affect`,`id_anneeS`,`id_catF`,`id_semestre`,`id_mois`,`id_payement_frais`) VALUES
(14,'2024-02-02 00:00:00',200.000,2,3,3,2,20),
(13,'2024-02-02 00:00:00',200.000,2,3,3,2,20),
(15,'2024-02-02 00:00:00',200.000,2,3,3,2,19),
(16,'2024-02-02 00:00:00',50.000,2,4,2,2,21);
/*!40000 ALTER TABLE `aff_frais` ENABLE KEYS */;

-- 
-- Definition of affecter_agent_options
-- 

DROP TABLE IF EXISTS `affecter_agent_options`;
CREATE TABLE IF NOT EXISTS `affecter_agent_options` (
  `id_affecter_ag_opt` int(11) NOT NULL AUTO_INCREMENT,
  `id_agent` varchar(20) DEFAULT NULL,
  `code_option` varchar(15) DEFAULT NULL,
  `anneeScoalire` int(11) NOT NULL,
  PRIMARY KEY (`id_affecter_ag_opt`),
  KEY `fk23` (`id_agent`),
  KEY `fk24` (`code_option`),
  CONSTRAINT `fk23` FOREIGN KEY (`id_agent`) REFERENCES `agent` (`id_agent`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk24` FOREIGN KEY (`code_option`) REFERENCES `options` (`code_option`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table affecter_agent_options
-- 

/*!40000 ALTER TABLE `affecter_agent_options` DISABLE KEYS */;
INSERT INTO `affecter_agent_options`(`id_affecter_ag_opt`,`id_agent`,`code_option`,`anneeScoalire`) VALUES
(3,'KAMU 1/ 2023','COGE',2);
/*!40000 ALTER TABLE `affecter_agent_options` ENABLE KEYS */;

-- 
-- Definition of affecter_cours
-- 

DROP TABLE IF EXISTS `affecter_cours`;
CREATE TABLE IF NOT EXISTS `affecter_cours` (
  `id_affecter_cours` int(11) NOT NULL AUTO_INCREMENT,
  `nbre_heures` decimal(10,0) DEFAULT NULL,
  `ponderation` int(11) DEFAULT NULL,
  `code_option` varchar(15) DEFAULT NULL,
  `code_class` varchar(10) DEFAULT NULL,
  `id_annee_scol` int(11) DEFAULT NULL,
  `num_secope` varchar(20) DEFAULT NULL,
  `cours` varchar(10) NOT NULL,
  PRIMARY KEY (`id_affecter_cours`),
  KEY `fk5` (`code_option`),
  KEY `fk6` (`code_class`),
  KEY `fk7` (`id_annee_scol`),
  KEY `fk8` (`num_secope`),
  KEY `FK_Affeter_cours` (`cours`),
  CONSTRAINT `affecter_cours_ibfk_1` FOREIGN KEY (`cours`) REFERENCES `courses` (`id_cours`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk5` FOREIGN KEY (`code_option`) REFERENCES `options` (`code_option`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk6` FOREIGN KEY (`code_class`) REFERENCES `classes` (`code_class`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk7` FOREIGN KEY (`id_annee_scol`) REFERENCES `school_year` (`id_annee_scol`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk8` FOREIGN KEY (`num_secope`) REFERENCES `school` (`num_secope`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table affecter_cours
-- 

/*!40000 ALTER TABLE `affecter_cours` DISABLE KEYS */;

/*!40000 ALTER TABLE `affecter_cours` ENABLE KEYS */;

-- 
-- Definition of agent
-- 

DROP TABLE IF EXISTS `agent`;
CREATE TABLE IF NOT EXISTS `agent` (
  `id_agent` varchar(20) NOT NULL,
  `noms_agent` varchar(100) DEFAULT NULL,
  `genre` varchar(15) DEFAULT NULL,
  `grade` varchar(20) DEFAULT NULL,
  `fonction` varchar(50) DEFAULT NULL,
  `phone` varchar(15) DEFAULT NULL,
  `num_secop` varchar(20) NOT NULL,
  PRIMARY KEY (`id_agent`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table agent
-- 

/*!40000 ALTER TABLE `agent` DISABLE KEYS */;
INSERT INTO `agent`(`id_agent`,`noms_agent`,`genre`,`grade`,`fonction`,`phone`,`num_secop`) VALUES
('KAMU 1/ 2023','KAMBALE MUHESI MUYISA','Masculin','GRADUE','TITULAIRE','0998562099','0090');
/*!40000 ALTER TABLE `agent` ENABLE KEYS */;

-- 
-- Definition of categorie_cote
-- 

DROP TABLE IF EXISTS `categorie_cote`;
CREATE TABLE IF NOT EXISTS `categorie_cote` (
  `id_categ_cote` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(50) DEFAULT NULL,
  `id_affecter_cours` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_categ_cote`),
  KEY `fk22` (`id_affecter_cours`),
  CONSTRAINT `fk22` FOREIGN KEY (`id_affecter_cours`) REFERENCES `affecter_cours` (`id_affecter_cours`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table categorie_cote
-- 

/*!40000 ALTER TABLE `categorie_cote` DISABLE KEYS */;

/*!40000 ALTER TABLE `categorie_cote` ENABLE KEYS */;

-- 
-- Definition of categorie_frais
-- 

DROP TABLE IF EXISTS `categorie_frais`;
CREATE TABLE IF NOT EXISTS `categorie_frais` (
  `id_categ_frais` int(11) NOT NULL AUTO_INCREMENT,
  `description_frais` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_categ_frais`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table categorie_frais
-- 

/*!40000 ALTER TABLE `categorie_frais` DISABLE KEYS */;
INSERT INTO `categorie_frais`(`id_categ_frais`,`description_frais`) VALUES
(3,'Frais Divers'),
(4,'Frais scolairs');
/*!40000 ALTER TABLE `categorie_frais` ENABLE KEYS */;

-- 
-- Definition of classes
-- 

DROP TABLE IF EXISTS `classes`;
CREATE TABLE IF NOT EXISTS `classes` (
  `code_class` varchar(10) NOT NULL,
  `description_class` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`code_class`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table classes
-- 

/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
INSERT INTO `classes`(`code_class`,`description_class`) VALUES
('2er A','Deuxième année A');
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;

-- 
-- Definition of cote_eleve
-- 

DROP TABLE IF EXISTS `cote_eleve`;
CREATE TABLE IF NOT EXISTS `cote_eleve` (
  `id_cote` int(11) NOT NULL AUTO_INCREMENT,
  `cote_obtenue` double DEFAULT NULL,
  `id_periode` int(11) DEFAULT NULL,
  `id_categ_cote` int(11) DEFAULT NULL,
  `id_inscription` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_cote`),
  KEY `fk10` (`id_periode`),
  KEY `fk11` (`id_categ_cote`),
  KEY `fk21` (`id_inscription`),
  CONSTRAINT `fk10` FOREIGN KEY (`id_periode`) REFERENCES `periode` (`id_periode`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk11` FOREIGN KEY (`id_categ_cote`) REFERENCES `categorie_cote` (`id_categ_cote`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk21` FOREIGN KEY (`id_inscription`) REFERENCES `inscrire` (`id_inscription`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table cote_eleve
-- 

/*!40000 ALTER TABLE `cote_eleve` DISABLE KEYS */;

/*!40000 ALTER TABLE `cote_eleve` ENABLE KEYS */;

-- 
-- Definition of courses
-- 

DROP TABLE IF EXISTS `courses`;
CREATE TABLE IF NOT EXISTS `courses` (
  `id_cours` varchar(10) NOT NULL,
  `descrption_cours` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id_cours`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table courses
-- 

/*!40000 ALTER TABLE `courses` DISABLE KEYS */;

/*!40000 ALTER TABLE `courses` ENABLE KEYS */;

-- 
-- Definition of depenses
-- 

DROP TABLE IF EXISTS `depenses`;
CREATE TABLE IF NOT EXISTS `depenses` (
  `id_depense` int(11) NOT NULL AUTO_INCREMENT,
  `date_depense` date DEFAULT NULL,
  `motif` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_depense`)
) ENGINE=InnoDB AUTO_INCREMENT=1934935983 DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table depenses
-- 

/*!40000 ALTER TABLE `depenses` DISABLE KEYS */;
INSERT INTO `depenses`(`id_depense`,`date_depense`,`motif`) VALUES
(4,'2024-01-14 00:00:00','FRAIS TECHN'),
(94290908,'2024-02-02 00:00:00','PRIME'),
(411235098,'2024-02-02 00:00:00','hhh'),
(562958614,'2024-02-02 00:00:00','ras'),
(790771876,'2024-02-03 00:00:00','ras'),
(942718290,'2024-02-02 00:00:00','RAS'),
(1529146713,'2024-02-02 00:00:00','paiement frais scolaire'),
(1749161781,'2024-02-02 00:00:00','tttt'),
(1934935982,'2024-02-02 00:00:00','Paiement des frais divers');
/*!40000 ALTER TABLE `depenses` ENABLE KEYS */;

-- 
-- Definition of frais
-- 

DROP TABLE IF EXISTS `frais`;
CREATE TABLE IF NOT EXISTS `frais` (
  `id_frais` int(11) NOT NULL AUTO_INCREMENT,
  `montant` decimal(10,0) DEFAULT NULL,
  `id_categ_frais` int(11) DEFAULT NULL,
  `num_secope` varchar(20) DEFAULT NULL,
  `code_option` varchar(15) DEFAULT NULL,
  `code_class` varchar(10) DEFAULT NULL,
  `id_annee_scol` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_frais`),
  KEY `fk12` (`id_categ_frais`),
  KEY `fk13` (`num_secope`),
  KEY `fk14` (`code_option`),
  KEY `fk15` (`code_class`),
  KEY `fk16` (`id_annee_scol`),
  CONSTRAINT `fk12` FOREIGN KEY (`id_categ_frais`) REFERENCES `categorie_frais` (`id_categ_frais`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk13` FOREIGN KEY (`num_secope`) REFERENCES `school` (`num_secope`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk14` FOREIGN KEY (`code_option`) REFERENCES `options` (`code_option`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk15` FOREIGN KEY (`code_class`) REFERENCES `classes` (`code_class`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk16` FOREIGN KEY (`id_annee_scol`) REFERENCES `school_year` (`id_annee_scol`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table frais
-- 

/*!40000 ALTER TABLE `frais` DISABLE KEYS */;

/*!40000 ALTER TABLE `frais` ENABLE KEYS */;

-- 
-- Definition of inscrire
-- 

DROP TABLE IF EXISTS `inscrire`;
CREATE TABLE IF NOT EXISTS `inscrire` (
  `id_inscription` int(11) NOT NULL AUTO_INCREMENT,
  `date_inscription` date DEFAULT NULL,
  `code_class` varchar(10) DEFAULT NULL,
  `code_option` varchar(15) DEFAULT NULL,
  `id_annee_scol` int(11) DEFAULT NULL,
  `num_secope` varchar(20) DEFAULT NULL,
  `student` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id_inscription`),
  KEY `fk1` (`code_class`),
  KEY `fk2` (`code_option`),
  KEY `fk3` (`id_annee_scol`),
  KEY `fk4` (`num_secope`),
  CONSTRAINT `fk1` FOREIGN KEY (`code_class`) REFERENCES `classes` (`code_class`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk2` FOREIGN KEY (`code_option`) REFERENCES `options` (`code_option`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk3` FOREIGN KEY (`id_annee_scol`) REFERENCES `school_year` (`id_annee_scol`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk4` FOREIGN KEY (`num_secope`) REFERENCES `school` (`num_secope`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table inscrire
-- 

/*!40000 ALTER TABLE `inscrire` DISABLE KEYS */;

/*!40000 ALTER TABLE `inscrire` ENABLE KEYS */;

-- 
-- Definition of mois
-- 

DROP TABLE IF EXISTS `mois`;
CREATE TABLE IF NOT EXISTS `mois` (
  `id_mois` int(11) NOT NULL AUTO_INCREMENT,
  `description_mois` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id_mois`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table mois
-- 

/*!40000 ALTER TABLE `mois` DISABLE KEYS */;
INSERT INTO `mois`(`id_mois`,`description_mois`) VALUES
(2,'Janvier'),
(3,'Février'),
(4,'Mars'),
(5,'Avril'),
(6,'Mai'),
(7,'Juin'),
(8,'Juillet');
/*!40000 ALTER TABLE `mois` ENABLE KEYS */;

-- 
-- Definition of options
-- 

DROP TABLE IF EXISTS `options`;
CREATE TABLE IF NOT EXISTS `options` (
  `code_option` varchar(15) NOT NULL,
  `description_option` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`code_option`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table options
-- 

/*!40000 ALTER TABLE `options` DISABLE KEYS */;
INSERT INTO `options`(`code_option`,`description_option`) VALUES
('COGE','Commerciales et Gestion');
/*!40000 ALTER TABLE `options` ENABLE KEYS */;

-- 
-- Definition of payement_frais
-- 

DROP TABLE IF EXISTS `payement_frais`;
CREATE TABLE IF NOT EXISTS `payement_frais` (
  `id_payement_frais` int(11) NOT NULL AUTO_INCREMENT,
  `date_paie` date DEFAULT NULL,
  `montant_paye` decimal(10,0) DEFAULT NULL,
  `devise` varchar(20) DEFAULT NULL,
  `taux` decimal(10,0) DEFAULT '0',
  `libelle` varchar(255) NOT NULL,
  `id_inscription` int(11) DEFAULT NULL,
  `cumule` decimal(10,0) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_payement_frais`),
  KEY `fk20` (`id_inscription`),
  CONSTRAINT `fk20` FOREIGN KEY (`id_inscription`) REFERENCES `inscrire` (`id_inscription`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table payement_frais
-- 

/*!40000 ALTER TABLE `payement_frais` DISABLE KEYS */;

/*!40000 ALTER TABLE `payement_frais` ENABLE KEYS */;

-- 
-- Definition of payement_prime_agent
-- 

DROP TABLE IF EXISTS `payement_prime_agent`;
CREATE TABLE IF NOT EXISTS `payement_prime_agent` (
  `id_prime` int(11) NOT NULL AUTO_INCREMENT,
  `montant_prime` decimal(10,0) DEFAULT NULL,
  `libelle` varchar(50) DEFAULT NULL,
  `id_agent` varchar(20) DEFAULT NULL,
  `id_mois` int(11) DEFAULT NULL,
  `id_annee_scol` int(11) DEFAULT NULL,
  `datePaiment` date NOT NULL,
  PRIMARY KEY (`id_prime`),
  KEY `fk29` (`id_annee_scol`),
  KEY `fk30` (`id_agent`),
  KEY `fk31` (`id_mois`),
  CONSTRAINT `fk29` FOREIGN KEY (`id_annee_scol`) REFERENCES `school_year` (`id_annee_scol`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk30` FOREIGN KEY (`id_agent`) REFERENCES `agent` (`id_agent`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk31` FOREIGN KEY (`id_mois`) REFERENCES `mois` (`id_mois`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table payement_prime_agent
-- 

/*!40000 ALTER TABLE `payement_prime_agent` DISABLE KEYS */;

/*!40000 ALTER TABLE `payement_prime_agent` ENABLE KEYS */;

-- 
-- Definition of periode
-- 

DROP TABLE IF EXISTS `periode`;
CREATE TABLE IF NOT EXISTS `periode` (
  `id_periode` int(11) NOT NULL AUTO_INCREMENT,
  `date_debut` date DEFAULT NULL,
  `date_fin` date DEFAULT NULL,
  `id_semestre` int(11) DEFAULT NULL,
  `description` varchar(100) NOT NULL,
  PRIMARY KEY (`id_periode`),
  KEY `fk9` (`id_semestre`),
  CONSTRAINT `fk9` FOREIGN KEY (`id_semestre`) REFERENCES `semestre` (`id_semestre`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table periode
-- 

/*!40000 ALTER TABLE `periode` DISABLE KEYS */;
INSERT INTO `periode`(`id_periode`,`date_debut`,`date_fin`,`id_semestre`,`description`) VALUES
(4,'2024-02-03 00:00:00','2024-03-24 00:00:00',2,'Iere periode');
/*!40000 ALTER TABLE `periode` ENABLE KEYS */;

-- 
-- Definition of school
-- 

DROP TABLE IF EXISTS `school`;
CREATE TABLE IF NOT EXISTS `school` (
  `num_secope` varchar(20) NOT NULL,
  `nom_ecole` varchar(150) DEFAULT NULL,
  `reseau` varchar(100) DEFAULT NULL,
  `pays` varchar(255) DEFAULT NULL,
  `province` varchar(255) NOT NULL,
  `ville_territoire` varchar(255) NOT NULL,
  `commune_chefferi` varchar(255) NOT NULL,
  PRIMARY KEY (`num_secope`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table school
-- 

/*!40000 ALTER TABLE `school` DISABLE KEYS */;
INSERT INTO `school`(`num_secope`,`nom_ecole`,`reseau`,`pays`,`province`,`ville_territoire`,`commune_chefferi`) VALUES
('0090','INSTITUT DE BUTEMBO','Public','RDC','NORD KIVU','BUTEMBO','VULAMBA');
/*!40000 ALTER TABLE `school` ENABLE KEYS */;

-- 
-- Definition of school_year
-- 

DROP TABLE IF EXISTS `school_year`;
CREATE TABLE IF NOT EXISTS `school_year` (
  `id_annee_scol` int(11) NOT NULL AUTO_INCREMENT,
  `description_annee` varchar(15) DEFAULT NULL,
  `reportNouveau` double DEFAULT NULL,
  PRIMARY KEY (`id_annee_scol`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table school_year
-- 

/*!40000 ALTER TABLE `school_year` DISABLE KEYS */;
INSERT INTO `school_year`(`id_annee_scol`,`description_annee`,`reportNouveau`) VALUES
(4,'2023 - 2025',NULL);
/*!40000 ALTER TABLE `school_year` ENABLE KEYS */;

-- 
-- Definition of semestre
-- 

DROP TABLE IF EXISTS `semestre`;
CREATE TABLE IF NOT EXISTS `semestre` (
  `id_semestre` int(11) NOT NULL AUTO_INCREMENT,
  `description_sem` varchar(30) DEFAULT NULL,
  `date_debut_sem` date DEFAULT NULL,
  `date_fin_sem` date DEFAULT NULL,
  PRIMARY KEY (`id_semestre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table semestre
-- 

/*!40000 ALTER TABLE `semestre` DISABLE KEYS */;
INSERT INTO `semestre`(`id_semestre`,`description_sem`,`date_debut_sem`,`date_fin_sem`) VALUES
(2,'Premier Timestre','2024-01-02 00:00:00','2024-01-31 00:00:00'),
(3,'Deuxième Trimestre','2024-01-31 00:00:00','2024-02-29 00:00:00');
/*!40000 ALTER TABLE `semestre` ENABLE KEYS */;

-- 
-- Definition of students
-- 

DROP TABLE IF EXISTS `students`;
CREATE TABLE IF NOT EXISTS `students` (
  `num_mat` varchar(10) NOT NULL,
  `stdnames` varchar(100) DEFAULT NULL,
  `genre` varchar(15) DEFAULT NULL,
  `lieu_naissance` varchar(30) DEFAULT NULL,
  `date_naissance` date DEFAULT NULL,
  `photo_eleve` text,
  `ecole_provenance` varchar(100) DEFAULT NULL,
  `religion` varchar(50) DEFAULT NULL,
  `adresse` varchar(150) DEFAULT NULL,
  `documents_deposes` varchar(200) DEFAULT NULL,
  `tuteur` varchar(100) DEFAULT NULL,
  `tele_tuteur` varchar(20) DEFAULT NULL,
  `noms_pere` varchar(100) DEFAULT NULL,
  `profession_pere` varchar(100) DEFAULT NULL,
  `noms_mere` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table students
-- 

/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students`(`num_mat`,`stdnames`,`genre`,`lieu_naissance`,`date_naissance`,`photo_eleve`,`ecole_provenance`,`religion`,`adresse`,`documents_deposes`,`tuteur`,`tele_tuteur`,`noms_pere`,`profession_pere`,`noms_mere`) VALUES
('HEKA1/2024','HERVAIN KATEMBO LIKO','Masculin ','BUTEMBO','2024-02-03 00:00:00','System.Byte[]','KATWA','CATHOLIQUE','MONDO','BULLETIN','RAS','0993254536','KAKULE','CULTIV','KAVIRA');
/*!40000 ALTER TABLE `students` ENABLE KEYS */;

-- 
-- Definition of users
-- 

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id_user` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(30) DEFAULT NULL,
  `password` varchar(20) DEFAULT NULL,
  `fonction` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table users
-- 

/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users`(`id_user`,`username`,`password`,`fonction`) VALUES
(5,'admin','1234','Pref');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- 
-- Dumping views
-- 

DROP TABLE IF EXISTS `caisse_depenses`;
DROP VIEW IF EXISTS `caisse_depenses`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `caisse_depenses` AS (select `school`.`num_secope` AS `num_secope`,`school`.`reseau` AS `reseau`,`school`.`pays` AS `pays`,`school`.`province` AS `province`,`school`.`ville_territoire` AS `ville_territoire`,`school`.`commune_chefferi` AS `commune_chefferi`,`categorie_frais`.`id_categ_frais` AS `id_categ_frais`,`categorie_frais`.`description_frais` AS `description_frais`,`school_year`.`id_annee_scol` AS `id_annee_scol`,`school_year`.`description_annee` AS `description_annee`,`mois`.`id_mois` AS `id_mois`,`mois`.`description_mois` AS `description_mois`,`aff_depenses`.`id_AffD` AS `id_AffD`,`aff_depenses`.`Date_AffD` AS `Date_AffD`,`aff_depenses`.`montant_affectD` AS `montant_affectD`,`semestre`.`id_semestre` AS `id_semestre`,`semestre`.`description_sem` AS `description_sem`,`depenses`.`id_depense` AS `id_depense`,`depenses`.`motif` AS `motif` from ((((((`school` join `school_year`) join `categorie_frais`) join `mois`) join `aff_depenses`) join `depenses`) join `semestre`) where ((`categorie_frais`.`id_categ_frais` = `aff_depenses`.`id_catF`) and (`school_year`.`id_annee_scol` = `aff_depenses`.`id_anneeS`) and (`mois`.`id_mois` = `aff_depenses`.`id_mois`) and (`semestre`.`id_semestre` = `aff_depenses`.`id_semestre`) and (`depenses`.`id_depense` = `aff_depenses`.`id_depense`)));

DROP TABLE IF EXISTS `caisse_recette`;
DROP VIEW IF EXISTS `caisse_recette`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `caisse_recette` AS (select `school`.`num_secope` AS `num_secope`,`school`.`reseau` AS `reseau`,`school`.`pays` AS `pays`,`school`.`province` AS `province`,`school`.`ville_territoire` AS `ville_territoire`,`school`.`commune_chefferi` AS `commune_chefferi`,`categorie_frais`.`id_categ_frais` AS `id_categ_frais`,`categorie_frais`.`description_frais` AS `description_frais`,`school_year`.`id_annee_scol` AS `id_annee_scol`,`school_year`.`description_annee` AS `description_annee`,`mois`.`id_mois` AS `id_mois`,`mois`.`description_mois` AS `description_mois`,`semestre`.`id_semestre` AS `id_semestre`,`semestre`.`description_sem` AS `description_sem`,`aff_frais`.`id_Aff` AS `id_Aff`,`aff_frais`.`montant_affect` AS `montant_affect`,`payement_frais`.`id_payement_frais` AS `id_payement_frais`,`payement_frais`.`libelle` AS `libelle` from ((((((`school` join `school_year`) join `categorie_frais`) join `mois`) join `aff_frais`) join `payement_frais`) join `semestre`) where ((`categorie_frais`.`id_categ_frais` = `aff_frais`.`id_catF`) and (`school_year`.`id_annee_scol` = `aff_frais`.`id_anneeS`) and (`mois`.`id_mois` = `aff_frais`.`id_mois`) and (`semestre`.`id_semestre` = `aff_frais`.`id_semestre`) and (`payement_frais`.`id_payement_frais` = `aff_frais`.`id_payement_frais`)));

DROP TABLE IF EXISTS `fiche_paie_student`;
DROP VIEW IF EXISTS `fiche_paie_student`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `fiche_paie_student` AS (select `school`.`num_secope` AS `num_secope`,`school`.`nom_ecole` AS `nom_ecole`,`school`.`pays` AS `pays`,`school`.`province` AS `province`,`school`.`reseau` AS `reseau`,`school`.`ville_territoire` AS `ville_territoire`,`school`.`commune_chefferi` AS `commune_chefferi`,`students`.`num_mat` AS `num_mat`,`students`.`stdnames` AS `stdnames`,`students`.`genre` AS `genre`,`students`.`lieu_naissance` AS `lieu_naissance`,`students`.`date_naissance` AS `date_naissance`,`students`.`photo_eleve` AS `photo_eleve`,`students`.`adresse` AS `adresse`,`inscrire`.`id_inscription` AS `id_inscription`,`school_year`.`id_annee_scol` AS `id_annee_scol`,`school_year`.`description_annee` AS `description_annee`,`classes`.`code_class` AS `code_class`,`classes`.`description_class` AS `description_class`,`options`.`code_option` AS `code_option`,`options`.`description_option` AS `description_option`,`payement_frais`.`id_payement_frais` AS `id_payement_frais`,`payement_frais`.`date_paie` AS `date_paie`,`payement_frais`.`libelle` AS `libelle`,`payement_frais`.`montant_paye` AS `montant_paye` from ((((((`school` join `students`) join `inscrire`) join `school_year`) join `payement_frais`) join `classes`) join `options`) where ((`school`.`num_secope` = `inscrire`.`num_secope`) and (`classes`.`code_class` = `inscrire`.`code_class`) and (`options`.`code_option` = `inscrire`.`code_option`) and (`students`.`num_mat` = `inscrire`.`student`) and (`inscrire`.`id_inscription` = `payement_frais`.`id_payement_frais`)));

DROP TABLE IF EXISTS `liste_des_eleves`;
DROP VIEW IF EXISTS `liste_des_eleves`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `liste_des_eleves` AS (select distinct `school`.`num_secope` AS `num_secope`,`school`.`nom_ecole` AS `nom_ecole`,`school`.`reseau` AS `reseau`,`school`.`pays` AS `pays`,`school`.`province` AS `province`,`school`.`ville_territoire` AS `ville_territoire`,`school`.`commune_chefferi` AS `commune_chefferi`,`students`.`num_mat` AS `num_mat`,`students`.`stdnames` AS `stdnames`,`students`.`genre` AS `genre`,`students`.`lieu_naissance` AS `lieu_naissance`,`students`.`date_naissance` AS `date_naissance`,`students`.`adresse` AS `adresse`,`inscrire`.`id_inscription` AS `id_inscription`,`inscrire`.`date_inscription` AS `date_inscription`,`inscrire`.`code_class` AS `code_class`,`inscrire`.`code_option` AS `code_option`,`school_year`.`id_annee_scol` AS `id_annee_scol`,`school_year`.`description_annee` AS `description_annee` from (((`students` join `inscrire`) join `school`) join `school_year`) where ((`students`.`num_mat` = `inscrire`.`student`) and (`school_year`.`id_annee_scol` = `inscrire`.`id_annee_scol`)));

DROP TABLE IF EXISTS `liste_paie`;
DROP VIEW IF EXISTS `liste_paie`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `liste_paie` AS (select `school`.`num_secope` AS `num_secope`,`school`.`nom_ecole` AS `nom_ecole`,`school`.`reseau` AS `reseau`,`school`.`pays` AS `pays`,`school`.`province` AS `province`,`school`.`ville_territoire` AS `ville_territoire`,`school`.`commune_chefferi` AS `commune_chefferi`,`agent`.`id_agent` AS `id_agent`,`agent`.`noms_agent` AS `noms_agent`,`agent`.`genre` AS `genre`,`agent`.`grade` AS `grade`,`agent`.`fonction` AS `fonction`,`payement_prime_agent`.`datePaiment` AS `datePaiment`,`payement_prime_agent`.`libelle` AS `libelle`,`payement_prime_agent`.`montant_prime` AS `montant_prime`,`mois`.`id_mois` AS `id_mois`,`mois`.`description_mois` AS `description_mois`,`school_year`.`description_annee` AS `description_annee` from ((((`agent` join `payement_prime_agent`) join `school_year`) join `mois`) join `school`) where ((`payement_prime_agent`.`id_mois` = `mois`.`id_mois`) and (`payement_prime_agent`.`id_annee_scol` = `school_year`.`id_annee_scol`) and (`payement_prime_agent`.`id_agent` = `agent`.`id_agent`)));

DROP TABLE IF EXISTS `solde_globale`;
DROP VIEW IF EXISTS `solde_globale`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `solde_globale` AS (select distinct `school`.`num_secope` AS `num_secope`,`school`.`reseau` AS `reseau`,`school`.`pays` AS `pays`,`school`.`province` AS `province`,`school`.`ville_territoire` AS `ville_territoire`,`school`.`commune_chefferi` AS `commune_chefferi`,`categorie_frais`.`id_categ_frais` AS `id_categ_frais`,`categorie_frais`.`description_frais` AS `description_frais`,`school_year`.`id_annee_scol` AS `id_annee_scol`,`school_year`.`description_annee` AS `description_annee`,`mois`.`id_mois` AS `id_mois`,`mois`.`description_mois` AS `description_mois`,`totrecettes`.`Recettes` AS `Recettes`,`totdepense`.`DepenseTotal` AS `DepenseTotal` from ((((((`aff_depenses` join `school_year`) join `mois`) join `categorie_frais`) join `totdepense`) join `totrecettes`) join `school`) where ((`categorie_frais`.`id_categ_frais` = `totrecettes`.`id_categ_frais`) and (`categorie_frais`.`id_categ_frais` = `totrecettes`.`id_categ_frais`) and (`school_year`.`id_annee_scol` = `totdepense`.`id_annee_scol`) and (`school_year`.`id_annee_scol` = `totrecettes`.`id_annee_scol`) and (`mois`.`id_mois` = `totdepense`.`id_mois`) and (`mois`.`id_mois` = `totrecettes`.`id_mois`)));

DROP TABLE IF EXISTS `totdepense`;
DROP VIEW IF EXISTS `totdepense`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `totdepense` AS (select sum(`aff_depenses`.`montant_affectD`) AS `DepenseTotal`,`categorie_frais`.`id_categ_frais` AS `id_categ_frais`,`categorie_frais`.`description_frais` AS `description_frais`,`school_year`.`id_annee_scol` AS `id_annee_scol`,`school_year`.`description_annee` AS `description_annee`,`mois`.`id_mois` AS `id_mois`,`mois`.`description_mois` AS `description_mois` from (((`aff_depenses` join `school_year`) join `mois`) join `categorie_frais`) where ((`school_year`.`id_annee_scol` = `aff_depenses`.`id_anneeS`) and (`mois`.`id_mois` = `aff_depenses`.`id_mois`) and (`aff_depenses`.`id_catF` = `categorie_frais`.`id_categ_frais`)) group by `school_year`.`id_annee_scol`,`mois`.`id_mois`,`categorie_frais`.`id_categ_frais`);

DROP TABLE IF EXISTS `totrecettes`;
DROP VIEW IF EXISTS `totrecettes`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `totrecettes` AS (select sum(`aff_frais`.`montant_affect`) AS `Recettes`,`categorie_frais`.`id_categ_frais` AS `id_categ_frais`,`categorie_frais`.`description_frais` AS `description_frais`,`school_year`.`id_annee_scol` AS `id_annee_scol`,`school_year`.`description_annee` AS `description_annee`,`mois`.`id_mois` AS `id_mois`,`mois`.`description_mois` AS `description_mois` from (((`aff_frais` join `school_year`) join `mois`) join `categorie_frais`) where ((`school_year`.`id_annee_scol` = `aff_frais`.`id_anneeS`) and (`mois`.`id_mois` = `aff_frais`.`id_mois`) and (`aff_frais`.`id_catF` = `categorie_frais`.`id_categ_frais`)) group by `school_year`.`id_annee_scol`,`mois`.`id_mois`,`categorie_frais`.`id_categ_frais`);



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2024-02-03 18:11:29
-- Total time: 0:0:0:0:752 (d:h:m:s:ms)
