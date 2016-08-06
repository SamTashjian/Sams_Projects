using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using BaseballLeague.Models.Data;

namespace BaseballLeague.Models.ViewModels
{
    public class AddTeamVM
    {
        public Team Team;
        public List<SelectListItem> LeagueItems { get; set; }

        public AddTeamVM()
        {
            LeagueItems = new List<SelectListItem>();

            Team = new Team();
        }

        public void SetLeagueItems(IEnumerable<Team> teams)
        {
            foreach (var team in teams.Select(t => t.LeagueId).Distinct())
            {
                LeagueItems.Add(new SelectListItem()
                {
                    Value = team.ToString(),
                    Text = team.ToString(),
                });


            }
        }
    }
}