using System;
using System.Collections.Generic;
using ScoresApp2016.Common.Models;
using Xamarin.Forms;

namespace ScoresApp2016
{
	public partial class FixtureCardDetailsView : ContentView
	{
		public FixtureCardDetailsView()
		{
			InitializeComponent();
		}

		public void SetDetailViewData(FixtureTeam team)
		{
			BindingContext = team;
		}
	}
}
