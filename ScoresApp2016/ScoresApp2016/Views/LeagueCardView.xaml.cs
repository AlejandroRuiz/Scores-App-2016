using System;
using System.Collections.Generic;
using ScoresApp2016.Common.Models;
using Xamarin.Forms;

namespace ScoresApp2016
{
	public partial class LeagueCardView : ContentView
	{
		public ScoresApp2016.Common.Models.LeagueItem LeagueItem
		{
			get
			{
				return BindingContext as ScoresApp2016.Common.Models.LeagueItem;
			}
		}

		public LeagueCardView(LeagueItem context)
		{
			BindingContext = context;
			InitializeComponent();
			_card.SetBinding(context);
		}

		void Button_Clicked(object sender, EventArgs e)
		{
			OnCardClicked?.Invoke(LeagueItem);
		}

		public Action<ScoresApp2016.Common.Models.LeagueItem> OnCardClicked { get; set; }
	}
}
