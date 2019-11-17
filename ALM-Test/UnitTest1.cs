using System;
using System.Collections.Generic;
using System.Linq;
using Inlaming1_ALM.Models.Entities;
using Inlaming1_ALM.Models.Services;
using Xunit;

namespace ALM_Test
{
    public class UnitTest1
    {
        private readonly Customer Customer = new Customer()
        {
            CustomerID = 1,
            CustomerName = "Test",
            Accounts = new List<Account>()
            {
                new Account()
                {
                    AccountID = 1,
                    Balance = 7500m
                }
            }
        };
        [Fact]
        public void TestDeposit()
        {
            // Arrange
            var account = Customer.Accounts.First();
            var depositAmount = 500m;
            var expectedBalance = 8000m;

            BankRepository.AddAccounts(Customer.Accounts);

            // Act
            var result = BankRepository.Deposit(depositAmount, account.AccountID);

            // Assert
            Assert.Equal(account.Balance, expectedBalance);
        }
        //[Fact]
        //public void TestDepositNegativeAmount()
        //{
        //    // Arrange
        //    var account = Customer.Accounts.First();
        //    var amount = -500m;
        //    var expectedResult = false;

        //    BankRepository.AddAccounts(Customer.Accounts);

        //    // Act
        //    var result = BankRepository.Deposit(amount, account.AccountID);

        //    // Assert
        //    Assert.Equal(result, expectedResult);
        //}

        [Fact]
        public void TestWithdrawal()
        {
            // Arrange
            var account = Customer.Accounts.First();
            var withdrawalAmount = 500m;
            var expectedBalance = 7000m;

            BankRepository.AddAccounts(Customer.Accounts);

            // Act
            var result = BankRepository.Withdraw(withdrawalAmount, account.AccountID);

            // Assert
            Assert.Equal(account.Balance, expectedBalance);
        }

        [Fact]
        public void TestWithdrawalNegativeAmount()
        {
            // Arrange
            var account = Customer.Accounts.First();
            var withdrawalAmount = -8000m;
            var expectedResult = BankRepository.Errormessage;
            var expected = 7500m;
            

            BankRepository.AddAccounts(Customer.Accounts);

            // Act
            var result = BankRepository.Withdraw(withdrawalAmount, account.AccountID);

            // Assert
            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void TestWithdrawTooMuch()
        {
            // Arrange
            var account = Customer.Accounts.First();
            var withdrawalAmount = 8000m;
            //var expectedBalance = -500m;

            BankRepository.AddAccounts(Customer.Accounts);

            // Act
            var result = BankRepository.Withdraw(withdrawalAmount, account.AccountID);

            // Assert
            Assert.False(result);
        }




    }
}
