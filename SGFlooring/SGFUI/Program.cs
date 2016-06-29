using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFUI.SGFWorkflows;

namespace SGFUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenuWorkflow mainMenu = new MainMenuWorkflow();
            mainMenu.DisplayMainMenu();
        }
    }
}
