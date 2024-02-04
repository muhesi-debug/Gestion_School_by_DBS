-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: schooldb
-- ------------------------------------------------------
-- Server version	5.7.10-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `affecter_agent_options`
--

DROP TABLE IF EXISTS `affecter_agent_options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `affecter_agent_options` (
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `affecter_agent_options`
--

LOCK TABLES `affecter_agent_options` WRITE;
/*!40000 ALTER TABLE `affecter_agent_options` DISABLE KEYS */;
INSERT INTO `affecter_agent_options` VALUES (3,'KAMU 1/ 2023','COGE',2);
/*!40000 ALTER TABLE `affecter_agent_options` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `affecter_cours`
--

DROP TABLE IF EXISTS `affecter_cours`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `affecter_cours` (
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `affecter_cours`
--

LOCK TABLES `affecter_cours` WRITE;
/*!40000 ALTER TABLE `affecter_cours` DISABLE KEYS */;
/*!40000 ALTER TABLE `affecter_cours` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agent`
--

DROP TABLE IF EXISTS `agent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `agent` (
  `id_agent` varchar(20) NOT NULL,
  `noms_agent` varchar(100) DEFAULT NULL,
  `genre` varchar(15) DEFAULT NULL,
  `grade` varchar(20) DEFAULT NULL,
  `fonction` varchar(50) DEFAULT NULL,
  `phone` varchar(15) DEFAULT NULL,
  `num_secop` varchar(20) NOT NULL,
  PRIMARY KEY (`id_agent`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agent`
--

