using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBsnk.Data
{
    public class FileRepository : AccountRepository
    {
        private const string FILENAME = "accounts.txt";

        static FileRepository()
        {
            using (StreamReader sr = File.OpenText(FILENAME))
            {
                string inputLine = "";
                string[] inputParts;
                while ((inputLine = sr.ReadLine()) != null)
                {
                    inputParts = inputLine.Split('|');
                    Account thisAccount = new Account()
                    {
                        AccountId = int.Parse(inputParts[0]),
                        Balance = decimal.Parse(inputParts[1]),
                        Name = inputParts[2]
                    };

                    AccountList.Add(thisAccount.AccountId, thisAccount);
                }
            }   
        }

        public override Account CreateAccount(Account account)
        {
            base.CreateAccount(account);

            using (StreamWriter sw = new StreamWriter(FILENAME, false))
            {
                foreach (var a in AccountList)
                {
                    sw.WriteLine($"{a.Value.AccountId}|{a.Value.Balance}|{a.Value.Name}");
                }
            }

            return account;
        }
        
        public override bool Deposit(Account account, decimal amountToDeposit)
        {
            bool isSuccessful = false;

            if (AccountList.ContainsKey(account.AccountId))
            {
                Account currentAccount = AccountList[account.AccountId];
                currentAccount.Balance += amountToDeposit;

                using (StreamWriter sw = new StreamWriter(FILENAME, false))
                {
                    foreach (var a in AccountList)
                    {
                        sw.WriteLine($"{a.Value.AccountId}|{a.Value.Balance}|{a.Value.Name}");
                    }
                }

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

                using (StreamWriter sw = new StreamWriter(FILENAME, false))
                {
                    foreach (var a in AccountList)
                    {
                        sw.WriteLine($"{a.Value.AccountId}|{a.Value.Balance}|{a.Value.Name}");
                    }
                }

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

                using (StreamWriter sw = new StreamWriter(FILENAME, false))
                {
                    foreach (var a in AccountList)
                    {
                        sw.WriteLine($"{a.Value.AccountId}|{a.Value.Balance}|{a.Value.Name}");
                    }
                }

                amount = account.Balance;
            }

            return amount;
        }
    }
}
