using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioDAOICGO
{
    public class UtilisateurDAO
    {
        /// <summary>
        /// Vérifier qu'un utilisateur existe
        /// </summary>
        /// <param name="unLogin">Login</param>
        /// <param name="unMotPasse">Mot de passe</param>
        /// <returns></returns>
        public static Boolean VerifierUtilisateur(string unLogin, string unMotPasse)
        {
            Boolean existe = false;
            int nb;

            // Exécuter la requête de sélection
            string requete = "SELECT COUNT(*) AS NB FROM UTILISATEUR WHERE LOGIN = @login AND MOTPASSE = @pwd";
            DataTable dt = Connexion.ExecutionRequete(requete,
                new MySqlParameter("@login", unLogin),
                new MySqlParameter("@pwd", unMotPasse)
                );


            // Parcours du résultat de la requête
            if (dt.Rows.Count == 1)
            {
                nb = int.Parse(dt.Rows[0]["NB"].ToString());
                if (nb == 1)
                {
                    existe = true;
                }
            }
            return existe;
        }
        }
}
