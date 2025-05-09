using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioMetierICGO;
using MySql.Data.MySqlClient;

namespace BiblioDAOICGO
{
    public class ModuleDAO
    {
        /// <summary>
        /// Ajouter un module dans la table MODULE
        /// </summary>
        /// <param name="unModule">Un module</param>
        public static void AjouterUnModule(Module unModule)
        {
            string requete = "INSERT INTO `module`(`NUMMODULE`, `NOMMODULE`, `NOMSUPPORTCOURS`, `NOMPRESENTATION`, `PLACESUPPORTCOURS`, `PLACEPRESENTATION`) VALUES (@numS, @nomS, @nomsupportS, @nompresentationS, @palcesupportS, @placepresentationS)";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@numS", unModule.GetNumModule()),
                new MySqlParameter("@nomS", unModule.GetNomModule()),
                new MySqlParameter("@nomsupportS", unModule.GetNomSupportCours()),
                new MySqlParameter("@nompresentationS", unModule.GetNomPresentation()),
                new MySqlParameter("@palcesupportS", unModule.GetPlaceSupportCours()),
                new MySqlParameter("@placepresentationS", unModule.GetPlacePresentation())
                );


        }

        /// <summary>
        /// Charger les modules de la table MODULE dans une liste de modules
        /// </summary>
        /// <returns></returns>
        public static List<Module> ChargerLesModules()
        {
            List<Module> lesModules = new List<Module>();
            Module unModule;
            int numModule;
            string nomModule;
            string nomSupportCours;
            string nomPresentation;
            string placeSupportCours;
            string placePresentation;



            string requete = "SELECT NUMMODULE, NOMMODULE, NOMSUPPORTCOURS, NOMPRESENTATION, PLACESUPPORTCOURS, PLACEPRESENTATION FROM MODULE;";
            DataTable dt = Connexion.ExecutionRequete(requete, null);
            foreach (DataRow uneLigne in dt.Rows)
            {
                // Récupération des caractéristiques d'un stagiaire à partir du résultat de la requête
                numModule = int.Parse(uneLigne["NUMMODULE"].ToString());
                nomModule = uneLigne["NOMMODULE"].ToString();
                nomSupportCours = uneLigne["NOMSUPPORTCOURS"].ToString();
                nomPresentation = uneLigne["NOMPRESENTATION"].ToString();
                placeSupportCours = uneLigne["PLACESUPPORTCOURS"].ToString();
                placePresentation = uneLigne["PLACEPRESENTATION"].ToString();


                // Construction de l'objet unStagiaire avec chargement des sessions auxquelles ce stagiaire est inscrit
                unModule = new Module(numModule, nomModule, nomSupportCours, nomPresentation, placeSupportCours, placePresentation);

                // Ajout du stagiaire dans la liste lesStagiaires
                lesModules.Add(unModule);
            }
            return lesModules;

        }

        /// <summary>
        /// Retourne un module identifié par son numéro dans la table MODULE
        /// </summary>
        /// <param name="idModule">Numéro module</param>
        /// <returns></returns>
        public static Module GetModule(int idModule)
        {
            Module unModule;
            string requete = "SELECT NUMMODULE, NOMMODULE, NOMSUPPORTCOURS, NOMPRESENTATION, PLACESUPPORTCOURS, PLACEPRESENTATION FROM module WHERE NUMMODULE = @id";
            DataTable dt = Connexion.ExecutionRequete(requete,
               new MySqlParameter("@id", idModule));
            if (dt.Rows.Count == 1)
            {
                int numModule = int.Parse(dt.Rows[0]["NUMMODULE"].ToString());
                string nomModule = dt.Rows[0]["NOMMODULE"].ToString();
                string nomSupportCours = dt.Rows[0]["NOMSUPPORTCOURS"].ToString();
                string nomPresentation = dt.Rows[0]["NOMPRESENTATION"].ToString();
                string placeSupportCours = dt.Rows[0]["PLACESUPPORTCOURS"].ToString();
                string placePresentation = dt.Rows[0]["PLACEPRESENTATION"].ToString();

                // Construction de l'objet unFormateur avec chargement des compétences attribuées à ce formateur
                unModule = new Module(numModule, nomModule, nomSupportCours, nomPresentation, placeSupportCours, placePresentation);
            }
            else
            {
                unModule = new Module();
            }



            return unModule;
        }

