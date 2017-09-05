-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: informatica industrial db
-- ------------------------------------------------------
-- Server version	5.5.57

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
-- Table structure for table `articulo`
--

DROP TABLE IF EXISTS `articulo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `articulo` (
  `numero_serie` int(11) NOT NULL,
  `idProducto` int(11) NOT NULL,
  `fecha_fabricacion` date NOT NULL,
  `fecha_caducidad` date NOT NULL,
  `estado` varchar(45) NOT NULL,
  `ubicacion` varchar(45) NOT NULL,
  `last_upd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `user_upd` int(11) NOT NULL,
  PRIMARY KEY (`numero_serie`,`idProducto`),
  KEY `idProductoA_idx` (`idProducto`),
  KEY `usser_updA_idx` (`user_upd`),
  CONSTRAINT `idProductoA` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `usser_updA` FOREIGN KEY (`user_upd`) REFERENCES `users` (`idUsers`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `articulo`
--

LOCK TABLES `articulo` WRITE;
/*!40000 ALTER TABLE `articulo` DISABLE KEYS */;
/*!40000 ALTER TABLE `articulo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conversion`
--

DROP TABLE IF EXISTS `conversion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conversion` (
  `U_medida_default` int(11) NOT NULL,
  `U_medida` int(11) NOT NULL,
  `Coeficiente` float NOT NULL,
  PRIMARY KEY (`U_medida_default`,`U_medida`),
  KEY `U_medida_idx` (`U_medida`),
  KEY `Secundaria` (`U_medida`,`U_medida_default`),
  CONSTRAINT `U_medida` FOREIGN KEY (`U_medida`) REFERENCES `unidad_medida` (`idUnidad_Medida`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `U_medida_default` FOREIGN KEY (`U_medida_default`) REFERENCES `unidad_medida` (`idUnidad_Medida`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conversion`
--

LOCK TABLES `conversion` WRITE;
/*!40000 ALTER TABLE `conversion` DISABLE KEYS */;
INSERT INTO `conversion` VALUES (1,3,0.0833333),(1,12,0.00694444),(1,13,0.001),(2,6,1000),(2,7,0.001),(5,4,100),(5,11,0.001),(8,9,10000);
/*!40000 ALTER TABLE `conversion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `direccion`
--

DROP TABLE IF EXISTS `direccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `direccion` (
  `idDireccion` int(11) NOT NULL AUTO_INCREMENT,
  `Calle` varchar(45) NOT NULL,
  `Numero` int(11) NOT NULL,
  `Barrio` varchar(45) NOT NULL,
  `Ciudad` varchar(45) NOT NULL,
  `Pais` varchar(45) NOT NULL,
  `CodigoPostal` int(11) NOT NULL,
  `Direccioncol` varchar(45) NOT NULL,
  PRIMARY KEY (`idDireccion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `direccion`
--

LOCK TABLES `direccion` WRITE;
/*!40000 ALTER TABLE `direccion` DISABLE KEYS */;
/*!40000 ALTER TABLE `direccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `externo`
--

DROP TABLE IF EXISTS `externo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `externo` (
  `idExterno` int(11) NOT NULL AUTO_INCREMENT,
  `idTipo_Externo` int(11) NOT NULL,
  `Description_id` int(11) NOT NULL,
  `CUIT` varchar(15) NOT NULL,
  `Direcion_id` int(11) NOT NULL,
  `Direcion_ent_id` int(11) NOT NULL,
  `Direcion_fac_id` int(11) NOT NULL,
  `Nac_Ext` varchar(45) NOT NULL,
  PRIMARY KEY (`idExterno`),
  KEY `Direccion_id_idx` (`Direcion_id`),
  KEY `Direcion_ent_id_idx` (`Direcion_ent_id`),
  KEY `Direccion_fac_id_idx` (`Direcion_fac_id`),
  KEY `idTipo_Externo_idx` (`idTipo_Externo`),
  CONSTRAINT `Direccion_fac_id` FOREIGN KEY (`Direcion_fac_id`) REFERENCES `direccion` (`idDireccion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Direccion_id` FOREIGN KEY (`Direcion_id`) REFERENCES `direccion` (`idDireccion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Direcion_ent_id` FOREIGN KEY (`Direcion_ent_id`) REFERENCES `direccion` (`idDireccion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idTipo_Externo` FOREIGN KEY (`idTipo_Externo`) REFERENCES `tipo_externo` (`idTipo_Externo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `externo`
--

LOCK TABLES `externo` WRITE;
/*!40000 ALTER TABLE `externo` DISABLE KEYS */;
INSERT INTO `externo` VALUES (1,1,3001,'20223750398',0,0,0,'N'),(2,1,3001,'20223732123',0,0,0,'N'),(3,1,3001,'27223732125',0,0,0,'N'),(4,2,3001,'12331441322',0,0,0,'E'),(5,2,3001,'12314546635',0,0,0,'N'),(6,2,3001,'12319996635',0,0,0,'N'),(7,2,3001,'44124124312',0,0,0,'N');
/*!40000 ALTER TABLE `externo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `language`
--

DROP TABLE IF EXISTS `language`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `language` (
  `idLanguage` int(11) NOT NULL AUTO_INCREMENT,
  `Language_Desc` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idLanguage`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `language`
--

LOCK TABLES `language` WRITE;
/*!40000 ALTER TABLE `language` DISABLE KEYS */;
INSERT INTO `language` VALUES (1,'Español'),(2,'Ingles');
/*!40000 ALTER TABLE `language` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movimiento`
--

DROP TABLE IF EXISTS `movimiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movimiento` (
  `ubicacion_origen` varchar(45) NOT NULL,
  `ubicacion_destino` varchar(45) NOT NULL,
  `idProducto` int(11) NOT NULL,
  `fecha_movimiento` date NOT NULL,
  `cantidad` float NOT NULL,
  `unidad_medida` int(11) NOT NULL,
  `idRazon` int(11) NOT NULL,
  PRIMARY KEY (`ubicacion_origen`,`fecha_movimiento`,`idProducto`,`ubicacion_destino`),
  KEY `idProductoM_idx` (`idProducto`),
  KEY `unidad_medidaM_idx` (`unidad_medida`),
  KEY `idRazonM_idx` (`idRazon`),
  CONSTRAINT `idProductoM` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idRazonM` FOREIGN KEY (`idRazon`) REFERENCES `razon` (`idRazon`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `unidad_medidaM` FOREIGN KEY (`unidad_medida`) REFERENCES `unidad_medida` (`idUnidad_Medida`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movimiento`
--

LOCK TABLES `movimiento` WRITE;
/*!40000 ALTER TABLE `movimiento` DISABLE KEYS */;
/*!40000 ALTER TABLE `movimiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `padre-componente-publicado`
--

DROP TABLE IF EXISTS `padre-componente-publicado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `padre-componente-publicado` (
  `idPadreP` int(11) NOT NULL,
  `idHijoP` int(11) NOT NULL,
  `Cantidad` float NOT NULL,
  `U_medida_default` int(11) NOT NULL,
  `U_medida_usada` int(11) NOT NULL,
  `fecha_aplicacion` int(6) NOT NULL,
  `last_upd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `user_upd` int(11) NOT NULL,
  `activado` tinyint(4) NOT NULL,
  `version` int(11) NOT NULL,
  PRIMARY KEY (`idPadreP`,`idHijoP`,`fecha_aplicacion`,`version`),
  KEY `idHijo_idx` (`idHijoP`),
  KEY `user_upd_idx` (`user_upd`),
  KEY `idPadreP_idx` (`idPadreP`),
  CONSTRAINT `idHijoP` FOREIGN KEY (`idHijoP`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idPadreP` FOREIGN KEY (`idPadreP`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `user_upd` FOREIGN KEY (`user_upd`) REFERENCES `users` (`idUsers`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `padre-componente-publicado`
--

LOCK TABLES `padre-componente-publicado` WRITE;
/*!40000 ALTER TABLE `padre-componente-publicado` DISABLE KEYS */;
INSERT INTO `padre-componente-publicado` VALUES (10056456,10056461,1,1,1,36,'2017-09-04 13:54:23',1,1,0),(10056456,10056461,1,1,1,36,'2017-09-04 13:54:23',1,1,1),(10056456,10056461,1,1,1,36,'2017-09-03 21:26:20',1,1,4),(10056456,10056461,1,1,1,37,'2017-09-04 13:54:23',1,1,2),(10056456,10056461,1,1,1,38,'2017-09-04 13:54:23',1,1,3),(10056456,10056467,1,1,1,36,'2017-09-04 13:56:51',1,1,4);
/*!40000 ALTER TABLE `padre-componente-publicado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `padre-componente-temporal`
--

DROP TABLE IF EXISTS `padre-componente-temporal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `padre-componente-temporal` (
  `idPadre` int(11) NOT NULL,
  `idHijo` int(11) NOT NULL,
  `Cantidad` float NOT NULL,
  `U_medida_default` int(11) NOT NULL,
  `U_medida_usada` int(11) NOT NULL,
  PRIMARY KEY (`idPadre`,`idHijo`),
  KEY `idHijo_idx` (`idHijo`),
  KEY `idPadre_idx` (`idPadre`),
  CONSTRAINT `idHijoT` FOREIGN KEY (`idHijo`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idPadreT` FOREIGN KEY (`idPadre`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `padre-componente-temporal`
--

LOCK TABLES `padre-componente-temporal` WRITE;
/*!40000 ALTER TABLE `padre-componente-temporal` DISABLE KEYS */;
INSERT INTO `padre-componente-temporal` VALUES (10056456,10056461,1,1,1);
/*!40000 ALTER TABLE `padre-componente-temporal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto` (
  `idProducto` int(11) NOT NULL AUTO_INCREMENT,
  `idDescriptionP` int(11) NOT NULL,
  `idTipo` int(11) NOT NULL,
  `Unidad_id_Purchase` int(11) NOT NULL,
  `Unidad_id_Aplication` int(11) NOT NULL,
  `Start_Date` date DEFAULT NULL,
  `End_Date` date DEFAULT NULL,
  `Last_Upd` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `User_Upd` int(11) DEFAULT NULL,
  `Codigo_abreviado` int(4) DEFAULT NULL,
  PRIMARY KEY (`idProducto`),
  KEY `idTipo_idx` (`idTipo`),
  KEY `Unidad_id_Purchase_idx` (`Unidad_id_Purchase`),
  KEY `Unidad_id_Aplication_idx` (`Unidad_id_Aplication`),
  KEY `idDescriptionP_idx` (`idDescriptionP`),
  CONSTRAINT `idDescriptionP` FOREIGN KEY (`idDescriptionP`) REFERENCES `traduccion` (`idDescriptionT`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idTipo` FOREIGN KEY (`idTipo`) REFERENCES `tipo_producto` (`idTipo_Producto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Unidad_id_Aplication` FOREIGN KEY (`Unidad_id_Aplication`) REFERENCES `unidad_medida` (`idUnidad_Medida`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Unidad_id_Purchase` FOREIGN KEY (`Unidad_id_Purchase`) REFERENCES `unidad_medida` (`idUnidad_Medida`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10056530 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (10056456,2001,1,1,1,'2009-01-01','2009-01-01','2017-09-05 02:50:18',1,1),(10056457,2002,1,1,1,'2009-01-02','2009-01-02','2017-09-05 02:50:18',1,2),(10056458,2003,1,1,1,'2009-01-03','2009-01-03','2017-09-05 02:50:18',1,3),(10056459,2004,1,1,1,'2009-01-04','2009-01-04','2017-09-05 02:50:18',1,4),(10056460,2005,1,1,1,'2009-01-05','2009-01-05','2017-09-05 02:50:18',1,5),(10056461,2006,2,1,1,'2009-01-06','2009-01-06','2017-09-05 02:50:18',1,6),(10056462,2007,2,1,1,'2009-01-07','2009-01-07','2017-09-05 02:50:18',1,7),(10056463,2008,2,1,1,'2009-01-08','2009-01-08','2017-09-05 02:50:18',1,8),(10056464,2009,2,1,1,'2009-01-09','2009-01-09','2017-09-05 02:50:18',1,9),(10056465,2010,2,1,1,'2009-01-10','2009-01-10','2017-09-05 02:50:18',1,10),(10056466,2011,2,1,1,'2009-01-11','2009-01-11','2017-09-05 02:50:18',1,11),(10056467,2012,2,1,1,'2009-01-12','2009-01-12','2017-09-05 02:50:18',1,12),(10056468,2013,2,1,1,'2009-01-13','2009-01-13','2017-09-05 02:50:18',1,13),(10056469,2014,2,1,1,'2009-01-14','2009-01-14','2017-09-05 02:50:18',1,14),(10056470,2015,2,1,1,'2009-01-15','2009-01-15','2017-09-05 02:50:18',1,15),(10056471,2016,2,1,1,'2009-01-16','2009-01-16','2017-09-05 02:50:18',1,16),(10056472,2017,2,1,1,'2009-01-17','2009-01-17','2017-09-05 02:50:18',1,17),(10056473,2018,3,1,1,'2009-01-18','2009-01-18','2017-09-05 02:50:18',1,18),(10056474,2019,3,1,1,'2009-01-19','2009-01-19','2017-09-05 02:50:18',1,19),(10056475,2020,3,1,1,'2009-01-20','2009-01-20','2017-09-05 02:50:18',1,20),(10056476,2021,3,1,1,'2009-01-21','2009-01-21','2017-09-05 02:50:18',1,21),(10056477,2022,3,1,1,'2009-01-22','2009-01-22','2017-09-05 02:50:18',1,22),(10056478,2023,3,1,1,'2009-01-23','2009-01-23','2017-09-05 02:50:18',1,23),(10056479,2024,4,1,1,'2009-01-24','2009-01-24','2017-09-05 02:50:18',1,24),(10056480,2025,4,1,1,'2009-01-25','2009-01-25','2017-09-05 02:50:18',1,25),(10056481,2026,4,1,1,'2009-01-26','2009-01-26','2017-09-05 02:50:18',1,26),(10056482,2027,4,1,1,'2009-01-27','2009-01-27','2017-09-05 02:50:18',1,27),(10056483,2028,4,1,1,'2009-01-28','2009-01-28','2017-09-05 02:50:18',1,28),(10056484,2029,4,1,1,'2009-01-29','2009-01-29','2017-09-05 02:50:18',1,29),(10056485,2030,1,12,12,'2009-01-30','2009-01-30','2017-09-05 02:50:18',1,30),(10056486,2031,1,12,12,'2009-01-31','2009-01-31','2017-09-05 02:50:18',1,31),(10056487,2032,1,12,12,'2009-02-01','2009-02-01','2017-09-05 02:50:18',1,32),(10056488,2033,1,12,12,'2009-02-02','2009-02-02','2017-09-05 02:52:22',1,33),(10056489,2034,1,1,1,'2009-02-03','2009-02-03','2017-09-05 02:52:22',1,34),(10056490,2035,1,1,1,'2009-02-04','2009-02-04','2017-09-05 02:52:22',1,35),(10056491,2036,1,1,1,'2009-02-05','2009-02-05','2017-09-05 02:52:22',1,36),(10056492,2037,1,1,1,'2009-02-06','2009-02-06','2017-09-05 02:52:22',1,37),(10056493,2038,1,1,1,'2009-02-07','2009-02-07','2017-09-05 02:52:22',1,38),(10056494,2039,1,1,1,'2009-02-08','2009-02-08','2017-09-05 02:52:22',1,39),(10056495,2040,1,5,5,'2009-02-09','2009-02-09','2017-09-05 02:52:22',1,40),(10056496,2041,1,2,2,'2009-02-10','2009-02-10','2017-09-05 02:52:22',1,41),(10056497,2042,1,2,2,'2009-02-11','2009-02-11','2017-09-05 02:52:22',1,42),(10056498,2043,1,2,2,'2009-02-12','2009-02-12','2017-09-05 02:52:22',1,43),(10056499,2044,1,2,2,'2009-02-13','2009-02-13','2017-09-05 02:52:22',1,44),(10056500,2045,1,2,2,'2009-02-14','2009-02-14','2017-09-05 02:52:22',1,45),(10056501,2046,1,1,1,'2009-02-15','2009-02-15','2017-09-05 02:52:22',1,46),(10056502,2047,1,1,1,'2009-02-16','2009-02-16','2017-09-05 02:52:22',1,47),(10056503,2048,1,1,1,'2009-02-17','2009-02-17','2017-09-05 02:52:22',1,48),(10056504,2049,1,1,1,'2009-02-18','2009-02-18','2017-09-05 02:52:22',1,49),(10056505,2050,3,9,9,'2009-02-19','2009-02-19','2017-09-05 02:52:22',1,50),(10056506,2051,3,9,9,'2009-02-20','2009-02-20','2017-09-05 02:52:22',1,51),(10056507,2052,3,9,9,'2009-02-21','2009-02-21','2017-09-05 02:52:22',1,52),(10056508,2053,3,9,9,'2009-02-22','2009-02-22','2017-09-05 02:52:22',1,53),(10056509,2054,3,9,9,'2009-02-23','2009-02-23','2017-09-05 02:52:22',1,54),(10056510,2055,3,9,9,'2009-02-24','2009-02-24','2017-09-05 02:52:22',1,55),(10056511,2056,3,9,9,'2009-02-25','2009-02-25','2017-09-05 02:52:22',1,56),(10056512,2057,3,9,9,'2009-02-26','2009-02-26','2017-09-05 02:52:22',1,57),(10056513,2058,3,9,9,'2009-02-27','2009-02-27','2017-09-05 02:52:22',1,58),(10056514,2059,3,9,9,'2009-02-28','2009-02-28','2017-09-05 02:52:22',1,59),(10056515,2060,3,9,9,'2009-03-01','2009-03-01','2017-09-05 02:52:22',1,60),(10056516,2061,3,9,9,'2009-03-02','2009-03-02','2017-09-05 02:52:22',1,61),(10056517,2062,3,9,9,'2009-03-03','2009-03-03','2017-09-05 02:52:22',1,62),(10056518,2063,3,9,9,'2009-03-04','2009-03-04','2017-09-05 02:52:22',1,63),(10056519,2064,3,9,9,'2009-03-05','2009-03-05','2017-09-05 02:52:22',1,64),(10056520,2065,3,9,9,'2009-03-06','2009-03-06','2017-09-05 02:52:22',1,65),(10056521,2066,3,9,9,'2009-03-07','2009-03-07','2017-09-05 02:52:22',1,66),(10056522,2067,3,9,9,'2009-03-08','2009-03-08','2017-09-05 02:52:22',1,67),(10056523,2068,3,9,9,'2009-03-09','2009-03-09','2017-09-05 02:52:22',1,68),(10056524,2069,3,9,9,'2009-03-10','2009-03-10','2017-09-05 02:52:22',1,69),(10056525,2070,3,9,9,'2009-03-11','2009-03-11','2017-09-05 02:52:22',1,70),(10056526,2071,3,9,9,'2009-03-12','2009-03-12','2017-09-05 02:52:22',1,71),(10056527,2072,3,9,9,'2009-03-13','2009-03-13','2017-09-05 02:52:22',1,72),(10056528,2073,3,9,9,'2009-03-14','2009-03-14','2017-09-05 02:52:22',1,73),(10056529,2074,1,13,13,'2009-03-15','2009-03-15','2017-09-05 02:52:22',1,74);
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto-sustituto`
--

DROP TABLE IF EXISTS `producto-sustituto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto-sustituto` (
  `idPadre` int(11) NOT NULL,
  `idHijo` int(11) NOT NULL,
  `sustituto` int(11) NOT NULL,
  `last_upd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `user_upd` int(11) NOT NULL,
  `fecha_aplicacion` int(6) NOT NULL,
  `activado` tinyint(4) NOT NULL,
  `version` int(11) NOT NULL,
  PRIMARY KEY (`idPadre`,`idHijo`,`sustituto`,`fecha_aplicacion`,`version`),
  KEY `idPadrePS_idx` (`idPadre`),
  KEY `idHijoPS_idx` (`idHijo`),
  KEY `idSustitutoPS_idx` (`sustituto`),
  KEY `userPS_idx` (`user_upd`),
  CONSTRAINT `idHijoPS` FOREIGN KEY (`idHijo`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idPadrePS` FOREIGN KEY (`idPadre`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idSustitutoPS` FOREIGN KEY (`sustituto`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `userPS` FOREIGN KEY (`user_upd`) REFERENCES `users` (`idUsers`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto-sustituto`
--

LOCK TABLES `producto-sustituto` WRITE;
/*!40000 ALTER TABLE `producto-sustituto` DISABLE KEYS */;
INSERT INTO `producto-sustituto` VALUES (10056456,10056461,10056462,'2017-09-03 19:24:40',1,36,0,0),(10056456,10056461,10056462,'2017-09-03 21:21:23',1,36,0,1),(10056456,10056461,10056462,'2017-09-03 21:26:20',1,36,1,2),(10056457,10056467,10056468,'2017-09-03 21:26:50',1,36,1,0);
/*!40000 ALTER TABLE `producto-sustituto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `razon`
--

DROP TABLE IF EXISTS `razon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `razon` (
  `idRazon` int(11) NOT NULL AUTO_INCREMENT,
  `idDescripcion` int(11) NOT NULL,
  PRIMARY KEY (`idRazon`),
  KEY `idDescripcionR_idx` (`idDescripcion`),
  CONSTRAINT `idDescripcionR` FOREIGN KEY (`idDescripcion`) REFERENCES `traduccion` (`idDescriptionT`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `razon`
--

LOCK TABLES `razon` WRITE;
/*!40000 ALTER TABLE `razon` DISABLE KEYS */;
/*!40000 ALTER TABLE `razon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `remito`
--

DROP TABLE IF EXISTS `remito`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `remito` (
  `idRemito` int(11) NOT NULL AUTO_INCREMENT,
  `Cliente` int(11) NOT NULL,
  `Destino` varchar(45) NOT NULL,
  PRIMARY KEY (`idRemito`),
  KEY `Cliente_idx` (`Cliente`),
  CONSTRAINT `Cliente` FOREIGN KEY (`Cliente`) REFERENCES `externo` (`idExterno`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `remito`
--

LOCK TABLES `remito` WRITE;
/*!40000 ALTER TABLE `remito` DISABLE KEYS */;
/*!40000 ALTER TABLE `remito` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `remito_detalle`
--

DROP TABLE IF EXISTS `remito_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `remito_detalle` (
  `idRemito` int(11) NOT NULL,
  `idProducto` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  PRIMARY KEY (`idRemito`,`idProducto`),
  KEY `idProductoRD_idx` (`idProducto`),
  CONSTRAINT `idProductoRD` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idRemitoRD` FOREIGN KEY (`idRemito`) REFERENCES `remito` (`idRemito`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `remito_detalle`
--

LOCK TABLES `remito_detalle` WRITE;
/*!40000 ALTER TABLE `remito_detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `remito_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `role` (
  `idRole` int(11) NOT NULL AUTO_INCREMENT,
  `idDescriptionR` int(11) NOT NULL,
  PRIMARY KEY (`idRole`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,2075);
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stock` (
  `idProducto` int(11) NOT NULL,
  `Cantidad` float NOT NULL,
  `unidad_medida` int(11) NOT NULL,
  `last_upd` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `user_upd` int(11) NOT NULL,
  PRIMARY KEY (`idProducto`),
  KEY `User_updS_idx` (`user_upd`),
  CONSTRAINT `idProductoS` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `User_updS` FOREIGN KEY (`user_upd`) REFERENCES `users` (`idUsers`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_externo`
--

DROP TABLE IF EXISTS `tipo_externo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_externo` (
  `idTipo_Externo` int(11) NOT NULL AUTO_INCREMENT,
  `idDescriptionTE` int(11) NOT NULL,
  PRIMARY KEY (`idTipo_Externo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_externo`
--

LOCK TABLES `tipo_externo` WRITE;
/*!40000 ALTER TABLE `tipo_externo` DISABLE KEYS */;
INSERT INTO `tipo_externo` VALUES (1,1200),(2,1201);
/*!40000 ALTER TABLE `tipo_externo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_producto`
--

DROP TABLE IF EXISTS `tipo_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_producto` (
  `idTipo_Producto` int(11) NOT NULL AUTO_INCREMENT,
  `idDescriptionTP` int(11) NOT NULL,
  PRIMARY KEY (`idTipo_Producto`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_producto`
--

LOCK TABLES `tipo_producto` WRITE;
/*!40000 ALTER TABLE `tipo_producto` DISABLE KEYS */;
INSERT INTO `tipo_producto` VALUES (1,1001),(2,1002),(3,1003),(4,1004);
/*!40000 ALTER TABLE `tipo_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `traduccion`
--

DROP TABLE IF EXISTS `traduccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `traduccion` (
  `idDescriptionT` int(11) NOT NULL,
  `idLanguageT` int(11) NOT NULL,
  `Traduccion_str` varchar(45) NOT NULL,
  PRIMARY KEY (`idDescriptionT`,`idLanguageT`),
  KEY `idLanguageT_idx` (`idLanguageT`),
  KEY `descripcion_idx` (`Traduccion_str`),
  CONSTRAINT `idLanguageT` FOREIGN KEY (`idLanguageT`) REFERENCES `language` (`idLanguage`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `traduccion`
--

LOCK TABLES `traduccion` WRITE;
/*!40000 ALTER TABLE `traduccion` DISABLE KEYS */;
INSERT INTO `traduccion` VALUES (1022,1,'A'),(1022,2,'A'),(2010,2,'Aglo wood'),(2037,1,'Antideslizante Goma 1'),(2038,1,'Antideslizante Goma 3'),(2039,1,'Antideslizante Goma 3'),(2037,2,'Antiskid Rubber 1'),(2028,2,'Bar B Aglo'),(2026,2,'Bar B Oak'),(2024,2,'Bar B Pino'),(2029,2,'Bar B Plate'),(2027,2,'Bar B Smooth'),(2028,1,'Barra B Aglo'),(2025,1,'Barra B Caoba'),(2027,1,'Barra B Liso'),(2024,1,'Barra B Pino'),(2029,1,'Barra B Placa'),(2026,1,'Barra B Roble'),(2041,2,'Blue paint'),(1004,1,'Bruto'),(2016,1,'Cinta Borde Aglo'),(2013,1,'Cinta Borde Caoba'),(2015,1,'Cinta Borde Liso'),(2012,1,'Cinta Borde Pino'),(2017,1,'Cinta Borde Placa'),(2014,1,'Cinta Borde Roble'),(2074,1,'Clavo Cajonero'),(1201,2,'Client'),(1201,1,'Cliente'),(1013,1,'Cm'),(1013,2,'Cm'),(1018,1,'cm2'),(1018,2,'cm2'),(1015,1,'cm3'),(1015,2,'cm3'),(2023,2,'cover Plate'),(2075,1,'Desarrollador'),(2003,2,'desk 2x1'),(2004,2,'desktop 1x30'),(2075,2,'developer'),(1019,1,'Dl'),(1019,2,'Dl'),(1012,1,'Docena'),(1012,2,'Dozen'),(2013,2,'Edge Ribbon Mahogany'),(2016,2,'Edge tape Aglo'),(2014,2,'Edge tape Oak'),(2004,1,'Escritorio 1x30'),(2003,1,'Escritorio 2x1'),(2005,1,'Escritorio Exec'),(2005,2,'Exec desktop'),(1001,2,'Final product'),(2072,2,'Front side Aglo'),(2069,2,'Front Side Mahogany'),(2068,2,'Front side Pino'),(2073,2,'Front Side Plate'),(2070,2,'Front side Roble'),(2071,2,'Front Side Smooth'),(2043,2,'Gray paint'),(2042,2,'Green paint'),(1021,1,'Ha'),(1021,2,'Ha'),(2048,2,'hardware C'),(2046,1,'Herraje A'),(2047,1,'Herraje B'),(2048,1,'Herraje C'),(2049,1,'Herraje D'),(1002,2,'intermediate Buy'),(1003,2,'intermediate Make'),(1002,1,'Intermedio Buy'),(1003,1,'Intermedio Make'),(1020,1,'Km'),(1020,2,'Km'),(2045,1,'Laca Brillante'),(2045,2,'Laca Brillante'),(2044,1,'Laca Opaca'),(2066,2,'Lateral Aglo Fund'),(2054,1,'Lateral Derecho Aglo'),(2051,1,'Lateral Derecho Caoba'),(2053,1,'Lateral Derecho Liso'),(2050,1,'Lateral Derecho Pino'),(2055,1,'Lateral Derecho Placa'),(2052,1,'Lateral Derecho Roble'),(2066,1,'Lateral Fondo Aglo'),(2063,1,'Lateral Fondo Caoba'),(2065,1,'Lateral Fondo Liso'),(2062,1,'Lateral Fondo Pino'),(2067,1,'Lateral Fondo Placa'),(2064,1,'Lateral Fondo Roble'),(2072,1,'Lateral Frente Aglo'),(2069,1,'Lateral Frente Caoba'),(2071,1,'Lateral Frente Liso'),(2068,1,'Lateral Frente Pino'),(2073,1,'Lateral Frente Placa'),(2070,1,'Lateral Frente Roble'),(2060,1,'Lateral Izquierdo Aglo'),(2057,1,'Lateral Izquierdo Caoba'),(2059,1,'Lateral Izquierdo Liso'),(2056,1,'Lateral Izquierdo Pino'),(2061,1,'Lateral Izquierdo Placa'),(2058,1,'Lateral Izquierdo Roble'),(2064,2,'Lateral Oak Fund'),(2062,2,'Lateral Pino Fund'),(2065,2,'Lateral plain background'),(2060,2,'Left side Aglo'),(2057,2,'Left Side Mahogany'),(2056,2,'Left side Pino'),(2061,2,'Left Side plate'),(2058,2,'Left side Roble'),(1011,2,'Liter'),(1011,1,'Litro'),(2033,2,'Long screw'),(1014,1,'M'),(1014,2,'M'),(1017,1,'m2'),(1017,2,'m2'),(1016,1,'m3'),(1016,2,'m3'),(2010,1,'Madera Aglo'),(2007,1,'Madera Caoba'),(2009,1,'Madera Liso'),(2006,1,'Madera Pino'),(2011,1,'Madera Placa'),(2008,1,'Madera Roble'),(2019,2,'Mahogany'),(2025,2,'Mahogany Bar B'),(2051,2,'Mahogany Right Wing'),(2063,2,'Mahogany Side Fund'),(2007,2,'Mahogany wood'),(2002,1,'Mesa Redonda'),(2001,1,'Mesa Tubular'),(1010,2,'N Number'),(1010,1,'N Numero'),(2074,2,'nail cajonero'),(2008,2,'Oak wood'),(2044,2,'Opaque Laca'),(2012,2,'Pine Edge Tape'),(2006,2,'Pine wood'),(2018,2,'Pino top'),(2041,1,'Pintura Azul'),(2043,1,'Pintura Gris'),(2042,1,'Pintura Verde'),(2017,2,'Plate Edge Tape'),(1004,2,'product Gross'),(1001,1,'Producto Final'),(1200,1,'Proveedor'),(1200,2,'Provider'),(2055,2,'Right Side Plate'),(2054,2,'Right Wing Aglo'),(2052,2,'Right Wing Oak'),(2050,2,'Right Wing Pino'),(2002,2,'Round table'),(2038,2,'Rubber nonslip 3'),(2039,2,'Rubber nonslip 3'),(2030,2,'Screws secured C'),(2031,2,'Screws secured L'),(2046,2,'shoeing A'),(2047,2,'shoeing B'),(2049,2,'shoeing D'),(2032,2,'Short screw'),(2067,2,'Side plate Fund'),(2059,2,'Smooth Left Side'),(2021,2,'Smooth top'),(2009,2,'Smooth wood'),(2035,1,'Soporte T 1'),(2036,1,'Soporte T 1 -1/2'),(2034,1,'Soporte T ½'),(2015,2,'Straight Edge Tape'),(2053,2,'Straight Right Side'),(2030,1,'Sujeta Tornillos C'),(2031,1,'Sujeta Tornillos L'),(2035,2,'Support T 1'),(2036,2,'Support T 1 -1/2'),(2034,2,'Support T ½'),(2022,1,'Tapa Aglo'),(2019,1,'Tapa Caoba'),(2021,1,'Tapa Liso'),(2018,1,'Tapa Pino'),(2023,1,'Tapa Placa'),(2020,1,'Tapa Roble'),(2022,2,'top Aglo'),(2020,2,'top Oak'),(2032,1,'Tornillo Corto'),(2033,1,'Tornillo Largo'),(2040,2,'Tube 6/8 \"'),(2040,1,'Tubo 6/8\"'),(2001,2,'Tubular table'),(2011,2,'wood Stove');
/*!40000 ALTER TABLE `traduccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidad_medida`
--

DROP TABLE IF EXISTS `unidad_medida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unidad_medida` (
  `idUnidad_Medida` int(11) NOT NULL AUTO_INCREMENT,
  `idDescriptionUM` int(11) NOT NULL,
  `Factor_N` int(11) NOT NULL,
  PRIMARY KEY (`idUnidad_Medida`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidad_medida`
--

LOCK TABLES `unidad_medida` WRITE;
/*!40000 ALTER TABLE `unidad_medida` DISABLE KEYS */;
INSERT INTO `unidad_medida` VALUES (1,1010,1),(2,1011,1),(3,1012,12),(4,1013,1),(5,1014,1),(6,1015,1),(7,1016,1),(8,1017,1),(9,1018,1),(10,1019,1),(11,1020,1),(12,1021,144),(13,1022,1000);
/*!40000 ALTER TABLE `unidad_medida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `idUsers` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `Sector` varchar(45) NOT NULL,
  `idRole` int(11) NOT NULL,
  `Interno` varchar(15) NOT NULL,
  `Mail` varchar(45) NOT NULL,
  `idLanguage` int(11) NOT NULL,
  `Password` varchar(30) NOT NULL,
  PRIMARY KEY (`idUsers`),
  KEY `idRole_idx` (`idRole`),
  KEY `idLanguage_idx` (`idLanguage`),
  KEY `mail&pass_idx` (`Mail`,`Password`),
  KEY `pass&mail_idx` (`Password`,`Mail`),
  CONSTRAINT `idLanguage` FOREIGN KEY (`idLanguage`) REFERENCES `language` (`idLanguage`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idRole` FOREIGN KEY (`idRole`) REFERENCES `role` (`idRole`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Matias','Cassanelli','sw',1,'3512253697','mati@gmail.com',1,'mati'),(2,'Felipe','Toledo','sw',1,'3516581627','feli@gmail.com',2,'feli');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-09-04 23:52:44
