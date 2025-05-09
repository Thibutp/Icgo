using BiblioDAOICGO;
using BiblioMetierICGO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblioManager
{
    public class SessionStageManager
    {
        static public void ChargerLesSessionsStage(ComboBox cboSession, ComboBox cboStage, ComboBox cboAgence, ComboBox cboForamteur)
        {
            List<Session> lesSessions = new List<Session>();
            List<Stage> lesStages = new List<Stage>();
            List<Agence> lesAgences = new List<Agence>();
            List<Formateur> lesFormateurs = new List<Formateur>();

            // Recherche des stages dans la base de données
            lesSessions = SessionDAO.ChargerLesSessions();
            lesStages = StageDAO.ChargerLesStages();
            lesAgences = AgenceDAO.ChargerLesAgences(); 
            lesFormateurs = FormateurDAO.ChargerLesFormateurs();
            // Remise à vide de cboStage
            cboSession.SelectedIndex = -1;
            cboSession.Items.Clear();
            cboStage.SelectedIndex = -1;
            cboStage.Items.Clear();
            cboAgence.SelectedIndex = -1;
            cboAgence.Items.Clear();
            cboForamteur.SelectedIndex = -1;
            cboForamteur.Items.Clear(); 
            // Création d'un libellé "numéro. nom" et ajout dans cboStage pour chaque stage (étalé ou groupé)
            foreach (Session uneSession in lesSessions)
            {
                cboSession.Items.Add(uneSession.getCompetence().GetCodeCompetence() + "-" + uneSession.GetLeStage().GetNumStage() + "-" + uneSession.GetNumSession() + "-" + uneSession.GetLeStage().GetNomStage());
            }

            foreach (Stage unStage in lesStages)
            {
                cboStage.Items.Add(unStage.GetNumStage() + "-" + unStage.GetLaCompetence().GetCodeCompetence() + "-" + unStage.GetNomStage());
            }
            
            foreach (Agence uneAgence in lesAgences)
            {
                cboAgence.Items.Add(uneAgence.NomAgence.ToString()); 
            }

            foreach (Formateur unFormateur in lesFormateurs)
            {
                cboForamteur.Items.Add(unFormateur.GetNumFormateur() + "-" + unFormateur.GetNomFormateur().ToString() + "-" + unFormateur.GetPrenom().ToString()); 
            }
        }
    }

}
