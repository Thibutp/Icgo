using System.Collections.Generic;

namespace BiblioMetierICGO
{
    public class Stagiaire
    {
        #region Attributs privés

        private int numStagiaire;
        private string nomStagiaire;
        private string prenom;
        private string rue;
        private string codePostal;
        private string ville;
        private string telephone;
        private List<Session> lesSessions;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur
        /// </summary>
        public Stagiaire()
        {
            lesSessions = new List<Session>();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="unNumStagiaire">Numéro stagiaire</param>
        /// <param name="unNomStagiaire">Nom stagiaire</param>
        /// <param name="unPrenom">Prénom stagiaire</param>
        /// <param name="uneRue">Rue</param>
        /// <param name="unCodePostal">Code postal</param>
        /// <param name="uneVille">Ville</param>
        /// <param name="unTelephone">Téléphone</param>
        public Stagiaire(int unNumStagiaire, string unNomStagiaire, string unPrenom, string uneRue, string unCodePostal, string uneVille, string unTelephone)
        {
            numStagiaire = unNumStagiaire;
            nomStagiaire = unNomStagiaire;
            prenom = unPrenom;
            rue = uneRue;
            codePostal = unCodePostal;
            ville = uneVille;
            telephone = unTelephone;
            lesSessions = new List<Session>();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="unNumStagiaire">Numéro stagiaire</param>
        /// <param name="unNomStagiaire">Nom stagiaire</param>
        /// <param name="unPrenom">Prénom stagiaire</param>
        /// <param name="uneRue">Rue</param>
        /// <param name="unCodePostal">Code postal</param>
        /// <param name="uneVille">Ville</param>
        /// <param name="unTelephone">Téléphone</param>
        /// <param name="desSessions">Liste des sessions affectées au stage</param>
        public Stagiaire(int unNumStagiaire, string unNomStagiaire, string unPrenom, string uneRue, string unCodePostal, string uneVille, string unTelephone, List<Session> desSessions)
        {
            numStagiaire = unNumStagiaire;
            nomStagiaire = unNomStagiaire;
            prenom = unPrenom;
            rue = uneRue;
            codePostal = unCodePostal;
            ville = uneVille;
            telephone = unTelephone;
            lesSessions = new List<Session>();
            lesSessions = desSessions;
        }

        #endregion

        #region Accesseurs

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Numéro stagiaire</returns>
        public int GetNumStagiaire()
        {
            return numStagiaire;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Numéro stagiaire</param>
        public void SetNumStagiaire(int value)
        {
            numStagiaire = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Nom stagiaire</returns>
        public string GetNomStagiaire()
        {
            return nomStagiaire;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Nom stagiaire</param>
        public void SetNomStagiaire(string value)
        {
            nomStagiaire = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Prénom stagiaire</returns>
        public string GetPrenom()
        {
            return prenom;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Prénom stagiaire</param>
        public void SetPrenom(string value)
        {
            prenom = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Rue stagiaire</returns>
        public string GetRue()
        {
            return rue;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Rue stagiaire</param>
        public void SetRue(string value)
        {
            rue = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Code postal stagiaire</returns>
        public string GetCodePostal()
        {
            return codePostal;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Code postal stagiaire</param>
        public void SetCodePostal(string value)
        {
            codePostal = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Ville stagiaire</returns>
        public string GetVille()
        {
            return ville;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Ville stagiaire</param>
        public void SetVille(string value)
        {
            ville = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Telephone stagiaire</returns>
        public string GetTelephone()
        {
            return telephone;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Telephone stagiaire</param>
        public void SetTelephone(string value)
        {
            telephone = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Liste des sessions</returns>
        public List<Session> GetLesSessions()
        {
            return lesSessions;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Liste des sessions</param>
        public void SetLesSessions(List<Session> value)
        {
            lesSessions = value;
        }

        #endregion

    }
}
