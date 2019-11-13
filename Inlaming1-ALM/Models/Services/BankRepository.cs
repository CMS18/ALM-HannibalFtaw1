using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlaming1_ALM.Models.Entities;

namespace Inlaming1_ALM.Models.Services
{
    public static class BankRepository
    {
        public static List<Customer> Customers { get; set; }
        public static List<Customer> GetCustomers()
        {
            return Customers;
        }

        public static void AddCustomers(List<Customer> customers)
        {
            Customers = customers;
        }

        //public List<Account> Accounts = new List<Account>
        //{
        //    new Account {CustomerID = 1, Balance = 2000m, AccountID = 1},
        //    new Account {CustomerID = 2, Balance = 5000m, AccountID = 2},
        //    new Account {CustomerID = 3, Balance = 8000m, AccountID = 3},
        //    new Account {CustomerID = 4, Balance = 7000m, AccountID = 4}
        //};

    }
}
