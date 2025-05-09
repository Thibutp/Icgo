using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioMetierICGO
{
    public class Stage
    {
        #region Attributs privés

        private int numStage;
        private string nomStage;
        private int duree;
        private string prix;
        private int nbPlaces;
        private Competence laCompetence;
        private List<Module> lesModules;

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur
        /// </summary>

        public Stage()
        {
            lesModules = new List<Module>();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="unNumStage">Numéro stage</param>
        /// <param name="unNomStage">Nom stage</param>
        /// <param name="uneDuree">Durée stage</param>
        /// <param name="unPrix">Prix stage</param>
        /// <param name="unNbPlaces">Nombre de places</param>
        /// <param name="uneCompetence">Compétence enseignée lors du stage</param>
        public Stage(int unNumStage, string unNomStage, int uneDuree, string unPrix, int unNbPlaces, Competence uneCompetence)
        {
            numStage = unNumStage;
            nomStage = unNomStage;
            duree = uneDuree;
            prix = unPrix;
            nbPlaces = unNbPlaces;
            laCompetence = uneCompetence;
            lesModules = new List<Module>();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="unNumStage">Numéro stage</param>
        /// <param name="unNomStage">Nom stage</param>
        /// <param name="uneDuree">Durée stage</param>
        /// <param name="unPrix">Prix stage</param>
        /// <param name="unNbPlaces">Nombre de places</param>
        /// <param name="uneCompetence">Compétence enseignée lors du stage</param>
        /// <param name="desModules">Liste des modules composant le stage</param>
        public Stage(int unNumStage, string unNomStage, int uneDuree, string unPrix, int unNbPlaces, Competence uneCompetence, List<Module> desModules)
        {
            numStage = unNumStage;
            nomStage = unNomStage;
            duree = uneDuree;
            prix = unPrix;
            nbPlaces = unNbPlaces;
            laCompetence = uneCompetence;
            lesModules = new List<Module>();
            lesModules = desModules;
        }

        #endregion

        #region Accesseurs

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Numéro stage</returns>
        public int GetNumStage()
        {
            return numStage;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Numéro stage</param>
        public void SetNumStage(int value)
        {
            numStage = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Nom stage</returns>
        public string GetNomStage()
        {
            return nomStage;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Nom stage</param>
        public void SetNomStage(string value)
        {
            nomStage = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Durée</returns>
        public int GetDuree()
        {
            return duree;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">durée</param>
        public void SetDuree(int value)
        {
            duree = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Prix</returns>
        public string GetPrix()
        {
            return prix;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Prix</param>
        public void SetPrix(string value)
        {
            prix = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Nombre de places</returns>
        public int GetNbPlaces()
        {
            return nbPlaces;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Nombre de places</param>
        public void SetNbPlaces(int value)
        {
            nbPlaces = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Compétence enseignée</returns>
        public Competence GetLaCompetence()
        {
            return laCompetence;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Compétence enseignée</param>
        public void SetLaCompetence(Competence value)
        {
            laCompetence = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Liste des modules</returns>
        public List<Module> GetLesModules()
        {
            return lesModules;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Liste des modules</param>
        public void SetLesModules(List<Module> value)
        {
            lesModules = value;
        }

        #endregion
    }
}
