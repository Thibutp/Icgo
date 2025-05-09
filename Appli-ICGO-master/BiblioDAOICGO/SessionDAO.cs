using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioMetierICGO;
using MySql.Data.MySqlClient;
using BiblioSupport;

namespace BiblioDAOICGO
{
    public class SessionDAO
    {
        /// <summary>
        /// Ajouter une session dans la table SESSION
        /// </summary>
        /// <param name="uneSession"></param>
        public static void AjouterUneSession(Session uneSession)
        {
            string requete;

            requete = "INSERT INTO SESSION VALUES(@codeCompetence, @numStage, @numSession, @nomAgence, @numFormateur, @dateDebutSession)";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@codeCompetence", uneSession.GetLeStage().GetLaCompetence().GetCodeCompetence()),
                new MySqlParameter("@numStage", uneSession.GetLeStage().GetNumStage()),
                new MySqlParameter("@numSession", uneSession.GetNumSession()),
                new MySqlParameter("@nomAgence", uneSession.GetNomAgence()),
                new MySqlParameter("@numFormateur", uneSession.GetLeFormateur().GetNumFormateur()),
                new MySqlParameter("@dateDebutSession", uneSession.GetDateSession())); 
        }

        /// <summary>
        ///  Charger les sessions de la table SESSION dans une liste de sessions
        /// </summary>
        /// <returns></returns>
        public static List<Session> ChargerLesSessions()
        {
            List<Session> lesSessions = new List<Session>();
            Session uneSession;
            string codeCompetence;
            int numStage;
            int numSession;
            string nomAgence;
            int numFormateur;
            DateTime dateDebutSession;

            lesSessions.Clear();

            // Requête : 
            string requete = "SELECT * FROM session";
            DataTable dt = Connexion.ExecutionRequete(requete, null); 

            foreach (DataRow uneLigne in dt.Rows)
            {
                // Récupération des caractéristiques d'une session à partir du résultat de la requête
                codeCompetence = uneLigne["CODECOMPETENCE"].ToString();
                numStage = int.Parse(uneLigne["NUMSTAGE"].ToString());
                numSession = int.Parse(uneLigne["NUMSESSION"].ToString());
                nomAgence = uneLigne["NOMAGENCE"].ToString(); 
                numFormateur = int.Parse(uneLigne["NUMFORMATEUR"].ToString()) ;
                dateDebutSession = DateTime.Parse(uneLigne["DATEDEBUTSESSION"].ToString());

                uneSession = new Session(CompetenceDAO.GetCompetence(codeCompetence), numSession, dateDebutSession, StageDAO.GetStage(codeCompetence, numStage), FormateurDAO.GetFormateur(numFormateur), nomAgence);
                lesSessions.Add(uneSession); 
            }

            return lesSessions;
        }

        /// <summary>
        /// Retourne une session identifiée dans la table SESSION
        /// </summary>
        /// <param name="idCompetence">Code compétence</param>
        /// <param name="idStage">Numéro stage</param>
        /// <param name="idSession">Numéro session</param>
        /// <returns></returns>
        public static Session GetSession(string idCompetence, int idStage, int idSession)
        {
            Session uneSession = new Session();
            string codeCompetence;
            int numStage;
            int numSession;
            string nomAgence;
            int numFormateur;
            DateTime dateDebutSession;

            string requete = "SELECT * FROM session WHERE CODECOMPETENCE = @idCompetence AND NUMSTAGE = @idStage AND NUMSESSION = @idSession";
            DataTable dt = Connexion.ExecutionRequete(requete,
            new MySqlParameter("@idCompetence", idCompetence),
            new MySqlParameter("@idStage", idStage),
            new MySqlParameter("@idSession", idSession));

            if (dt.Rows.Count == 1)
            {
                codeCompetence = dt.Rows[0]["CODECOMPETENCE"].ToString();
                numStage = int.Parse(dt.Rows[0]["NUMSTAGE"].ToString());
                numSession = int.Parse(dt.Rows[0]["NUMSESSION"].ToString());
                nomAgence = dt.Rows[0]["NOMAGENCE"].ToString();
                numFormateur = int.Parse(dt.Rows[0]["NUMFORMATEUR"].ToString());
                dateDebutSession = DateTime.Parse(dt.Rows[0]["DATEDEBUTSESSION"].ToString());

                uneSession = new Session(CompetenceDAO.GetCompetence(codeCompetence), numSession, dateDebutSession, StageDAO.GetStage(idCompetence, idStage), FormateurDAO.GetFormateur(numFormateur), nomAgence);
            }

            return uneSession;
        }

        /// <summary>
        /// Modifier les caractéristiques d'une session identifiée dans la table SESSION
        /// </summary>
        /// <param name="uneSession">Une session</param>
        /// <param name="idCompetence">Code compétence</param>
        /// <param name="idStage">Numéro stage</param>
        /// <param name="idSession">Numéro session</param>

