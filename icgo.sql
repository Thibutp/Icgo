-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost:3306
-- Généré le : ven. 09 mai 2025 à 08:40
-- Version du serveur : 5.7.39
-- Version de PHP : 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `icgo`
--

DELIMITER $$
--
-- Procédures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `verifierPlaces` (IN `codeCompetence` CHAR(3), IN `noStage` INT, IN `noSession` INT, OUT `dispo` INT)   BEGIN
    DECLARE nbInscrits INT;
    DECLARE nbPlaces INT;

    -- Compter le nombre de stagiaires inscrits pour la session
    SELECT COUNT(*) INTO nbInscrits
    FROM inscrire
    WHERE CODECOMPETENCE = codeCompetence
      AND NUMSTAGE = noStage
      AND NUMSESSION = noSession
      AND ETATINSCRIPTION = 'd';  -- On suppose que 'd' signifie inscrit

    -- Récupérer le nombre de places disponibles pour la session
    SELECT nombreplacesstage INTO nbPlaces
    FROM stage
    INNER JOIN session ON
    stage.CODECOMPETENCE = session.CODECOMPETENCE
    AND stage.NUMSTAGE = session.NUMSTAGE
    WHERE stage.CODECOMPETENCE = codeCompetence
      AND stage.NUMSTAGE = noStage
      AND NUMSESSION = noSession;

    -- Comparer le nombre d'inscrits avec le nombre de places disponibles
    IF nbInscrits < nbPlaces THEN
        SET dispo = 1; -- Inscription possible
    ELSE
        SET dispo = 0; -- Inscription impossible
    END IF;

END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `agence`
--

