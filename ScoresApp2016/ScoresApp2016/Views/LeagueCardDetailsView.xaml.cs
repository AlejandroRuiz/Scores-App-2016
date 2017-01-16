using System;
using System.Collections.Generic;
using ScoresApp2016.Common.Models;
using Xamarin.Forms;

namespace ScoresApp2016
{
	public partial class LeagueCardDetailsView : ContentView
	{
		ScoresApp2016.Common.Models.LeagueItem LeagueItem
		{
			get
			{
				return BindingContext as ScoresApp2016.Common.Models.LeagueItem;
			}
		}

		public LeagueCardDetailsView()
		{
			InitializeComponent();
		}

		public void SetBinding(ScoresApp2016.Common.Models.LeagueItem item)
		{
			BindingContext = item;
		}
	}
}
