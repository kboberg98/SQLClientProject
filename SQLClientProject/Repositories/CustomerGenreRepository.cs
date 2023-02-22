using Microsoft.Data.SqlClient;
using SQLClientProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SQLClientProject.Repositories
{
    public class CustomerGenreRepository : ICustomerGenreRepository
    {
        public List<CustomerGenre> GetAllCustomerGenre(int id)
        {
            List<CustomerGenre> customerGenreList = new List<CustomerGenre>();
            string sql = "SELECT c.CustomerId, c.FirstName, c.LastName, g.Name AS PopularGenre " +
                "FROM Customer c JOIN Invoice i ON c.CustomerId = i.CustomerId JOIN InvoiceLine il ON i.InvoiceId = il.InvoiceId " +
                "JOIN Track t ON il.TrackId = t.TrackId JOIN Genre g ON t.GenreId = g.GenreId " +
                "WHERE c.CustomerId = @CustomerId " +
                "GROUP BY c.CustomerId, c.FirstName, c.LastName, g.Name " +
                "HAVING COUNT(*) = (SELECT MAX(count) " +
                "FROM(SELECT COUNT(*) AS count " +
                "FROM Invoice i2 JOIN InvoiceLine il2 ON i2.InvoiceId = il2.InvoiceId JOIN Track t2 ON il2.TrackId = t2.TrackId " +
                "WHERE i2.CustomerId = c.CustomerId GROUP BY t2.GenreId) AS genre_counts)";
            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Reader
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                CustomerGenre customerGenre = new CustomerGenre();
                                customerGenre.CustomerId = reader.GetInt32(0);
                                customerGenre.FirstName = reader.GetString(1);
                                customerGenre.LastName = reader.GetString(2);
                                customerGenre.PopularGenre = reader.GetString(3);
                                customerGenreList.Add(customerGenre);
                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                //Log error
                Console.WriteLine(ex);
            }
            return customerGenreList;
        }
    }
}
