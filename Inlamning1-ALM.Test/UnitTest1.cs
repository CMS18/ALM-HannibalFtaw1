using System;
using Inlaming1_ALM.Models.Entities;
using Inlaming1_ALM.Models.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inlamning1_ALM.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AccountHasBalance()
        {
            // Arrange
            decimal expectedBalance = 123.54m;
            var account = new Account();

            // Act
            var actualBalance = account.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        public void CanDeposit()
        {
            // Arrange
            decimal initialBalance = 123.54m;
            decimal depositAmount = 50m;

            decimal expectedBalance = 173.54m;
            var _repo = new BankRepository(Account);


            // Act
            var account = _repo.
            var actualBalance = account.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotWithdrawMoreThanBalance()
        {
            // Arrange
            var _repo = BankRepository();


            var account = new Account();


            // Act
            account.Deposit(depositAmount);

            // Assert
            // Expects ArgumentOutOfRangeException
        }
    }
}
