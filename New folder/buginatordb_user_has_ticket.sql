-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: buginatordb
-- ------------------------------------------------------
-- Server version	8.0.18

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
-- Table structure for table `user_has_ticket`
--

DROP TABLE IF EXISTS `user_has_ticket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_has_ticket` (
  `User_has_TicketId` char(36) DEFAULT NULL,
  `UserTicketRole` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `User_UserId` char(36) NOT NULL,
  `Ticket_TicketId` char(36) NOT NULL,
  PRIMARY KEY (`User_UserId`,`Ticket_TicketId`),
  KEY `fk_User_has_Ticket_Ticket1_idx` (`Ticket_TicketId`),
  KEY `fk_User_has_Ticket_User1_idx` (`User_UserId`),
  CONSTRAINT `fk_User_has_Ticket_Ticket1` FOREIGN KEY (`Ticket_TicketId`) REFERENCES `ticket` (`TicketId`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_User_has_Ticket_User1` FOREIGN KEY (`User_UserId`) REFERENCES `user` (`UserId`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_has_ticket`
--

LOCK TABLES `user_has_ticket` WRITE;
/*!40000 ALTER TABLE `user_has_ticket` DISABLE KEYS */;
INSERT INTO `user_has_ticket` VALUES ('9a37c407-9acc-4e60-873f-97b2b5871cd9','\"Tester\"','0b46e617-d6c4-4cb3-b439-03853d549125','8f858ee6-615b-4693-8600-0395d40a9824'),('b5ae047e-e4cc-4f47-970d-656be129ab6b','\"Admin\"','24c08a58-d2f7-4b2e-b2f3-787ffae8e390','2ea7b900-15df-4c39-bd56-b08810f3e6ce');
/*!40000 ALTER TABLE `user_has_ticket` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-12-31 13:28:23
