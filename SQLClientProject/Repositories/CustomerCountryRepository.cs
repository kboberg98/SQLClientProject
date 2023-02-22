using Microsoft.Data.SqlClient;
using SQLClientProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientProject.Repositories
{
    public class CustomerCountryRepository : ICustomerCountryRepository
    {
        public List<CustomerCountry> GetAllCustomerCountries()
        {
            List<CustomerCountry> customerCountryList = new List<CustomerCountry>();
            string sql = "SELECT Country, COUNT(*) AS NumCustomers FROM Customer GROUP BY Country ORDER BY NumCustomers DESC";
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
                                CustomerCountry customerCountry = new CustomerCountry();
                                customerCountry.Country = reader.GetString(0);
                                customerCountry.NumCustomers = reader.GetInt32(1);
                                customerCountryList.Add(customerCountry);

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
            return customerCountryList;
        }
    }
}
