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


        [Fact]
        public void Transfer_CantTransferMoreThanBalanceFromAccount()
        {
            // Arrange
            var fromAccount = new Account() { AccountID = 66,  Balance = 500M };
            var toAccount = new Account() {  AccountID = 99, Balance = 400M };
            var amount = 600M;
            var expected = 500M;

            // Act
            var account = fromAccount.Transfer(amount, fromAccount, toAccount);
            var actual = account.Balance;

            // Assert
            Assert.Equal(expected, actual, 2);
        }

        [Fact]
        public void Transfer_CorrectBalanceesAfterTransfer()
        {
            // Arrange
            var fromAccount = new Account() { AccountID = 66, Balance = 500M };
            var toAccount = new Account() { AccountID = 99, Balance = 400M };
            var amount = 400M;
            var expectedFromAccount = 100M;
            var expectedToAccount = 800M;

            // Act
            var account = fromAccount.Transfer(amount, fromAccount, toAccount);
            var actualFromAccount = account.Balance;
            var actualToAccount = toAccount.Balance;

            // Assert
            Assert.Equal(expectedFromAccount, actualFromAccount, 2);
            Assert.Equal(expectedToAccount, actualToAccount, 2);
        }

        [Fact]
        public void Transfer_CantTransferToSameAccount()
        {
            // Arrange
            var account = new Account() { AccountID = 66, Balance = 500M };
            var amount = 400M;
            var expected = Account.CantTransferBetweenSameAccounts;

            // Act
            account.Transfer(amount, account, account);

            // Assert
            Assert.Equal(expected, account.ErrorMessage);
        }

        [Fact]
        public void Transfer_CantTransferBetweenNonExistingAccounts()
        {
            // Arrage
            var expected = Account.AtLeastOneOfTheAccountsDoesntExist;
            var amount = 500M;
            var account = new Account();

            // Act
            account.Transfer(amount, null, null);

            // Assert
            Assert.Equal(expected, account.ErrorMessage);
        }

        [Fact]
        public void Transfer_CantTransferNegativeAmounts()
        {
            // Arrange
            var fromAccount = new Account() { AccountID = 11, Balance = 500M };
            var toAccount = new Account() { AccountID = 22, Balance = 400M };
            var amount = -400M;
            var expectedError = Account.CantTransferNegativeAmounts;
            var expectedAmount = 500M;


            // Act
            var account = fromAccount.Transfer(amount, fromAccount, toAccount);

            // Assert
            Assert.Equal(expectedAmount, account.Balance, 2);
            Assert.Equal(expectedError, account.ErrorMessage);
        }
    }
}
