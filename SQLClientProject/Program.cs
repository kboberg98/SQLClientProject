using SQLClientProject.Models;
using SQLClientProject.Repositories;

namespace SQLClientProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ICustomerRepository repository = new CustomerRepository();
            TestSelectAll(repository);
        }

        static void TestSelectAll(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        static void TestSelect(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer(1));
        }

        static void TestInsert(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                CustomerId = 1,
                FirstName = "testfirstname",
                LastName = "testlastname",
                Country = "norway",
                PostalCode = "1088",
                Phone = "24342432", 
                Email = "testemail@hotmail.com" 
            };
            if (repository.AddNewCustomer(test))
            {
                Console.WriteLine("YAY, Insert worked");
            } else
            {
                Console.WriteLine("BOO, Insert didnt work");
            }
        }

        static void TestDelete(ICustomerRepository repository)
        {
            
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


    }
}