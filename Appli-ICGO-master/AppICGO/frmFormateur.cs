using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiblioDAOICGO;
using BiblioManager;
using BiblioMetierICGO;
using BiblioSupport;

namespace AppICGO
{
    public partial class frmFormateur : Form
    {
        public frmFormateur()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFormateur_Load(object sender, EventArgs e)
        {
            // Valorisation de cboNiveauEtude
            cboNiveauEtude.Items.Add("Baccalauréat");
            cboNiveauEtude.Items.Add("BTS");
            cboNiveauEtude.Items.Add("Licence");
            cboNiveauEtude.Items.Add("Master");
            cboNiveauEtude.Items.Add("Doctorat");
            // Valorisation de cboFormateur
            FormateurManager.ChargerLesFormateurs(cboFormateur);
            // Valorisation de cboAgence
            AgenceManager.ChargerLesAgences(cboAgence);
        }

        /// <summary>
        /// Ajouter un formateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int numFormateur;
            string nomFormateur, prenomFormateur;
            string nomAgence;
            string rue, codePostal, ville;
            string telephone, niveauEtude;
            DateTime dateIntervention;
            string salaire;
            Agence uneAgence;
            Formateur unFormateur;

            if (!int.TryParse(txtNumFormateur.Text, out numFormateur))
            {
                MessageBox.Show("Le numéro de formateur est incorrect", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // Récupération des informations saisies et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                    nomAgence = cboAgence.Text;
                    nomFormateur = txtNomFormateur.Text.Replace("'", "''");
                    prenomFormateur = txtPrenomFormateur.Text.Replace("'", "''");
                    rue = txtRue.Text.Replace("'", "''");
                    codePostal = mskCodePostal.Text;
                    ville = txtVille.Text.Replace("'", "''");
                    telephone = mskTelephone.Text;
                    niveauEtude = cboNiveauEtude.Text;
                    dateIntervention = dtpDateIntervention.Value;
                    salaire = txtSalaire.Text;
                    // Création de l'objet uneAgence
                    uneAgence = new Agence(nomAgence);
                    // Création de l'objet unFormateur
                    unFormateur = new Formateur(numFormateur, nomFormateur, prenomFormateur, rue, codePostal, ville, telephone, niveauEtude, dateIntervention, salaire, uneAgence);
                    // Création du formateur dans la base de données
                    FormateurDAO.AjouterUnFormateur(unFormateur);
                    // Valorisation de cboFormateur
                    FormateurManager.ChargerLesFormateurs(cboFormateur);
                    // Message
                    MessageBox.Show("Formateur enregistré", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Déclencher l'ouverture du formulaire AffecterCompetence
                    btnAffecterCompetence_Click(null, EventArgs.Empty);
                    // Remise à vide des zones : déclenchement du bouton annuler
                    btnAnnuler_Click(null, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAffecterCompetence_Click(object sender, EventArgs e)
        {
            int idFormateur;
            Formateur unFormateur;

            // Si un formateur est choisi dans cboFormateur
            if (cboFormateur.SelectedIndex >= 0)
            {
                // Récupération du numéro formateur choisi dans cboFormateur
                idFormateur = Utilitaires.ExtraireNumFormateur(cboFormateur.Text);
                // Recherche du formateur identifié dans la base de données
                unFormateur = FormateurDAO.GetFormateur(idFormateur);
                // Ouverture du formulaire frmAffecterCompetence avec transmission du formateur
                frmAffecterCompetence fac = new frmAffecterCompetence(unFormateur);
                fac.Show();
            }
            else
            {
                // Si un formateur vient d'être créé (pas de sélection dans cboFormateur)
                if (!txtNumFormateur.Text.Equals(""))
                {
                    // Création de l'objet unFormateur identifié 
                    unFormateur = FormateurDAO.GetFormateur(int.Parse(txtNumFormateur.Text));
                    // Ouverture du formulaire frmAffecterCompetence avec transmission du formateur
                    frmAffecterCompetence fac = new frmAffecterCompetence(unFormateur);
                    fac.Show();
                }
                else
                {
                    MessageBox.Show("Aucun formateur choisi dans la liste", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Vides les contrôles du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtNumFormateur.Clear();
            txtNomFormateur.Clear();
            txtPrenomFormateur.Clear();
            txtRue.Clear();
            mskCodePostal.Clear();
            txtVille.Clear();
            mskTelephone.Clear();
            cboNiveauEtude.SelectedIndex = -1;
            txtSalaire.Clear();
            cboAgence.SelectedIndex = -1;
            cboFormateur.SelectedIndex = -1;
        }

        /// <summary>
        /// Modifier un formateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            int idFormateur;
            int numFormateur;
            string nomFormateur, prenomFormateur;
            string nomAgence;
            string rue, codePostal, ville;
            string telephone, niveauEtude;
            DateTime dateIntervention;
            string salaire;
            Agence uneAgence;
            Formateur unFormateur;

            // Si un formateur est choisi dans cboFormateur
            if (cboFormateur.SelectedIndex >= 0)
            {
                if (!int.TryParse(txtNumFormateur.Text, out numFormateur))
                {
                    MessageBox.Show("Le numéro de formateur est incorrect", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        // Récupération du numéro formateur choisi dans cboFormateur
                        idFormateur = Utilitaires.ExtraireNumFormateur(cboFormateur.Text);
                        // Récupération des informations des zones de saisie et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                        nomAgence = cboAgence.Text;
                        nomFormateur = txtNomFormateur.Text.Replace("'", "''");
                        prenomFormateur = txtPrenomFormateur.Text.Replace("'", "''");
                        rue = txtRue.Text.Replace("'", "''");
                        codePostal = mskCodePostal.Text;
                        ville = txtVille.Text.Replace("'", "''");
                        telephone = mskTelephone.Text;
                        niveauEtude = cboNiveauEtude.Text;
                        dateIntervention = dtpDateIntervention.Value;
                        salaire = txtSalaire.Text;
                        // Création de l'objet uneAgence
                        uneAgence = new Agence(nomAgence);
                        // Création de l'objet unFormateur
                        unFormateur = new Formateur(numFormateur, nomFormateur, prenomFormateur, rue, codePostal, ville, telephone, niveauEtude, dateIntervention, salaire, uneAgence);
                        // Mise à jour du formateur dans la base de données
                        FormateurDAO.ModifierUnFormateur(unFormateur, idFormateur);
                        // Valorisation de cboFormateur
                        FormateurManager.ChargerLesFormateurs(cboFormateur);
                        // Message
                        MessageBox.Show("Formateur enregistré", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucun formateur choisi dans la liste", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Supprimer un formateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int idFormateur;
            DialogResult reponse;

            // Si un formateur est choisi dans cboFormateur
            if (cboFormateur.SelectedIndex >= 0)
            {
                reponse = MessageBox.Show("Etes vous sûr de vouloir supprimer ce formateur ?", "Suppression d'un formateur", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (reponse == DialogResult.Yes)
                {
                    try
                    {
                        // Récupération du numéro formateur choisi dans cboFormateur
                        idFormateur = Utilitaires.ExtraireNumFormateur(cboFormateur.Text);
                        // Supprimer le formateur identifié dans la base de données
                        FormateurDAO.SupprimerUnFormateur(idFormateur);
                        // Valorisation de cboFormateur
                        FormateurManager.ChargerLesFormateurs(cboFormateur);
                        // Message
                        MessageBox.Show("Formateur supprimé", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucun formateur choisi dans la liste", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Fermeture du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Valorisation des zones de saisie à la sélection d'un formateur choisi dans cboFormateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboFormateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idFormateur;
            Formateur unFormateur;

            // si sélection d'un formateur : extraction de son identifiant et recherche et affichage de ses coordonnées
            if (cboFormateur.SelectedIndex >= 0)
            {
                idFormateur = Utilitaires.ExtraireNumFormateur(cboFormateur.Text);
                unFormateur = FormateurDAO.GetFormateur(idFormateur);
                txtNumFormateur.Text = idFormateur.ToString();
                cboAgence.Text = unFormateur.GetLAgence().GetNomAgence();
                txtNomFormateur.Text = unFormateur.GetNomFormateur();
                txtPrenomFormateur.Text = unFormateur.GetPrenom();
                txtRue.Text = unFormateur.GetRue();
                mskCodePostal.Text = unFormateur.GetCodePostal();
                txtVille.Text = unFormateur.GetVille();
                mskTelephone.Text = unFormateur.GetTelephone();
                cboNiveauEtude.Text = unFormateur.GetNiveauEtude();
                dtpDateIntervention.Value = unFormateur.GetDateIntervention();
                // Affichage du salaire sous la forme d'une chaine de caractères avec un point décimal au lieu d'une virgule
                txtSalaire.Text = unFormateur.GetSalaireAnnuel().Replace(",", ".");
            }
            else // remise à vide des zones et affichage de la date du jour
            {
                txtNumFormateur.Clear();
                txtNomFormateur.Clear();
                txtPrenomFormateur.Clear();
                txtRue.Clear();
                mskCodePostal.Clear();
                txtVille.Clear();
                mskTelephone.Clear();
                cboNiveauEtude.SelectedIndex = -1;
                txtSalaire.Clear();
                cboAgence.SelectedIndex = -1;
                dtpDateIntervention.Value = DateTime.Now;
            }
        }
    }
}
