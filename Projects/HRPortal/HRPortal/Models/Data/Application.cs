using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRPortal.Models.Data
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string WorkHistory { get; set; }
    }
}