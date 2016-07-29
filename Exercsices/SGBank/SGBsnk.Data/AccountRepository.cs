using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBsnk.Data
{
    public abstract class AccountRepository
    {
        protected static Dictionary<int, Account> AccountList { get; private set; }

        /// <summary>
        /// default constructor that initializes our account list
        /// </summary>
        static AccountRepository()
        {
            AccountList = new Dictionary<int, Account>();
        }

        /// <summary>
        /// method to get account by account number
        /// </summary>
        /// <param name="accountNumber">account number of the account</param>
        /// <returns>account</returns>
        public Account GetAccountByNumber(int accountNumber)
        {
            Account account = null;

            if (AccountList.ContainsKey(accountNumber))
            {
                account = AccountList[accountNumber];
            }

            return account;
        }

        public virtual Account CreateAccount(Account account)
        {
            AccountList.Add(account.AccountId, account);

            return account;
        }

        /// <summary>
        /// find the last account number and increement it by 1
        /// </summary>
        /// <returns>return 1 more than highest account number</returns>
        public int GetNextAccountNumber()
        {

            int accountNumber = 0;

            if (AccountList.Count != 0)
            {
                accountNumber = AccountList.Keys.Max();
            }

            return ++accountNumber;
        }

        /// <summary>
        /// deposit into the account given the amount given.
        /// </summary>
        /// <param name="account">where to put the $$$</param>
        /// <param name="amountToDeposit">$$$$</param>
        /// <returns>did it work?</returns>
        public abstract bool Deposit(Account account, decimal amountToDeposit);

        /// <summary>
        /// take money from account given in the amount given
        /// </summary>
        /// <param name="account">where to get the $$$</param>
        /// <param name="amountToWithdraw">$$$</param>
        /// <returns>boolean value indicating if it was successful</returns>
        public abstract bool Withdrawal(Account account, decimal amountToWithdraw);

        /// <summary>
        /// remove the account from record
        /// </summary>
        /// <param name="account">which account to close</param>
        /// <returns>any remaining balance</returns>
        public abstract decimal Close(Account account);
    }
}
