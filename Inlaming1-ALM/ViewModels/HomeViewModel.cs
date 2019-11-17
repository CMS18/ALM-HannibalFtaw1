using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlaming1_ALM.Models.Entities;
using Inlaming1_ALM.Models.Services;

namespace Inlaming1_ALM.ViewModels
{
    public class HomeViewModel
    {
        public List<Customer> Customers { get; set; }

        public HomeViewModel()
        {
            Customers = BankRepository.GetCustomers();
        }
    }
}
