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
        public static List<Account> Accounts { get; set; }
        public static string Errormessage { get; set; }
        public static string SuccessMessage { get; set; }

        public static List<Customer> GetCustomers()
        {
            return Customers;
        }

        public static List<Account> GetAccounts()
        {
            return Accounts;
        }

        public static void AddCustomers(List<Customer> customers)
        {
            Customers = customers;
        }

        public static void AddAccounts(List<Account> accounts)
        {
            Accounts = accounts;
        }

        public static bool Withdraw(decimal amount, int accountId)
        {
            var account = Accounts.SingleOrDefault(a => a.AccountID == accountId);

            if (amount < 0)
            {
                Errormessage = "You can't withdraw a negative amount, please try again.";
                SuccessMessage = "";
            }
            else
            {
                if (account != null)
                {
                    if (amount <= account.Balance)
                    {
                        account.Balance -= amount;
                        SuccessMessage =
                            $"You've withdrawn {amount} from your account. Your balance is now {account.Balance}";
                        Errormessage = "";
                    }
                    else
                    {
                        Errormessage = $"You can't withdraw more than your current balance which is {account.Balance}";
                        SuccessMessage = "";
                        return false;
                    }
                }
                else
                {
                    Errormessage = "Account not found";
                    SuccessMessage = "";
                }
            }

            return true;
        }


        public static bool Deposit(decimal amount, int accountId)
        {
            var account = Accounts.SingleOrDefault(a => a.AccountID == accountId);

            if (account != null)
            {
                if (amount < 0)
                {
                    Errormessage = "You can't deposit a negative amount, please try again.";
                    SuccessMessage = "";
                }
                else
                {
                    account.Balance += amount;
                    SuccessMessage =
                        $"You've deposited {amount} into your account. Your balance is now {account.Balance}";
                    Errormessage = "";
                    return true;
                }
            }
            else
            {
                Errormessage = "Account not found";
                SuccessMessage = "";
            }

            return true;

        }
    }
}
