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
    public class StagiaireManager
    {
        /// <summary>
        /// Valorisation de cboStagiaire
        /// </summary>
        /// <param name="cboStagiaire">Combo cboStagiaire</param>
        static public void ChargerLesStagiaires(ComboBox cboStagiaire)
        {
            List<Stagiaire> lesStagiaires = new List<Stagiaire>();
            // Recherche des stagiaires dans la base de données
            lesStagiaires = StagiaireDAO.ChargerLesStagiaires();
            // Remise à vide de cboStagaire
            cboStagiaire.SelectedIndex = -1;
            cboStagiaire.Items.Clear();
            // Création d'un libellé "numéro. nom prénom" et ajout dans cboStagiaire pour chaque stagiaire
            foreach (Stagiaire unStagiaire in lesStagiaires)
            {
                cboStagiaire.Items.Add(unStagiaire.GetNumStagiaire() + ". " + unStagiaire.GetNomStagiaire() + " " + unStagiaire.GetPrenom());
            }
        }

        /// <summary>
        /// Valorisation de cboStagiaire
        /// </summary>
        /// <param name="cboStagiaire">Combo cboStagiaire</param>
        static public void ChargerLesStagiairesInscrits(ComboBox cboStagiaire)
        {
            List<Stagiaire> lesStagiairesInscrits = new List<Stagiaire>();
            // Recherche des stagiaires dans la base de données
            lesStagiairesInscrits = StagiaireDAO.ChargerLesStagiairesInscrits();
            // Remise à vide de cboStagaire
            cboStagiaire.SelectedIndex = -1;
            cboStagiaire.Items.Clear();
            // Création d'un libellé "numéro. nom prénom" et ajout dans cboStagiaire pour chaque stagiaire
            foreach (Stagiaire unStagiaire in lesStagiairesInscrits)
            {
                cboStagiaire.Items.Add(unStagiaire.GetNumStagiaire() + ". " + unStagiaire.GetNomStagiaire() + " " + unStagiaire.GetPrenom());
            }
        }
    }
}
