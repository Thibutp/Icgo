using MySql.Data.MySqlClient;
using BiblioMetierICGO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Notice.SessionStateChanged.Types;

namespace BiblioDAOICGO
{
    public static class Connexion
    {
        private static MySqlConnection connexion;
        private static string server = "localhost";
        private static string database = "ICGO";
        private static string uid = "root";
        private static string password = "";

        //#region Accesseur

        ///// <summary>
        ///// Retourne la connexion
        ///// </summary>
        ///// <returns></returns>
        //public static MySqlConnection GetConnexion()
        //{
        //    return connexion;
        //}

        //#endregion

        //#region Méthodes

        ///// <summary>
        ///// Ouverture de la connexion à la base de données
        ///// </summary>

        //public static void OuvrirConnexion()
        //{
        //    connexion = new MySqlConnection(@"SERVER={server};DATABASE={database}; UID={uid};PASSWORD={password};");
        //    try
        //    {
        //        connexion.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(@"Erreur de connexion : {ex.Message} ");
        //    }

        //}

        ///// <summary>
        ///// Fermeture de la connexion
        ///// </summary>
        //public static void FermerConnexion()
        //{
        //    connexion.Close();
        //}

        //public static List<T> ExecuteSelectQuery<T>(string query, Func<MySqlDataReader, T> mapFunction)
        //{
        //    var results = new List<T>();
        //    using (var command = new MySqlCommand(query, connexion))
        //    {
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var item = mapFunction(reader);
        //                results.Add(item);
        //            }
        //        }
        //    }

        //    return results;
        //}

        //public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        //{

        //    using (var command = new MySqlCommand(query, connexion))
        //    {
        //        command.Parameters.AddRange(parameters);
        //        return command.ExecuteNonQuery(); // Retourne le nombre de lignes affectées
        //    }
        //}

        //#endregion

        public static void OuvertureConnexion()
        {
            string ChaineConnexion = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connexion = new MySqlConnection(ChaineConnexion);
            connexion.Open();
        }

        public static void FermetureConnexion()
        {
            connexion.Close();
        }

        public static DataTable ExecutionRequete(string req, params MySqlParameter[] parameters)
        {
            var command = new MySqlCommand(req, connexion);
            //Valorisation des paramètres si nécessaire
            if(!Object.ReferenceEquals(null,parameters))
            {
                command.Parameters.AddRange(parameters);
            }
            
            // Utilisation d'un DataAdapter
            MySqlDataAdapter unDataAdapter = new MySqlDataAdapter(command);  
            // Remplissage du DataSet avec le resultat du DataAdapter
            DataSet unDataSet = new DataSet();
            unDataAdapter.Fill(unDataSet);
            //Selection du 1er DataTable
            DataTable unDataTable = unDataSet.Tables[0];
            return unDataTable;
        }

        public static void ExecutionMaj(string req, params MySqlParameter[] parameters)
        {   // type de maj : insertion, suppression, modification
            MySqlCommand cmdMaj = new MySqlCommand(req, connexion);
            cmdMaj.Parameters.AddRange(parameters);
            cmdMaj.ExecuteNonQuery();
        }

        public static int ExecutionProc(string codeCompetence, int noStage, int noSession)
        {
            int resultat = 0;
            try
            {

                using (MySqlCommand cmd = new MySqlCommand("verifierPlaces", connexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Ajouter les paramètres si nécessaire
                    cmd.Parameters.AddWithValue("@codeCompetence", codeCompetence);
                    cmd.Parameters.AddWithValue("@noStage", noStage);
                    cmd.Parameters.AddWithValue("@noSession", noSession);

                    // Exécution de la procédure
                    cmd.Parameters.Add(new MySqlParameter
                    {
                        ParameterName = "@dispo",
                        MySqlDbType = MySqlDbType.Int32,

                        // Adapter le type de données en fonction de la procédure
                         Direction = System.Data.ParameterDirection.Output }); 
                    
                    //Exécution de la procédure
                    cmd.ExecuteNonQuery(); 
                    // Récupérer la valeur du paramètre de sortie
                    resultat = (int)cmd.Parameters["@dispo"].Value;
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
                resultat = 0;
            }
            return resultat;
        }
  
    }
}
