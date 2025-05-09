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
    public class StageManager
    {
        /// <summary>
        /// Valorisation de cboStage
        /// </summary>
        /// <param name="cboStage">Combo cboStage</param>
        static public void ChargerLesStages(ComboBox cboStage)
        {
            List<Stage> lesStages = new List<Stage>();

            // Recherche des stages dans la base de données
            lesStages = StageDAO.ChargerLesStages();
            // Remise à vide de cboStage
            cboStage.SelectedIndex = -1;
            cboStage.Items.Clear();
            // Création d'un libellé "numéro. nom" et ajout dans cboStage pour chaque stage (étalé ou groupé)
            foreach (dynamic unStage in lesStages)
            {
                cboStage.Items.Add(unStage.GetLaCompetence().GetCodeCompetence() + ". " + unStage.GetNumStage() + ". " + unStage.GetNomStage());
            }
        }
    }
}
