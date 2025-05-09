using BiblioMetierICGO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioDAOICGO
{
    public class FormateurDAO
    {
        /// <summary>
        /// Ajouter un formateur dans la table FORMATEUR
        /// </summary>
        /// <param name="unFormateur">Un formateur</param>
        public static void AjouterUnFormateur(Formateur unFormateur)
        {
            // Exécuter la requête d'insertion
            string requete = "INSERT INTO FORMATEUR VALUES (@numF, @agence, @nomF, @prenomF, @rueF, @cpF, @villeF, @telF, @niveauF, @interventionF, @salaireF)";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@numF", unFormateur.GetNumFormateur()),
                new MySqlParameter("@agence", unFormateur.GetLAgence().GetNomAgence()),
                new MySqlParameter("@nomF", unFormateur.GetNomFormateur()),
                new MySqlParameter("@prenomF", unFormateur.GetPrenom()),
                new MySqlParameter("@rueF", unFormateur.GetRue()),
                new MySqlParameter("@cpF", unFormateur.GetCodePostal()),
                new MySqlParameter("@villeF", unFormateur.GetVille()),
                new MySqlParameter("@telF", unFormateur.GetTelephone()),
                new MySqlParameter("@niveauF", unFormateur.GetNiveauEtude()),
                new MySqlParameter("@interventionF", unFormateur.GetDateIntervention()),
                new MySqlParameter("@salaireF", unFormateur.GetSalaireAnnuel())
                );
            //CAST(" + unFormateur.GetSalaireAnnuel() + " AS float)
        }

        /// <summary>
        /// Charger les formateurs de la table FORMATEUR dans une liste de formateurs
        /// </summary>
        /// <returns></returns>
        public static List<Formateur> ChargerLesFormateurs()
        {

            List<Formateur> lesFormateurs = new List<Formateur>();
            Formateur unFormateur;
            int numFormateur;
            string nomFormateur, prenomFormateur;
            string nomAgence;
            string rue, codePostal, ville;
            string telephone, niveauEtude;
            DateTime dateIntervention;
            string salaire;
            Agence uneAgence;


            lesFormateurs.Clear();

            // Exécuter la requête de sélection
            string requete = "SELECT NUMFORMATEUR, NOMAGENCE, NOMFORMATEUR, PRENOMFORMATEUR, RUE, CODEPOSTAL, VILLE, TELEPHONE, NIVEAUETUDE, DATEINTERVENTION, SALAIREANNUEL FROM FORMATEUR";
            DataTable dt = Connexion.ExecutionRequete(requete, null);

            // Parcours du résultat de la requête
            foreach (DataRow uneLigne in dt.Rows)
            {
                // Récupération des caractéristiques d'un formateur à partir du résultat de la requête
                numFormateur = int.Parse(uneLigne["NUMFORMATEUR"].ToString());
                nomAgence = uneLigne["NOMAGENCE"].ToString();
                nomFormateur = uneLigne["NOMFORMATEUR"].ToString();
                prenomFormateur = uneLigne["PRENOMFORMATEUR"].ToString();
                rue = uneLigne["RUE"].ToString();
                codePostal = uneLigne["CODEPOSTAL"].ToString();
                ville = uneLigne["VILLE"].ToString();
                telephone = uneLigne["TELEPHONE"].ToString();
                niveauEtude = uneLigne["NIVEAUETUDE"].ToString();
                dateIntervention = DateTime.Parse(uneLigne["DATEINTERVENTION"].ToString());
                salaire = uneLigne["SALAIREANNUEL"].ToString();
                uneAgence = new Agence(nomAgence);
                // Construction de l'objet unFormateur avec chargement des compétences attribuées à ce formateur
                unFormateur = new Formateur(numFormateur, nomFormateur, prenomFormateur, rue, codePostal, ville, telephone, niveauEtude, dateIntervention, salaire, uneAgence, CompetenceDAO.ChargerLesCompetencesDuFormateur(numFormateur));
                // Ajout du formateur dans la liste lesFormateurs
                lesFormateurs.Add(unFormateur);
            }

            return lesFormateurs;
        }

        /// <summary>
        /// Retourne un formateur identifié par son numéro dans la table FORMATEUR
        /// </summary>
        /// <param name="idFormateur">Numéro formateur</param>
        /// <returns></returns>
        public static Formateur GetFormateur(int idFormateur)
        {
            Formateur unFormateur;
            string nomFormateur, prenomFormateur;
            string nomAgence;
            string rue, codePostal, ville;
            string telephone, niveauEtude;
            DateTime dateIntervention;
            string salaire;
            Agence uneAgence;

            // Recherche du formateur identifié par son numéro dans la table FORMATEUR
            string requete = "SELECT NOMAGENCE, NOMFORMATEUR, PRENOMFORMATEUR, RUE, CODEPOSTAL, VILLE, TELEPHONE, NIVEAUETUDE, DATEINTERVENTION, SALAIREANNUEL FROM FORMATEUR WHERE NUMFORMATEUR = @id";
            DataTable dt = Connexion.ExecutionRequete(requete,
                new MySqlParameter("@id", idFormateur));

            if (dt.Rows.Count == 1)
            {
                nomAgence = dt.Rows[0]["NOMAGENCE"].ToString();
                nomFormateur = dt.Rows[0]["NOMFORMATEUR"].ToString();
                prenomFormateur = dt.Rows[0]["PRENOMFORMATEUR"].ToString();
                rue = dt.Rows[0]["RUE"].ToString();
                codePostal = dt.Rows[0]["CODEPOSTAL"].ToString();
                ville = dt.Rows[0]["VILLE"].ToString();
                telephone = dt.Rows[0]["TELEPHONE"].ToString();
                niveauEtude = dt.Rows[0]["NIVEAUETUDE"].ToString();
                dateIntervention = DateTime.Parse(dt.Rows[0]["DATEINTERVENTION"].ToString());
                salaire = dt.Rows[0]["SALAIREANNUEL"].ToString();
                uneAgence = new Agence(nomAgence);
                // Construction de l'objet unFormateur avec chargement des compétences attribuées à ce formateur
                unFormateur = new Formateur(idFormateur, nomFormateur, prenomFormateur, rue, codePostal, ville, telephone, niveauEtude, dateIntervention, salaire, uneAgence, CompetenceDAO.ChargerLesCompetencesDuFormateur(idFormateur));
            }
            else
            {
                unFormateur = new Formateur();
            }
            return unFormateur;
        }

        /// <summary>
        /// Modifier les caractéristiques d'un formateur identifié par son numéro dans la table FORMATEUR
        /// </summary>
        /// <param name="unFormateur">Un formateur</param>
        /// <param name="idFormateur">Numéro formateur</param>
        public static void ModifierUnFormateur(Formateur unFormateur, int idFormateur)
        {
            // Exécution de la requête de modification
            string requete = "UPDATE FORMATEUR SET NUMFORMATEUR = @numF, NOMAGENCE = @agenceF, NOMFORMATEUR = @nomF, PRENOMFORMATEUR = @prenomF , RUE = @rueF, CODEPOSTAL = @cpF, VILLE = @villeF, TELEPHONE = @telF, NIVEAUETUDE = @niveauF, DATEINTERVENTION = @interventionF, SALAIREANNUEL = @salaireF WHERE NUMFORMATEUR = @id";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@numF", unFormateur.GetNumFormateur()),
                new MySqlParameter("@agenceF", unFormateur.GetLAgence().GetNomAgence()),
                new MySqlParameter("@nomF", unFormateur.GetNomFormateur()),
                new MySqlParameter("@prenomF", unFormateur.GetPrenom()),
                new MySqlParameter("@rueF", unFormateur.GetRue()),
                new MySqlParameter("@cpF", unFormateur.GetCodePostal()),
                new MySqlParameter("@villeF", unFormateur.GetVille()),
                new MySqlParameter("@telF", unFormateur.GetTelephone()),
                new MySqlParameter("@niveauF", unFormateur.GetNiveauEtude()),
                new MySqlParameter("@interventionF", unFormateur.GetDateIntervention()),
                new MySqlParameter("@salaireF", unFormateur.GetSalaireAnnuel()),
                new MySqlParameter("@id", idFormateur)
                );
        }

        /// <summary>
        /// Supprimer un formateur identifié par son numéro dans la table FORMATEUR
        /// </summary>
        /// <param name="idFormateur">Numéro formateur</param>
        public static void SupprimerUnFormateur(int idFormateur)
        {
            // Exécution de la requête de suppression
            string requete = "DELETE FROM FORMATEUR WHERE NUMFORMATEUR = @id";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@id", idFormateur));
        }

        /// <summary>
        /// Ajouter une compétence à un formateur dans la table ETRE_COMPETENT
        /// </summary>
        /// <param name="unFormateur">Un formateur</param>
        /// <param name="uneCompetence">Une compétence</param>
        public static void AjouterUneCompetence(Formateur unFormateur, Competence uneCompetence)
        {
            // Exécution de la requête d'insertion
            string requete = "INSERT INTO ETRE_COMPETENT VALUES ( @numF, @codeComp)";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@numF", unFormateur.GetNumFormateur()),
                new MySqlParameter("@codeComp", uneCompetence.GetCodeCompetence())
                );
        }

        /// <summary>
        /// Supprimer une compétence à un formateur dans la table ETRE_COMPETENT
        /// </summary>
        /// <param name="unFormateur">Un formateur</param>
        /// <param name="uneCompetence">Une compétence</param>
        public static void SupprimerUneCompetence(Formateur unFormateur, Competence uneCompetence)
        {
            // Exécuter la requête de suppression
            string requete = "DELETE FROM ETRE_COMPETENT WHERE NUMFORMATEUR = @numF AND CODECOMPETENCE = @codeComp";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@numF", unFormateur.GetNumFormateur()),
                new MySqlParameter("@codeComp", uneCompetence.GetCodeCompetence())
                );
        }

        /// <summary>
        /// Charger les formateurs de la table ETRE_COMPETENT d'une compétence identifié par son code
        /// </summary>
        /// <param name="idCompetence">Code compétence</param>
        /// <returns></returns>
        public static List<Formateur> ChargerLesFormateursCompetents(string idCompetence)
        {

            List<Formateur> lesFormateurs = new List<Formateur>();
            Formateur unFormateur;
            int numFormateur;
            string nomFormateur, prenomFormateur;
            string nomAgence;
            string rue, codePostal, ville;
            string telephone, niveauEtude;
            DateTime dateIntervention;
            string salaire;
            Agence uneAgence;

            lesFormateurs.Clear();

            // Recherche des formateurs de la compétence
            string requete = "SELECT F.NUMFORMATEUR, NOMAGENCE, NOMFORMATEUR, PRENOMFORMATEUR, RUE, CODEPOSTAL, VILLE, TELEPHONE, NIVEAUETUDE, DATEINTERVENTION, SALAIREANNUEL FROM FORMATEUR AS F INNER JOIN ETRE_COMPETENT AS E ON F.NUMFORMATEUR = E.NUMFORMATEUR WHERE CODECOMPETENCE = @codeComp";
            DataTable dt = Connexion.ExecutionRequete(requete,
                new MySqlParameter("@codeComp", idCompetence)
                );

            foreach (DataRow uneLigne in dt.Rows)
            {
                // Récupération des caractéristiques d'un formateur à partir du résultat de la requête
                numFormateur = int.Parse(uneLigne["NUMFORMATEUR"].ToString());
                nomAgence = uneLigne["NOMAGENCE"].ToString();
                nomFormateur = uneLigne["NOMFORMATEUR"].ToString();
                prenomFormateur = uneLigne["PRENOMFORMATEUR"].ToString();
                rue = uneLigne["RUE"].ToString();
                codePostal = uneLigne["CODEPOSTAL"].ToString();
                ville = uneLigne["VILLE"].ToString();
                telephone = uneLigne["TELEPHONE"].ToString();
                niveauEtude = uneLigne["NIVEAUETUDE"].ToString();
                dateIntervention = DateTime.Parse(uneLigne["DATEINTERVENTION"].ToString());
                salaire = uneLigne["SALAIREANNUEL"].ToString();
                uneAgence = new Agence(nomAgence);
                // Création de l'objet unFormateur et ajout dans la liste des formateurs 
                unFormateur = new Formateur(numFormateur, nomFormateur, prenomFormateur, rue, codePostal, ville, telephone, niveauEtude, dateIntervention, salaire, uneAgence);
                lesFormateurs.Add(unFormateur);
            }

            return lesFormateurs;
        }
    }
}
