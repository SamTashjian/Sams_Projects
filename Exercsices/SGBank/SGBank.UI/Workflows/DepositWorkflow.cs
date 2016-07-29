using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
        private Account _currentAccount;
        /// <summary>
        /// constructtor
        /// </summary>
        /// <param name="account">account retreived to deposit money in</param>
        public DepositWorkflow(Account account)
        {
            _currentAccount = account;
        }
        /// <summary>
        /// get ammount to deposit and process the deposit
        /// </summary>
        public void Execute()
        {
            decimal amount = GetAmountToDeposit();

            ProcessDeposit(amount);
        }
        /// <summary>
        /// prompt the user for the  amount and verify valid input
        /// </summary>
        /// <returns>amount to deposit</returns>
        private decimal GetAmountToDeposit()
        {
            bool isValid = false;
            decimal amount;
            do
            {
                Console.Clear();
                Console.Write("How much money would you like to Deposit: ");
                string input = Console.ReadLine();


                if (!(isValid = decimal.TryParse(input, out amount)))
                {
                    Console.WriteLine("That was not a valid amount...");
                    Console.WriteLine("Please provide a valid amount...");
                    Console.ReadLine();
                }
                else
                {
                    if (amount <= 0)
                    {
                        Console.WriteLine("The amount must be greater than $0...");
                        Console.WriteLine("Please provide a valid amount...");
                        Console.ReadLine();
                        isValid = false;
                    }
                }
            } while (!isValid);

            return amount;
        }

        private void ProcessDeposit(decimal amount)
        {
            var ops = new AccountOperations();
            var response = ops.MakeDeposit(_currentAccount, amount);

            if (!response.Success)
            {
                //crap we got an error!
                Console.WriteLine("Error Occurred!!!!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Move Along...");
                Console.ReadLine();
            }
        }
    }
}
