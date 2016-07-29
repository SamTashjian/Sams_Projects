using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewOrganization.Models;

namespace ViewOrganization.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            var players = new List<Player>
            {
                new Player() {Name = "Francisco Lindor", Number = 12, Position = "SS"},
                new Player() {Name = "Jason Kipnis", Position = "2B", Number = 22}
            };

            return View(players);
        }
    }
}