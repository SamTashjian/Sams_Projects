using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseballLeague.Models.Data;

namespace BaseballLeague.Models.Repositories
{
    public static class PlayerRepository
    {
        private static List<Player> _players;

        static PlayerRepository()
        {
            _players = new List<Player>
            {
                new Player {PlayerId = 1, TeamId = 1, PlayerFirstName = "Fred", PlayerLastName = "Fast", PositionId = 4, JerseyNumber = 26, YearsPlayed = 2},
                new Player {PlayerId = 2, TeamId = 1, PlayerFirstName = "Juan", PlayerLastName = "Jose", PositionId = 8, JerseyNumber = 10, YearsPlayed = 6},
                new Player {PlayerId = 3, TeamId = 2, PlayerFirstName = "Saul", PlayerLastName = "Slander", PositionId = 3, JerseyNumber = 12, YearsPlayed = 1},
                new Player {PlayerId = 4, TeamId = 2, PlayerFirstName = "Greg", PlayerLastName = "Gringo", PositionId = 2, JerseyNumber = 23, YearsPlayed = 10},
                new Player {PlayerId = 5, TeamId = 3, PlayerFirstName = "Lester", PlayerLastName = "Lefty", PositionId = 1, JerseyNumber = 15, YearsPlayed = 1},
                new Player {PlayerId = 6, TeamId = 3, PlayerFirstName = "Robert", PlayerLastName = "Righty", PositionId = 1, JerseyNumber = 51, YearsPlayed = 10},
                new Player {PlayerId = 7, TeamId = 4, PlayerFirstName = "Franky", PlayerLastName = "Fosters", PositionId = 7, JerseyNumber = 33, YearsPlayed = 2},
                new Player {PlayerId = 8, TeamId = 4, PlayerFirstName = "Bobby", PlayerLastName = "Budweiser", PositionId = 9, JerseyNumber = 5, YearsPlayed = 1},
            };
        }

        public static IEnumerable<Player> GetPlayersForTeam(int teamId)
        {
            return  _players.Where(t => t.TeamId == teamId);
        }


    }
}