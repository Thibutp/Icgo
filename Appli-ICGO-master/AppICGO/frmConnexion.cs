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
using BiblioMetierICGO;
using BiblioManager;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppICGO
{
    public partial class frmConnexion : Form
    {
        private frmMenu fm;
        public frmConnexion()
        {
            InitializeComponent();

            // Connexion à la base de données 
            try
            {
                Connexion.OuvertureConnexion();
            }
            catch
            {
                MessageBox.Show("Impossible de se connecter à la base de données.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            // Vérifier si l'utilisateur existe
            if (UtilisateurDAO.VerifierUtilisateur(txtLogin.Text, txtMotPasse.Text))
            {
                // Afficher le menu de l'application
                fm = new frmMenu(this);
                fm.Show();
                // Cacher le formulaire de connexion
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login et/ou mot de passe incorrects", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Clear();
                txtMotPasse.Clear();
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Etes-vous sûr(e) de vouloir quitter ?", "Demande de confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Fermer la connexion à la base de données
                Connexion.FermetureConnexion();
                this.Close();
            }

        }


        private void txtMotPasse_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Vérifier si la touche Entrée est pressée
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Appeler la méthode pour gérer la connexion
                btnConnexion.PerformClick();
            }
        }
    }
}
