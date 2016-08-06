using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseballLeague.Models.Data;

namespace BaseballLeague.Models.Repositories
{
    public static class TeamRepository
    {
        private static List<Team> _teams;

        static TeamRepository()
        {
            _teams = new List<Team>
            {
                new Team {TeamId = 1, LeagueId = 1, TeamName = "Pierogies", TeamCity = "Parma", Wins = 25, Losses = 35},
                new Team {TeamId = 2, LeagueId = 1, TeamName = "Wizards", TeamCity = "Westlake", Wins = 40, Losses = 20},
                new Team {TeamId = 3, LeagueId = 2, TeamName = "Turtles", TeamCity = "Twinsburg", Wins = 30, Losses = 30},
                new Team {TeamId = 4, LeagueId = 2, TeamName = "Banditos", TeamCity = "Bay Village", Wins = 35, Losses = 25}
            };
        }

        public static IEnumerable<Team> GetAll()
        {
            return _teams;
        }

        public static Team Get(int teamId)
        {
            return _teams.FirstOrDefault(t => t.TeamId == teamId);
        }

        public static void Add(Team team)
        {
            Team newTeam = new Team();
            newTeam.TeamId = _teams.Max(t => t.TeamId) + 1;
            newTeam.LeagueId = team.LeagueId;
            newTeam.TeamCity = team.TeamCity;
            newTeam.TeamName = team.TeamName;
            newTeam.Wins = team.Wins;
            newTeam.Losses = team.Losses;
        }
    }
}