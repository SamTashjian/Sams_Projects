using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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


    }
}