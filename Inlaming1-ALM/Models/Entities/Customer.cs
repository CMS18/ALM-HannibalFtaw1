using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlaming1_ALM.Models.Entities
{
    public class Customer
    {
        public string CustomerName { get; set; }

        public int CustomerID { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
