using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBsnk.Data;

namespace SGBank.BLL
{
    public class AccountOperations
    {
        public Response GetAccount(int accountNumber)
        {
            var repo = AccountRepositoryFactory.CreateAccountRepository();

            var response = new Response();

            var account = repo.GetAccountByNumber(accountNumber);

            if (account == null)
            {
                response.Success = false;
                response.Message = "This is not the Account you are looking for...";
            }
            else
            {
                response.Success = true;
                response.AccountInfo = account;
            }

            return response;
        }

        public Response MakeDeposit(Account account, decimal amountToDeposit)
        {
            var repo = AccountRepositoryFactory.CreateAccountRepository();

            var response = new Response();

            if (repo.Deposit(account, amountToDeposit))
            {
                response = GetAccount(account.AccountId);
                if (!response.Success)
                {
                    response.Message = "The deposit succeeded but account info lost";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "deposit failed!";
            }

            return response;
        }

        public Response CreateNewAccount(string name)
        {
            var repo = AccountRepositoryFactory.CreateAccountRepository();

            var  response = new Response();

            int accountNumber = repo.GetNextAccountNumber();

            decimal balance = 0m;

            Account newAccount = new Account()
            {
                AccountId = accountNumber,
                Name = name,
                Balance = balance
            };

            newAccount = repo.CreateAccount(newAccount);

            if (newAccount != null)
            {
                response.Success = true;
                response.AccountInfo = newAccount;
            }
            else
            {
                response.Success = false;
                response.Message = $"Failed to create account for {newAccount.Name}";
            }

            return response;
        }

        public Response MakeWithdraw(Account account, decimal amountToWithdraw)
        {
            var repo = AccountRepositoryFactory.CreateAccountRepository();

            var response = new Response();

            if (repo.Withdrawal(account, amountToWithdraw))
            {
                response = GetAccount(account.AccountId);
                if (!response.Success)
                {
                    response.Message = "The Withdraw succeeded but account info lost";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Withdraw failed!";
            }

            return response;
        }
    }
}
