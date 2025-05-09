using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioMetierICGO
{
    public class Utilisateur
    {
        #region Attributs privés

        private string numUtilisateur;
        private string nomUtilisateur;
        private string prenomUtilisateur;
        private string login;
        private string motPasse;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Utilisateur()
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="unNumUtilisateur">Numéro</param>
        /// <param name="unNomUtilisateur">Nom</param>
        /// <param name="unPrenomUtilisateur">Prénom</param>
        /// <param name="unLogin">Login</param>
        /// <param name="unMotPasse">Mot de passe</param>
        public Utilisateur(string unNumUtilisateur, string unNomUtilisateur, string unPrenomUtilisateur, string unLogin, string unMotPasse)
        {
            numUtilisateur = unNumUtilisateur;
            nomUtilisateur = unNomUtilisateur;
            prenomUtilisateur = unPrenomUtilisateur;
            login = unLogin;
            motPasse = unMotPasse;
        }

        #endregion

        #region Accesseurs

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Numéro utilisateur</returns>
        public string GetNumUtilisateur()
        {
            return numUtilisateur;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Numéro utilisateur</param>
        public void SetNumUtilisateur(string value)
        {
            numUtilisateur = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Nom utilisateur</returns>
        public string GetNomUtilisateur()
        {
            return nomUtilisateur;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Nom utilisateur</param>
        public void SetNomUtilisateur(string value)
        {
            nomUtilisateur = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Prénom utilisateur</returns>
        public string GetPrenomUtilisateur()
        {
            return prenomUtilisateur;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Prénom utilisateur</param>
        public void SetPrenomUtilisateur(string value)
        {
            prenomUtilisateur = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Login</returns>
        public string GetLogin()
        {
            return login;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Login</param>
        public void SetLogin(string value)
        {
            login = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Mot de passe</returns>
        public string GetMotPasse()
        {
            return motPasse;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Mot de passe</param>
        public void SetMotPasse(string value)
        {
            motPasse = value;
        }

        #endregion
    }
}
