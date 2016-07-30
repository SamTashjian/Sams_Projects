--Getting all batters personal stats and their hitting stats
select *
from HittingStats 
	inner join Players
		on HittingStats.PlayerId = Players.PlayerId


--Ranking Players by Home Runs
select Players.PlayerFirstName, Players.PlayerLastName, Teams.TeamCity, Teams.TeamName, HR,
rank() over (order by HR desc) as [HR Rank]
from HittingStats
	inner join Players
		on HittingStats.PlayerId = Players.PlayerId
			inner join Teams
				on Players.TeamId = Teams.TeamId


--Ranking center fielders by their amount of walks
select Players.PlayerFirstName, Players.PlayerLastName, Teams.TeamCity, Teams.TeamName, Positions.PositionTitle, BB,
rank() over (order by BB desc) as [Walk Rank]
from HittingStats
	inner join Players
		on HittingStats.PlayerId = Players.PlayerId
			inner join Teams
				on Players.TeamId = Teams.TeamId
					inner join Positions 
						on Players.PositionId = Positions.PositionId
where PositionTitle = 'Center Field'


--Ranking all player into percentile groups based on their amount of hits
select Players.PlayerFirstName, Players.PlayerLastName, Teams.TeamCity, Teams.TeamName, Hits,
ntile(5) over (order by Hits desc) as [hits percentile rank]
from HittingStats
	inner join Players
		on HittingStats.PlayerId = Players.PlayerId
			inner join Teams
				on Players.TeamId = Teams.TeamId


--selecting the top 5 players in terms of RBIs
select top(5) with ties Players.PlayerFirstName, Players.PlayerLastName, Teams.TeamCity, Teams.TeamName, HittingStats.RBI
from HittingStats
	inner join Players
		on HittingStats.PlayerId = Players.PlayerId
			inner join Teams
				on Players.TeamId = Teams.TeamId
order by RBI desc


--selecting the bottom 2 short stops in terms of hits
select top(2) with ties Players.PlayerFirstName, Players.PlayerLastName, Teams.TeamCity, Teams.TeamName, HittingStats.Hits
from HittingStats
	inner join Players
		on HittingStats.PlayerId = Players.PlayerId
			inner join Teams
				on Players.TeamId = Teams.TeamId
					inner join Positions
						on Players.PositionId = Positions.PositionId
where PositionTitle = 'Short Stop'
order by Hits


--calling a stored procedure
exec GetAllPlayersStatsFromATeam 'Guitarists'


--batting average(BA) and on base percentage(OBP) as a calculated field using expresions 
select players.PlayerFirstName, players.PlayerLastName, teams.TeamCity, teams.TeamName,
(cast(HittingStats.Hits as float) / cast(HittingStats.AB as float)) as [BA], 
(cast(HittingStats.Hits + HittingStats.BB as float)) / (cast(HittingStats.AB + HittingStats.BB as float)) as [OBP] 
from HittingStats
	inner join Players
		on HittingStats.PlayerId = Players.PlayerId
			inner join Teams
				on Players.TeamId = Teams.TeamId
order by [BA] desc


--earned run average(ERA) and walks plus hits per inning pitched (WHIP) as a calcualted field using expresions
select Players.PlayerFirstName, Players.PlayerLastName, Teams.TeamCity, Teams.TeamName ,
(cast(PitchingStats.ER /PitchingStats.IP as float ) * 9) as [ERA],
(cast(PitchingStats.Walks + PitchingStats.HitsAllowed as float)) / PitchingStats.IP as [WHIP]
from PitchingStats
	inner join Players
		on PitchingStats.PlayerId = Players.PlayerId
			inner join Teams
				on Players.TeamId = Teams.TeamId
order by [ERA]


--using aggregates 'sum' funciton' to count the total number of hits a team has
select Teams.TeamCity, Teams.TeamName, sum(HittingStats.Hits) as [Total team hits]
from HittingStats
	inner join Players
		on HittingStats.PlayerId = Players.PlayerId
			inner join Teams
				on Players.TeamId = Teams.TeamId
group by Teams.TeamCity, Teams.TeamName
order by [Total team hits] desc



 