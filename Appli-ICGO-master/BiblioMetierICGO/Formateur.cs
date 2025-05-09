using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioMetierICGO
{
    public class Formateur
    {
        #region Attributs privés

        private int numFormateur;
        private string nomFormateur;
        private string prenom;
        private string rue;
        private string codePostal;
        private string ville;
        private string telephone;
        private string niveauEtude;
        private DateTime dateIntervention;
        private string salaireAnnuel;
        private Agence lAgence;
        private List<Competence> lesCompetences;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur
        /// </summary>
        public Formateur()
        {
            lesCompetences = new List<Competence>();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="unNumFormateur">Numéro formateur</param>
        /// <param name="unNomFormateur">Nom formateur</param>
        /// <param name="unPrenom">Prénom formateur</param>
        /// <param name="uneRue">Rue</param>
        /// <param name="unCodePostal">Code postal</param>
        /// <param name="uneVille">Ville</param>
        /// <param name="unTelephone">Téléphone</param>
        /// <param name="unNiveauEtude">Niveau d'étude</param>
        /// <param name="uneDate">Date de 1ère intervention</param>
        /// <param name="unSalaire">Salaire annuel</param>
        /// <param name="uneAgence">Agence de rattachement du formateur</param>
        public Formateur(int unNumFormateur, string unNomFormateur, string unPrenom, string uneRue, string unCodePostal, string uneVille, string unTelephone, string unNiveauEtude, DateTime uneDate, string unSalaire, Agence uneAgence)
        {
            numFormateur = unNumFormateur;
            nomFormateur = unNomFormateur;
            prenom = unPrenom;
            rue = uneRue;
            codePostal = unCodePostal;
            ville = uneVille;
            telephone = unTelephone;
            niveauEtude = unNiveauEtude;
            dateIntervention = uneDate;
            salaireAnnuel = unSalaire;
            lAgence = uneAgence;
            lesCompetences = new List<Competence>();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="unNumFormateur">Numéro formateur</param>
        /// <param name="unNomFormateur">Nom formateur</param>
        /// <param name="unPrenom">Prénom formateur</param>
        /// <param name="uneRue">Rue</param>
        /// <param name="unCodePostal">Code postal</param>
        /// <param name="uneVille">Ville</param>
        /// <param name="unTelephone">Téléphone</param>
        /// <param name="unNiveauEtude">Niveau d'étude</param>
        /// <param name="uneDate">Date de 1ère intervention</param>
        /// <param name="unSalaire">Salaire annuel</param>
        /// <param name="uneAgence">Agence de rattachement du formateur</param>
        /// <param name="desCompetences">Liste des compétences attribuées au formateur</param>
        public Formateur(int unNumFormateur, string unNomFormateur, string unPrenom, string uneRue, string unCodePostal, string uneVille, string unTelephone, string unNiveauEtude, DateTime uneDate, string unSalaire, Agence uneAgence, List<Competence> desCompetences)
        {
            numFormateur = unNumFormateur;
            nomFormateur = unNomFormateur;
            prenom = unPrenom;
            rue = uneRue;
            codePostal = unCodePostal;
            ville = uneVille;
            telephone = unTelephone;
            niveauEtude = unNiveauEtude;
            dateIntervention = uneDate;
            salaireAnnuel = unSalaire;
            lAgence = uneAgence;
            lesCompetences = new List<Competence>();
            lesCompetences = desCompetences;
        }

        #endregion

        #region Accesseurs

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Numéro formateur</returns>
        public int GetNumFormateur()
        {
            return numFormateur;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Numéro formateur</param>
        public void SetNumFormateur(int value)
        {
            numFormateur = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Nom formateur</returns>
        public string GetNomFormateur()
        {
            return nomFormateur;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Nom formateur</param>
        public void SetNomFormateur(string value)
        {
            nomFormateur = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Prénom formateur</returns>
        public string GetPrenom()
        {
            return prenom;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Prénom formateur</param>
        public void SetNom(string value)
        {
            prenom = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Rue formateur</returns>
        public string GetRue()
        {
            return rue;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Rue formateur</param>
        public void SetRue(string value)
        {
            rue = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Code postal formateur</returns>
        public string GetCodePostal()
        {
            return codePostal;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Code postal formateur</param>
        public void SetCodePostal(string value)
        {
            codePostal = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Ville formateur</returns>
        public string GetVille()
        {
            return ville;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Ville formateur</param>
        public void SetVille(string value)
        {
            ville = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Telephone formateur</returns>
        public string GetTelephone()
        {
            return telephone;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Telephone formateur</param>
        public void SetTelephone(string value)
        {
            telephone = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Niveau étude formateur</returns>
        public string GetNiveauEtude()
        {
            return niveauEtude;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Niveau étude formateur</param>
        public void SetNiveauEtude(string value)
        {
            niveauEtude = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Date 1ère intervention formateur</returns>
        public DateTime GetDateIntervention()
        {
            return dateIntervention;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Date 1ère intervention formateur</param>
        public void SetDateIntervention(DateTime value)
        {
            dateIntervention = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Salaire annuel formateur</returns>
        public string GetSalaireAnnuel()
        {
            return salaireAnnuel;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Salaire annuel formateur</param>
        public void SetSalaireAnnuel(string value)
        {
            salaireAnnuel = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Agence formateur</returns>
        public Agence GetLAgence()
        {
            return lAgence;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Agence formateur</param>
        public void SetLAgence(Agence value)
        {
            lAgence = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Liste des compétences formateur</returns>
        public List<Competence> GetLesCompetences()
        {
            return lesCompetences;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Liste des compétences formateur</param>
        public void SetLesCompetences(List<Competence> value)
        {
            lesCompetences = value;
        }

        #endregion
    }
}
