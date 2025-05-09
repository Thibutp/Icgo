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
    public class ModuleManager
    {
        /// <summary>
        /// Valorisation de cboAgence
        /// </summary>
        /// <param name="cboModule">Combo cboAgence</param>
        static public void ChargerLesModules(ComboBox cboModule)
        {
            List<Module> lesModules = new List<Module>();

            // Remise à vide de cboAgence
            cboModule.SelectedIndex = -1;
            cboModule.Items.Clear();
            // Recherche des agences dans la base de données
            lesModules = ModuleDAO.ChargerLesModules();

            // Ajout de chaque nom d'agence dans cboAgence
            foreach (Module unModule in lesModules)
            {
                cboModule.Items.Add(unModule.GetNumModule() + ". " + unModule.GetNomModule());
            }
        }
    }
}
