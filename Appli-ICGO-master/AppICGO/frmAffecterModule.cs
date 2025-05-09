using BiblioDAOICGO;
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
    public partial class frmAffecterModule : Form
    {// Déclaration d'un objet dynamic qui sera soit un stage étalé soit un stage groupé lors de l'exécution


        /// <summary>
        /// Constructeur du formulaire
        /// </summary>
        /// <param name="leStage">Stage transmis par le formulaire frmStage</param>
        /// 
        private Stage unStage;

        /// <summary>
        /// Constructeur du formulaire
        /// </summary>
        /// <param name="leFormateur">Formateur transmis par le formulaire frmFormateur</param>

        public frmAffecterModule(Stage leStage)
        {
            InitializeComponent();
            unStage = leStage;
        }

        private void frmAffecterModule_Load(object sender, EventArgs e)
        {
            txtCodeCompetence.Text = unStage.GetLaCompetence().GetCodeCompetence().ToString();
            txtNomStage.Text = unStage.GetNomStage().ToString();
            txtNumStage.Text = unStage.GetNumStage().ToString();

            List<Module> lesModules = ModuleDAO.ChargerLesModulesDuStage(txtCodeCompetence.Text, int.Parse(txtNumStage.Text));


            foreach (Module unModule1 in lesModules)
            {
                dgvModule.Rows.Add(unModule1.GetNumModule(), unModule1.GetNomModule());
            }

            ChargerListeModules();
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
        /// Suppression d'un module d'un stage en cliquant sur le bouton supprimer (X)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvModule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult reponse;
            int numModule;
            Module unModule;
            int index;
            DataGridViewRow uneLigne;

            if (dgvModule.SelectedCells.Count == 1)
            {
                if (dgvModule.CurrentCell.ColumnIndex == 2)
                {
                    reponse = MessageBox.Show("Etes vous sûr de vouloir supprimer ce module ?", "Suppression d'un module", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (reponse == DialogResult.Yes)
                    {
                        index = dgvModule.CurrentCell.RowIndex;
                        uneLigne = dgvModule.Rows[index];
                        // Récupération du code compétence de la ligne sélectionnée
                        numModule = int.Parse(uneLigne.Cells["colNumModule"].Value.ToString());
                        unModule = ModuleDAO.GetModule(numModule);
                        // Supprimer la compétence de la base de données
                        StageDAO.SupprimerUnModule(unStage, unModule);
                        // Supprimer la compétence du datagrid
                        dgvModule.Rows.Remove(uneLigne);
                        // Recharger la liste des compétences lstcompetence avec les compétences non attribuées au formateur
                        ChargerListeModules();
                    }
                }
            }

        }

        /// <summary>
        /// Suppression de modules (sélection de un ou plusieurs) d'un stage par l'intermédiaire de la touche SUPPR du clavier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvModule_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult reponse;
            int numModule;
            Module unModule;

            reponse = MessageBox.Show("Etes vous sûr de vouloir supprimer ce module ?", "Suppression d'un module", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reponse == DialogResult.Yes)
            {
                foreach (DataGridViewRow uneLigne in dgvModule.SelectedRows)
                {
                    // Récupération du code compétence de la ligne sélectionnée
                    numModule = int.Parse(uneLigne.Cells["colNumModule"].Value.ToString());

                    unModule = ModuleDAO.GetModule(numModule);
                    // Supprimer la compétence de la base de données
                    StageDAO.SupprimerUnModule(unStage, unModule);
                }
                // Recharger la liste des compétences lstcompetence avec les compétences non attribuées au formateur
                ChargerListeModules();
            }

        }

        /// <summary>
        /// Valorisation de la liste lstModule
        /// </summary>
        private void ChargerListeModules()
        {
            List<Module> lesModules = new List<Module>();
            Boolean trouve;
            int i;
            Module unModule2;

            lstModule.Items.Clear();

            lesModules = ModuleDAO.ChargerLesModules();
            List<Module> lesModulesDuStage = ModuleDAO.ChargerLesModulesDuStage(unStage.GetLaCompetence().GetCodeCompetence(), unStage.GetNumStage());

            foreach (Module unModule in lesModules)
            {
                trouve = false;
                i = 0;

                while ((i <= lesModulesDuStage.Count - 1) && !trouve)
                {
                    unModule2 = lesModulesDuStage[i];
                    if (unModule.GetNomModule().Equals(unModule2.GetNomModule()))
                    {
                        trouve = true;
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
                if (!trouve)
                {
                    lstModule.Items.Add(unModule.GetNumModule() + ". " + unModule.GetNomModule());
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstModule);
            selectedItems = lstModule.SelectedItems;
            foreach (var uneChaine in selectedItems)
            {
                if (uneChaine.ToString() != null) // Vérifie qu'un élément est sélectionné
                {

                    int numModule = Utilitaires.ExtraireNumModule(uneChaine.ToString());

                    // Charger l'objet Module correspondant
                    Module unModule = ModuleDAO.GetModule(numModule);

                    // Mise à jour de la table ETRE_COMPETENT de la base de données
                    StageDAO.AjouterUnModule(unStage, unModule);

                    // Ajout de ce module dans le DataGridView
                    dgvModule.Rows.Add(unModule.GetNumModule(), unModule.GetNomModule());

                    lstModule.Items.Remove(unModule.GetNumModule());
                }
                else
                {
                    MessageBox.Show("Aucun module n'est sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            // Mise à jour de la liste des modules
            ChargerListeModules();

        }
    }
}