using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioMetierICGO
{
    public class Competence
    {
        #region Attributs privés

        private string codeCompetence;
        private string nomCompetence;
        private List<Formateur> lesFormateurs;
        private string numCompetence;

        public string CodeCompetence { get => codeCompetence; set => codeCompetence = value; }
        public string NomCompetence { get => nomCompetence; set => nomCompetence = value; }
        public List<Formateur> LesFormateurs { get => lesFormateurs; set => lesFormateurs = value; }

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur
        /// </summary>
        public Competence()
        {
            lesFormateurs = new List<Formateur>();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="unCodeCompetence">Code compétence</param>
        /// <param name="unNomCompetence">Nom compétence</param>
        public Competence(string unCodeCompetence, string unNomCompetence)
        {
            codeCompetence = unCodeCompetence;
            nomCompetence = unNomCompetence;
            lesFormateurs = new List<Formateur>();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="unCodeCompetence">Code compétence</param>
        /// <param name="unNomCompetence">Nom compétence</param>
        /// <param name="desFormateurs">Liste des formateurs ayant la compétence</param>
        public Competence(string unCodeCompetence, string unNomCompetence, List<Formateur> desFormateurs)
        {
            codeCompetence = unCodeCompetence;
            nomCompetence = unNomCompetence;
            lesFormateurs = new List<Formateur>();
            lesFormateurs = desFormateurs;
        }

        public Competence(string numCompetence)
        {
            this.numCompetence = numCompetence;
        }

        #endregion

        #region Accesseurs

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Code compétence</returns>
        public string GetCodeCompetence()
        {
            return codeCompetence;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Code compétence</param>
        public void SetCodeCompetence(string value)
        {
            codeCompetence = value;
        }


        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Nom compétence</returns>
        public string GetNomCompetence()
        {
            return nomCompetence;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Nom compétence</param>
        public void SetNomCompetence(string value)
        {
            nomCompetence = value;
        }

        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Les formateurs</returns>
        public List<Formateur> GetLesFormateurs()
        {
            return lesFormateurs;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Les formateurs</param>
        public void SetLesFormateurs(List<Formateur> value)
        {
            lesFormateurs = value;
        }

        #endregion
    }
}
