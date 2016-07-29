using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models.Data;
using HRPortal.Models.Repositories;
using HRPortal.Models.ViewModels;

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

        [HttpGet]
        public ActionResult AddJob()
        {
            var VM = new AddJobVM();
            VM.SetDepartmentItems(JobRepository.GetAll());
            return View((VM));
        }

        //attribute model validation, aka annotation validation, 
        //'Job' in Models.Data.Job contains the 'Required' and 'ErrorMessage' for each field of a complete Job object
        //form is never submitted to server unless there is valid data input by user
        [HttpPost]
        public ActionResult AddJob(Job job)
        {
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

        //explicit model validation, all validation is happening in the controller
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

        [HttpGet]
        public ActionResult ViewPolicies()
        {
          var VM = new ViewPolicyVM();
          VM.SetCategoryItems(PolicyRepository.GetAll());
            return View((VM));
        }

        [HttpGet]
        public ActionResult ManagePolicies()
        {
            var VM = new ViewPolicyVM();
            VM.SetCategoryItems(PolicyRepository.GetAll());
            return View(VM);
        }

        [HttpGet]
        public ActionResult AddPolicy()
        {
            var VM = new ViewPolicyVM();
            VM.SetCategoryItems(PolicyRepository.GetAll());
            return View(VM);
        }

        //attribute model validation, aka annotation validation, 
        //'Job' in Models.Data.Policy contains the 'Required' and 'ErrorMessage' for each field of a complete Job object
        //form is never submitted to server unless there is valid data input by user
        [HttpPost]
        public ActionResult AddPolicy(Policy  policy)
        {
            if (ModelState.IsValid)
            {
                PolicyRepository.Add(policy);
                return View("AddedPolicy", policy);
            }

            return View();
        }

        [HttpGet]
        public ActionResult ViewPoliciesByCat(string chosenCat)
        {
            var VM = new ViewPolicyVM();
            VM.SetCategoryItems(PolicyRepository.GetAll());
            return View("ViewPoliciesByCat", PolicyRepository.GetAll().Where(p=>p.Category.Equals(chosenCat, StringComparison.CurrentCultureIgnoreCase)));
        }

        [HttpGet]
        public ActionResult ManagePoliciesByCat(string chosenCat)
        {
            var VM = new ViewPolicyVM();
            VM.SetCategoryItems(PolicyRepository.GetAll());
            return View("ManagePoliciesByCat", PolicyRepository.GetAll().Where(p=>p.Category.Equals(chosenCat, StringComparison.CurrentCultureIgnoreCase)));
        }

        [HttpGet]
        public ActionResult DeletePolicy(string policyTitle)
        {
            var policy = PolicyRepository.Get(policyTitle);
            return View(policy);
        }

        [HttpPost]
        public ActionResult DeletePolicy(Policy policy)
        {
            PolicyRepository.Delete(policy.PolicyTitle);
            return RedirectToAction("ManagePolicies");
        }
    }
}