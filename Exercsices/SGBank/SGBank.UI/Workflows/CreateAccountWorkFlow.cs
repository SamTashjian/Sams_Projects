using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    public class CreateAccountWorkFlow
    {
        public void Execute()
        {
            string name = GetNameForAccount();

            ProccessNewAccount(name);


        }

        private string GetNameForAccount()
        {
            string name = "";

            do
            {
                Console.Clear();

                Console.WriteLine("Please enter a name for your new account:");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Please enter something");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(name));

            return name;
        }

        private void ProccessNewAccount(string name)
        {
            var ops = new AccountOperations();

            Response response = ops.CreateNewAccount(name);

            if (response.Success)
            {
                LookupWorkflow lookup = new LookupWorkflow();
                lookup.Execute(response.AccountInfo.AccountId);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.ReadLine();
            }
        }
    }
}
