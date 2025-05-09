using BiblioDAOICGO;
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
    public partial class frmAffecterCompetence : Form
    {
        // Déclaration d'un objet formateur
        private Formateur unFormateur;

        /// <summary>
        /// Constructeur du formulaire
        /// </summary>
        /// <param name="leFormateur">Formateur transmis par le formulaire frmFormateur</param>
        public frmAffecterCompetence(Formateur leFormateur)
        {
            InitializeComponent();
            unFormateur = leFormateur;
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAffecterCompetence_Load(object sender, EventArgs e)
        {
            // Valorisation des zones avec les valeurs numéro, nom et prénom du formateur
            txtNumFormateur.Text = unFormateur.GetNumFormateur().ToString();
            txtNomFormateur.Text = unFormateur.GetNomFormateur();
            txtPrenomFormateur.Text = unFormateur.GetPrenom();

            // Valorisation du datagrid dgvCompetence avec les compétences attribuées au formateur
            foreach (Competence uneCompetence1 in unFormateur.GetLesCompetences())
                dgvCompetence.Rows.Add(uneCompetence1.GetCodeCompetence(), uneCompetence1.GetNomCompetence());

            // Valoriser la liste des compétences lstCompetence avec les compétences non encore attribuées au formateur
            ChargerListeCompetences();

        }

        /// <summary>
        /// Valorisation de la liste lstCompetence
        /// </summary>
        private void ChargerListeCompetences()
        {
            List<Competence> lesCompetences = new List<Competence>();
            Boolean trouve;
            int i;
            Competence uneCompetence2;

            lstCompetence.Items.Clear();

            // Mise à jour de la liste des compétences du formateur
            unFormateur.SetLesCompetences(CompetenceDAO.ChargerLesCompetencesDuFormateur(unFormateur.GetNumFormateur()));
            // Chargement de l'ensemble des compétences
            lesCompetences = CompetenceDAO.ChargerLesCompetences();
            // Parcours de l'ensemble des compétences existantes dans la base de données
            foreach (Competence uneCompetence in lesCompetences)
            {
                trouve = false;
                i = 0;
                // Recherche les compétences qui n'ont pas été attribuées au formateur
                while ((i <= unFormateur.GetLesCompetences().Count - 1) && (!trouve))
                {
                    // une compétence du formateur
                    uneCompetence2 = unFormateur.GetLesCompetences()[i];
                    if (uneCompetence.GetCodeCompetence().Equals(uneCompetence2.GetCodeCompetence()))
                    {
                        // la compétence uneCompetence a été attribuée au formateur
                        trouve = true;
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
                // Si une compétence n'a pas été attribuée au formateur, ajout de cette compétence à la liste lstCompetence
                if (!trouve)
                {
                    lstCompetence.Items.Add(uneCompetence.GetCodeCompetence());
                }
            }
        }

        /// <summary>
        /// Ajout d'une compétence choisie dans lstCompetence au formateur et mise à jour du datagrid dgvCompetence et de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int i;
            string codeCompetence;
            Competence uneCompetence;

            for (i = 0; i <= lstCompetence.Items.Count - 1; i++)
            {
                // Si une compétence est sélectionnée
                if (lstCompetence.GetSelected(i))
                {
                    codeCompetence = lstCompetence.Items[i].ToString();
                    uneCompetence = CompetenceDAO.GetCompetence(codeCompetence);
                    // Mise à jour de la table ETRE_COMPETENT de la base de données
                    FormateurDAO.AjouterUneCompetence(unFormateur, uneCompetence);
                    // Ajout de cette compétence dans le datagrid dgvCompetence
                    dgvCompetence.Rows.Add(uneCompetence.GetCodeCompetence(), uneCompetence.GetNomCompetence());
                }
            }
            // Mise à jour de la liste lstCompetence
            ChargerListeCompetences();
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
        /// Suppression d'une compétence d'un formateur en cliquant sur le bouton supprimer (X)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCompetence_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult reponse;
            string codeCompetence;
            Competence uneCompetence;
            int index;
            DataGridViewRow uneLigne;

            if (dgvCompetence.SelectedCells.Count == 1)
            {
                if (dgvCompetence.CurrentCell.ColumnIndex == 2)
                {
                    reponse = MessageBox.Show("Etes vous sûr de vouloir supprimer cette compétence ?", "Suppression d'une compétence", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (reponse == DialogResult.Yes)
                    {
                        index = dgvCompetence.CurrentCell.RowIndex;
                        uneLigne = dgvCompetence.Rows[index];
                        // Récupération du code compétence de la ligne sélectionnée
                        codeCompetence = uneLigne.Cells["colCodeCompetence"].Value.ToString();
                        uneCompetence = CompetenceDAO.GetCompetence(codeCompetence);
                        // Supprimer la compétence de la base de données
                        FormateurDAO.SupprimerUneCompetence(unFormateur, uneCompetence);
                        // Supprimer la compétence du datagrid
                        dgvCompetence.Rows.Remove(uneLigne);
                        // Recharger la liste des compétences lstcompetence avec les compétences non attribuées au formateur
                        ChargerListeCompetences();
                    }
                }
            }
        }

        /// <summary>
        /// Suppression de compétences (sélection de un ou plusieurs) d'un formateur par l'intermédiaire de la touche SUPPR du clavier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCompetence_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult reponse;
            string codeCompetence;
            Competence uneCompetence;

            reponse = MessageBox.Show("Etes vous sûr de vouloir supprimer cette compétence ?", "Suppression d'une compétence", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reponse == DialogResult.Yes)
            {
                foreach (DataGridViewRow uneLigne in dgvCompetence.SelectedRows)
                {
                    // Récupération du code compétence de la ligne sélectionnée
                    codeCompetence = uneLigne.Cells["colCodeCompetence"].Value.ToString();
                    uneCompetence = CompetenceDAO.GetCompetence(codeCompetence);
                    // Supprimer la compétence de la base de données
                    FormateurDAO.SupprimerUneCompetence(unFormateur, uneCompetence);
                }
                // Recharger la liste des compétences lstcompetence avec les compétences non attribuées au formateur
                ChargerListeCompetences();
            }
        }
    }
}
