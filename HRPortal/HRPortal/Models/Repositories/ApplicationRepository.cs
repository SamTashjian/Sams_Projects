using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using HRPortal.Models.Data;

namespace HRPortal.Models.Repositories
{
    public class ApplicationRepository
    {
        public static List<Application> _applications;

        static ApplicationRepository()
        {
            _applications = new List<Application>
            {
                new Application {ApplicationId = 1, FirstName = "Sam", LastName = "Tashjian", PhoneNumber = 123-4567, Email = "stashjia@kent.edu", Education = "Bachelors of Education", WorkHistory = "4 years full time perishable recieving"}
            };
        }

        public static IEnumerable<Application> GetAll()
        {
            return _applications;
        }


        public static Application Get(int applicationId)
        {
            return _applications.FirstOrDefault(a => a.ApplicationId == applicationId);
        }

      
    }
}