using BiblioDAOICGO;
using BiblioManager;
using BiblioMetierICGO;
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
    public partial class frmCompetence : Form
    {
        public frmCompetence()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chargement du formulaire : initialisation du combo des compétences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCompetence_Load(object sender, EventArgs e)
        {
            CompetenceManager.ChargerLesCompetences(cboCompetence);
        }

        /// <summary>
        /// Ajouter une compétence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string codeCompetence;
            string nomCompetence;
            Competence uneCompetence;

            try
            {
                if (!txtCodeCompetence.Text.Equals(""))
                {
                    // Récupération des informations saisies et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                    codeCompetence = txtCodeCompetence.Text.Replace("'", "''");
                    nomCompetence = txtNomCompetence.Text.Replace("'", "''");
                    // Création de l'objet uneCompetence
                    uneCompetence = new Competence(codeCompetence, nomCompetence);
                    // Création de la compétence dans la base de données
                    CompetenceDAO.AjouterUneCompetence(uneCompetence);
                    // Valorisation de cboCompetence
                    CompetenceManager.ChargerLesCompetences(cboCompetence);
                    // Remise à vide des zones : déclenchement du bouton annuler
                    btnAnnuler_Click(null, EventArgs.Empty);
                    // Message
                    MessageBox.Show("Compétence enregistrée", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Saisir un code compétence", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Fermeture du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Réinitialisation des contrôles graphiques du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtCodeCompetence.Clear();
            txtNomCompetence.Clear();
            cboCompetence.SelectedIndex = -1;
        }

        /// <summary>
        /// Modifier une compétence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            string idCompetence;
            string codeCompetence;
            string nomCompetence;
            Competence uneCompetence;

            // Si une compétence est choisie dans cboCompetence
            if (cboCompetence.SelectedIndex >= 0)
            {
                try
                {
                    // Récupération des informations saisies et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                    idCompetence = cboCompetence.Text;
                    codeCompetence = txtCodeCompetence.Text.Replace("'", "''");
                    nomCompetence = txtNomCompetence.Text.Replace("'", "''");
                    // Création de l'objet uneCompetence
                    uneCompetence = new Competence(codeCompetence, nomCompetence);

                    // Mise à jour de la compétence dans la base de données
                    CompetenceDAO.ModifierUneCompetence(uneCompetence, idCompetence);
                    // Valorisation de cboCompetence
                    CompetenceManager.ChargerLesCompetences(cboCompetence);
                    // Message
                    MessageBox.Show("Compétence modifiée", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Aucune compétence choisie dans la liste", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Supprimer une competence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string idCompetence;
            DialogResult reponse;

            // Si une compétence est choisie dans cboCompetence
            if (cboCompetence.SelectedIndex >= 0)
            {
                reponse = MessageBox.Show("Etes vous sûr de vouloir supprimer cette compétence ?", "Suppression d'une compétence", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (reponse == DialogResult.Yes)
                {
                    try
                    {
                        // Récupération du code compétence choisi dans cboCompetence
                        idCompetence = cboCompetence.Text;
                        // Supprimer la compétence identifiée dans la base de données
                        CompetenceDAO.SupprimerUneCompetence(idCompetence);
                        CompetenceManager.ChargerLesCompetences(cboCompetence);
                        // Message
                        MessageBox.Show("Compétence supprimée", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucune compétence choisie dans la liste", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Changement de la sélection dans le combo
        /// Valorisation des zones de saisie à la sélection d'une compétence choisie dans cboCompetence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCompetence_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idCompetence;
            Competence uneCompetence;

            // Récupération du code compétence choisi dans cboCompetence 
            idCompetence = cboCompetence.Text;
            // Recherche de la compétence identifiée dans la base de données
            uneCompetence = CompetenceDAO.GetCompetence(idCompetence);
            // Valorisation des zones de saisie
            txtCodeCompetence.Text = idCompetence;
            txtNomCompetence.Text = uneCompetence.GetNomCompetence();
        }
    }
}
