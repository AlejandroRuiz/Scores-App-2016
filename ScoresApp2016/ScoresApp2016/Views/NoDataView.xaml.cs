using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ScoresApp2016
{
	public partial class NoDataView : ContentView
	{
		public NoDataView(string icon, string text)
		{
			InitializeComponent();
			_noFavoritesImage.Source = icon;
			_noFavoritesLabel.Text = text;
		}
	}
}
