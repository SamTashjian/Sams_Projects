using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    public class WithdrawWorkflow
    {
        private Account _currentAccount;

        /// <summary>
        /// constructtor
        /// </summary>
        /// <param name="account">account retreived to withdraw money in</param>
        public WithdrawWorkflow(Account account)
        {
            _currentAccount = account;
        }

        /// <summary>
        /// get ammount to withdraw and process the withdraw
        /// </summary>
        public void Execute()
        {
            decimal amount = GetAmountToWithdraw();

            ProcessWithdraw(amount);
        }

        /// <summary>
        /// prompt the user for the  amount to withdraw and verify valid input
        /// </summary>
        /// <returns>amount to withdraw</returns>
        private decimal GetAmountToWithdraw()
        {
            bool isValid = false;
            decimal amount;
            do
            {
                Console.Clear();
                Console.Write("How much money would you like to Withdraw: ");
                string input = Console.ReadLine();


                if (!(isValid = decimal.TryParse(input, out amount)))
                {
                    Console.WriteLine("That was not a valid amount...");
                    Console.WriteLine("Please provide a valid amount...");
                    Console.ReadLine();
                }
                else
                {
                    if (amount > _currentAccount.Balance)
                    {
                        Console.WriteLine("You cannot withdraw more money than you have in your account");
                        Console.WriteLine("Perhaps you would like to come in and apply for a loan...");
                        Console.ReadLine();
                        isValid = false;
                    }
                }
            } while (!isValid);

            return amount;
        }

        private void ProcessWithdraw(decimal amount)
        {
            var ops = new AccountOperations();
            var response = ops.MakeWithdraw(_currentAccount, amount);

            if (!response.Success)
            {
                
                Console.WriteLine("Error Occurred!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Please try again");
                Console.ReadLine();
            }
        }

    }
}
