using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskListADO.Data;
using TaskListADO.Models;

namespace TaskListADO.Web.Controllers
{
    public class EmployeesController : ApiController
    {
        public List<Employee> Get()
        {
            DBRepository repo = new DBRepository();
            return repo.GetAllEmployees();
        }

        public Employee GetById(int id)
        {
            DBRepository repo = new DBRepository();
            List<Employee> employees = repo.GetAllEmployees();

            return employees.FirstOrDefault(e => e.EmpId == id);
        }
    }
}
