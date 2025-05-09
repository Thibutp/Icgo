using BiblioDAOICGO;
using BiblioMetierICGO;
using BiblioManager;
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
    public partial class frmAgence : Form
    {
        public frmAgence()
        {
            InitializeComponent();
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
        /// Chargement du formulaire : alimenter la combo des agences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAgence_Load(object sender, EventArgs e)
        {
            // Valorisation de cboAgence
            AgenceManager.ChargerLesAgences(cboAgence);
        }

        /// <summary>
        /// Ajout d'une agence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string nomAgence;
            Agence uneAgence;

            try
            {
                if (!txtNomAgence.Text.Equals(""))
                {
                    // Récupération du nom de l'agence saisi et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                    nomAgence = txtNomAgence.Text.Replace("'", "''");
                    // Création de l'objet uneAgence
                    uneAgence = new Agence(nomAgence);
                    // Création de l'agence dans la base de données
                    AgenceDAO.AjouterUneAgence(uneAgence);
                    // Valorisation de cboAgence
                    AgenceManager.ChargerLesAgences(cboAgence);
                    // Remise à vide des zones : déclenchement du bouton annuler
                    btnAnnuler_Click(null, EventArgs.Empty);
                    // Message
                    MessageBox.Show("Agence enregistrée", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Saisir un nom d'agence", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  Remise à vide de l'ensemble des zones de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtNomAgence.Clear();
            cboAgence.SelectedIndex = -1;
        }

        /// <summary>
        /// Suppression d'une agence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string idAgence;
            DialogResult reponse;

            // Si une agence est choisie dans cboAgence
            if (cboAgence.SelectedIndex >= 0)
            {
                reponse = MessageBox.Show("Etes vous sûr de vouloir supprimer cette agence ?", "Suppression d'une agence", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (reponse == DialogResult.Yes)
                {
                    try
                    {
                        // Récupération du nom de l'agence choisi dans cboAgence
                        idAgence = cboAgence.Text;
                        // Supprimer l'agence dans la base de données
                        AgenceDAO.SupprimerUneAgence(idAgence);
                        AgenceManager.ChargerLesAgences(cboAgence);
                        // Message
                        MessageBox.Show("Agence supprimée", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucune agence choisie dans la liste", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Valorisation de txtNomAgence à la sélection d'un nom choisi dans cboAgence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboAgence_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNomAgence.Text = cboAgence.Text;
        }
    }
}
