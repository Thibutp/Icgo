using BiblioMetierICGO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioDAOICGO
{
    public class InscriptionDAO
    {
        /// <summary>
        /// Ajouter une inscription
        /// </summary>
        /// <param name="uneInscription"></param>
        public static void AjouterUneInscription(Inscription uneInscription)
        {
            // Requête SQL corrigée avec la virgule manquante
            string requete = "INSERT INTO inscrire(NUMSTAGIAIRE, CODECOMPETENCE, NUMSTAGE, NUMSESSION, ETATINSCRIPTION) VALUES (@numstagiaire, @codeCompetence, @numStage, @numsession, @etatinscription)";

            // Exécution de la requête avec les paramètres appropriés
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@numstagiaire", uneInscription.GetLeStagiaire().GetNumStagiaire()),
                new MySqlParameter("@codeCompetence", uneInscription.GetLaSession().getCompetence().GetCodeCompetence()),
                new MySqlParameter("@numStage", uneInscription.GetLaSession().GetLeStage().GetNumStage()),
                new MySqlParameter("@numsession", uneInscription.GetLaSession().GetNumSession()),
                new MySqlParameter("@etatinscription", uneInscription.GetEtatInscription())
            );
        }


        /// <summary>
        /// Confirmer une inscription : état définitif 
        /// </summary>
        /// <param name="uneInscription">Une inscription</param>
        public static void ConfirmerInscription(Inscription uneInscription)
        {
            // Exécution de la requête d'insertion
            string requete = "UPDATE inscrire SET ETATINSCRIPTION='d' WHERE NUMSTAGIAIRE = @idStagiaire AND NUMSTAGE = @idStage AND NUMSESSION = @numSession AND CODECOMPETENCE = @codeCompetence";
            Connexion.ExecutionMaj(requete,
               new MySqlParameter("@idStagiaire", uneInscription.GetLeStagiaire().GetNumStagiaire()),
               new MySqlParameter("@numSession", uneInscription.GetLaSession().GetNumSession()),
               new MySqlParameter("@idStage", uneInscription.GetLaSession().GetLeStage().GetNumStage()),
               new MySqlParameter("@codeCompetence", uneInscription.GetLaSession().getCompetence().GetCodeCompetence())
                );
        }

        /// <summary>
        /// Supprimer une inscription identifiée par une session et un stagiaire
        /// </summary>
        /// <param name="idCompetence">Code compétence</param>
        /// <param name="idStage">Numéro stage</param>
        /// <param name="idSession">Numéro session</param>
        /// <param name="idStagiaire">Numéro stagiaire</param>
        public static void SupprimerUneInscription(string idCompetence, int idStage, int idSession, int idStagiaire)
        {
            string requete = "DELETE FROM INSCRIRE WHERE CODECOMPETENCE = @idC AND NUMSTAGE = @idS AND NUMSESSION = @idSession AND NUMSTAGIAIRE = @idStagiaire";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@idC", idCompetence),
                new MySqlParameter("@idS", idStage),
                new MySqlParameter("@idSession", idSession),
                new MySqlParameter("@idStagiaire", idStagiaire)
            );
        }

        /// <summary>
        /// Procédure stockée qui vérifie le nombre de places disponibles
        /// </summary>
        /// <param name="idCompetence"></param>
        /// <param name="idStage"></param>
        /// <param name="idSession"></param>
        /// <returns></returns>
        public static int VerifierPlacesDisponibles(string idCompetence, int idStage, int idSession)
        {
            int dispo = Connexion.ExecutionProc(idCompetence, idStage, idSession);
            return dispo;
        }

        
    }
}
