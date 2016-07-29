using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models.Data;

namespace HRPortal.Models.ViewModels
{
    public class AddJobVM
    {
        public Job Job;
        public List<SelectListItem> DepartmentItems { get; set; }


        public AddJobVM()
        {
            DepartmentItems = new List<SelectListItem>();

            Job = new Job();
        }

        public void SetDepartmentItems(IEnumerable<Job> jobs )
        {
            foreach (var job in jobs.Select(j=>j.Department).Distinct())
            {
                DepartmentItems.Add(new SelectListItem()
                {
                    Value = job,
                    Text =  job,
                });
            }
        }
    }
}