using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiblioManager;
using BiblioMetierICGO;
using BiblioSupport;
using BiblioDAOICGO;

namespace AppICGO
{
    public partial class frmStagiaire : Form
    {
        public frmStagiaire()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStagiaire_Load(object sender, EventArgs e)
        {
            // Valorisation de cboStagiaire
            StagiaireManager.ChargerLesStagiaires(cboStagiaire);
        }

        /// <summary>
        /// Ajouter un stagiaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int numStagiaire;
            string nomStagiaire, prenomStagiaire;
            string rue, codePostal, ville;
            string telephone;
            Stagiaire unStagiaire;

            if (!int.TryParse(txtNumStagiaire.Text, out numStagiaire))
            {
                MessageBox.Show("Le numéro de stagiaire est incorrect", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // Récupération des informations saisies et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                    nomStagiaire = txtNomStagiaire.Text.Replace("'", "''");
                    prenomStagiaire = txtPrenomStagiaire.Text.Replace("'", "''");
                    rue = txtRue.Text.Replace("'", "''");
                    codePostal = mskCodePostal.Text;
                    ville = txtVille.Text.Replace("'", "''");
                    telephone = mskTelephone.Text;
                    // Création de l'objet unStagiaire
                    unStagiaire = new Stagiaire(numStagiaire, nomStagiaire, prenomStagiaire, rue, codePostal, ville, telephone);
                    // Création du stagiaire dans la base de données
                    StagiaireDAO.AjouterUnStagiaire(unStagiaire);
                    // Valorisation de cboStagiaire
                    StagiaireManager.ChargerLesStagiaires(cboStagiaire);
                    // Remise à vide des zones : déclenchement du bouton annuler
                    btnAnnuler_Click(null, EventArgs.Empty);
                    // Message
                    MessageBox.Show("Stagiaire enregistré", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Remise à vide de l'ensemble des contrôles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtNumStagiaire.Clear();
            txtNomStagiaire.Clear();
            txtPrenomStagiaire.Clear();
            txtRue.Clear();
            mskCodePostal.Clear();
            txtVille.Clear();
            mskTelephone.Clear();
            cboStagiaire.SelectedIndex = -1;
        }

        /// <summary>
        /// Modifier un stagiaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            int idStagiaire;
            int numStagiaire;
            string nomStagiaire, prenomStagiaire;
            string rue, codePostal, ville;
            string telephone;
            Stagiaire unStagiaire;

            // Si un stagiaire est choisi dans cboStagiaire
            if (cboStagiaire.SelectedIndex >= 0)
            {
                if (!int.TryParse(txtNumStagiaire.Text, out numStagiaire))
                {
                    MessageBox.Show("Le numéro de stagiaire est incorrect", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        // Récupération du numéro stagiaire choisi dans cboStagiaire
                        idStagiaire = Utilitaires.ExtraireNumStagiaire(cboStagiaire.Text);
                        // Récupération des informations des zones de saisie et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                        nomStagiaire = txtNomStagiaire.Text.Replace("'", "''");
                        prenomStagiaire = txtPrenomStagiaire.Text.Replace("'", "''");
                        rue = txtRue.Text.Replace("'", "''");
                        codePostal = mskCodePostal.Text;
                        ville = txtVille.Text.Replace("'", "''");
                        telephone = mskTelephone.Text;
                        // Création de l'objet unStagiaire
                        unStagiaire = new Stagiaire(numStagiaire, nomStagiaire, prenomStagiaire, rue, codePostal, ville, telephone);
                        // Mise à jour du stagiaire dans la base de données
                        StagiaireDAO.ModifierUnStagiaire(unStagiaire, idStagiaire);
                        // Valorisation de cboStagiaire
                        StagiaireManager.ChargerLesStagiaires(cboStagiaire);
                        // Message
                        MessageBox.Show("Stagiaire enregistré", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucun stagiaire choisi dans la liste", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Supprimer un stagiaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int idStagiaire;
            DialogResult reponse;

            // Si un stagiaire est choisi dans cboStagiaire
            if (cboStagiaire.SelectedIndex >= 0)
            {
                reponse = MessageBox.Show("Etes vous sûr de vouloir supprimer ce stagiaire ?", "Suppression d'un stagiaire", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (reponse == DialogResult.Yes)
                {
                    try
                    {
                        // Récupération du numéro stagiaire choisi dans cboStagiaire
                        idStagiaire = Utilitaires.ExtraireNumStagiaire(cboStagiaire.Text);
                        // Supprimer le stagiaire identifié dans la base de données
                        StagiaireDAO.SupprimerUnStagiaire(idStagiaire);
                        // Valorisation de cboStagiaire
                        StagiaireManager.ChargerLesStagiaires(cboStagiaire);
                        // Message
                        MessageBox.Show("Stagiaire supprimé", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucun stagiaire choisi dans la liste", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /// Valorisation des zones de saisie à la sélection d'un stagiaire choisi dans cboStagiaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStagiaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idStagiaire;
            Stagiaire unStagiaire;

            // si sélection d'un Stagiaire : extraction de son identifiant et recherche et affichage de ses coordonnées
            if (cboStagiaire.SelectedIndex >= 0)
            {
                idStagiaire = Utilitaires.ExtraireNumStagiaire(cboStagiaire.Text);
                unStagiaire = StagiaireDAO.GetStagiaire(idStagiaire);
                txtNumStagiaire.Text = idStagiaire.ToString();
                txtNomStagiaire.Text = unStagiaire.GetNomStagiaire();
                txtPrenomStagiaire.Text = unStagiaire.GetPrenom();
                txtRue.Text = unStagiaire.GetRue();
                mskCodePostal.Text = unStagiaire.GetCodePostal();
                txtVille.Text = unStagiaire.GetVille();
                mskTelephone.Text = unStagiaire.GetTelephone();
            }
            else // remise à vide des zones 
            {
                txtNumStagiaire.Clear();
                txtNomStagiaire.Clear();
                txtPrenomStagiaire.Clear();
                txtRue.Clear();
                mskCodePostal.Clear();
                txtVille.Clear();
                mskTelephone.Clear();
            }
        }
    }
}
