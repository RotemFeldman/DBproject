-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: trivia
-- ------------------------------------------------------
-- Server version	8.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `questions` (
  `QuestionId` int NOT NULL AUTO_INCREMENT,
  `QuestionText` varchar(128) DEFAULT NULL,
  `Answer1Text` varchar(45) DEFAULT NULL,
  `Answer2Text` varchar(45) DEFAULT NULL,
  `Answer3Text` varchar(45) DEFAULT NULL,
  `Answer4Text` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`QuestionId`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
INSERT INTO `questions` VALUES (1,'How long is an Olympic swimming pool?','50 meters','25 meters','30 meters','40 meters'),(2,'Which country do cities of Perth, Adelade & Brisbane belong to?','Australia','Portugal','Spain','England'),(3,'Who named the Pacific Ocean?','Ferdinand Magellan','Christopher Columbus','James Cook','Henry Hudson'),(4,'Which animal can be seen on the Porsche logo?','Horse','Lion','Bull','Wolf'),(5,'What is the World\'s largest ocean?','Pacific Ocean','Atlantic Ocean','Arctic Ocean','Inidan Ocean'),(6,'Demolition of the Berlin wall separating East and West Germany began in what year?','1989','1985','1990','1992'),(7,'Which member of the Beatles married Yoko Ono?','John Lennon','Paul Mccartney','Ringo Starr','George Harrison'),(8,'The biggest selling music single of all time is?','Elton John -  Candle in the Wind ','Celine Dion - My Heart Will Go On','Ed Sheeran - Shape Of You','Adele - Rolling In The Deep'),(9,' What is Earth\'s largest continent?','Asia','Africa','North America','Antarctica'),(10,'What\'s the smallest country in the world?','Vatican ','Liechtenstein','Micronesia','Nauru');
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-16 19:34:43
