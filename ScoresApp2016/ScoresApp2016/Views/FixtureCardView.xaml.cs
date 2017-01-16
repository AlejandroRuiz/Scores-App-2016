using System;
using System.Collections.Generic;
using ScoresApp2016.Service;
using Xamarin.Forms;

namespace ScoresApp2016
{
	public partial class FixtureCardView : ContentView
	{
		public FixtureCardView()
		{
			InitializeComponent();
		}

		public void SetCardData(FixtureViewModel fixture)
		{
			_homeTeamDetails.SetDetailViewData(fixture?.Fixture.HomeTeam);
			_awayTeamDetails.SetDetailViewData(fixture?.Fixture.AwayTeam);
		}
	}
}
