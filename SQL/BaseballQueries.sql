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





 