LOCK TABLES `agent` WRITE;
/*!40000 ALTER TABLE `agent` DISABLE KEYS */;
INSERT INTO `agent` VALUES ('KAMU 1/ 2023','KAMBALE MUHESI MUYISA','Masculin','GRADUE','TITULAIRE','0998562099','0090');
/*!40000 ALTER TABLE `agent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `caisse_depenses`
--

DROP TABLE IF EXISTS `caisse_depenses`;
/*!50001 DROP VIEW IF EXISTS `caisse_depenses`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `caisse_depenses` AS SELECT 
 1 AS `date_depense`,
 1 AS `id_depense`,
 1 AS `montant_depense`,
 1 AS `motif`,
 1 AS `observation`,
 1 AS `id_annee_scol`,
 1 AS `description_annee`,
 1 AS `reportNouveau`,
 1 AS `id_mois`,
 1 AS `description_mois`,
 1 AS `id_categ_frais`,
 1 AS `description_frais`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `categorie_cote`
--

DROP TABLE IF EXISTS `categorie_cote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categorie_cote` (
  `id_categ_cote` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(50) DEFAULT NULL,
  `id_affecter_cours` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_categ_cote`),
  KEY `fk22` (`id_affecter_cours`),
  CONSTRAINT `fk22` FOREIGN KEY (`id_affecter_cours`) REFERENCES `affecter_cours` (`id_affecter_cours`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorie_cote`
--

LOCK TABLES `categorie_cote` WRITE;
/*!40000 ALTER TABLE `categorie_cote` DISABLE KEYS */;
/*!40000 ALTER TABLE `categorie_cote` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categorie_frais`
--

DROP TABLE IF EXISTS `categorie_frais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categorie_frais` (
  `id_categ_frais` int(11) NOT NULL AUTO_INCREMENT,
  `description_frais` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_categ_frais`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorie_frais`
--

LOCK TABLES `categorie_frais` WRITE;
/*!40000 ALTER TABLE `categorie_frais` DISABLE KEYS */;
INSERT INTO `categorie_frais` VALUES (3,'Frais Divers'),(4,'Frais scolairs');
/*!40000 ALTER TABLE `categorie_frais` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classes`
--

DROP TABLE IF EXISTS `classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classes` (
  `code_class` varchar(10) NOT NULL,
  `description_class` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`code_class`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes`
--

LOCK TABLES `classes` WRITE;
/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
INSERT INTO `classes` VALUES ('1er A','Première année A'),('2er A','Deuxième année A');
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cote_eleve`
--

DROP TABLE IF EXISTS `cote_eleve`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cote_eleve` (
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cote_eleve`
--

LOCK TABLES `cote_eleve` WRITE;
/*!40000 ALTER TABLE `cote_eleve` DISABLE KEYS */;
/*!40000 ALTER TABLE `cote_eleve` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `courses`
--

DROP TABLE IF EXISTS `courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `courses` (
  `id_cours` varchar(10) NOT NULL,
  `descrption_cours` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id_cours`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
INSERT INTO `courses` VALUES ('Angl 3','Anglais'),('Comp 1','Comptabilité'),('Fran 2','Français');
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `depenses`
--

DROP TABLE IF EXISTS `depenses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `depenses` (
  `id_depense` int(11) NOT NULL AUTO_INCREMENT,
  `date_depense` date DEFAULT NULL,
  `motif` varchar(50) DEFAULT NULL,
  `montant_depense` double DEFAULT NULL,
  `id_categ_frais` int(11) DEFAULT NULL,
  `id_annee_scol` int(11) DEFAULT NULL,
  `id_user` int(11) DEFAULT NULL,
  `num_secop` varchar(20) NOT NULL,
  `observation` varchar(50) DEFAULT NULL,
  `mois` int(11) NOT NULL,
  PRIMARY KEY (`id_depense`),
  KEY `fk25` (`id_categ_frais`),
  KEY `fk26` (`id_annee_scol`),
  KEY `fk27` (`id_user`),
  KEY `num_secop` (`num_secop`),
  KEY `Ffk_dep_mois` (`mois`),
  CONSTRAINT `Ffk_dep_mois` FOREIGN KEY (`mois`) REFERENCES `mois` (`id_mois`),
  CONSTRAINT `depenses_ibfk_1` FOREIGN KEY (`num_secop`) REFERENCES `school` (`num_secope`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk25` FOREIGN KEY (`id_categ_frais`) REFERENCES `categorie_frais` (`id_categ_frais`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk26` FOREIGN KEY (`id_annee_scol`) REFERENCES `school_year` (`id_annee_scol`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk27` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `depenses`
--

LOCK TABLES `depenses` WRITE;
/*!40000 ALTER TABLE `depenses` DISABLE KEYS */;
INSERT INTO `depenses` VALUES (1,'2024-01-07','PAIEMENT PRIME',40,3,2,5,'0090','TAUX 2800 FC',2);
/*!40000 ALTER TABLE `depenses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `frais`
--

DROP TABLE IF EXISTS `frais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `frais` (
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `frais`
--

LOCK TABLES `frais` WRITE;
/*!40000 ALTER TABLE `frais` DISABLE KEYS */;
INSERT INTO `frais` VALUES (2,50,4,'0090','COGE','1er A',2),(4,50,4,'0090','COGE','2er A',2);
/*!40000 ALTER TABLE `frais` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inscrire`
--

DROP TABLE IF EXISTS `inscrire`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inscrire` (
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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inscrire`
--

LOCK TABLES `inscrire` WRITE;
/*!40000 ALTER TABLE `inscrire` DISABLE KEYS */;
INSERT INTO `inscrire` VALUES (4,'2024-01-02','1er A','COGE',2,'0090','KAMU1/2024'),(5,'2024-01-02','1er A','COGE',2,'0090','KANG2/2024'),(6,'2024-01-07','2er A','COGE',2,'0090','KAMU2/2024'),(7,'2024-01-07','2er A','COGE',2,'0090','KOMU3/2024'),(8,'2024-01-07','2er A','COGE',2,'0090','KOMU4/2024'),(9,'2024-01-07','1er A','COGE',2,'0090','MBMA5/2024'),(10,'2024-01-07','1er A','COGE',2,'0090','KKKK6/2024');
/*!40000 ALTER TABLE `inscrire` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mois`
--

DROP TABLE IF EXISTS `mois`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mois` (
  `id_mois` int(11) NOT NULL AUTO_INCREMENT,
  `description_mois` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id_mois`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mois`
--

LOCK TABLES `mois` WRITE;
/*!40000 ALTER TABLE `mois` DISABLE KEYS */;
INSERT INTO `mois` VALUES (2,'Janvier'),(3,'Février'),(4,'Mars'),(5,'Avril'),(6,'Mai'),(7,'Juin'),(8,'Juillet');
/*!40000 ALTER TABLE `mois` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `options`
--

DROP TABLE IF EXISTS `options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `options` (
  `code_option` varchar(15) NOT NULL,
  `description_option` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`code_option`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `options`
--

LOCK TABLES `options` WRITE;
/*!40000 ALTER TABLE `options` DISABLE KEYS */;
INSERT INTO `options` VALUES ('COGE','Commerciale et Gestion');
/*!40000 ALTER TABLE `options` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payement_frais`
--

DROP TABLE IF EXISTS `payement_frais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payement_frais` (
  `id_payement_frais` int(11) NOT NULL AUTO_INCREMENT,
  `date_paie` date DEFAULT NULL,
  `montant_paye` varchar(255) DEFAULT NULL,
  `devise` varchar(20) DEFAULT NULL,
  `taux` decimal(10,0) DEFAULT '0',
  `id_categ_frais` int(11) DEFAULT NULL,
  `id_frais` int(11) DEFAULT NULL,
  `id_semestre` int(11) DEFAULT NULL,
  `id_inscription` int(11) DEFAULT NULL,
  `mois` int(11) NOT NULL,
  `motif` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_payement_frais`),
  KEY `fk17` (`id_categ_frais`),
  KEY `fk18` (`id_frais`),
  KEY `fk19` (`id_semestre`),
  KEY `fk20` (`id_inscription`),
  KEY `mois` (`mois`),
  CONSTRAINT `fk17` FOREIGN KEY (`id_categ_frais`) REFERENCES `categorie_frais` (`id_categ_frais`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk18` FOREIGN KEY (`id_frais`) REFERENCES `frais` (`id_frais`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk19` FOREIGN KEY (`id_semestre`) REFERENCES `semestre` (`id_semestre`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk20` FOREIGN KEY (`id_inscription`) REFERENCES `inscrire` (`id_inscription`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_mois` FOREIGN KEY (`mois`) REFERENCES `mois` (`id_mois`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payement_frais`
--

LOCK TABLES `payement_frais` WRITE;
/*!40000 ALTER TABLE `payement_frais` DISABLE KEYS */;
INSERT INTO `payement_frais` VALUES (18,'2024-01-02','113.2076','Franc Congolais',2650,4,2,2,4,2,'Paiement');
/*!40000 ALTER TABLE `payement_frais` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payement_prime_agent`
--

DROP TABLE IF EXISTS `payement_prime_agent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payement_prime_agent` (
  `id_prime` int(11) NOT NULL AUTO_INCREMENT,
  `montant_prime` decimal(10,0) DEFAULT NULL,
  `libelle` varchar(50) DEFAULT NULL,
  `id_categ_frais` int(11) DEFAULT NULL,
  `id_agent` varchar(20) DEFAULT NULL,
  `id_mois` int(11) DEFAULT NULL,
  `id_annee_scol` int(11) DEFAULT NULL,
  `datePaiment` date NOT NULL,
  PRIMARY KEY (`id_prime`),
  KEY `fk28` (`id_categ_frais`),
  KEY `fk29` (`id_annee_scol`),
  KEY `fk30` (`id_agent`),
  KEY `fk31` (`id_mois`),
  CONSTRAINT `fk28` FOREIGN KEY (`id_categ_frais`) REFERENCES `categorie_frais` (`id_categ_frais`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk29` FOREIGN KEY (`id_annee_scol`) REFERENCES `school_year` (`id_annee_scol`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk30` FOREIGN KEY (`id_agent`) REFERENCES `agent` (`id_agent`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk31` FOREIGN KEY (`id_mois`) REFERENCES `mois` (`id_mois`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payement_prime_agent`
--

LOCK TABLES `payement_prime_agent` WRITE;
/*!40000 ALTER TABLE `payement_prime_agent` DISABLE KEYS */;
/*!40000 ALTER TABLE `payement_prime_agent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `periode`
--

DROP TABLE IF EXISTS `periode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `periode` (
  `id_periode` int(11) NOT NULL AUTO_INCREMENT,
  `date_debut` date DEFAULT NULL,
  `date_fin` date DEFAULT NULL,
  `id_semestre` int(11) DEFAULT NULL,
  `description` varchar(100) NOT NULL,
  PRIMARY KEY (`id_periode`),
  KEY `fk9` (`id_semestre`),
  CONSTRAINT `fk9` FOREIGN KEY (`id_semestre`) REFERENCES `semestre` (`id_semestre`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `periode`
--

LOCK TABLES `periode` WRITE;
/*!40000 ALTER TABLE `periode` DISABLE KEYS */;
INSERT INTO `periode` VALUES (3,'2024-01-02','2024-01-10',2,'Première période');
/*!40000 ALTER TABLE `periode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `rdepenses`
--

DROP TABLE IF EXISTS `rdepenses`;
/*!50001 DROP VIEW IF EXISTS `rdepenses`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `rdepenses` AS SELECT 
 1 AS `id_depense`,
 1 AS `date_depense`,
 1 AS `motif`,
 1 AS `montant_depense`,
 1 AS `id_mois`,
 1 AS `description_mois`,
 1 AS `id_categ_frais`,
 1 AS `description_frais`,
 1 AS `id_annee_scol`,
 1 AS `description_annee`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `rlivre`
--

DROP TABLE IF EXISTS `rlivre`;
/*!50001 DROP VIEW IF EXISTS `rlivre`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `rlivre` AS SELECT 
 1 AS `num_secope`,
 1 AS `nom_ecole`,
 1 AS `reseau`,
 1 AS `id_mois`,
 1 AS `description_mois`,
 1 AS `date_paie`,
 1 AS `id_payement_frais`,
 1 AS `montant_paye`,
 1 AS `id_depense`,
 1 AS `date_depense`,
 1 AS `motif`,
 1 AS `montant_depense`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `rrecettes`
--

DROP TABLE IF EXISTS `rrecettes`;
/*!50001 DROP VIEW IF EXISTS `rrecettes`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `rrecettes` AS SELECT 
 1 AS `id_payement_frais`,
 1 AS `date_paie`,
 1 AS `montant_paye`,
 1 AS `motif`,
 1 AS `id_categ_frais`,
 1 AS `description_frais`,
 1 AS `id_mois`,
 1 AS `description_mois`,
 1 AS `id_annee_scol`,
 1 AS `description_annee`,
 1 AS `id_inscription`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `school`
--

DROP TABLE IF EXISTS `school`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `school` (
  `num_secope` varchar(20) NOT NULL,
  `nom_ecole` varchar(150) DEFAULT NULL,
  `adresse_ecole` varchar(150) DEFAULT NULL,
  `reseau` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`num_secope`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `school`
--

LOCK TABLES `school` WRITE;
/*!40000 ALTER TABLE `school` DISABLE KEYS */;
INSERT INTO `school` VALUES ('0090','INSTITUT DE BUTEMBO','Comm Vulamba','Public');
/*!40000 ALTER TABLE `school` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `school_year`
--

DROP TABLE IF EXISTS `school_year`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `school_year` (
  `id_annee_scol` int(11) NOT NULL AUTO_INCREMENT,
  `description_annee` varchar(15) DEFAULT NULL,
  `reportNouveau` double DEFAULT NULL,
  PRIMARY KEY (`id_annee_scol`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `school_year`
--

LOCK TABLES `school_year` WRITE;
/*!40000 ALTER TABLE `school_year` DISABLE KEYS */;
INSERT INTO `school_year` VALUES (2,'2023 - 2024',NULL);
/*!40000 ALTER TABLE `school_year` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `semestre`
--

DROP TABLE IF EXISTS `semestre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `semestre` (
  `id_semestre` int(11) NOT NULL AUTO_INCREMENT,
  `description_sem` varchar(30) DEFAULT NULL,
  `date_debut_sem` date DEFAULT NULL,
  `date_fin_sem` date DEFAULT NULL,
  PRIMARY KEY (`id_semestre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `semestre`
--

LOCK TABLES `semestre` WRITE;
/*!40000 ALTER TABLE `semestre` DISABLE KEYS */;
INSERT INTO `semestre` VALUES (2,'Premier Timestre','2024-01-02','2024-01-31'),(3,'Deuxième Trimestre','2024-01-31','2024-02-29');
/*!40000 ALTER TABLE `semestre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES ('KAMU1/2024','KAMBALE MUHESI MUYISA','Masculin ','BUTEMBO','2022-12-01','System.Byte[]','EP MASIKILIZANO','CATHOLIQUE','NGERE','EO FR','MUHINDO','0995612077','MHINDO','Commerçant','KAVUGHO'),('KAMU2/2024','KAMBALE MUHESI MUYISA','Masculin ','BUTEMBO','2024-01-07','System.Drawing.Bitmap','EP MASIKILIZANO','CATHOLIQUE','Q. NGERE','EP FE','JEAN PIERRE','0998753753','JEAN PIERRE','COMMERCANT','KAVUGHO'),('KOMU3/2024','KOMBI MUSAYI ISHARA','Masculin ','BUTEMBO','2024-01-07','','EP KATWA','CATHOLIQUE','Q. KATWA','B1','K','0970734419','KAMBALE','C','KANYERE'),('KOMU4/2024','KOMBI MUSAYI ISHARA','Masculin ','BUTEMBO','2024-01-07','System.Drawing.Bitmap','EP KATWA','CATHOLIQUE','Q. KATWA','B1','K','0970734419','KAMBALE','C','KANYERE'),('MBMA5/2024','MBUSA MALONGA D','Masculin ','BUTEMBO','2024-01-07','','EP Mgr KAHONGYA','CATHOLIQUE','Q. KITULU','B2 CG','K','0819151963','K','K','K'),('KKKK6/2024','KAKULE MUMBE MBALE','Masculin ','KYONDO','2024-01-07','','EP KABENETE','PROTESTE','KATSYA','DD','','0987645266','KAMBALE','CULTIVATEUR','KAVUGHO');
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id_user` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(30) DEFAULT NULL,
  `password` varchar(20) DEFAULT NULL,
  `fonction` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (5,'admin','1234','Pref');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Final view structure for view `caisse_depenses`
--

/*!50001 DROP VIEW IF EXISTS `caisse_depenses`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `caisse_depenses` AS (select `depenses`.`date_depense` AS `date_depense`,`depenses`.`id_depense` AS `id_depense`,`depenses`.`montant_depense` AS `montant_depense`,`depenses`.`motif` AS `motif`,`depenses`.`observation` AS `observation`,`school_year`.`id_annee_scol` AS `id_annee_scol`,`school_year`.`description_annee` AS `description_annee`,`school_year`.`reportNouveau` AS `reportNouveau`,`mois`.`id_mois` AS `id_mois`,`mois`.`description_mois` AS `description_mois`,`categorie_frais`.`id_categ_frais` AS `id_categ_frais`,`categorie_frais`.`description_frais` AS `description_frais` from (((`depenses` join `school_year`) join `mois`) join `categorie_frais`) where ((`depenses`.`id_annee_scol` = `school_year`.`id_annee_scol`) and (`mois`.`id_mois` = `depenses`.`mois`) and (`categorie_frais`.`id_categ_frais` = `depenses`.`id_categ_frais`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `rdepenses`
--

/*!50001 DROP VIEW IF EXISTS `rdepenses`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`muhesi`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `rdepenses` AS (select `depenses`.`id_depense` AS `id_depense`,`depenses`.`date_depense` AS `date_depense`,`depenses`.`motif` AS `motif`,`depenses`.`montant_depense` AS `montant_depense`,`mois`.`id_mois` AS `id_mois`,`mois`.`description_mois` AS `description_mois`,`categorie_frais`.`id_categ_frais` AS `id_categ_frais`,`categorie_frais`.`description_frais` AS `description_frais`,`school_year`.`id_annee_scol` AS `id_annee_scol`,`school_year`.`description_annee` AS `description_annee` from (((`depenses` join `mois`) join `school_year`) join `categorie_frais`) where ((`depenses`.`mois` = `mois`.`id_mois`) and (`categorie_frais`.`id_categ_frais` = `depenses`.`id_categ_frais`) and (`school_year`.`id_annee_scol` = `depenses`.`id_annee_scol`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `rlivre`
--

/*!50001 DROP VIEW IF EXISTS `rlivre`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`muhesi`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `rlivre` AS (select `school`.`num_secope` AS `num_secope`,`school`.`nom_ecole` AS `nom_ecole`,`school`.`reseau` AS `reseau`,`mois`.`id_mois` AS `id_mois`,`mois`.`description_mois` AS `description_mois`,`payement_frais`.`date_paie` AS `date_paie`,`payement_frais`.`id_payement_frais` AS `id_payement_frais`,`payement_frais`.`montant_paye` AS `montant_paye`,`depenses`.`id_depense` AS `id_depense`,`depenses`.`date_depense` AS `date_depense`,`depenses`.`motif` AS `motif`,`depenses`.`montant_depense` AS `montant_depense` from (((`school` join `mois`) join `depenses`) join `payement_frais`) where ((`school`.`num_secope` = `depenses`.`num_secop`) and (`depenses`.`mois` = `mois`.`id_mois`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `rrecettes`
--

/*!50001 DROP VIEW IF EXISTS `rrecettes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`muhesi`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `rrecettes` AS (select `payement_frais`.`id_payement_frais` AS `id_payement_frais`,`payement_frais`.`date_paie` AS `date_paie`,`payement_frais`.`montant_paye` AS `montant_paye`,`payement_frais`.`motif` AS `motif`,`categorie_frais`.`id_categ_frais` AS `id_categ_frais`,`categorie_frais`.`description_frais` AS `description_frais`,`mois`.`id_mois` AS `id_mois`,`mois`.`description_mois` AS `description_mois`,`school_year`.`id_annee_scol` AS `id_annee_scol`,`school_year`.`description_annee` AS `description_annee`,`inscrire`.`id_inscription` AS `id_inscription` from (((((`payement_frais` join `categorie_frais`) join `mois`) join `school`) join `inscrire`) join `school_year`) where ((`payement_frais`.`motif` = `mois`.`id_mois`) and (`categorie_frais`.`id_categ_frais` = `payement_frais`.`id_categ_frais`) and (`inscrire`.`id_inscription` = `payement_frais`.`id_inscription`) and (`school_year`.`id_annee_scol` = `inscrire`.`id_annee_scol`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-11 20:27:38
