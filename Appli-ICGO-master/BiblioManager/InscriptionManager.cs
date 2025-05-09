using BiblioDAOICGO;
using BiblioMetierICGO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblioManager
{
    public class InscriptionManager
    {
        /// <summary>
        /// Valorisation de cboStagiaire
        /// </summary>
        /// <param name="cboStagiaire">Combo cboStagiaire</param>
        static public void ChargerLesStagiaire(ComboBox cboStagiaire)
        {
            List<Stagiaire> lesStagiaires = new List<Stagiaire>();

            // Recherche des Stagiaire dans la base de données
            lesStagiaires = StagiaireDAO.ChargerLesStagiaires();
            // Remise à vide de cboStagiaire
            cboStagiaire.SelectedIndex = -1;
            cboStagiaire.Items.Clear();
            // Création d'un libellé "numéro. nom prénom" et ajout dans cboStagiaire pour chaque Stagiaire
            foreach (Stagiaire unStagiaire in lesStagiaires)
            {
                cboStagiaire.Items.Add(unStagiaire.GetNumStagiaire() + ". " + unStagiaire.GetNomStagiaire() + " " + unStagiaire.GetPrenom());
            }


        }

        static public void ChargerEtatInscription(ComboBox cboEtat)
        {
            // Liste des états d'inscription que vous souhaitez afficher dans le ComboBox
            List<string> etatsInscription = new List<string>
            {
                "Définitif",
                "Provisoire"
            };

            // Remise à zéro de cboEtat
            cboEtat.SelectedIndex = -1;
            cboEtat.Items.Clear();

            // Ajout des états d'inscription dans le ComboBox
            foreach (string etat in etatsInscription)
            {
                cboEtat.Items.Add(etat);
            }
        }

        /// <summary>
        /// Charge dans la ComboBox les sessions non choisies par un stagiaire donné.
        /// </summary>
        /// <param name="cboSession">La ComboBox des sessions</param>
        /// <param name="idStagiaire">L'identifiant du stagiaire</param>
        static public void ChargerLesSessions(ComboBox cboSession, int idStagiaire)
        {
            List<Session> sessions = new List<Session>();

            try
            {
                // Recherche des sessions non choisies par le stagiaire
                sessions = SessionDAO.ChargerLesSessionsNonChoisiesDuStagiaire(idStagiaire);

                // Remise à vide de cboSession
                cboSession.SelectedIndex = -1;
                cboSession.Items.Clear();

                foreach (Session uneSession in sessions)
                {
                    // On récupère les places disponibles via la procédure stockée
                    int placesDisponibles = InscriptionDAO.VerifierPlacesDisponibles(
                        uneSession.getCompetence().GetCodeCompetence(),
                        uneSession.GetLeStage().GetNumStage(),
                        uneSession.GetNumSession()
                    );

                    if (placesDisponibles != 0) // Ajouter uniquement les sessions avec des places
                    {
                        string libelleSession = uneSession.getCompetence().GetCodeCompetence() + "-" +
                                                uneSession.GetLeStage().GetNumStage() + "-" +
                                                uneSession.GetNumSession() + "-" +
                                                uneSession.GetLeStage().GetNomStage();
                        // Ajout du libellé dans la combo box
                        cboSession.Items.Add(libelleSession);
                    }
                }

                // Si aucune session disponible, afficher un message à l'utilisateur
                if (sessions.Count == 0)
                {
                    MessageBox.Show("Aucune session disponible pour ce stagiaire.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des sessions : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
