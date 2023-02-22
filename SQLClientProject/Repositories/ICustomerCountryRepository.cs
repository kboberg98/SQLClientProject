using SQLClientProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientProject.Repositories
{
    public interface ICustomerCountryRepository
    {
        public List<CustomerCountry> GetAllCustomerCountries();
    }
}
