using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioMetierICGO
{
    public class Agence
    {
        #region Attributs privés

        private string nomAgence;

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur
        /// </summary>
        public Agence()
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="unNomAgence">Nom agence</param>
        public Agence(string unNomAgence)
        {
            nomAgence = unNomAgence;
        }

        

        #endregion

        #region Accesseurs
        public string NomAgence { get => nomAgence; set => nomAgence = value; }
        /// <summary>
        /// Accesseur Get
        /// </summary>
        /// <returns>Nom agence</returns>
        public string GetNomAgence()
        {
            return nomAgence;
        }

        /// <summary>
        /// Accesseur Set
        /// </summary>
        /// <param name="value">Nom agence</param>
        public void SetNomAgence(string value)
        {
            nomAgence = value;
        }

        #endregion
    }
}
