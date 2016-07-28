using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TaskListADO.Models;

namespace TaskListADO.Data
{
    public class DBRepository
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["TaskList"].ConnectionString;
        private static string connectionString2 = ConfigurationManager.ConnectionStrings["SWCCorp"].ConnectionString;

        public List<Task> GetAll()
        {
            List<Task> tasks= new List<Task>();

            //todo: connect to the database

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                //todo: write a SQL query to get the data
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM tasks";

                //you must open the database connection to use it
                cn.Open();

                //todo: take the SQL data and make it Task objects
                using (SqlDataReader dr = cmd.ExecuteReader()) //hits F5 in our ssms
                {
                    //we have to read the results 
                    while (dr.Read())
                    {
                        //todo: add those take objects to my list
                        Task newTask = new Task()
                        {
                            TaskId= (int)dr["taskId"],
                            Description = dr ["description"].ToString(),
                            DateEntered = DateTime.Parse(dr["dateEntered"].ToString()),   
                            Notes = dr["Notes"].ToString()
                        };

                        if (dr["dueDate"] != DBNull.Value)
                        {
                            newTask.DueDate = DateTime.Parse(dr["dueDate"].ToString());
                        }

                        tasks.Add(newTask);
                    }
                }
            }
            return tasks;
        }

        public Task GetById(int id)
        {
            Task task = new Task();

            using (var cn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM tasks WHERE taskId = @TaskId";
                cmd.Parameters.AddWithValue("@TaskId", id);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    

                    if (dr.HasRows)
                    {
                        dr.Read();

                        task.TaskId = (int) dr["taskId"];
                        task.Description = dr["description"].ToString();
                        task.DateEntered = DateTime.Parse(dr["dateEntered"].ToString());
                        task.Notes = dr["notes"].ToString();

                        if (dr["dueDate"] != DBNull.Value)
                        {
                            task.DueDate = DateTime.Parse(dr["dueDate"].ToString());
                        }
                    }
                }
                
            }

            return task;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var cn = new SqlConnection(connectionString2))
            {
                var cmd = new SqlCommand();
                cmd.CommandText="spGetEmployeeGrants";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Employee newEmployee = employees.FirstOrDefault(e => e.EmpId == (int) dr["EmpId"]);
                        if (newEmployee == null)
                        {
                            newEmployee = new Employee()
                            {
                                EmpId = (int) dr["EmpId"],
                                FirstName = dr["FirstName"].ToString(),
                                LastName = dr["LastName"].ToString(),

                                Grants = new List<Grant>()
                            };
                            employees.Add(newEmployee);
                        }

                        Grant newGrant = new Grant()
                        {
                            GrantId = int.Parse( dr["GrantId"].ToString()),
                            GrantName = dr["GrantName"].ToString(),
                            Amount = decimal.Parse(dr["Amount"].ToString())
                        };

                        newEmployee.Grants.Add(newGrant);
                    }
                }
            }

            return employees;
        }
    }
}
