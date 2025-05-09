using BiblioDAOICGO;
using BiblioManager;
using BiblioMetierICGO;
using BiblioSupport;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Session = BiblioMetierICGO.Session;

namespace AppICGO
{
    public partial class frmConfirmerInscription : Form
    {
        public frmConfirmerInscription()
        {
            InitializeComponent();
        }

        private void frmConfirmerInscription_Load(object sender, EventArgs e)
        {
            StagiaireManager.ChargerLesStagiairesInscrits(cboStagiaire);
        }

        private void cboStagiaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Valorisation de cboSession
            ChargerLesSessionsDuStagiaire();
        }

        /// <summary>
        /// Valorisation de cboSession : chargement des sessions du stagiaire
        /// </summary>
        private void ChargerLesSessionsDuStagiaire()
        {
            try
            {
                // Récupérer le libellé complet sélectionné dans le ComboBox
                string libelleStagiaire = cboStagiaire.Text;

                // Utiliser la méthode ExtraireNumStagiaire pour obtenir le numéro du stagiaire
                int numStagiaire = Utilitaires.ExtraireNumStagiaire(libelleStagiaire);

                // Charger les sessions du stagiaire
                List<Session> sessionsDuStagiaire = SessionDAO.ChargerLesSessionsDuStagiaire(numStagiaire);

                cboSession.Items.Clear();

                foreach (var session in sessionsDuStagiaire)
                {
                    cboSession.Items.Add($"{session.getCompetence().GetCodeCompetence()} - {session.GetLeStage().GetNumStage()} - {session.GetNumSession()} - {session.GetLeStage().GetNomStage()}");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des sessions : " + ex.Message);
            }
        }


        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       private void btnConfirmer_Click(object sender, EventArgs e)
        {
            try
            {
                string libelleStagiaire = cboStagiaire.SelectedItem.ToString();
                string libelleSession = cboSession.SelectedItem.ToString();
                int numStagiaire = Utilitaires.ExtraireNumStagiaire(libelleStagiaire);
                int numSession, numStage;
                string numCompetence;
                Utilitaires.ExtraireIdSession(libelleSession, out numCompetence, out numStage, out numSession);
                Session session = SessionDAO.GetSession(numCompetence, numStage, numSession);
                Stagiaire stagiaire = StagiaireDAO.GetStagiaire(numStagiaire);
                Inscription inscription = new Inscription(session, stagiaire);
                InscriptionDAO.ConfirmerInscription(inscription);
                MessageBox.Show("L'inscription du stagiaire a été confirmée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StagiaireManager.ChargerLesStagiairesInscrits(cboStagiaire);
                cboStagiaire.SelectedIndex = -1;
                cboSession.SelectedIndex = -1;
            }

            catch (FormatException)
            {
                MessageBox.Show("Erreur dans le format des données. Vérifiez la sélection.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                string libelleStagiaire = cboStagiaire.SelectedItem.ToString();
                string libelleSession = cboSession.SelectedItem.ToString();

                if (string.IsNullOrEmpty(libelleStagiaire) || string.IsNullOrEmpty(libelleSession))
                {
                    MessageBox.Show("Veuillez sélectionner un stagiaire et une session pour supprimer l'inscription.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int numStagiaire = Utilitaires.ExtraireNumStagiaire(libelleStagiaire);
                int numSession, numStage;
                string numCompetence;
                Utilitaires.ExtraireIdSession(libelleSession, out numCompetence, out numStage, out numSession);
                InscriptionDAO.SupprimerUneInscription(numCompetence, numStage, numSession, numStagiaire);
                MessageBox.Show("L'inscription a été supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
