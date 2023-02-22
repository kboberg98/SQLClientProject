using SQLClientProject.Models;
using SQLClientProject.Repositories;

namespace SQLClientProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //ICustomerRepository repository = new CustomerRepository();
            //TestUpdate(repository);
            //ICustomerCountryRepository repository = new CustomerCountryRepository();
            //TestSelectCustomerCountries(repository);
            ICustomerSpenderRepository repository = new CustomerSpenderRepository();
            TestSelectCustomerSpenders(repository);
        }

        static void TestSelectAll(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        static void TestSelectPage(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetCustomersPage(20, 5));
        }

        static void TestSelect(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer(1));
        }

        static void TestSelectByName(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerByName("John"));
        }

        static void TestInsert(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                FirstName = "Kristus",
                LastName = "Bobus",
                Country = "Norway",
                PostalCode = "1088",
                Phone = "32563255", 
                Email = "tusbus@hotmail.com" 
            };
            if (repository.AddNewCustomer(test))
            {
                Console.WriteLine("YAY, Insert worked");
                PrintCustomer(repository.GetCustomerByName("Kristus"));
            } else
            {
                Console.WriteLine("BOO, Insert didnt work");
            }
        }

        static void TestDelete(ICustomerRepository repository)
        {
            
        }

        static void TestUpdate(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                CustomerId = 61,
                FirstName = "Kris",
                LastName = "Bob",
                Country = "Norway",
                PostalCode = "1088",
                Phone = "32563255",
                Email = "tusbus@hotmail.com"
            };
            if (repository.UpdateCustomer(test))
            {
                Console.WriteLine("YAY, Update worked");
                PrintCustomer(repository.GetCustomer(61));
            }
            else
            {
                Console.WriteLine("BOO, Update didnt work");
            }
        }

        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach(Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Email} {customer.Phone} ---");
        }

        static void TestSelectCustomerCountries(ICustomerCountryRepository repository)
        {
            PrintCustomerCountries(repository.GetAllCustomerCountries());
        }

        static void PrintCustomerCountries(IEnumerable<CustomerCountry> customerCountries)
        {
            foreach (CustomerCountry customerCountry in customerCountries)
            {
                PrintCustomerCountry(customerCountry);
            }
        }

        static void PrintCustomerCountry(CustomerCountry customerCountry)
        {
            Console.WriteLine($"--- {customerCountry.Country} {customerCountry.NumCustomers} ---");
        }

        static void TestSelectCustomerSpenders(ICustomerSpenderRepository repository)
        {
            PrintCustomerSpenders(repository.GetCustomerSpenders());
        }

        static void PrintCustomerSpenders(IEnumerable<CustomerSpender> customerSpenders)
        {
            foreach (CustomerSpender customerSpender in customerSpenders)
            {
                PrintCustomerSpender(customerSpender);
            }
        }

        static void PrintCustomerSpender(CustomerSpender customerSpender)
        {
            Console.WriteLine($"---{customerSpender.CustomerId} {customerSpender.FirstName} {customerSpender.LastName} {customerSpender.TotalSum} ---");
        }


    }
}