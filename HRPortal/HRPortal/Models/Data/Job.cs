using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRPortal.Models.Data
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}