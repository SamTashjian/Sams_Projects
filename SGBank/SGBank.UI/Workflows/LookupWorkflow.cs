using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    public class LookupWorkflow
    {
        private Account _currentAccount;

        /// <summary>
        /// get the account number  from the user and call other exectue method
        /// </summary>
        public void Execute()
        {
            //I need to get the account number from the user
            int accountNumber = GetAccountNumberFromUser();
            Execute(accountNumber);
        }
        /// <summary>
        /// take the account number and display account info
        /// </summary>
        /// <param name="accountNumber">account number to display</param>
        public void Execute(int accountNumber)
        {
            //I need display the account returned to the user
            DisplayAccountInformation(accountNumber);          
        }
        /// <summary>
        /// prompt the user to enter the account number and return valid input
        /// </summary>
        /// <returns>account number</returns>
        private int GetAccountNumberFromUser()
        {
            do
            {
                Console.Clear();
                Console.Write("Enter an account number: ");
                string input = Console.ReadLine();

                int accountNumber;
                if (int.TryParse(input, out accountNumber))
                {
                    return accountNumber;
                }

                Console.WriteLine("That was not a valid account number...");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            } while (true);
        }

        private void DisplayAccountInformation(int accountNumber)
        {
            var ops = new AccountOperations();
            var response = ops.GetAccount(accountNumber);

            if (response.Success)
            {
                _currentAccount = response.AccountInfo;

                //print account info
                PrintAccountInformation();

                DisplayAccountMenu();
            }
            else
            {
                //crap we got an error!
                Console.WriteLine("Error Occurred!!!!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Move Along...");
                Console.ReadLine();
            }
        }

        private void PrintAccountInformation()
        {
            Console.Clear();
            Console.WriteLine("Account Information");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Account Number: {0}", _currentAccount.AccountId);
            Console.WriteLine("Name: {0}", _currentAccount.Name);
            Console.WriteLine("Account Balance: {0:c}", _currentAccount.Balance);
        }

        private void DisplayAccountMenu()
        {
            string input = "";

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Close Account");
                Console.WriteLine();
                Console.WriteLine("(Q) to Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter Choice: ");

                input = Console.ReadLine();

                if (input.ToUpper() != "Q")
                {
                    ProcessChoice(input);
                }

            } while (input.ToUpper() != "Q");
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    var depositWF = new DepositWorkflow(_currentAccount);
                    depositWF.Execute();
                    break;
                case "2":
                    var withdrawWF = new WithdrawWorkflow(_currentAccount);
                    withdrawWF.Execute();
                    break;
                case "3":
                case "4":
                    Console.WriteLine("This feature is not implemented yet!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("{0} is not valid!", choice);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }

            PrintAccountInformation();
        }
    }
}
