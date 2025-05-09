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
    public class FormateurManager
    {
        /// <summary>
        /// Valorisation de cboFormateur
        /// </summary>
        /// <param name="cboFormateur">Combo cboFormateur</param>
        static public void ChargerLesFormateurs(ComboBox cboFormateur)
        {
            List<Formateur> lesFormateurs = new List<Formateur>();

            // Recherche des formateurs dans la base de données
            lesFormateurs = FormateurDAO.ChargerLesFormateurs();
            // Remise à vide de cboFormateur
            cboFormateur.SelectedIndex = -1;
            cboFormateur.Items.Clear();
            // Création d'un libellé "numéro. nom prénom" et ajout dans cboFormateur pour chaque formateur
            foreach (Formateur unFormateur in lesFormateurs)
            {
                cboFormateur.Items.Add(unFormateur.GetNumFormateur() + ". " + unFormateur.GetNomFormateur() + " " + unFormateur.GetPrenom());
            }
        }
    }
}
