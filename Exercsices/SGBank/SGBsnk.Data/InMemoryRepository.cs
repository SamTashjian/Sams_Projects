using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBsnk.Data
{
    public class InMemoryRepository : AccountRepository
    {
        static InMemoryRepository()
        {
            AccountList.Add(1, new Account() { AccountId = 1, Balance = 1.99m, Name = "Johnny Manziel" });
            AccountList.Add(2, new Account() { AccountId = 2, Balance = 100000000000000m, Name = "Mark Cuban" });
            AccountList.Add(3, new Account() { AccountId = 3, Balance = 1234567.89m, Name = "Kermit The Frog" });
        }

        public override bool Deposit(Account account, decimal amountToDeposit)
        {
            bool isSuccessful = false;

            if (AccountList.ContainsKey(account.AccountId))
            {
                Account currentAccount = AccountList[account.AccountId];
                currentAccount.Balance += amountToDeposit;

                isSuccessful = true;
            }

            return isSuccessful;
        }

        public override bool Withdrawal(Account account, decimal amountToWithdraw)
        {
            bool isSuccessful = false;

            if (AccountList.ContainsKey(account.AccountId))
            {
                Account currentAccount = AccountList[account.AccountId];
                currentAccount.Balance -= amountToWithdraw;

                isSuccessful = true;
            }

            return isSuccessful;
        }

        public override decimal Close(Account account)
        {
            decimal amount = 0;

            if (AccountList.ContainsKey(account.AccountId))
            {
                AccountList.Remove(account.AccountId);
                amount = account.Balance;
            }

            return amount;
        }
    }
}
