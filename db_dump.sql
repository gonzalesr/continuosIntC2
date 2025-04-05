-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: patient
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20241216184516_CreateDatabase','8.0.8'),('20241217141917_CreateDatabase1','8.0.8'),('20241218023655_patientMod','8.0.8'),('20241218054526_patientMod1','8.0.8'),('20241218064033_patientMod2','8.0.8'),('20241218155548_CreateDatabase2','8.0.8'),('20241218161102_CreateDatabase3','8.0.8'),('20241218161706_CreateDatabase4','8.0.8'),('20241218162032_CreateDatabase5','8.0.8'),('20241218220548_CreateDatabase6','8.0.8'),('20241218222446_CreateDatabase7','8.0.8');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `initialconsultation`
--

DROP TABLE IF EXISTS `initialconsultation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `initialconsultation` (
  `initialConsultationId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `patientId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `date` datetime(6) NOT NULL,
  `reason` varchar(250) NOT NULL,
  `observations` varchar(250) NOT NULL,
  PRIMARY KEY (`initialConsultationId`),
  KEY `IX_initialConsultation_patientId` (`patientId`),
  CONSTRAINT `FK_initialConsultation_patient_patientId` FOREIGN KEY (`patientId`) REFERENCES `patient` (`patientId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `initialconsultation`
--

