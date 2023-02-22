using Microsoft.Data.SqlClient;
using SQLClientProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientProject.Repositories
{
    public class CustomerSpenderRepository : ICustomerSpenderRepository
    {
        public List<CustomerSpender> GetCustomerSpenders()
        {
            List<CustomerSpender> customerSpenderList = new List<CustomerSpender>();
            string sql = "SELECT c.CustomerId, c.FirstName, c.LastName, SUM(i.Total) AS TotalSum FROM Invoice i JOIN Customer c ON i.CustomerId = c.CustomerId GROUP BY c.CustomerId, c.FirstName, c.LastName ORDER BY TotalSum DESC";
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
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                CustomerSpender customerSpender = new CustomerSpender();
                                customerSpender.CustomerId = reader.GetInt32(0);
                                customerSpender.FirstName = reader.GetString(1);
                                customerSpender.LastName = reader.GetString(2);
                                customerSpender.TotalSum = reader.GetDecimal(3);
                                customerSpenderList.Add(customerSpender);

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
            return customerSpenderList;
        }
    }
}
