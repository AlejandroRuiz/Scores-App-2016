using System;
using System.Collections.Generic;
using ScoresApp2016.Service;
using Xamarin.Forms;

namespace ScoresApp2016
{
	public partial class FixtureLayout : ViewCell
	{
		public FixtureLayout()
		{
			InitializeComponent();
			_mainCardView.SetCardData(Fixture);
		}

		FixtureViewModel Fixture
		{
			get
			{
				return BindingContext as FixtureViewModel;
			}
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			if (Fixture == null)
				return;
			_mainCardView.SetCardData(Fixture);
		}
	}
}
