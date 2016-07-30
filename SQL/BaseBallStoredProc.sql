--creating a stored procedure to take in a team name and display all the players stats
create procedure GetAllPlayersStatsFromATeam
(
	@TeamName nvarchar(50)
)as

select *
from HittingStats
	inner join Players
		on HittingStats.PlayerId = Players.PlayerId
			inner join Teams
				on Players.TeamId = Teams.TeamId
					inner join PitchingStats
						on Players.PlayerId = PitchingStats.PlayerId
where Teams.TeamName = @TeamName
go

