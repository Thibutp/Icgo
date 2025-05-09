using BiblioMetierICGO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BiblioDAOICGO
{
    public class CompetenceDAO
    {
        
        /// <summary>
        /// Ajouter une compétence dans la table COMPETENCE
        /// </summary>
        /// <param name="uneCompetence">Une compétence</param>
        public static void AjouterUneCompetence(Competence uneCompetence)
        {
            // Exécuter la requête d'insertion
            string requete = "INSERT INTO COMPETENCE VALUES (@code, @nom)";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@code", uneCompetence.CodeCompetence),
                new MySqlParameter("@nom", uneCompetence.NomCompetence));
        }


        /// <summary>
        /// Charger les compétences de la table COMPETENCE dans une liste de compétences
        /// </summary>
        /// <returns>Liste des compétences</returns>
        public static List<Competence> ChargerLesCompetences()
        {
            List<Competence> lesCompetences = new List<Competence>();
            // Exécuter la requête de sélection
            string requete = "SELECT CODECOMPETENCE, LIBELLECOMPETENCE FROM COMPETENCE";
            DataTable dt = Connexion.ExecutionRequete(requete, null);

            // Parcours du résultat de la requête
            foreach (DataRow uneLigne in dt.Rows)
            {
                // Récupération des caractéristiques d'une compétence à partir du résultat de la requête
                string codeCompetence = uneLigne["CODECOMPETENCE"].ToString();
                string nomCompetence = uneLigne["LIBELLECOMPETENCE"].ToString();
                // Construction de l'objet uneCompetence avec chargement des formateurs ayant cette compétence
                Competence uneCompetence = new Competence(codeCompetence, nomCompetence, FormateurDAO.ChargerLesFormateursCompetents(codeCompetence));
                // Ajout de la compétence dans la liste lesCompetences
                lesCompetences.Add(uneCompetence);
            }
            return lesCompetences;
        }


        /// <summary>
        /// Retourne une compétence identifiée par son code dans la table COMPETENCE
        /// </summary>
        /// <param name="idCompetence">Code compétence</param>
        /// <returns></returns>
        public static Competence GetCompetence(string idCompetence)
        {
            //Instanciation de la compétence vide
            Competence uneCompetence = new Competence();
            // Exécuter la requête de sélection
            string requete = "SELECT LIBELLECOMPETENCE FROM COMPETENCE WHERE CODECOMPETENCE =@competence";
            DataTable dt = Connexion.ExecutionRequete(requete, new MySqlParameter("@competence", idCompetence));

            if (dt.Rows.Count == 1)
            {
                string nomCompetence = dt.Rows[0]["LIBELLECOMPETENCE"].ToString();
                // Création de l'objet uneCompetence avec chargement des formateurs ayant cette compétence
                uneCompetence = new Competence(idCompetence, nomCompetence, FormateurDAO.ChargerLesFormateursCompetents(idCompetence));
            }

            // Retour de la compétence uneCompetence
            return uneCompetence;
        }

        /// <summary>
        /// Modifier les caractéristiques d'une compétence identifiée par son code dans la table COMPETENCE 
        /// </summary>
        /// <param name="uneCompetence">Une Competence</param>
        /// <param name="idCompetence">Code compétence</param>
        public static void ModifierUneCompetence(Competence uneCompetence, string idCompetence)
        {
            // Exécuter la requête de modification
            string requete = "UPDATE COMPETENCE SET CODECOMPETENCE = @code, LIBELLECOMPETENCE = @libelle WHERE CODECOMPETENCE = @id";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@code", uneCompetence.GetCodeCompetence()),
                new MySqlParameter("@libelle", uneCompetence.GetNomCompetence()),
                new MySqlParameter("@id", idCompetence));
        }

        /// <summary>
        /// Supprimer une compétence identifiée par son code dans la table COMPETENCE
        /// </summary>
        /// <param name="idCompetence">Code compétence</param>
        public static void SupprimerUneCompetence(string idCompetence)
        {
            // Exécuter la requête de suppression
            string requete = "DELETE FROM COMPETENCE WHERE CODECOMPETENCE = @id";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@id", idCompetence));
        }

        /// <summary>
        /// Charger les compétences de la table ETRE_COMPETENT d'un formateur identifié par son numéro
        /// </summary>
        /// <param name="idFormateur">Numéro formateur</param>
        /// <returns></returns>
        public static List<Competence> ChargerLesCompetencesDuFormateur(int idFormateur)
        {
            List<Competence> lesCompetences = new List<Competence>();
            Competence uneCompetence;
            string codeCompetence;
            string nomCompetence;

            // Recherche des compétences du formateur
            lesCompetences.Clear();

            string requete = "SELECT C.CODECOMPETENCE, LIBELLECOMPETENCE FROM COMPETENCE AS C INNER JOIN ETRE_COMPETENT AS E ON C.CODECOMPETENCE = E.CODECOMPETENCE WHERE NUMFORMATEUR = @formateur";
            DataTable dt = Connexion.ExecutionRequete(requete,
                new MySqlParameter("@formateur", idFormateur));

            foreach (DataRow uneLigne in dt.Rows)
            {
                codeCompetence = uneLigne["CODECOMPETENCE"].ToString();
                nomCompetence = uneLigne["LIBELLECOMPETENCE"].ToString();
                // Création de l'objet uneCompetence et ajout dans la liste des compétences 
                uneCompetence = new Competence(codeCompetence, nomCompetence);
                lesCompetences.Add(uneCompetence);
            }

            // Retour de la liste lesCompetences
            return lesCompetences;
        }



    }
}
