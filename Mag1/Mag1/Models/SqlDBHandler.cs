using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Xamarin.Essentials;

namespace Mag1.Models
{
    class SqlDBHandler
    {
        public string DBName { get; set; }
        public string ServerIP { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        string _connectionString;

        public SqlDBHandler()
        {
            _connectionString = @"Data Source=192.168.8.124,1433; Initial Catalog=firma_dem; User Id=sa; Password=sa";
        }

        public List<string> ExecuteQuery(string query)
        {
            string con_string= _connectionString;
            SqlConnection sqlConnection = new SqlConnection(con_string);
            SqlCommand command = new SqlCommand(query, sqlConnection);
            string queryResult = "";
            List<string> results  = new List<string>(); 
            
            try
            {
                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        queryResult = String.Format( "{0}*{1}*{2}", reader[0], reader[1], reader[2]);
                        if (queryResult != null)
                        {
                            results.Add(queryResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd połączenia z bazą: ");
                Console.WriteLine(ex);
            }
            sqlConnection.Close();
            return results;
            
        }

    }
}