CREATE TABLE `agence` (
  `NOMAGENCE` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `agence`
--

INSERT INTO `agence` (`NOMAGENCE`) VALUES
('ICGO AUXERRE'),
('ICGO BEAUNE'),
('ICGO DIJON');

-- --------------------------------------------------------

--
-- Structure de la table `competence`
--

CREATE TABLE `competence` (
  `CODECOMPETENCE` char(3) NOT NULL,
  `LIBELLECOMPETENCE` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `competence`
--

INSERT INTO `competence` (`CODECOMPETENCE`, `LIBELLECOMPETENCE`) VALUES
('BDD', 'Bases de donnéeees'),
('BUR', 'Bureautique'),
('DEV', 'Développement'),
('JUR', 'RGPD'),
('RES', 'Réseau'),
('SYS', 'Systèmes d\'exploitation'),
('WEB', 'Sites Web');

-- --------------------------------------------------------

--
-- Structure de la table `composer`
--

CREATE TABLE `composer` (
  `CODECOMPETENCE` char(3) NOT NULL,
  `NUMSTAGE` int(11) NOT NULL,
  `NUMMODULE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `composer`
--

INSERT INTO `composer` (`CODECOMPETENCE`, `NUMSTAGE`, `NUMMODULE`) VALUES
('DEV', 1, 2),
('BDD', 1, 3),
('BDD', 1, 4),
('BDD', 4, 5),
('BDD', 1, 6),
('DEV', 1, 7);

-- --------------------------------------------------------

--
-- Structure de la table `etre_competent`
--

CREATE TABLE `etre_competent` (
  `NUMFORMATEUR` int(11) NOT NULL,
  `CODECOMPETENCE` char(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `etre_competent`
--

INSERT INTO `etre_competent` (`NUMFORMATEUR`, `CODECOMPETENCE`) VALUES
(1, 'BUR'),
(1, 'RES'),
(1, 'SYS'),
(2, 'BDD'),
(2, 'BUR'),
(2, 'WEB'),
(3, 'BDD'),
(3, 'DEV'),
(3, 'WEB'),
(4, 'BDD'),
(4, 'BUR'),
(4, 'DEV');

-- --------------------------------------------------------

--
-- Structure de la table `formateur`
--

CREATE TABLE `formateur` (
  `NUMFORMATEUR` int(11) NOT NULL,
  `NOMAGENCE` varchar(20) NOT NULL,
  `NOMFORMATEUR` varchar(25) DEFAULT NULL,
  `PRENOMFORMATEUR` varchar(20) DEFAULT NULL,
  `RUE` varchar(50) DEFAULT NULL,
  `CODEPOSTAL` char(5) DEFAULT NULL,
  `VILLE` varchar(20) DEFAULT NULL,
  `TELEPHONE` char(14) DEFAULT NULL,
  `NIVEAUETUDE` varchar(30) DEFAULT NULL,
  `DATEINTERVENTION` datetime DEFAULT NULL,
  `SALAIREANNUEL` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `formateur`
--

INSERT INTO `formateur` (`NUMFORMATEUR`, `NOMAGENCE`, `NOMFORMATEUR`, `PRENOMFORMATEUR`, `RUE`, `CODEPOSTAL`, `VILLE`, `TELEPHONE`, `NIVEAUETUDE`, `DATEINTERVENTION`, `SALAIREANNUEL`) VALUES
(1, 'ICGO AUXERRE', 'DUPONT', 'Marc', '15 Bd Vaulabelle', '89000', 'AUXERRE', '03 86 12 45 12', 'Licence', '2025-10-03 00:00:00', 20000),
(2, 'ICGO AUXERRE', 'DURAND', 'Isabelle', '20 Bd du Maréchal Jui', '89000', 'AUXERRE', '03 86 95 47 85', 'BTS', '2025-05-09 00:00:00', 15000.5),
(3, 'ICGO DIJON', 'BENARD', 'Claude', '5 Rue de la Liberté', '21000', 'DIJO', '03 80 12 65 85', 'Master', '2025-12-01 00:00:00', 30000),
(4, 'ICGO BEAUNE', 'MIGNARD', 'Laurence', '5 Bd du Général de Gaulle', '89000', 'AUXERRE', '06 12 45 77 45', 'Baccalauréat', '2025-06-01 00:00:00', 15000.5);

-- --------------------------------------------------------

--
-- Structure de la table `inscrire`
--

CREATE TABLE `inscrire` (
  `NUMSTAGIAIRE` int(11) NOT NULL,
  `CODECOMPETENCE` char(3) NOT NULL,
  `NUMSTAGE` int(11) NOT NULL,
  `NUMSESSION` int(11) NOT NULL,
  `ETATINSCRIPTION` char(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `inscrire`
--

INSERT INTO `inscrire` (`NUMSTAGIAIRE`, `CODECOMPETENCE`, `NUMSTAGE`, `NUMSESSION`, `ETATINSCRIPTION`) VALUES
(1, 'BUR', 1, 2, 'p'),
(1, 'WEB', 1, 1, 'd'),
(3, 'BDD', 1, 1, 'd');

-- --------------------------------------------------------

--
-- Structure de la table `module`
--

CREATE TABLE `module` (
  `NUMMODULE` int(11) NOT NULL,
  `NOMMODULE` varchar(50) DEFAULT NULL,
  `NOMSUPPORTCOURS` varchar(25) DEFAULT NULL,
  `NOMPRESENTATION` varchar(25) DEFAULT NULL,
  `PLACESUPPORTCOURS` varchar(25) DEFAULT NULL,
  `PLACEPRESENTATION` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `module`
--

INSERT INTO `module` (`NUMMODULE`, `NOMMODULE`, `NOMSUPPORTCOURS`, `NOMPRESENTATION`, `PLACESUPPORTCOURS`, `PLACEPRESENTATION`) VALUES
(1, 'Linux Commandes de base', 'commande.docx', 'commande.pptx', 'srv_form', 'srv_form'),
(2, 'SQL', 'LMD_SQL.docx', 'LMD_SQL.pptx', 'srv_form', 'srv_form'),
(3, 'Modélisation conceptuelle MERISE', 'MCD_MERISE.docx', 'MCD_MERISE.pptx', 'srv_form', 'srv_form'),
(4, 'Modélisation relationnelle', 'MLD_MERISE.docx', 'MLD_MERISE.pptx', 'srv_form', 'srv_form'),
(5, 'UML Diagramme de classes', 'ClassesUML.docx', 'ClassesUML.pptx', 'srv_form', 'srv_form'),
(6, 'SGBD SQL SERVER', 'SQLSERVER.docx', 'SQLSERVER.pptx', 'srv_form', 'srv_form'),
(7, 'SGBD Mysql', 'Mysql.docx', 'Mysql.pptx', 'srv_form', 'srv_form'),
(8, 'SGBD ORACLE', 'ORACLE.docx', 'ORACLE.pptx', 'srv_form', 'srv_form');

-- --------------------------------------------------------

--
-- Structure de la table `session`
--

CREATE TABLE `session` (
  `CODECOMPETENCE` char(3) NOT NULL,
  `NUMSTAGE` int(11) NOT NULL,
  `NUMSESSION` int(11) NOT NULL,
  `NOMAGENCE` varchar(20) NOT NULL,
  `NUMFORMATEUR` int(11) NOT NULL,
  `DATEDEBUTSESSION` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `session`
--

INSERT INTO `session` (`CODECOMPETENCE`, `NUMSTAGE`, `NUMSESSION`, `NOMAGENCE`, `NUMFORMATEUR`, `DATEDEBUTSESSION`) VALUES
('BDD', 1, 1, 'ICGO BEAUNE', 3, '2025-10-07 00:00:00'),
('BUR', 1, 1, 'ICGO AUXERRE', 4, '2025-09-24 00:00:00'),
('BUR', 1, 2, 'ICGO BEAUNE', 2, '2025-09-03 00:00:00'),
('DEV', 1, 1, 'ICGO AUXERRE', 3, '2025-10-02 00:00:00'),
('RES', 1, 1, 'ICGO AUXERRE', 1, '2025-10-21 00:00:00'),
('SYS', 2, 1, 'ICGO BEAUNE', 1, '2025-11-12 00:00:00'),
('WEB', 1, 1, 'ICGO AUXERRE', 2, '2025-12-09 00:00:00');

-- --------------------------------------------------------

--
-- Structure de la table `stage`
--

CREATE TABLE `stage` (
  `CODECOMPETENCE` char(3) NOT NULL,
  `NUMSTAGE` int(11) NOT NULL,
  `INTITULESTAGE` varchar(50) DEFAULT NULL,
  `DUREESTAGE` int(11) DEFAULT NULL,
  `PRIXSTAGE` float DEFAULT NULL,
  `NOMBREPLACESSTAGE` int(11) DEFAULT NULL,
  `TYPESTAGE` char(1) DEFAULT NULL,
  `JOUR` varchar(15) DEFAULT NULL,
  `NOMBREHEURESPARJOUR` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `stage`
--

INSERT INTO `stage` (`CODECOMPETENCE`, `NUMSTAGE`, `INTITULESTAGE`, `DUREESTAGE`, `PRIXSTAGE`, `NOMBREPLACESSTAGE`, `TYPESTAGE`, `JOUR`, `NOMBREHEURESPARJOUR`) VALUES
('BDD', 1, 'Conception base de données ', 15, 2000, 10, 'G', NULL, 8),
('BDD', 2, 'Bases de données No SQL', 10, 2000.5, 10, 'G', NULL, 7.5),
('BDD', 4, 'Conception bases de données', 15, 2500, 12, 'E', 'Mercredi', NULL),
('BUR', 1, 'Bureautique Libre Office', 5, 850, 10, 'G', NULL, 7),
('BUR', 2, 'Bureautique Microsoft Office', 5, 100, 1, 'E', 'Mercredi', NULL),
('DEV', 1, 'Développement Java', 15, 2500, 12, 'E', 'Mercredi', NULL),
('RES', 1, 'Notions de base réseau', 10, 4000.5, 15, 'G', NULL, 8),
('SYS', 1, 'Système exploitatio', 5, 250, 5, 'E', 'Lundi', NULL),
('SYS', 2, 'Notions avancées système', 10, 2500, 20, 'G', NULL, 7),
('WEB', 1, 'Découverte Internet', 3, 250, 15, 'G', NULL, 7);

-- --------------------------------------------------------

--
-- Structure de la table `stagiaire`
--

CREATE TABLE `stagiaire` (
  `NUMSTAGIAIRE` int(11) NOT NULL,
  `NOMSTAGIAIRE` varchar(25) DEFAULT NULL,
  `PRENOMSTAGIAIRE` varchar(20) DEFAULT NULL,
  `RUESTAGIAIRE` varchar(50) DEFAULT NULL,
  `CODEPOSTALSTAGIAIRE` char(5) DEFAULT NULL,
  `VILLESTAGIAIRE` varchar(20) DEFAULT NULL,
  `TELEPHONESTAGIAIRE` char(14) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `stagiaire`
--

INSERT INTO `stagiaire` (`NUMSTAGIAIRE`, `NOMSTAGIAIRE`, `PRENOMSTAGIAIRE`, `RUESTAGIAIRE`, `CODEPOSTALSTAGIAIRE`, `VILLESTAGIAIRE`, `TELEPHONESTAGIAIRE`) VALUES
(1, 'DUCRE', 'Colette', '12 Bd de la Liberté', '89000', 'AUXERRE', '03 80 65 79 63'),
(2, 'BARRET', 'Françoise', '4 Bd de la République', '21000', 'DIJO', '03 80 43 55 22'),
(3, 'PERRI', 'Pascal', '10 rue Monge', '21200', 'BEAUNE', '03 80 35 79 54'),
(4, 'DURANTO', 'Floria', '4 Bd Bictor Hugo', '89100', 'SENS', '02 58 74 57 44');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

CREATE TABLE `utilisateur` (
  `NUMUTILISATEUR` varchar(5) NOT NULL,
  `NOM` varchar(25) DEFAULT NULL,
  `PRENOM` varchar(25) DEFAULT NULL,
  `LOGIN` varchar(20) DEFAULT NULL,
  `MOTPASSE` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`NUMUTILISATEUR`, `NOM`, `PRENOM`, `LOGIN`, `MOTPASSE`) VALUES
('a131', 'Villechalane', 'Louis', 'lvillachane', 'jux7g'),
('a17', 'Andre', 'David', 'dandre', 'oppg5'),
('a55', 'Bedos', 'Christia', 'cbedos', 'gmhxd'),
('a93', 'Tusseau', 'Louis', 'ltusseau', 'ktp3s'),
('b13', 'Bentot', 'Pascal', 'pbentot', 'doyw1'),
('b16', 'Bioret', 'Luc', 'lbioret', 'hrjfs'),
('b19', 'Bunisset', 'Francis', 'fbunisset', '4vbnd'),
('b25', 'Bunisset', 'Denise', 'dbunisset', 's1y1r'),
('b28', 'Cacheux', 'Bernard', 'bcacheux', 'uf7r3'),
('b34', 'Cadic', 'Eric', 'ecadic', '6u8dc'),
('b4', 'Charoze', 'Catherine', 'ccharoze', 'u817o');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `agence`
--
ALTER TABLE `agence`
  ADD PRIMARY KEY (`NOMAGENCE`);

--
-- Index pour la table `competence`
--
ALTER TABLE `competence`
  ADD PRIMARY KEY (`CODECOMPETENCE`);

--
-- Index pour la table `composer`
--
ALTER TABLE `composer`
  ADD PRIMARY KEY (`CODECOMPETENCE`,`NUMSTAGE`,`NUMMODULE`),
  ADD KEY `LIEN_68_FK` (`CODECOMPETENCE`,`NUMSTAGE`),
  ADD KEY `LIEN_69_FK` (`NUMMODULE`);

--
-- Index pour la table `etre_competent`
--
ALTER TABLE `etre_competent`
  ADD PRIMARY KEY (`NUMFORMATEUR`,`CODECOMPETENCE`),
  ADD KEY `LIEN_54_FK` (`NUMFORMATEUR`),
  ADD KEY `LIEN_55_FK` (`CODECOMPETENCE`);

--
-- Index pour la table `formateur`
--
ALTER TABLE `formateur`
  ADD PRIMARY KEY (`NUMFORMATEUR`),
  ADD KEY `DEPENDRE_FK` (`NOMAGENCE`);

--
-- Index pour la table `inscrire`
--
ALTER TABLE `inscrire`
  ADD PRIMARY KEY (`NUMSTAGIAIRE`,`CODECOMPETENCE`,`NUMSTAGE`,`NUMSESSION`),
  ADD KEY `LIEN_128_FK` (`NUMSTAGIAIRE`),
  ADD KEY `LIEN_138_FK` (`CODECOMPETENCE`,`NUMSTAGE`,`NUMSESSION`);

--
-- Index pour la table `module`
--
ALTER TABLE `module`
  ADD PRIMARY KEY (`NUMMODULE`);

--
-- Index pour la table `session`
--
ALTER TABLE `session`
  ADD PRIMARY KEY (`CODECOMPETENCE`,`NUMSTAGE`,`NUMSESSION`),
  ADD KEY `SE_DEROULER_FK` (`CODECOMPETENCE`,`NUMSTAGE`),
  ADD KEY `AVOIR_LIEU_FK` (`NOMAGENCE`),
  ADD KEY `ANIMER_FK` (`NUMFORMATEUR`);

--
-- Index pour la table `stage`
--
ALTER TABLE `stage`
  ADD PRIMARY KEY (`CODECOMPETENCE`,`NUMSTAGE`),
  ADD KEY `APPARTENIR_FK` (`CODECOMPETENCE`);

--
-- Index pour la table `stagiaire`
--
ALTER TABLE `stagiaire`
  ADD PRIMARY KEY (`NUMSTAGIAIRE`);

--
-- Index pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD PRIMARY KEY (`NUMUTILISATEUR`);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `composer`
--
ALTER TABLE `composer`
  ADD CONSTRAINT `FK_COMPOSER_LIEN_68_STAGE` FOREIGN KEY (`CODECOMPETENCE`,`NUMSTAGE`) REFERENCES `stage` (`CODECOMPETENCE`, `NUMSTAGE`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_COMPOSER_LIEN_69_MODULE` FOREIGN KEY (`NUMMODULE`) REFERENCES `module` (`NUMMODULE`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `etre_competent`
--
ALTER TABLE `etre_competent`
  ADD CONSTRAINT `FK_ETRE_COM_LIEN_54_FORMATEU` FOREIGN KEY (`NUMFORMATEUR`) REFERENCES `formateur` (`NUMFORMATEUR`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_ETRE_COM_LIEN_55_COMPETEN` FOREIGN KEY (`CODECOMPETENCE`) REFERENCES `competence` (`CODECOMPETENCE`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `formateur`
--
ALTER TABLE `formateur`
  ADD CONSTRAINT `FK_FORMATEU_DEPENDRE_AGENCE` FOREIGN KEY (`NOMAGENCE`) REFERENCES `agence` (`NOMAGENCE`);

--
-- Contraintes pour la table `inscrire`
--
ALTER TABLE `inscrire`
  ADD CONSTRAINT `FK_S_INSCRI_LIEN_128_STAGIAIR` FOREIGN KEY (`NUMSTAGIAIRE`) REFERENCES `stagiaire` (`NUMSTAGIAIRE`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_S_INSCRI_LIEN_138_SESSION` FOREIGN KEY (`CODECOMPETENCE`,`NUMSTAGE`,`NUMSESSION`) REFERENCES `session` (`CODECOMPETENCE`, `NUMSTAGE`, `NUMSESSION`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `session`
--
ALTER TABLE `session`
  ADD CONSTRAINT `FK_SESSION_ANIMER_FORMATEU` FOREIGN KEY (`NUMFORMATEUR`) REFERENCES `formateur` (`NUMFORMATEUR`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_SESSION_AVOIR_LIE_AGENCE` FOREIGN KEY (`NOMAGENCE`) REFERENCES `agence` (`NOMAGENCE`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_SESSION_SE_DEROUL_STAGE` FOREIGN KEY (`CODECOMPETENCE`,`NUMSTAGE`) REFERENCES `stage` (`CODECOMPETENCE`, `NUMSTAGE`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `stage`
--
ALTER TABLE `stage`
  ADD CONSTRAINT `FK_STAGE_APPARTENI_COMPETEN` FOREIGN KEY (`CODECOMPETENCE`) REFERENCES `competence` (`CODECOMPETENCE`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
