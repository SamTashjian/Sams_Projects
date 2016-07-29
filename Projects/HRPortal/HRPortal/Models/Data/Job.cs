using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRPortal.Models.Data
{
    public class Job
    {
        //'Required' and 'Error message' are part of the attribute model validation
        public int JobId { get; set; }
        [Required(ErrorMessage = "Please enter a job title")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Please enter a department for this job")]
        public string Department { get; set; }
        [Range(1,int.MaxValue,ErrorMessage = "Please enter a number greater than 0 for this job's salary")]
        public decimal Salary { get; set; }
    }
}