        public static void ModifierUneSession(string codeCompetence, int numStage, int numSession, string nomAgence, int numFormateur, DateTime dateDebutSession)
        { 

            string requete = "UPDATE session " +
                "             SET NOMAGENCE = @nomAgence," +
                "             NUMFORMATEUR = @numFormateur," +
                "             DATEDEBUTSESSION = @dateDebutSession " +
                "             WHERE CODECOMPETENCE = @codeCompetence" +
                "             AND NUMSTAGE = @numStage" +
                "             AND NUMSESSION = @numSession ";
            Connexion.ExecutionMaj(requete,
            new MySqlParameter("@nomAgence", nomAgence),
            new MySqlParameter("@numFormateur", numFormateur),
            new MySqlParameter("@dateDebutSession", dateDebutSession),
            new MySqlParameter("@codeCompetence", codeCompetence),
            new MySqlParameter("@numStage", numStage),
            new MySqlParameter("@numSession", numSession));

        }

        /// <summary>
        /// Supprimer une session identifiée dans la table SESSION
        /// </summary>
        /// <param name="idCompetence">Code compétence</param>
        /// <param name="idStage">Numéro stage</param>
        /// <param name="idSession">Numéro session</param>
        public static void SupprimerUneSession(string codeCompetence, int numStage, int numSession)
        {

            string requete = "DELETE FROM session " +
                "             WHERE CODECOMPETENCE = @codeCompetence " +
                "             AND NUMSTAGE = @numStage " +
                "             AND NUMSESSION = @numSession";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@codeCompetence", codeCompetence),
                new MySqlParameter("@numStage", numStage),
                new MySqlParameter("@numSession", numSession));
        }

        /// <summary>
        /// Charger les sessions de la table INSCRIRE d'un stagiaire identifié par son numéro
        /// </summary>
        /// <param name="libelleStagiaire">Libellé du stagiaire</param>
        /// <returns></returns>
        public static List<Session> ChargerLesSessionsDuStagiaire(int numStagiaire)
        {
            List<Session> lesSessions = new List<Session>();

            string requete = "SELECT s.* FROM session s INNER JOIN inscrire i ON s.NUMSESSION = i.NUMSESSION AND s.CODECOMPETENCE = i.CODECOMPETENCE AND s.NUMSTAGE = i.NUMSTAGE WHERE i.NUMSTAGIAIRE = @idStagiaire AND ETATINSCRIPTION = 'p';";

            DataTable dt = Connexion.ExecutionRequete(requete, new MySqlParameter("@idStagiaire", numStagiaire));

            foreach (DataRow uneLigne in dt.Rows)
            {
                string codeCompetence = uneLigne["CODECOMPETENCE"].ToString();
                int numStage = int.Parse(uneLigne["NUMSTAGE"].ToString());
                int numSession = int.Parse(uneLigne["NUMSESSION"].ToString());
                string nomAgence = uneLigne["NOMAGENCE"].ToString();
                int numFormateur = int.Parse(uneLigne["NUMFORMATEUR"].ToString());
                DateTime dateDebutSession = DateTime.Parse(uneLigne["DATEDEBUTSESSION"].ToString());

                // Reconstituer une session et l'ajouter à la liste
                Session uneSession = new Session(
                    CompetenceDAO.GetCompetence(codeCompetence),
                    numSession,
                    dateDebutSession,
                    StageDAO.GetStage(codeCompetence, numStage),
                    FormateurDAO.GetFormateur(numFormateur),
                    nomAgence
                );

                lesSessions.Add(uneSession);
            }

            return lesSessions;
        }

        public static List<Session> ChargerLesSessionsNonChoisiesDuStagiaire(int idStagiaire)
        {
            List<Session> lesSessions = new List<Session>();

            string requete = "select * from session s WHERE NOT EXISTS (SELECT * from inscrire i WHERE s.CODECOMPETENCE = i.CODECOMPETENCE and s.NUMSTAGE = i.NUMSTAGE and s.NUMSESSION = i.NUMSESSION and NUMSTAGIAIRE = @idStagiaire)";

            DataTable dt = Connexion.ExecutionRequete(requete, new MySqlParameter("@idStagiaire", idStagiaire));

            foreach (DataRow uneLigne in dt.Rows)
            {
                string codeCompetence = uneLigne["CODECOMPETENCE"].ToString();
                int numStage = int.Parse(uneLigne["NUMSTAGE"].ToString());
                int numSession = int.Parse(uneLigne["NUMSESSION"].ToString());
                string nomAgence = uneLigne["NOMAGENCE"].ToString();
                int numFormateur = int.Parse(uneLigne["NUMFORMATEUR"].ToString());
                DateTime dateDebutSession = DateTime.Parse(uneLigne["DATEDEBUTSESSION"].ToString());

                Session uneSession = new Session(
                    CompetenceDAO.GetCompetence(codeCompetence),
                    numSession,
                    dateDebutSession,
                    StageDAO.GetStage(codeCompetence, numStage),
                    FormateurDAO.GetFormateur(numFormateur),
                    nomAgence
                );

                lesSessions.Add(uneSession);
            }

            return lesSessions;
        }


    }
}
