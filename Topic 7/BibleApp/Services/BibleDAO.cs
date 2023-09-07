using BibleApp.Models;
using System.Data.SqlClient;

namespace BibleApp.Services
{
    public class BibleDAO
    {
        String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bibex_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<BibleModel> SearchVersesBoth(string searchTerm)
        {
            List<BibleModel> foundVerses = new List<BibleModel>();

            String sqlStatment = "SELECT * FROM dbo.t_bbe WHERE t LIKE @t";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);

                command.Parameters.AddWithValue("@t", '%' + searchTerm + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundVerses.Add(new BibleModel((int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundVerses;
        }

        public List<BibleModel> SearchVersesNew(string searchTerm)
        {
            List<BibleModel> foundVerses = new List<BibleModel>();

            String sqlStatment = "SELECT * FROM dbo.t_bbe WHERE id > 39999999 AND t LIKE @t";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);

                command.Parameters.AddWithValue("@t", '%' + searchTerm + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundVerses.Add(new BibleModel((int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundVerses;
        }
        public List<BibleModel> SearchVersesOld(string searchTerm)
        {
            List<BibleModel> foundVerses = new List<BibleModel>();

            String sqlStatment = "SELECT * FROM dbo.t_bbe WHERE id < 39999999 AND t LIKE @t";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);

                command.Parameters.AddWithValue("@t", '%' + searchTerm + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundVerses.Add(new BibleModel((int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundVerses;
        }

    }
}
