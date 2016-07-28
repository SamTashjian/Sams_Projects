using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TaskListADO.Data;
using TaskListADO.Models;

namespace TaskListADO
{
    class Program
    {
        static void Main(string[] args)
        {
            DBRepository repo = new DBRepository();
            List<Task> tasks = repo.GetAll();

            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TaskId}{task.Description}");
            }

            Console.WriteLine();

            Task myTask = repo.GetById(1);
            Console.WriteLine($"{myTask.TaskId}{myTask.Description}");
            Console.WriteLine($"{myTask.DateEntered.ToLongDateString()}");
            if (myTask.DueDate != null)
            {
                Console.WriteLine($"This is due on {((DateTime)myTask.DueDate).ToShortDateString()}");
            }
            Console.WriteLine($"{myTask.Notes}");

            Console.WriteLine();

            CalledStoredProc(repo);

            Console.ReadLine();
        }

        public static void CalledStoredProc(DBRepository repo)
        {
            List<Employee> employees = repo.GetAllEmployees();

            foreach (var  employee in employees)
            {
                Console.WriteLine($"{employee.EmpId} - {employee.FirstName} {employee.LastName}");

                Console.WriteLine("Grants");
                foreach (var grant in employee.Grants)
                {
                    Console.WriteLine($"\t{grant.GrantId} {grant.GrantName} {grant.Amount}");
                }

                Console.WriteLine();
            }
        }
    }
}