        /// <summary>
        /// Modifier les caractéristiques d'un module identifié par son numéro dans la table MODULE
        /// </summary>
        /// <param name="unModule">Un module</param>
        /// <param name="idModule">Numéro module</param>
        public static void ModifierUnModule(Module unModule, int idModule)
        {

            // Exécution de la requête de modification
            string requete = "UPDATE MODULE SET NUMMODULE = @numS, NOMMODULE = @nomS, NOMSUPPORTCOURS = @nomsupportS, NOMPRESENTATION = @nompresentationS, PLACESUPPORTCOURS = @palcesupportS, PLACEPRESENTATION = @placepresentationS WHERE NUMMODULE = @idS";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@numS", unModule.GetNumModule()),
                new MySqlParameter("@nomS", unModule.GetNomModule()),
                new MySqlParameter("@nomsupportS", unModule.GetNomSupportCours()),
                new MySqlParameter("@nompresentationS", unModule.GetNomPresentation()),
                new MySqlParameter("@palcesupportS", unModule.GetPlaceSupportCours()),
                new MySqlParameter("@placepresentationS", unModule.GetPlacePresentation()),
                new MySqlParameter("@idS", idModule));

        }

        /// <summary>
        /// Supprimer un module identifié par son numéro dans la table MODULE
        /// </summary>
        /// <param name="idModule">Numéro module</param>
        public static void SupprimerUnModule(int idModule)
        {

            // Exécution de la requête de suppression
            string requete = "DELETE FROM MODULE WHERE NUMMODULE = @idS";
            Connexion.ExecutionMaj(requete,
                new MySqlParameter("@idS", idModule));

        }

        /// <summary>
        /// Charger les modules de la table COMPOSER d'un stage identifié par son code compétence et numéro stage
        /// </summary>
        /// <param name="idCompetence">Code compétence</param>
        /// <param name="idStage">Numéro stage</param>
        /// <returns></returns>
        public static List<Module> ChargerLesModulesDuStage(string idCompetence, int idStage)
        {
            int numModule;
            string nomModule;
            string nomSupportCours;
            string nomPresentation;
            string placeSupportCours;
            string placePresentation;
            Module unModule;
            List<Module> lesModules = new List<Module>();

            string requete = "SELECT DISTINCT m.NUMMODULE, m.NOMMODULE, m.NOMSUPPORTCOURS, m.NOMPRESENTATION, m.PLACESUPPORTCOURS, m.PLACEPRESENTATION " +
                "FROM composer c " +
                "INNER JOIN stage s ON s.CODECOMPETENCE = c.CODECOMPETENCE AND s.NUMSTAGE = c.NUMSTAGE " +
                "INNER JOIN module m ON m.NUMMODULE = c.NUMMODULE " +
                "WHERE s.CODECOMPETENCE = @codeCompetence AND s.NUMSTAGE = @numStage;";

            DataTable dt = Connexion.ExecutionRequete(requete,
                new MySqlParameter("@codeCompetence", idCompetence),
                new MySqlParameter("@numStage", idStage));

            foreach (DataRow uneLigne in dt.Rows)
            {
                // Récupération des caractéristiques d'un stagiaire à partir du résultat de la requête
                numModule = int.Parse(uneLigne["NUMMODULE"].ToString());
                nomModule = uneLigne["NOMMODULE"].ToString();
                nomSupportCours = uneLigne["NOMSUPPORTCOURS"].ToString();
                nomPresentation = uneLigne["NOMPRESENTATION"].ToString();
                placeSupportCours = uneLigne["PLACESUPPORTCOURS"].ToString();
                placePresentation = uneLigne["PLACEPRESENTATION"].ToString();


                // Construction de l'objet unStagiaire avec chargement des sessions auxquelles ce stagiaire est inscrit
                unModule = new Module(numModule, nomModule, nomSupportCours, nomPresentation, placeSupportCours, placePresentation);

                // Ajout du stagiaire dans la liste lesStagiaires
                lesModules.Add(unModule);
            }
            return lesModules;

        }
    }
}
