using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models.Data;
using HRPortal.Models.Repositories;

namespace HRPortal.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Jobs()
        {
            var model = JobRepository.GetAll();
            return View(model.ToList());
        }

        public ActionResult AddJob()
        {
            return View(new Job());
        }

        [HttpPost]
        public ActionResult AddJob(Job job)
        {
            if (string.IsNullOrEmpty(job.JobTitle))
            {
                ModelState.AddModelError("JobTitle", "Please enter a job title");
            }

            if (string.IsNullOrEmpty(job.Department))
            {
                ModelState.AddModelError("Department", "Please enter a department for this job");
            }

            if (job.Salary <= 0) //ask how to check if the user input is an int
            {
                ModelState.AddModelError("Salary", "Please enter a number for this job's salary");
            }

            if (ModelState.IsValid)
            {
                JobRepository.Add(job);
                return View("AddedJob", job);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Apply()
        {
            return View(new Application());
        }

        [HttpPost]
        public ActionResult Apply(Application application)
        {
            if (string.IsNullOrEmpty(application.FirstName))
            {
                ModelState.AddModelError("FirstName", "Please enter your first name");
            }

            if (string.IsNullOrEmpty(application.LastName))
            {
                ModelState.AddModelError("LastName", "Please enter your last name");
            }

            if (string.IsNullOrEmpty(application.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "Please enter your phone number");
            }

            if (string.IsNullOrEmpty(application.Email))
            {
                ModelState.AddModelError("Email", "Please enter your email");
            }

            if (string.IsNullOrEmpty(application.Education))
            {
                ModelState.AddModelError("Education", "Please enter any education you have received");
            }
            if (string.IsNullOrEmpty(application.WorkHistory))
            {
                ModelState.AddModelError("WorkHistory", "Please add any relevant work history");
            }
            if (ModelState.IsValid)
            {
                ApplicationRepository.Add(application);
                return View("YourSubmittedApp", application);
            }
            return View();
        }

        [HttpGet]
        public ActionResult ViewApps()
        {
            var model = ApplicationRepository.GetAll();

            return View(model.ToList());
        }
    }
}