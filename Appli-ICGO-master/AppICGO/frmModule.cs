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
    public partial class frmModule : Form
    {
        public frmModule()
        {
            InitializeComponent();
        }

        private void frmModule_Load(object sender, EventArgs e)
        {
            ModuleManager.ChargerLesModules(cboModule);
        }

        private void txtNomModule_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboModule_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboModule.SelectedIndex != -1)
            {
                string str = cboModule.Text;
                //MessageBox.Show(str.Substring(0, str.IndexOf(".")).ToString());
                int first = cboModule.Text.IndexOf(".");
                int numero = int.Parse(str.Substring(0, str.IndexOf(".")).ToString());


                Module unModule = ModuleDAO.GetModule(numero);
                txtNumModule.Text = unModule.GetNumModule().ToString();
                txtNomModule.Text = unModule.GetNomModule();
                txtNomSupportCours.Text = unModule.GetNomSupportCours();
                txtNomPresentation.Text = unModule.GetNomPresentation();
                txtPlaceSupportCours.Text = unModule.GetPlaceSupportCours();
                txtPlacePresentation.Text = unModule.GetPlacePresentation();
            }

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int numModule;
            string nomModule;
            string nomSupportCours;
            string nomPresentation;
            string placeSupportCours;
            string placePresentation;
            Module unModule;

            try
            {
                if (!txtNumModule.Text.Equals(""))
                {
                    // Récupération du nom de l'agence saisi et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                    numModule = Convert.ToInt32(txtNumModule.Text);
                    nomModule = txtNomModule.Text.Replace("'", "''");
                    nomSupportCours = txtNomSupportCours.Text.Replace("'", "''");
                    nomPresentation = txtNomPresentation.Text.Replace("'", "''");
                    placeSupportCours = txtPlaceSupportCours.Text.Replace("'", "''");
                    placePresentation = txtPlacePresentation.Text.Replace("'", "''");

                    // Création de l'objet uneAgence
                    unModule = new Module(numModule, nomModule, nomSupportCours, nomPresentation, placeSupportCours, placePresentation);
                    // Création de l'agence dans la base de données
                    ModuleDAO.AjouterUnModule(unModule);
                    // Valorisation de cboAgence
                    ModuleManager.ChargerLesModules(cboModule);
                    // Remise à vide des zones : déclenchement du bouton annuler
                    btnAnnuler_Click(null, EventArgs.Empty);
                    // Message
                    MessageBox.Show("Module enregistrée", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cboModule.SelectedIndex = -1;
            txtNomModule.Clear();
            txtNomPresentation.Clear();
            txtNomSupportCours.Clear();
            txtPlaceSupportCours.Clear();
            txtPlacePresentation.Clear();
            txtNumModule.Clear();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int idModule;
            int numModule;
            string nomModule;
            string nomSupportCours;
            string nomPresentation;
            string placeSupportCours;
            string placePresentation;
            Module unModule;

            // Si un formateur est choisi dans cboFormateur
            if (cboModule.SelectedIndex >= 0)
            {
                if (!int.TryParse(txtNumModule.Text, out numModule))
                {
                    MessageBox.Show("Le numéro du module est incorrect", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        // Récupération du numéro formateur choisi dans cboFormateur
                        idModule = Utilitaires.ExtraireNumModule(cboModule.Text);
                        // Récupération des informations des zones de saisie et ajout du caractère ' en double si nécessaire pour construire une requête SQL
                        nomModule = txtNomModule.Text.Replace("'", "''");
                        nomSupportCours = txtNomSupportCours.Text.Replace("'", "''");
                        nomPresentation = txtNomPresentation.Text.Replace("'", "''");
                        placeSupportCours = txtPlaceSupportCours.Text.Replace("'", "''");
                        placePresentation = txtPlacePresentation.Text.Replace("'", "''");


                        // Création de l'objet unFormateur
                        unModule = new Module(numModule, nomModule, nomSupportCours, nomPresentation, placeSupportCours, placePresentation);
                        // Mise à jour du formateur dans la base de données
                        ModuleDAO.ModifierUnModule(unModule, idModule);
                        // Valorisation de cboFormateur
                        ModuleManager.ChargerLesModules(cboModule);
                        // Message
                        MessageBox.Show("Module enregistré", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucun Module choisi dans la liste", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int idModule;
            DialogResult reponse;

            // Si un formateur est choisi dans cboFormateur
            if (cboModule.SelectedIndex >= 0)
            {
                reponse = MessageBox.Show("Etes vous sûr de vouloir supprimer ce module ?", "Suppression d'un module", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (reponse == DialogResult.Yes)
                {
                    try
                    {
                        // Récupération du numéro formateur choisi dans cboFormateur
                        idModule = Utilitaires.ExtraireNumModule(cboModule.Text);
                        // Supprimer le formateur identifié dans la base de données
                        ModuleDAO.SupprimerUnModule(idModule);
                        // Valorisation de cboFormateur
                        ModuleManager.ChargerLesModules(cboModule);
                        // Message
                        MessageBox.Show("Module supprimé", "Mise à jour réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mise à jour échouée !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucun Module choisi dans la liste", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}