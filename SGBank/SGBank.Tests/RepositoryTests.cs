using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Models;
using SGBsnk.Data;

namespace SGBank.Tests
{
    [TestFixture]
    class RepositoryTests
    {
        [Test]
        public void GetAccounts()
        {
            AccountRepository repo = AccountRepositoryFactory.CreateAccountRepository();

            Account account = repo.GetAccountByNumber(1);
            Assert.AreEqual(1, account.AccountId);

            Console.WriteLine($"{account.AccountId} {account.Name} - {account.Balance}");
        }

        [Test]
        public void GetNextAccountNumber()
        {
            AccountRepository repo = new InMemoryRepository();

            int nextAccountNumber = repo.GetNextAccountNumber();
            Assert.AreEqual(4, nextAccountNumber);
        }

        [Test]
        public void WithdrawTest()
        {
            AccountRepository repo = new InMemoryRepository();
           

            var WT = repo.GetAccountByNumber(1);
            repo.Withdrawal(WT, 1.98m );
            Assert.AreEqual(.01, WT.Balance);
        }
    }
}
