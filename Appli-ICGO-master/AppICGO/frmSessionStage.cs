using BiblioDAOICGO;
using BiblioManager;
using BiblioMetierICGO;
using BiblioSupport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppICGO
{
    public partial class frmSessionStage : Form
    {
        // Booléen indiquant si une session a été choisie dans cboSession
        private bool choixSession;

        public frmSessionStage()
        {
            InitializeComponent(); 
        }
        /// <summary>
        /// Vider les différents contrôles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            choixSession = false;
            txtNumSession.Clear();
            dtpDateSession.Value = DateTime.Now;
            cboAgence.SelectedIndex = -1;
            cboFormateur.SelectedIndex = -1;
            cboSession.SelectedIndex = -1;
            cboStage.SelectedIndex = -1;
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSessionStage_Load(object sender, EventArgs e)
        {

            SessionStageManager.ChargerLesSessionsStage(cboSession, cboStage, cboAgence, cboFormateur);
        }

        private void cboSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numCompetence;
            int numStage;
            int numSession;
            Session uneSession; 

            if (cboSession.SelectedIndex >= 0)
            {

                Utilitaires.ExtraireIdSession(cboSession.Text, out numCompetence, out numStage, out numSession);
                uneSession = SessionDAO.GetSession(numCompetence, numStage, numSession);
                txtNumSession.Text = uneSession.GetNumSession().ToString();
                dtpDateSession.Text = uneSession.GetDateSession().ToString();
                cboAgence.SelectedItem = uneSession.GetNomAgence();
                cboFormateur.SelectedItem = uneSession.GetLeFormateur().GetNumFormateur() + "-" + uneSession.GetLeFormateur().GetNomFormateur() + "-" + uneSession.GetLeFormateur().GetPrenom();
                cboStage.SelectedItem = uneSession.GetLeStage().GetNumStage() + "-"  + uneSession.GetLeStage().GetLaCompetence().GetCodeCompetence() + "-" + uneSession.GetLeStage().GetNomStage();
                
            }

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            Session uneSession;
            string codeCompetence;
            int numStage;
            int numSession;
            string nomAgence;
            int numFormateur;
            DateTime dateDebutSession;

            Competence uneCompetence;
            Stage unStage;
            Formateur unFormateur;

            // si sélection d'un stage : extraction de son identifiant et recherche et affichage de ses caractéristiques
            if (cboSession.SelectedIndex >= 0)
            {
                if (!int.TryParse(txtNumSession.Text, out numStage))
                {
                    MessageBox.Show("Le numéro de stage est incorrect", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        string[] elements = cboStage.Text.Split('-');
                        // Récupération des informations saisies et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                        codeCompetence = elements[1];

                        numStage = int.Parse(elements[0].ToString());

                        numSession = int.Parse(txtNumSession.Text);
                        elements = cboFormateur.Text.Split('-');
                        numFormateur = int.Parse(elements[0].ToString());

                        nomAgence = cboAgence.Text;
                        dateDebutSession = DateTime.Parse(dtpDateSession.Text);

                        SessionDAO.ModifierUneSession(codeCompetence, numStage, numSession, nomAgence, numFormateur, dateDebutSession);
                        MessageBox.Show("Session enregistrée", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Remise à vide des zones : déclenchement du bouton annuler
                        btnAnnuler_Click(null, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Aucune Session choisi dans la liste", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Session uneSession;
            string codeCompetence;
            int numStage;
            int numSession;
            string nomAgence;
            int numFormateur;
            DateTime dateDebutSession;

            Competence uneCompetence;
            Stage unStage;
            Formateur unFormateur; 

                if (!int.TryParse(txtNumSession.Text, out numSession))
                {
                    MessageBox.Show("Le numéro de stage est incorrect", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                   else
                        {
                            try
                            {
                                string[] elements = cboStage.Text.Split('-'); 
                                // Récupération des informations saisies et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                                codeCompetence = elements[1];
                                uneCompetence = CompetenceDAO.GetCompetence(codeCompetence);
                                
                                numStage = int.Parse(elements[0].ToString());
                                unStage = StageDAO.GetStage(uneCompetence.GetCodeCompetence(), numStage);
                                numSession = int.Parse(txtNumSession.Text);
                                elements = cboFormateur.Text.Split('-'); 
                                numFormateur = int.Parse(elements[0].ToString());
                                unFormateur = FormateurDAO.GetFormateur(numFormateur); 
                                // Selon le type de stage
                                uneSession = new Session(uneCompetence, numSession, DateTime.Parse(dtpDateSession.Text), unStage, unFormateur, cboAgence.Text);
                                // Création du stage dans la base de données
                                SessionDAO.AjouterUneSession(uneSession);
                                // Valorisation de cboStage
                                SessionStageManager.ChargerLesSessionsStage(cboSession, cboStage, cboAgence, cboFormateur);
                        
                                // Message
                                MessageBox.Show("Session enregistrée", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Remise à vide des zones : déclenchement du bouton annuler
                                btnAnnuler_Click(null, EventArgs.Empty);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ajout échoué !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                   }
            
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (cboSession.SelectedIndex > 0)
            {
                if (MessageBox.Show("Êtes vous sûr de vouloir supprimer la session ?", "Supprimer la session", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    string[] elements = cboStage.Text.Split('-');
                    // Récupération des informations saisies et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                    string codeCompetence = elements[1];

                    int numStage = int.Parse(elements[0].ToString());
                    int numSession = int.Parse(txtNumSession.Text);

                    SessionDAO.SupprimerUneSession(codeCompetence, numStage, numSession);
                    SessionStageManager.ChargerLesSessionsStage(cboSession, cboStage, cboAgence, cboFormateur); 
                    MessageBox.Show("La session a bien été supprimée");
                    btnAnnuler_Click(null, EventArgs.Empty); 
                }
            } 
            else
            {
                MessageBox.Show("Aucune session n'a été sélectionnée"); 
            }
        }
    }
}
