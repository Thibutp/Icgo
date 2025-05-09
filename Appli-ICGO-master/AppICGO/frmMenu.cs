using BiblioDAOICGO;
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
    public partial class frmMenu : Form
    {
        private frmAgence fa;
        private frmCompetence fc;
        private frmFormateur ff;
        private frmModule fm;
        private frmStage fs;
        private frmSessionStage fss;
        private frmInscription fi;
        private frmConfirmerInscription fci;
        private frmStagiaire fsg;
        private frmConnexion fconnexion;
        public frmMenu(frmConnexion formConnexion)
        {
            InitializeComponent();
            fconnexion = formConnexion;
        }

        /// <summary>
        /// Menu Quitter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
            // Afficher le formulaire de connexion à la fermeture du menu
            fconnexion.Show();
        }

        /// <summary>
        /// Menu MAJ des agences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuMajAgence_Click(object sender, EventArgs e)
        {
            fa = new frmAgence();
            // Le parent du formulaire agence est le menu
            fa.MdiParent = this;
            // Ouverture de frmAgence
            fa.Show();
        }

        /// <summary>
        /// Menu MAJ des compétences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuMajCompetence_Click(object sender, EventArgs e)
        {
            fc = new frmCompetence();
            // Le parent du formulaire compétence est le menu
            fc.MdiParent = this;
            // Ouverture de frmCompetence
            fc.Show();
        }
        /// <summary>
        /// Menu MAJ Formateurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuMajFormateur_Click(object sender, EventArgs e)
        {
            ff = new frmFormateur();
            // Le parent du formulaire formateur est le menu
            ff.MdiParent = this;
            // Ouverture de frmFormateur
            ff.Show();
        }

        /// <summary>
        /// Menu MAJ Module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void munMajModule_Click(object sender, EventArgs e)
        {
            fm = new frmModule();
            // Le parent du formulaire module est le menu
            fm.MdiParent = this;
            // Ouverture de frmModule
            fm.Show();
        }

        private void mnuMajStage_Click(object sender, EventArgs e)
        {
            fs = new frmStage();
            // Le parent du formulaire stage est le menu
            fs.MdiParent = this;
            // Ouverture de frmStage
            fs.Show();
        }

        /// <summary>
        /// Menu MAJ session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuMajSession_Click(object sender, EventArgs e)
        {
            fss = new frmSessionStage();
            // Le parent du formulaire session est le menu
            fss.MdiParent = this;
            // Ouverture de frmSession
            fss.Show();
        }

        /// <summary>
        /// Menu inscription d'un stagiaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuInscrireStagiaire_Click(object sender, EventArgs e)
        {
            fi = new frmInscription();
            // Le parent du formulaire inscription est le menu
            fi.MdiParent = this;
            // Ouverture de frmInscription
            fi.Show();
        }

        /// <summary>
        /// Menu Confirmer l'inscription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void mnuConfirmerInscription_Click(object sender, EventArgs e)
        {
            fci = new frmConfirmerInscription();
            // Le parent du formulaire confirmerInscription est le menu
            fci.MdiParent = this;
            // Ouverture de frmConfirmerInscription
            fci.Show();
        }

        private void mnuStagiaire_Click(object sender, EventArgs e)
        {
            fsg = new frmStagiaire();
            // Le parent du formulaire stagiaire est le menu
            fsg.MdiParent = this;
            // Ouverture de frmStagiaire
            fsg.Show();
        }
    }
}
