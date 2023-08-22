using Act_2.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Act_2.Services
{
    public class ProductsDAO : IProductsDataService
    {
        String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cst350;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<ProductModel> AllProducts()
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            String sqlStatment = "SELECT * FROM dbo.products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]));
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundProducts;
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            String sqlStatment = "SELECT * FROM dbo.products WHERE Name LIKE @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);

                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundProducts;
        }

        public bool Delete(ProductModel product)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String sqlStatment = "DELETE FROM dbo.products WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sqlStatment, connection);
                command.Parameters.AddWithValue("@Id", product.Id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Debug.WriteLine(rowsAffected);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                };
            }
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel foundProduct = null;

            String sqlStatment = "SELECT * FROM dbo.products WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);

                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProduct = new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundProduct;
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public int update(ProductModel product)
        {
            int rowIdNumber = 1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String sqlStatment = "UPDATE dbo.products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sqlStatment, connection);
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);


                try
                {
                    connection.Open();
                    rowIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return rowIdNumber;
        }
    }
}
