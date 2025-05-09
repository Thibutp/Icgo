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
    public class StageDAO
    {
        /// <summary>
        /// Ajouter un stage dans la table STAGE
        /// </summary>
        /// <param name="unStage">Un stage</param>
        public static void AjouterUnStage(dynamic unStage)
        {
            // Détermination du type de stage (étalé ou groupé) et exécution de la requête d'insertion
            string requete;
            if (unStage is StageEtale)
            {
                requete = "INSERT INTO STAGE VALUES (@codeComp, @numS ,@nomS, @dureeS, @prixS, @nbPS, 'E', @jourS, NULL)";
                Connexion.ExecutionMaj(requete,
                    new MySqlParameter("@codeComp", unStage.GetLaCompetence().GetCodeCompetence()),
                    new MySqlParameter("@numS", unStage.GetNumStage()),
                    new MySqlParameter("@nomS", unStage.GetNomStage()),
                    new MySqlParameter("@dureeS", unStage.GetDuree()),
                    new MySqlParameter("@prixS", unStage.GetPrix()),
                    new MySqlParameter("@nbPS", unStage.GetNbPlaces()),
                    new MySqlParameter("@jourS", unStage.GetJour())
                    );
            }
            else
            {
                requete = "INSERT INTO STAGE VALUES ( @codeComp, @numS, @nomS, @dureeS, @prixS, @nbPS, 'G', NULL , @nbHeureS)";
                Connexion.ExecutionMaj(requete,
                    new MySqlParameter("@codeComp", unStage.GetLaCompetence().GetCodeCompetence()),
                    new MySqlParameter("@numS", unStage.GetNumStage()),
                    new MySqlParameter("@nomS", unStage.GetNomStage()),
                    new MySqlParameter("@dureeS", unStage.GetDuree()),
                    new MySqlParameter("@prixS", unStage.GetPrix()),
                    new MySqlParameter("@nbPS", unStage.GetNbPlaces()),
                    new MySqlParameter("@nbHeureS", unStage.GetNbHeures())
                    );
            }
        }

        /// <summary>
        /// Charger les stages de la table STAGE dans une liste de stages
        /// </summary>
        /// <returns></returns>
        public static List<Stage> ChargerLesStages()
        {
            List<Stage> lesStages = new List<Stage>();

            Stage unStage;
            int numStage;
            int duree;
            string nbHeures;
            int nbPlaces;
            string prix;
            string nomStage;
            string jour;
            Competence uneCompetence;
            string codeCompetence;
            string typeStage;

            lesStages.Clear();

            // Exécuter la requête de sélection
            string requete = "SELECT CODECOMPETENCE, NUMSTAGE, INTITULESTAGE, DUREESTAGE, PRIXSTAGE, NOMBREPLACESSTAGE, TYPESTAGE, JOUR, NOMBREHEURESPARJOUR FROM STAGE";
            DataTable dt = Connexion.ExecutionRequete(requete, null);

            foreach (DataRow uneLigne in dt.Rows)
            {
                // Récupération des caractéristiques d'une session à partir du résultat de la requête
                codeCompetence = uneLigne["CODECOMPETENCE"].ToString();
                numStage = int.Parse(uneLigne["NUMSTAGE"].ToString());
                nomStage = uneLigne["INTITULESTAGE"].ToString();
                duree = int.Parse(uneLigne["DUREESTAGE"].ToString());
                prix = uneLigne["PRIXSTAGE"].ToString();
                nbPlaces = int.Parse(uneLigne["NOMBREPLACESSTAGE"].ToString());
                typeStage = uneLigne["TYPESTAGE"].ToString();
                uneCompetence = CompetenceDAO.GetCompetence(codeCompetence);
                // Création de l'objet unStage en fonction de son type (étalé ou groupé) et ajout dans la liste des stages 
                if (typeStage.Equals("E"))
                {
                    jour = uneLigne["JOUR"].ToString();
                    unStage = new StageEtale(numStage, nomStage, duree, prix, nbPlaces, uneCompetence, ModuleDAO.ChargerLesModulesDuStage(codeCompetence, numStage), jour);
                }
                else
                {
                    nbHeures = uneLigne["NOMBREHEURESPARJOUR"].ToString();
                    unStage = new StageGroupe(numStage, nomStage, duree, prix, nbPlaces, uneCompetence, ModuleDAO.ChargerLesModulesDuStage(codeCompetence, numStage), nbHeures);
                }
                // Ajout du stage dans la liste lesStages
                lesStages.Add(unStage);
            }

            return lesStages;
        }

        /// <summary>
        /// Retourne un stage (étalé ou groupé) identifié dans la table STAGE
        /// </summary>
        /// <param name="idCompetence">Code compétence</param>
        /// <param name="idStage">Numéro stage</param>
        /// <returns></returns>
        public static Stage GetStage(string idCompetence, int idStage)
        {
            Stage unStage = new Stage();
            int duree;
            string nbHeures;
            int nbPlaces;
            string prix;
            string nomStage;
            string jour;
            Competence uneCompetence;
            String typeStage;

            // Recherche du stage dans la table STAGE
            string requete = "SELECT INTITULESTAGE, DUREESTAGE, PRIXSTAGE, NOMBREPLACESSTAGE, TYPESTAGE, JOUR, NOMBREHEURESPARJOUR FROM STAGE WHERE CODECOMPETENCE = @idComp AND NUMSTAGE = @idS";
            DataTable dt = Connexion.ExecutionRequete(requete,
                new MySqlParameter("@idComp", idCompetence),
                new MySqlParameter("@idS", idStage)
                );

            if (dt.Rows.Count == 1)
            {
                nomStage = dt.Rows[0]["INTITULESTAGE"].ToString();
                duree = int.Parse(dt.Rows[0]["DUREESTAGE"].ToString());
                prix = dt.Rows[0]["PRIXSTAGE"].ToString();
                nbPlaces = int.Parse(dt.Rows[0]["NOMBREPLACESSTAGE"].ToString());
                typeStage = dt.Rows[0]["TYPESTAGE"].ToString();
                uneCompetence = CompetenceDAO.GetCompetence(idCompetence);
                // Création de l'objet unStage en fonction de son type (étalé ou groupé) et ajout dans la liste des stages 
                if (typeStage.Equals("E"))
                {
                    jour = dt.Rows[0]["JOUR"].ToString();
                    unStage = new StageEtale(idStage, nomStage, duree, prix, nbPlaces, uneCompetence, ModuleDAO.ChargerLesModulesDuStage(idCompetence, idStage), jour);
                }
                else
                {
                    nbHeures = dt.Rows[0]["NOMBREHEURESPARJOUR"].ToString();
                    unStage = new StageGroupe(idStage, nomStage, duree, prix, nbPlaces, uneCompetence, ModuleDAO.ChargerLesModulesDuStage(idCompetence, idStage), nbHeures);
                }

            }

            return unStage;
        }

        /// <summary>
        /// Modifier les caractéristiques d'un stage identifié dans la table STAGE
        /// </summary>
        /// <param name="unStage">Un stage</param>
        /// <param name="idCompetence">Code compétence</param>
        /// <param name="idStage">Numéro stage</param>
        public static void ModifierUnStage(dynamic unStage, string idCompetence, int idStage)
        {
            // Exécution de la requête de modification en fonction du type de stage (étalé ou groupé)
            string requete;
            if (unStage is StageEtale)
            {
                requete = "UPDATE STAGE SET CODECOMPETENCE = @codeComp, NUMSTAGE = @numS, INTITULESTAGE = @nomS, DUREESTAGE = @dureeS, PRIXSTAGE = @prixS, NOMBREPLACESSTAGE = @nbPS, TYPESTAGE = 'E', JOUR = @jourS, NOMBREHEURESPARJOUR = NULL WHERE CODECOMPETENCE = @idComp AND NUMSTAGE = @idS";
                Connexion.ExecutionMaj(requete,
                    new MySqlParameter("@codeComp", unStage.GetLaCompetence().GetCodeCompetence()),
                    new MySqlParameter("@numS", unStage.GetNumStage()),
                    new MySqlParameter("@nomS", unStage.GetNomStage()),
                    new MySqlParameter("@dureeS", unStage.GetDuree()),
                    new MySqlParameter("@prixS", unStage.GetPrix()),
                    new MySqlParameter("@nbPS", unStage.GetNbPlaces()),
                    new MySqlParameter("@jourS", unStage.GetJour()),
                    new MySqlParameter("@idComp", idCompetence),
                    new MySqlParameter("@idS", idStage)
                    );
            }
            else
            {
                requete = "UPDATE STAGE SET CODECOMPETENCE = @codeComp, NUMSTAGE = @numS, INTITULESTAGE = @nomS, DUREESTAGE = @dureeS, PRIXSTAGE = @prixS, NOMBREPLACESSTAGE = @nbPS, TYPESTAGE = 'G', JOUR = NULL , NOMBREHEURESPARJOUR = @nbHeure WHERE CODECOMPETENCE = @idComp AND NUMSTAGE = @idS";
                Connexion.ExecutionMaj(requete,
                    new MySqlParameter("@codeComp", unStage.GetLaCompetence().GetCodeCompetence()),
                    new MySqlParameter("@numS", unStage.GetNumStage()),
                    new MySqlParameter("@nomS", unStage.GetNomStage()),
                    new MySqlParameter("@dureeS", unStage.GetDuree()),
                    new MySqlParameter("@prixS", unStage.GetPrix()),
                    new MySqlParameter("@nbPS", unStage.GetNbPlaces()),
                    new MySqlParameter("@nbHeure", unStage.GetNbHeures()),
                    new MySqlParameter("@idComp", idCompetence),
                    new MySqlParameter("@idS", idStage)
                    );
            }
        }

        /// <summary>
        /// Supprimer un stage identifié dans la table STAGE
        /// </summary>
        /// <param name="idCompetence">Code compétence</param>
        /// <param name="idStage">Numéro stage</param>
        public static void SupprimerUnStage(string idCompetence, int idStage)
        {
            // Exécution de la requête de suppression
            string requete = "DELETE FROM STAGE WHERE CODECOMPETENCE = @idComp AND NUMSTAGE = @idS";
            Connexion.ExecutionMaj(requete,
                    new MySqlParameter("@idComp", idCompetence),
                    new MySqlParameter("@idS", idStage)
                    );
        }

        /// <summary>
        /// Ajouter un module à un stage dans la table COMPOSER
        /// </summary>
        /// <param name="unStage">Un stage</param>
        /// <param name="unModule">Un module</param>
        public static void AjouterUnModule(Stage unStage, Module unModule)
        {
            string requete = "INSERT INTO composer (CODECOMPETENCE, NUMSTAGE, NUMMODULE) VALUES (@codeCompetence, @numStage, @numModule)";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@codeCompetence", unStage.GetLaCompetence().GetCodeCompetence()),
                new MySqlParameter("@numStage", unStage.GetNumStage()),
                new MySqlParameter("@numModule", unModule.GetNumModule())); 
        }

        /// <summary>
        /// Supprimer un module à un stage dans la table COMPOSER
        /// </summary>
        /// <param name="unStage">Un stage</param>
        /// <param name="unModule">Un module</param>
        public static void SupprimerUnModule(Stage unStage, Module unModule)
        {
            string requete = "DELETE FROM composer WHERE codeCompetence = @codeCompetence AND numStage = @numStage AND numModule = @numModule";
            Connexion.ExecutionMaj(requete,
            new MySqlParameter("@codeCompetence", unStage.GetLaCompetence().GetCodeCompetence()),
            new MySqlParameter("@numStage", unStage.GetNumStage()),
            new MySqlParameter("@numModule", unModule.GetNumModule()));

        }

        /// <summary>
        /// Charger les stages de la table COMPOSER d'un module identifié par son numéro
        /// </summary>
        /// <param name="idModule">Numéro module</param>
        /// <returns></returns>
        public static List<Stage> ChargerLesStagesDuModule(int idModule)
        {
            List<Stage> lesStages = new List<Stage>();

            return lesStages;
        }

        public static List<Module> ChargerLesModules(string codeCompetence, int numStage)
        {
            List<Module> lesModules = new List<Module>();

            string requete = "SELECT module.NUMMODULE, module.NOMMODULE, module.NOMSUPPORTCOURS, " +
                             "       module.NOMPRESENTATION, module.PLACESUPPORTCOURS, module.PLACEPRESENTATION " +
                             "FROM module " +
                             "INNER JOIN composer ON module.NUMMODULE = composer.NUMMODULE " +
                             "INNER JOIN stage ON stage.NUMSTAGE = composer.NUMSTAGE " +
                             "WHERE stage.CODECOMPETENCE = @codeCompetence " +
                             "AND stage.NUMSTAGE = @numStage";

            DataTable dt = Connexion.ExecutionRequete(requete,
                new MySqlParameter("@codeCompetence", codeCompetence),
                new MySqlParameter("@numStage", numStage));

            // Parcourir chaque ligne du DataTable
            foreach (DataRow row in dt.Rows)
            {
                int numModule = int.Parse(row["NUMMODULE"].ToString());
                string nomModule = row["NOMMODULE"].ToString();
                string nomSupportCours = row["NOMSUPPORTCOURS"].ToString();
                string nomPresentation = row["NOMPRESENTATION"].ToString();
                string placeSupportCours = row["PLACESUPPORTCOURS"].ToString();
                string placePresentation = row["PLACEPRESENTATION"].ToString();

                // Créer l'objet Module
                Module unModule = new Module(numModule, nomModule, nomSupportCours, nomPresentation, placeSupportCours, placePresentation);

                // Ajouter à la liste
                lesModules.Add(unModule);
            }

            return lesModules;
        }
    }
}
