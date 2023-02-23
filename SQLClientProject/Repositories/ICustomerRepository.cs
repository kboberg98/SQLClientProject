using SQLClientProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientProject.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(int id);
        public Customer GetCustomerByName(string name);
        public List<Customer> GetAllCustomers();
        public List<Customer> GetCustomersPage(int limit, int offset);
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
    }
}
