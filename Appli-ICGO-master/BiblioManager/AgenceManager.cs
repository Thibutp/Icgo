using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiblioDAOICGO;
using BiblioMetierICGO;

namespace BiblioManager
{
    public class AgenceManager
    {
        /// <summary>
        /// Valorisation de cboAgence
        /// </summary>
        /// <param name="cboAgence">Combo cboAgence</param>
        static public void ChargerLesAgences(ComboBox cboAgence)
        {
            List<Agence> lesAgences = new List<Agence>();

            // Remise à vide de cboAgence
            cboAgence.SelectedIndex = -1;
            cboAgence.Items.Clear();
            // Recherche des agences dans la base de données
            lesAgences = AgenceDAO.ChargerLesAgences();

            // Ajout de chaque nom d'agence dans cboAgence
            foreach (Agence uneAgence in lesAgences)
            {
                cboAgence.Items.Add(uneAgence.GetNomAgence());
            }
        }
    }
}
