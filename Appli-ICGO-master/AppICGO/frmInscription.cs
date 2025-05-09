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
    public partial class frmInscription : Form
    {
        public frmInscription()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmInscription_Load(object sender, EventArgs e)
        {
            // Charger les états d'inscription dans la ComboBox cboEtat
            InscriptionManager.ChargerEtatInscription(cboEtat);

            InscriptionManager.ChargerLesStagiaire(cboStagiaire);

        }


        /// <summary>
        /// Remise à vide de l'ensemble des zones de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cboStagiaire.SelectedIndex = -1;
            cboSession.SelectedIndex = -1;
            cboEtat.SelectedIndex = -1;
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Ouverture du formulaire frmStagiaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStagiaire_Click(object sender, EventArgs e)
        {
            frmStagiaire fs = new frmStagiaire();
            cboStagiaire.SelectedIndex = -1;
            fs.Show();
        }

        private void cboStagiaire_SelectedIndexChanged_3(object sender, EventArgs e)
        {
            if (cboStagiaire.SelectedIndex != -1)
            {
                // Extraire l'ID du stagiaire sélectionné
                int idStagiaire = Utilitaires.ExtraireNumStagiaire(cboStagiaire.Text);

                // Charger les sessions non choisies pour ce stagiaire
                InscriptionManager.ChargerLesSessions(cboSession, idStagiaire);
            }
        }


        private void cboSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Vérifier si un élément a été sélectionné
            if (cboSession.SelectedIndex != -1)
            {
                // Récupérer l'élément sélectionné (texte)
                string selectedSession = cboSession.SelectedItem.ToString();
            }
        }

        private void cboEtat_SelectedIndexChanged(object sender, EventArgs e)
        {
             // Vérifie si un élément est sélectionné
            if (cboEtat.SelectedIndex != -1)
            {
                string etatSelectionne = cboEtat.SelectedItem.ToString();
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int numStagiaire;
            string codeCompetence;
            int numStage;
            int numSession;
            Stagiaire unStagiaire;
            Session uneSession;
            string unEtat;
            Inscription uneInscription;

            try
            {
                // Vérification que les ComboBox ont bien une sélection
                if (cboStagiaire.SelectedIndex >= 0 && cboSession.SelectedIndex >= 0 && !string.IsNullOrEmpty(cboEtat.Text))
                {
                    // Récupération du numéro de stagiaire et de ses informations
                    numStagiaire = Utilitaires.ExtraireNumStagiaire(cboStagiaire.Text);
                    unStagiaire = StagiaireDAO.GetStagiaire(numStagiaire);

                    // Récupération des informations de session
                    Utilitaires.ExtraireIdSession(cboSession.Text, out codeCompetence, out numStage, out numSession);
                    uneSession = SessionDAO.GetSession(codeCompetence, numStage, numSession);

                    // Récupération de l'état de l'inscription (Définitif ou Provisoire)
                    unEtat = cboEtat.Text;

                    // Création de l'objet Inscription en fonction de l'état
                    uneInscription = new Inscription(uneSession, unStagiaire, unEtat == "Définitif" ? "d" : "p");

                    // Vérification des places disponibles avant d'ajouter l'inscription
                    if (InscriptionDAO.VerifierPlacesDisponibles(codeCompetence, numStage, numSession) != 0)
                    {
                        // Ajout de l'inscription dans la base de données
                        InscriptionDAO.AjouterUneInscription(uneInscription);

                        // Message de confirmation
                        MessageBox.Show("La session a bien été enregistrée", "Information !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Message si les places sont indisponibles
                        MessageBox.Show("Il n'y a plus de place disponible", "Information !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Remise à zéro des champs après l'ajout (similaire à votre bouton Annuler)
                    btnAnnuler_Click(null, EventArgs.Empty);
                }
                else
                {
                    // Message d'erreur si une sélection est manquante
                    MessageBox.Show("Veuillez remplir tous les champs correctement !", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                MessageBox.Show(ex.Message, "Ajout échoué !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