LOCK TABLES `initialconsultation` WRITE;
/*!40000 ALTER TABLE `initialconsultation` DISABLE KEYS */;
INSERT INTO `initialconsultation` VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6','3fa85f64-5717-4562-b3fc-2c963f66afa6','2024-12-19 02:52:46.914000','MOTIVO CONSULTA INICIAL','OBSERVACION CONSULTA INICIAL');
/*!40000 ALTER TABLE `initialconsultation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patient`
--

DROP TABLE IF EXISTS `patient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patient` (
  `patientId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `name` varchar(250) NOT NULL,
  `birthDate` datetime(6) NOT NULL,
  `gender` varchar(250) NOT NULL,
  `email` varchar(250) NOT NULL,
  PRIMARY KEY (`patientId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patient`
--

LOCK TABLES `patient` WRITE;
/*!40000 ALTER TABLE `patient` DISABLE KEYS */;
INSERT INTO `patient` VALUES ('03be6986-26a1-4e83-bef7-2819fbdedeb6','Miss Roxanne Marvin','2023-08-28 06:33:10.400000','MALE','Isabel80@hotmail.com'),('14842a8e-1475-47d1-93f2-9da5b64f9445','Ruby Ernser','2025-01-10 04:16:26.960000','MALE','Sister_Pfeffer@gmail.com'),('24f360f3-346a-4ae4-a54d-39cae1e89ef4','Andy Krajcik','2022-02-03 12:36:43.937000','MALE','Myrl60@gmail.com'),('269d8e2c-1e91-454f-9423-c60db9023a55','Dr. Shari Mohr','2021-12-02 22:55:41.743000','MALE','Onie.Padberg41@gmail.com'),('277b6869-8867-4ac4-bc0e-cefd15298ad3','Jonathon Spinka','2022-06-12 04:29:56.268000','MALE','Charity.Bashirian@gmail.com'),('287cab22-4e8d-4ba0-83e3-d58cbc080dad','Penny Satterfield','2021-06-11 16:08:33.685000','MALE','Breanna_Cormier@hotmail.com'),('296f068d-020c-416e-92af-1e581dec72c2','Sheri Huels','2024-08-07 09:20:26.394000','MALE','Nathan89@gmail.com'),('2cbda2fa-bbfd-4061-aafd-ef6ffa410af8','Mario Brakus Jr.','2023-05-11 09:24:24.731000','MALE','Missouri85@hotmail.com'),('2d9700c4-fac2-4caa-9414-0221450517e4','Harvey Kessler','2022-11-10 15:38:51.415000','MALE','Corbin_MacGyver@hotmail.com'),('2da6842a-e008-4075-b4e6-d044d64ad4b1','Lorenzo Durgan','2024-06-21 15:59:51.629000','MALE','Reva_Dickinson86@yahoo.com'),('3bf11e14-9190-48c2-a5d3-3b2ace5b5a67','Rufus Breitenberg','2020-05-21 18:42:14.889000','MALE','Raymond_Ledner@yahoo.com'),('3cc69bbe-24d2-449f-bfa6-3c7b05df608e','Mr. Sandra Olson','2020-11-30 07:42:05.038000','MALE','Adelbert94@hotmail.com'),('3d9b31fd-7e13-4749-9f55-74ddaf4701f9','Kendra Rutherford','2020-04-05 20:18:21.814000','MALE','Bret26@yahoo.com'),('3fa85f63-5717-4562-b3fc-2c963f66afa6','GUIEDD','2025-02-02 23:30:47.485000','MALE','rg@sd.com'),('3fa85f63-5717-4562-b5fc-2c963f66af46','GUIEDD','2025-02-02 23:30:47.485000','MALE','rg@sd.com'),('3fa85f63-5717-4562-b5fc-2c963f66afa1','GUIEDD','2025-02-02 23:30:47.485000','MALE','rg@sd.com'),('3fa85f63-5717-4562-b5fc-2c963f66afa6','GUIEDD','2025-02-02 23:30:47.485000','MALE','rg@sd.com'),('3fa85f63-5717-4562-b5fc-2c963f66afa8','GUIEDD','2025-02-02 23:30:47.485000','MALE','rg@sd.com'),('3fa85f63-5717-4562-b5fc-2c963f66afa9','GUIEDD','2025-02-02 23:30:47.485000','MALE','rg@sd.com'),('3fa85f63-5717-4562-b5fc-2c963f66afb6','GUIEDD','2025-02-02 23:30:47.485000','MALE','rg@sd.com'),('3fa85f64-5717-4562-b3fc-2c963f66afa6','SAUL PINTO','2024-12-19 02:51:29.279000','MALE','rooo@dl.com'),('4e3dc593-710f-463a-96c6-8a7afff9f565','Miss Gilberto Goyette','2022-03-14 02:06:36.084000','MALE','Marilyne21@yahoo.com'),('4e60b7f2-c5f9-4597-9748-97c8a929caf1','Roger Becker','2022-06-04 07:28:55.313000','MALE','Javonte65@gmail.com'),('4f0ee8f0-ebe8-4010-90c7-a100001700a9','Amos Parker','2024-05-04 04:07:39.485000','MALE','Mohammad_Casper43@yahoo.com'),('58b11972-663a-4e72-b189-fd11d99554a3','Fred Collins','2020-12-29 06:46:32.836000','MALE','Ariane26@gmail.com'),('5ca752b7-5b32-41fe-97e9-b96b4414558f','Jaime Toy','2023-08-30 13:56:51.123000','MALE','Rafael.Maggio@hotmail.com'),('612dc96d-d60b-4316-8b98-3c24e5d04efa','Mr. Geraldine Kihn','2022-11-10 15:11:55.695000','MALE','Arlene.Krajcik25@yahoo.com'),('686cf707-de20-4ecf-b6b8-bd326c6d439b','Joan Boyle','2022-02-11 15:25:52.155000','MALE','Felipe_Bins@yahoo.com'),('6b61d4f4-62e4-4d33-8cd0-ef9a7a010ff7','Chester McLaughlin','2024-11-05 09:54:34.752000','MALE','Nelda81@hotmail.com'),('6d4854f6-1a78-4749-a8bc-8b6740879831','Glenn Kunde','2022-10-28 19:58:50.293000','MALE','Jaquelin_Parisian@hotmail.com'),('7c7861a8-1bc2-4c59-bf9e-756743db9b8d','Estelle Roob','2022-05-27 07:31:29.508000','MALE','Hailee96@hotmail.com'),('7dd1b35d-6b46-4f7f-8b30-814d8951a9ee','Walter McKenzie','2023-06-20 17:58:47.657000','MALE','Emmitt_Hammes@yahoo.com'),('85a8d827-ca7f-4a7f-bdb9-edc71de93aa8','Randall Heathcote','2024-07-15 04:20:06.854000','MALE','Mia.Kautzer@hotmail.com'),('875bc7fe-0aa6-4f4b-8836-6ca6b0f538c7','Essie Brown','2023-09-15 11:18:36.375000','MALE','Janet_Dicki59@yahoo.com'),('9a5259ca-cbb2-4f38-a7c3-c1f58230464f','Ron Collins','2020-09-12 22:41:34.292000','MALE','Amie_Schuppe@gmail.com'),('9ce285ef-6a83-4c0b-8649-1977af3005fb','Javier Blick','2023-11-10 01:27:45.217000','MALE','Trenton.Doyle@hotmail.com'),('9cfb2d89-774c-4e11-b555-97c670bc037c','Latoya Satterfield','2023-01-20 05:12:08.508000','MALE','Arlene21@yahoo.com'),('a4782540-e721-482e-8e91-c180f324fcbe','Tamara Stehr','2023-04-06 14:12:43.096000','MALE','Rodrick.Keebler@yahoo.com'),('af48b7c2-c4dc-44b1-afc3-f8f23c118ed6','Charles Botsford','2024-10-12 03:44:10.311000','MALE','Lenna.Lockman73@yahoo.com'),('b213c2f1-594b-4175-b88d-e4002d379901','Maurice Champlin','2023-08-25 01:54:19.162000','MALE','Sheridan_Lehner@hotmail.com'),('b2b77ee4-b1ce-4365-a7dc-6bb77097bf09','Kristi Koelpin','2020-12-28 18:24:45.731000','MALE','Erin31@hotmail.com'),('b4a5fbd2-bc6d-45ed-b29c-10335e0acc8c','Leslie Price','2022-09-05 10:44:36.108000','MALE','Lavon_Sporer@hotmail.com'),('b57399f4-b2fc-4d12-81b7-343903f8fc85','Henry Dicki','2024-09-27 04:38:14.160000','MALE','Osborne52@yahoo.com'),('b66bebe8-9d03-4c11-8d46-2b833a0002ec','Miranda Bogan','2024-05-30 06:21:41.082000','MALE','Benny36@gmail.com'),('d51284a1-636e-426c-b137-4f726f002907','Jeremy Hayes','2023-07-10 14:25:22.027000','MALE','Paige.Leffler@gmail.com'),('d775af23-67fa-4ffa-a789-6472fe5c3385','Blanche DuBuque','2022-12-12 20:09:24.400000','MALE','Kadin5@gmail.com'),('d8bb547e-2f37-4928-84ce-d8ba7d08f535','Kristopher Keeling','2023-11-11 02:36:12.771000','MALE','Autumn.Boyer@yahoo.com'),('ddc5baf9-97ea-49b7-9b73-54f64fefa606','Jennifer Marquardt','2022-04-04 09:14:05.613000','MALE','Neal.Ruecker@yahoo.com'),('e305255f-6c47-4fcf-a6a3-61e48c60469e','Kristin Feeney II','2023-08-20 12:03:50.137000','MALE','Timmy58@gmail.com'),('e55898de-1af1-4c6e-bf7c-0407d9a3c001','Dr. Vera Rolfson','2020-11-09 16:54:46.347000','MALE','Paul_Walker47@yahoo.com'),('ed182fe8-f391-4c87-8166-c0e4e01144e0','Emmett Friesen','2025-01-29 18:44:43.290000','MALE','Jeffery_Rau82@gmail.com'),('f462e6b5-56f5-4f3c-8d7f-5c2023c95249','Jacqueline Dooley','2021-07-12 22:08:55.933000','MALE','Lola_Kemmer@hotmail.com'),('f5978b57-a2dd-4582-893d-b2a69b1b2537','Eula Gottlieb','2024-09-30 04:28:01.345000','MALE','Elaina_Von1@yahoo.com'),('f97d8525-0485-44c2-bfb1-674f54ec7287','Santos Considine DVM','2021-03-03 02:51:25.124000','MALE','Walter_Nikolaus@yahoo.com'),('fc2a2c68-2c33-40ec-b3e1-8cbdfd27d3a0','Bertha Anderson','2021-11-18 16:05:18.429000','MALE','Tito59@hotmail.com'),('fd787773-01ba-4d21-ae8a-cc1538fac6d0','Tracy Hayes IV','2021-07-16 21:27:46.684000','MALE','Johan_Runolfsdottir@yahoo.com'),('ffdd5642-0bd6-47d7-988f-10519cb8e521','Steven Kulas V','2021-07-09 21:50:05.496000','MALE','Cordelia_Grimes89@gmail.com');
/*!40000 ALTER TABLE `patient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `periodicevaluation`
--

DROP TABLE IF EXISTS `periodicevaluation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `periodicevaluation` (
  `periodicEvaluationId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `patientId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `date` datetime(6) NOT NULL,
  `evaluationNotes` varchar(2000) NOT NULL,
  `weight` decimal(18,2) NOT NULL,
  `height` decimal(18,2) NOT NULL,
  `systolic` int(11) NOT NULL,
  `diastolic` int(11) NOT NULL,
  `heartRate` int(11) NOT NULL,
  PRIMARY KEY (`periodicEvaluationId`),
  KEY `IX_periodicEvaluation_patientId` (`patientId`),
  CONSTRAINT `FK_periodicEvaluation_patient_patientId` FOREIGN KEY (`patientId`) REFERENCES `patient` (`patientId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `periodicevaluation`
--

LOCK TABLES `periodicevaluation` WRITE;
/*!40000 ALTER TABLE `periodicevaluation` DISABLE KEYS */;
INSERT INTO `periodicevaluation` VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6','3fa85f64-5717-4562-b3fc-2c963f66afa6','2024-12-19 02:53:47.410000','NOTAS DE EVALUACIÓN DE PRUEBA',80.00,1.70,100,60,80);
/*!40000 ALTER TABLE `periodicevaluation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phone`
--

DROP TABLE IF EXISTS `phone`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phone` (
  `phoneId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `patientId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `number` varchar(250) NOT NULL,
  PRIMARY KEY (`phoneId`),
  KEY `IX_phone_patientId` (`patientId`),
  CONSTRAINT `FK_phone_patient_patientId` FOREIGN KEY (`patientId`) REFERENCES `patient` (`patientId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phone`
--

LOCK TABLES `phone` WRITE;
/*!40000 ALTER TABLE `phone` DISABLE KEYS */;
INSERT INTO `phone` VALUES ('018d1225-5024-49cf-b206-b9be4c3f3607','b2b77ee4-b1ce-4365-a7dc-6bb77097bf09','352-312-1707'),('0481eb2a-3dc3-47cc-8539-e38687cb7a83','d8bb547e-2f37-4928-84ce-d8ba7d08f535','530-613-2820'),('06aa79b9-08be-4780-99ce-3652eb8bc59e','b4a5fbd2-bc6d-45ed-b29c-10335e0acc8c','667-949-4002'),('07565371-85ff-4c00-9002-4ae6ce85c7ef','9a5259ca-cbb2-4f38-a7c3-c1f58230464f','419-485-2224'),('0922f124-29bc-48df-9dba-ece629ef8087','d775af23-67fa-4ffa-a789-6472fe5c3385','903-226-5677'),('0aa441b1-fad4-4def-ba3e-4c192d6051f3','6d4854f6-1a78-4749-a8bc-8b6740879831','393-673-0723'),('0bd453b2-dbe7-42cd-b059-e126d11bb225','3fa85f64-5717-4562-b3fc-2c963f66afa6','865543333'),('0dcd0d75-b84d-42a3-b4f3-ade0f67180e0','e55898de-1af1-4c6e-bf7c-0407d9a3c001','200-523-7445'),('0e610562-7991-4264-92e5-2d0890fac0a6','296f068d-020c-416e-92af-1e581dec72c2','875-633-5433'),('10b85a3f-afb1-4ea3-a400-7303cde41be4','58b11972-663a-4e72-b189-fd11d99554a3','290-344-8703'),('125bc1c0-b9d6-4536-9553-aa61f7ba637c','3fa85f63-5717-4562-b5fc-2c963f66afa1','43950'),('1745f972-81a1-4247-895d-c3882dfc68cb','3fa85f63-5717-4562-b5fc-2c963f66afa6','43950'),('18d27345-af7d-4cf4-aa6c-69a5a7031e6c','9cfb2d89-774c-4e11-b555-97c670bc037c','391-416-2510'),('19930b12-0ce2-4eaa-a6bf-77999a1048b5','b213c2f1-594b-4175-b88d-e4002d379901','478-568-4567'),('1be446c8-855f-4a24-b68e-e27002830d1a','9ce285ef-6a83-4c0b-8649-1977af3005fb','410-333-9662'),('1fc2f749-6a98-4bcd-89e9-aa1b43c358b1','3fa85f63-5717-4562-b5fc-2c963f66afa1','498239'),('215a2c02-c8f6-4c90-9bb3-6ef44901d066','14842a8e-1475-47d1-93f2-9da5b64f9445','330-862-2916'),('272926f5-a979-455c-8b9e-ddc495f11f5c','d51284a1-636e-426c-b137-4f726f002907','687-577-7509'),('2856f2fd-1481-4e21-846b-c2314a32f4d8','af48b7c2-c4dc-44b1-afc3-f8f23c118ed6','753-839-4791'),('2879df7a-e55b-47d5-afd0-ef21c5c54607','2da6842a-e008-4075-b4e6-d044d64ad4b1','515-404-2935'),('2aa2ba8d-4cfb-4874-9cfd-2da064e44f72','2cbda2fa-bbfd-4061-aafd-ef6ffa410af8','651-658-4302'),('2b77bb94-432b-4b1e-94b1-7a4aab9efc57','af48b7c2-c4dc-44b1-afc3-f8f23c118ed6','689-611-4945'),('2e8f8b83-7586-4ebe-a194-82999ec44bda','3cc69bbe-24d2-449f-bfa6-3c7b05df608e','794-640-0632'),('31aefe43-db38-4881-ad73-cc284e0685ac','2d9700c4-fac2-4caa-9414-0221450517e4','414-249-8208'),('31bf7d9b-0e92-4790-9a04-ddfd026b622a','287cab22-4e8d-4ba0-83e3-d58cbc080dad','417-516-8285'),('3584fef6-653d-4ae4-9d5a-7243ba7e2598','e305255f-6c47-4fcf-a6a3-61e48c60469e','517-931-9906'),('35f4d485-bac4-40cb-8d63-d170c170b177','85a8d827-ca7f-4a7f-bdb9-edc71de93aa8','788-257-3489'),('38393ebe-4f3a-4486-97bc-a8db0256ed69','14842a8e-1475-47d1-93f2-9da5b64f9445','966-969-6395'),('3c45d6f3-449f-4d4c-a81c-6961b6d9f7b0','3fa85f63-5717-4562-b5fc-2c963f66afa8','498239'),('410c7b84-b9f3-483a-923b-8cda053a4c40','7c7861a8-1bc2-4c59-bf9e-756743db9b8d','771-447-0829'),('43c36f4b-5454-4834-9e6e-f997300ea5c9','fd787773-01ba-4d21-ae8a-cc1538fac6d0','684-696-3656'),('43e5ca51-cb0e-4cac-a984-1e72c15767ca','875bc7fe-0aa6-4f4b-8836-6ca6b0f538c7','969-826-3106'),('45a4a8f1-86e1-40e7-948d-008fca5669bd','b66bebe8-9d03-4c11-8d46-2b833a0002ec','648-590-2446'),('48f5955b-0151-46c2-8a33-b1ca4fdfc595','ed182fe8-f391-4c87-8166-c0e4e01144e0','565-706-7440'),('49505f1c-f6ad-4621-bb01-341402ab30bb','3fa85f63-5717-4562-b5fc-2c963f66afa8','43950'),('4b65f9d0-715f-4112-a4e7-905ad6bdc032','4e3dc593-710f-463a-96c6-8a7afff9f565','558-477-3480'),('522c1ddc-edef-4282-9362-9cafebb54417','3cc69bbe-24d2-449f-bfa6-3c7b05df608e','262-754-2170'),('530ccf94-8b07-4ac6-bd36-b1debf99d902','a4782540-e721-482e-8e91-c180f324fcbe','553-737-9317'),('58c28d35-33c8-48bf-a97a-f80022068766','3fa85f64-5717-4562-b3fc-2c963f66afa6','80000866'),('5bc6baa6-faf9-4b1b-a447-f7e654133bc6','6d4854f6-1a78-4749-a8bc-8b6740879831','958-647-6473'),('602662da-d174-417a-8288-d489a142c78f','b57399f4-b2fc-4d12-81b7-343903f8fc85','214-594-3972'),('60acc481-986a-43b2-8aa2-eecc58715017','4e3dc593-710f-463a-96c6-8a7afff9f565','863-733-7044'),('60b108c1-5453-43f1-8cd9-b9b1587e1f9b','ddc5baf9-97ea-49b7-9b73-54f64fefa606','923-827-2736'),('623f32e0-0e6a-4d3e-bc2f-fe28451e02ea','2cbda2fa-bbfd-4061-aafd-ef6ffa410af8','307-714-0495'),('63409471-1653-408d-aeb4-80665f107a3f','3fa85f63-5717-4562-b5fc-2c963f66afa9','43950'),('6928df0f-4ee0-460b-bd2e-adba149b777e','2da6842a-e008-4075-b4e6-d044d64ad4b1','395-678-9898'),('6bd16df6-5537-4d0d-8809-a5e84d516b61','269d8e2c-1e91-454f-9423-c60db9023a55','224-843-7029'),('6c163398-fbda-46a0-8c85-d4aa76e4e668','03be6986-26a1-4e83-bef7-2819fbdedeb6','616-243-8857'),('6c74d205-6f78-475a-b1e8-1ab7b4efcceb','3fa85f63-5717-4562-b5fc-2c963f66afb6','43950'),('6c7d8dba-3faa-4b38-8b47-0eb083281531','d51284a1-636e-426c-b137-4f726f002907','628-551-8861'),('6f08aba2-b112-4dfb-a8bf-a3b07e40f0da','6b61d4f4-62e4-4d33-8cd0-ef9a7a010ff7','590-318-1469'),('71f02325-33b2-4ede-a6a3-3c1956614943','f462e6b5-56f5-4f3c-8d7f-5c2023c95249','996-913-0537'),('7451db39-c713-4977-a4ca-69c6a21c66cd','3bf11e14-9190-48c2-a5d3-3b2ace5b5a67','841-715-6090'),('74b4c19d-a341-4054-ae82-649680d80e69','4e60b7f2-c5f9-4597-9748-97c8a929caf1','285-547-1902'),('79dab9ea-c78f-40de-9d74-2f3362665f69','f97d8525-0485-44c2-bfb1-674f54ec7287','849-842-3119'),('7a0b37e5-9dd9-4dfa-809a-4224927c5bb7','3fa85f63-5717-4562-b5fc-2c963f66af46','43950'),('7d2e056f-9770-4074-810c-c0100a2b6a55','277b6869-8867-4ac4-bc0e-cefd15298ad3','532-343-5678'),('7d79470d-2a91-4b65-982c-919c06254e34','b213c2f1-594b-4175-b88d-e4002d379901','582-218-9647'),('7e20761b-5744-4808-914f-bd8f8406b820','686cf707-de20-4ecf-b6b8-bd326c6d439b','668-403-3491'),('7edd2eab-90a2-405e-833d-bc60ffa33f8a','9ce285ef-6a83-4c0b-8649-1977af3005fb','514-557-5664'),('8088adbb-d654-4ac4-9ef2-a6f3a2affc52','fc2a2c68-2c33-40ec-b3e1-8cbdfd27d3a0','564-285-3964'),('81b20ecb-2797-4767-830c-3c66e6a01711','3d9b31fd-7e13-4749-9f55-74ddaf4701f9','817-563-5057'),('8833582f-f215-4bb1-a5de-83e5017e1d10','3fa85f63-5717-4562-b5fc-2c963f66afa9','498239'),('8bccf6c8-bc8d-4701-b57a-04cc7636feee','b57399f4-b2fc-4d12-81b7-343903f8fc85','359-631-3842'),('8e64a206-d3b1-4b32-993e-25b4cb22c67c','03be6986-26a1-4e83-bef7-2819fbdedeb6','698-254-8715'),('8f032ea4-1ce0-4a06-96f0-3dcd150e19cd','f462e6b5-56f5-4f3c-8d7f-5c2023c95249','313-605-9830'),('9493d435-8aa3-4f89-aedd-6ed32a28b6cb','4f0ee8f0-ebe8-4010-90c7-a100001700a9','650-410-6493'),('96ae182a-00ee-44a6-a7a9-01d4e9449c60','e305255f-6c47-4fcf-a6a3-61e48c60469e','541-694-0477'),('9b0686df-5f26-4396-a7ac-6dc12fb06044','269d8e2c-1e91-454f-9423-c60db9023a55','645-281-7623'),('9c4e48af-811e-4fee-9605-966e8e5118ba','ffdd5642-0bd6-47d7-988f-10519cb8e521','623-736-9000'),('9d77753b-8128-4f43-92cb-29fac69fcd61','3fa85f63-5717-4562-b5fc-2c963f66afb6','498239'),('9defac96-3ded-4693-ab11-492dcb24993c','5ca752b7-5b32-41fe-97e9-b96b4414558f','271-352-8821'),('a1cf8e6d-5cdf-44e8-bc62-086ed0d6ff02','2d9700c4-fac2-4caa-9414-0221450517e4','617-906-5462'),('a299c8ec-dfa4-4e79-a310-2a2ef3816cfb','612dc96d-d60b-4316-8b98-3c24e5d04efa','899-882-1059'),('a37fd8bb-73d6-48b5-89e3-44b5be1fb7b2','ffdd5642-0bd6-47d7-988f-10519cb8e521','919-749-1475'),('a4750c12-0e26-4692-8a85-535bfa780fb7','b4a5fbd2-bc6d-45ed-b29c-10335e0acc8c','367-999-1709'),('a9f3f4d5-067f-4e3b-b408-ba7b37fc9daf','296f068d-020c-416e-92af-1e581dec72c2','709-379-1361'),('aa39c3a8-b8ce-4b6c-8a85-3f66cb68ea83','7dd1b35d-6b46-4f7f-8b30-814d8951a9ee','609-994-1218'),('ab885397-5459-4997-a038-fd391ba9c8d1','6b61d4f4-62e4-4d33-8cd0-ef9a7a010ff7','472-769-6049'),('b131c4b0-a2dc-4413-b8fe-d387d0704503','287cab22-4e8d-4ba0-83e3-d58cbc080dad','509-385-2017'),('b3780316-c09a-4a60-b551-60b9b8f774c0','3fa85f63-5717-4562-b3fc-2c963f66afa6','43950'),('b3bc1ba0-9974-48f0-b89c-1cfd1b8d5dce','3fa85f63-5717-4562-b3fc-2c963f66afa6','498239'),('b474a4b3-dda2-4227-bdd0-6ccd5d35d8f2','ed182fe8-f391-4c87-8166-c0e4e01144e0','593-401-5792'),('b4e08e24-2d51-404d-91df-73ad3f2da297','875bc7fe-0aa6-4f4b-8836-6ca6b0f538c7','790-876-8075'),('b6409545-2064-4f56-991d-5fa4dbcaeb90','b2b77ee4-b1ce-4365-a7dc-6bb77097bf09','937-670-4106'),('b71796c5-b969-45ff-9c86-26f07afc8599','a4782540-e721-482e-8e91-c180f324fcbe','670-460-0549'),('b71bbe1c-6d78-4280-b4b0-77eb3c8dbe9f','b66bebe8-9d03-4c11-8d46-2b833a0002ec','383-913-2840'),('b79e215e-95df-4692-adfd-93eed3d9a648','7dd1b35d-6b46-4f7f-8b30-814d8951a9ee','731-654-3793'),('bba4b7f9-0199-4f71-b1bf-21c4765697c2','4e60b7f2-c5f9-4597-9748-97c8a929caf1','439-409-0977'),('bdab7f9d-fc0a-4f73-a521-a77cc16cb223','4f0ee8f0-ebe8-4010-90c7-a100001700a9','952-457-2557'),('be1539b2-369b-4012-8ab7-0ca3a309f629','5ca752b7-5b32-41fe-97e9-b96b4414558f','859-930-6680'),('bff97c0f-9158-429e-a5d8-50bd1bf662b1','ddc5baf9-97ea-49b7-9b73-54f64fefa606','846-799-6242'),('cd7d2c3d-2a8f-4cf9-a3dd-debb64ea3907','3fa85f63-5717-4562-b5fc-2c963f66afa6','498239'),('cf2650d3-5cdc-4f72-83b8-b4fc2971a0fb','612dc96d-d60b-4316-8b98-3c24e5d04efa','797-881-6259'),('d208e8f7-b45d-4b4e-8083-45c206077088','9a5259ca-cbb2-4f38-a7c3-c1f58230464f','306-470-9658'),('d33e55b9-b4f2-4f0b-b367-434af7daa0a5','9cfb2d89-774c-4e11-b555-97c670bc037c','667-679-6261'),('d398b800-53ee-4db7-9725-5fdf6e435b2b','277b6869-8867-4ac4-bc0e-cefd15298ad3','355-417-7806'),('da227ed4-e575-4103-8d24-c7935c1962ae','3bf11e14-9190-48c2-a5d3-3b2ace5b5a67','892-957-0863'),('dcb037f0-7a59-435c-8ee4-ca4215c635b8','f97d8525-0485-44c2-bfb1-674f54ec7287','213-341-5903'),('df0ba34c-3dc5-423a-95d0-010a8ce255ab','d775af23-67fa-4ffa-a789-6472fe5c3385','314-706-4015'),('e21da8ac-46fb-4804-a303-0a52c0c97427','d8bb547e-2f37-4928-84ce-d8ba7d08f535','681-565-7519'),('e35d46b4-7e16-4b03-9f82-a740c2c67b28','f5978b57-a2dd-4582-893d-b2a69b1b2537','847-686-4316'),('e3906c97-ec96-4dd0-88a2-c2e664fde157','24f360f3-346a-4ae4-a54d-39cae1e89ef4','586-877-3067'),('e5d71b6e-51ff-4039-9f85-139c4a405a48','3fa85f63-5717-4562-b5fc-2c963f66af46','498239'),('e5f6d50f-1a26-4c16-9d5a-22184da2178d','f5978b57-a2dd-4582-893d-b2a69b1b2537','503-561-8921'),('e62e55b0-1c3e-4632-94e9-fb4fee5f4ca0','58b11972-663a-4e72-b189-fd11d99554a3','719-512-4235'),('ea3fc65e-45f5-4bb3-9424-e129ba8ace36','7c7861a8-1bc2-4c59-bf9e-756743db9b8d','337-512-9561'),('ed8e4c9b-15a7-4bdd-a318-86c28964e698','686cf707-de20-4ecf-b6b8-bd326c6d439b','732-467-1665'),('ee5bc875-8da5-40fb-8d97-147f0f381d4b','3d9b31fd-7e13-4749-9f55-74ddaf4701f9','266-472-7161'),('ef1e93bb-4056-4975-9486-39e8883edfda','fd787773-01ba-4d21-ae8a-cc1538fac6d0','267-824-6964'),('f72dcc50-fd47-454f-af74-4261bf25d522','fc2a2c68-2c33-40ec-b3e1-8cbdfd27d3a0','265-550-4000'),('f7882823-bd18-46d5-8d2c-b7ec7126fb5a','e55898de-1af1-4c6e-bf7c-0407d9a3c001','569-853-8363'),('f94fd631-765b-49a8-b16b-ff15fe564235','85a8d827-ca7f-4a7f-bdb9-edc71de93aa8','204-341-6998'),('fa4e8322-4d5c-41ca-abd2-571cca90205b','24f360f3-346a-4ae4-a54d-39cae1e89ef4','583-584-8038');
/*!40000 ALTER TABLE `phone` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `userId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `fullName` varchar(250) NOT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('0a1c4a95-24d1-4f24-864c-3176bfa67231','Tina Satterfield'),('1c4028ee-8b75-476f-b19a-0418859ee9b6','Lillian Crona'),('2dcc995a-90f9-4948-90eb-39cfed9ef7b4','Mr. Marshall Botsford'),('3af77312-bb1c-480c-8fbc-777fa6726d40','Harvey Christiansen MD'),('3fa85f64-5717-4562-b3fc-2c963f66afa6','string'),('6fcef409-4353-47c4-8495-43e3bbafbf68','Allan Johns'),('82843382-b8c1-4a84-a16c-ac89dd83851e','Mamie Ziemann'),('94f6b656-6139-41c7-a344-aa9b5398aa4a','Alexis Fritsch'),('b2c38d06-fba4-41bd-a189-c1b598bdf82f','Tony Bailey'),('dd2f1389-8cdf-4a87-9980-6fc690f1879e','Laurie Hyatt');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'patient'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-16  3:31:38
