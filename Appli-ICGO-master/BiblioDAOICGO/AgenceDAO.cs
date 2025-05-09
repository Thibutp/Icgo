using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BiblioMetierICGO;
using System.Data;

namespace BiblioDAOICGO
{
    public class AgenceDAO
    {
        /*
        /// <summary>
        /// Ajouter une agence dans la table AGENCE
        /// </summary>
        /// <param name="uneAgence">Une agence</param>
        /// <returns>Nbre de ligne ajoutée</returns>
        public static void AjouterUneAgence(Agence uneAgence)
        {
            // Exécuter la requête d'insertion
            string requete = "INSERT INTO AGENCE VALUES (@agence)";
            var ajouter = Connexion.ExecuteNonQuery(requete,
                new MySqlParameter("@agence", uneAgence.GetNomAgence()));
        }

        /// <summary>
        /// Charger les agences de la table AGENCE dans une liste
        /// </summary>
        /// <returns>List<Agence></Agence></returns>
        public static List<Agence> ChargerLesAgences()
        {
            // Exécuter la requête de sélection
            string requete = "SELECT NOMAGENCE FROM AGENCE";
            var lesAgences = Connexion.ExecuteSelectQuery(requete,
                reader => new Agence
                {
                    NomAgence = reader.GetString("NOMAGENCE")
                });

            // Retour de la liste les Agences
            return lesAgences;
        }

        /// <summary>
        /// Supprimer une agence identifiée dans la table AGENCE
        /// </summary>
        /// <param name="idAgence">Nom de l'agence</param>
        /// <returns></returns>
        public static int SupprimerUneAgence(string idAgence)
        {
            // Exécuter la requête de suppression
            string requete = "DELETE FROM AGENCE WHERE NOMAGENCE = @agence";
            var delete = Connexion.ExecuteNonQuery(requete,
                new MySqlParameter("@agence", idAgence));
            return delete;
        }*/

        /// <summary>
        /// Ajouter une agence dans la table AGENCE
        /// </summary>
        /// <param name="uneAgence">Une agence</param>
        /// <returns>Nbre de ligne ajoutée</returns>
        public static void AjouterUneAgence(Agence uneAgence)
        {
            // Exécuter la requête d'insertion
            string requete = "INSERT INTO AGENCE VALUES (@agence)";
            Connexion.ExecutionMaj(requete, new MySqlParameter("@agence", uneAgence.NomAgence));
        }

        /// <summary>
        /// Charger les agences de la table AGENCE dans une liste
        /// </summary>
        /// <returns>List<Agence></Agence></returns>
        public static List<Agence> ChargerLesAgences()
        {
            List<Agence> lesAgences = new List<Agence>();
            // Exécuter la requête de sélection
            string requete = "SELECT NOMAGENCE FROM AGENCE";
            DataTable dt= Connexion.ExecutionRequete(requete, null);

            // Parcours du résultat de la requête
            foreach (DataRow uneLigne in dt.Rows)
            {
                // Récupération du nom de l'agence de la ligne 
                string nomAgence = uneLigne["NOMAGENCE"].ToString();
                // Construction de l'objet uneAgence
                Agence uneAgence = new Agence(nomAgence);
                // Ajout de l'agence dans la liste lesAgences
                lesAgences.Add(uneAgence);
            }

            // Retour de la liste les Agences
            return lesAgences;
        }

        /// <summary>
        /// Supprimer une agence identifiée dans la table AGENCE
        /// </summary>
        /// <param name="idAgence">Nom de l'agence</param>
        /// <returns></returns>
        public static void SupprimerUneAgence(string idAgence)
        {
            // Exécuter la requête de suppression
            string requete = "DELETE FROM AGENCE WHERE NOMAGENCE = @agence";
            Connexion.ExecutionMaj(requete, new MySqlParameter("@agence", idAgence));
        }

    }

}
