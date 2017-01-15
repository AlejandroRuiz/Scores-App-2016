using System;
using System.Collections.ObjectModel;
using ScoresApp2016.Common;
using ScoresApp2016.Common.Models;

namespace ScoresApp2016.Service
{
	public static class FixturesExtensions
	{
		public static ObservableCollection<FixtureViewModel> ToAppFixtures(this Service.Responses.Fixtures fixtures)
		{
			var returnData = new ObservableCollection<FixtureViewModel>();
			if (fixtures.count > 0)
			{
				foreach (var responsefixture in fixtures.fixtures)
				{
					var appfixture = new Fixture
					{
						Id = responsefixture._links.self.href,
						Date = responsefixture.date,
						Status = responsefixture.status,
						MatchDay = responsefixture.matchday,
						HomeTeam = new FixtureTeam
						{
							TeamName = responsefixture.homeTeamName,
							TeamGoals = (responsefixture.result.goalsHomeTeam.HasValue) ? responsefixture.result.goalsHomeTeam.Value : 0,
							TeamImage = responsefixture.homeTeamImage,
							ShortName = responsefixture.homeShortTeamName
						},
						AwayTeam = new FixtureTeam
						{
							TeamName = responsefixture.awayTeamName,
							TeamGoals = (responsefixture.result.goalsAwayTeam.HasValue) ? responsefixture.result.goalsAwayTeam.Value : 0,
							TeamImage = responsefixture.awayTeamImage,
							ShortName = responsefixture.awayShortTeamName
						}
					};

					returnData.Add(new FixtureViewModel(appfixture));
				}
			}
			return returnData;
		}

		public static Fixture ToAppFixture(this Service.Responses.SingleFixture fixture)
		{
			var data = new Fixture
			{
				Date = fixture.fixture.date,
				Status = fixture.fixture.status,
				MatchDay = fixture.fixture.matchday,
				HomeTeam = new FixtureTeam
				{
					TeamName = fixture.fixture.homeTeamName,
					TeamGoals = (fixture.fixture.result.goalsHomeTeam.HasValue) ? fixture.fixture.result.goalsHomeTeam.Value : 0,
					TeamImage = fixture.fixture.homeTeamImage
				},
				AwayTeam = new FixtureTeam
				{
					TeamName = fixture.fixture.awayTeamName,
					TeamGoals = (fixture.fixture.result.goalsAwayTeam.HasValue) ? fixture.fixture.result.goalsAwayTeam.Value : 0,
					TeamImage = fixture.fixture.awayTeamImage
				}
			};
			foreach (var homplayer in fixture.homePlayers)
			{
				data.HomeTeam.Players.Add(homplayer.ToAppTeamPlayer());
			}
			foreach (var awayplayer in fixture.awayPlayers)
			{
				data.AwayTeam.Players.Add(awayplayer.ToAppTeamPlayer());
			}
			return data;
		}

		public static TeamPlayer ToAppTeamPlayer(this Service.Responses.Player player)
		{
			return new TeamPlayer
			{
				Name = player.name,
				Position = player.position,
				JerseyNumber = player.jerseyNumber,
				DateOfBirth = player.dateOfBirth,
				Nationality = player.nationality,
				ContractUntil = player.contractUntil,
				MarketValue = player.marketValue
			};
		}
	}
}

