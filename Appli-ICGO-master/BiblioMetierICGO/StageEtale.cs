using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioMetierICGO
{
    public class StageEtale : Stage
    {
        #region Attributs privés

        private string jour;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur
        /// </summary>
        public StageEtale()
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
        /// <param name="unJour">Jour</param>
        public StageEtale(int unNumStage, string unNomStage, int uneDuree, string unPrix, int unNbPlaces, Competence uneCompetence, string unJour)
            : base(unNumStage, unNomStage, uneDuree, unPrix, unNbPlaces, uneCompetence)
        {
            jour = unJour;
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
        /// <param name="unJour">Jour</param>
        public StageEtale(int unNumStage, string unNomStage, int uneDuree, string unPrix, int unNbPlaces, Competence uneCompetence, List<Module> desModules, string unJour) : base(unNumStage, unNomStage, uneDuree, unPrix, unNbPlaces, uneCompetence, desModules)
        {
            jour = unJour;
        }

        #endregion

        #region Accesseurs

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Jour</returns>
        public string GetJour()
        {
            return jour;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Jour</param>
        public void SetJour(string value)
        {
            jour = value;
        }

        #endregion
    }
}
