using BiblioDAOICGO;
using BiblioMetierICGO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblioManager
{
    public class CompetenceManager
    {
        /// <summary>
        /// Valorisation de cboCompetence
        /// </summary>
        /// <param name="cboCompetence">Combo cboCompetence</param>
        static public void ChargerLesCompetences(ComboBox cboCompetence)
        {
            List<Competence> lesCompetences = new List<Competence>();

            // Remise à vide de cboCompetence
            cboCompetence.SelectedIndex = -1;
            cboCompetence.Items.Clear();
            // Recherche des compétences dans la base de données
            lesCompetences = CompetenceDAO.ChargerLesCompetences();
            // Ajout de chaque code compétence dans cboCompetence
            foreach (Competence uneCompetence in lesCompetences)
            {
                cboCompetence.Items.Add(uneCompetence.GetCodeCompetence());
            }
        }

    }
}
