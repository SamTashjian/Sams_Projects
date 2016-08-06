using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Mvc;
using System.Web.UI.WebControls;
using BaseballLeague.Models.Data;
using BaseballLeague.Models.Repositories;

namespace BaseballLeague.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Teams()
        {
            var model = TeamRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult Players()
        {
            var model = PlayerRepository.GetPlayersForTeam();
            return View(model.ToList());
        }
    }
}
