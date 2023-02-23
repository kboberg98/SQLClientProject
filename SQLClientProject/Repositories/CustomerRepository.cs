using Microsoft.Data.SqlClient;
using SQLClientProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientProject.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
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
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                                customer.LastName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                                customer.Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                                customerList.Add(customer);

                            }
                        }
                    }
                }

            }catch(SqlException ex)
            {
                //Log error
                Console.WriteLine(ex);
            }
            return customerList;
        }
        /// <summary>
        /// Returns a List of all customers from the database
        /// </summary>
        /// <returns>List of Customer objects</returns>
        /// <exception cref="SqlException">Thrown when a database operation fails</exception>

        public List<Customer> GetCustomersPage(int limit, int offset)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = $"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                $"FROM Customer " +
                $"ORDER BY CustomerId " +
                $"OFFSET {offset} ROWS " +
                $"FETCH NEXT {limit} ROWS ONLY";

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
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = reader.GetString(4);
                                customer.Phone = reader.GetString(5);
                                customer.Email = reader.GetString(6);
                                customerList.Add(customer);
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

            return customerList;
        }
        /// <summary>
        /// Returns a List of all customers from the database based on limit and offset
        /// </summary>
        /// /// <param name="limit">The maximum number of customers to return</param>
        /// <param name="offset">The number of customers to skip before returning the results</param>
        /// <returns>List of Customer objects</returns>
        /// <exception cref="SqlException">Thrown when a database operation fails</exception>

        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" + 
                    " WHERE CustomerId = @CustomerId";
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
                                customer.CustomerId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                customer.FirstName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                                customer.LastName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                                customer.Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);

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
            return customer;
        }
        /// <summary>
        /// Retrieves a customer with the specified id from the database
        /// </summary>
        /// <param name="id">The id of the customer to retrieve</param>
        /// <returns>The Customer object with the specified id</returns>
        /// <exception cref="SqlException">Thrown when there is an error connecting to or querying the database</exception>

        public Customer GetCustomerByName(string name)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" +
                    " WHERE FirstName LIKE @FirstName";
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
                        cmd.Parameters.AddWithValue("@FirstName", name);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                customer.CustomerId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                customer.FirstName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                                customer.LastName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                                customer.Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);

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
            return customer;
        }
        /// <summary>
        /// Retrieves a customer with the specified first name from the database
        /// </summary>
        /// <param name="name">The first name of the customer to retrieve</param>
        /// <returns>The Customer object with the specified first name</returns>
        /// <exception cref="SqlException">Thrown when there is an error connecting to or querying the database</exception>
        
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);

                        // Execute the command
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log error
                Console.WriteLine(ex);
            }
            return success;
        }
        /// <summary>
        /// Adds a new customer to the database
        /// </summary>
        /// <param name="customer">The Customer object to add to the database</param>
        /// <returns>True if the customer was successfully added to the database, false otherwise</returns>
        /// <exception cref="SqlException">Thrown when there is an error connecting to or querying the database</exception>

        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email WHERE CustomerId = @CustomerId";

            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);

                        // Execute the command
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log error
                Console.WriteLine(ex);
            }
            return success;
        }
        /// <summary>
        /// Updates the information of an existing customer in the database
        /// </summary>
        /// <param name="customer">The updated Customer object to be saved in the database</param>
        /// <returns>True if the customer's information was successfully updated in the database, false otherwise</returns>
        /// <exception cref="SqlException">Thrown when there is an error connecting to or querying the database</exception>
    }
}
