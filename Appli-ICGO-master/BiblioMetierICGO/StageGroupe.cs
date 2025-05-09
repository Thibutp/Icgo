using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioMetierICGO
{
    public class StageGroupe:Stage
    {
        #region Attributs privés

        private string nbHeures;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur
        /// </summary>
        public StageGroupe()
        {
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
        /// <param name="unNbHeures">Nombre d'heures</param>
        public StageGroupe(int unNumStage, string unNomStage, int uneDuree, string unPrix, int unNbPlaces, Competence uneCompetence, string unNbHeures)
            : base(unNumStage, unNomStage, uneDuree, unPrix, unNbPlaces, uneCompetence)
        {
            nbHeures = unNbHeures;
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
        /// <param name="unNbHeures">Nombre d'heures</param>
        public StageGroupe(int unNumStage, string unNomStage, int uneDuree, string unPrix, int unNbPlaces, Competence uneCompetence, List<Module> desModules, string unNbHeures) : base(unNumStage, unNomStage, uneDuree, unPrix, unNbPlaces, uneCompetence, desModules)
        {
            nbHeures = unNbHeures;
        }

        #endregion

        #region Accesseurs

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Nombre d'heures</returns>
        public string GetNbHeures()
        {
            return nbHeures;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Nombre d'heures</param>
        public void SetNbHeures(string value)
        {
            nbHeures = value;
        }

        #endregion
    }
}
