using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UsersServer
{
    public class DataAccess
    {
        public int InsertData(string connectionString)
        {
            string categoryName;
            Console.WriteLine("insert Category");
            categoryName = Console.ReadLine();

            string query = "insert into Categories(CategoryName)"
                + "values(@CategoryName)";
            using(SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar, 20).Value = categoryName;
            
            cn.Open();
            int rowosAffected = cmd.ExecuteNonQuery();
            cn.Close();

            return rowosAffected;
            }
        }
        public int InsertProduct(string connectionString)
        {
            string categoryId, productName, productDescription, productPrice, productImage;
            Console.WriteLine("insert CategoryId");
            categoryId = Console.ReadLine();
            Console.WriteLine("insert ProductName");
            productName = Console.ReadLine();
            Console.WriteLine("insert ProductPrice");
            productPrice = Console.ReadLine();
            Console.WriteLine("insert ProductDescription");
            productDescription = Console.ReadLine();
            Console.WriteLine("insert ProductImage");
            productImage = Console.ReadLine();

            string query = "insert into Products(CategoryId,ProductName,ProductDescription,ProductPrice,ProductImage)"
                + "values(@CategoryId,@ProductName,@ProductPrice,@ProductDescription,@ProductImage)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 20).Value = productName;
                cmd.Parameters.Add("@ProductPrice",SqlDbType.Int ).Value = productPrice;
                cmd.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 100).Value = productDescription;
                cmd.Parameters.Add("@ProductImage", SqlDbType.VarChar, 40).Value = productImage;

                cn.Open();
                int rowosAffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowosAffected;
            }

        }
      internal void readData(string connectionString)
        {
            string queryString = "select *" +
                     "FROM Products p join Categories c on p.CategoryId=c.Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", 
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.ReadLine();
            }

        }
    }
}
