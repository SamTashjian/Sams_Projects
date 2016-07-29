using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRPortal.Models.Data
{
    public class Policy
    {
        //'Required' and 'Error message' are part of the attribute model validation
        [Required(ErrorMessage = "Please choose a category for this policy")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter a policy title for this policy")]
        public string PolicyTitle { get; set; }
        [Required(ErrorMessage = "Please enter the content of this policy")]
        public string PolicyContent { get; set; }
    }
}