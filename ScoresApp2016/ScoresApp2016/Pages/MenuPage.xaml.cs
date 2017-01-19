using System;
using System.Collections.Generic;
using ScoresApp2016.Common.Models;
using Xamarin.Forms;

namespace ScoresApp2016
{
	public partial class MenuPage : ContentPage
	{
		public MenuPage()
		{
			InitializeComponent();
			if (Device.OS == TargetPlatform.iOS)
				_menuListView.RowHeight = 50;
		}

		#region ContentPage LifeCycle

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_menuListView.ItemTapped += _menuListView_ItemTapped;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_menuListView.ItemTapped -= _menuListView_ItemTapped;
		}

		#endregion

		#region Handlers

		void _menuListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			_menuListView.SelectedItem = null;
			var leagueItem = e.Item as LeagueItem;
			if (leagueItem.Id == LeagueItem.Favorites.Id)
				App.CurrentApp.CurrentMasterDetailPage.NavigateToPage(new WelcomePage());
			else
				App.CurrentApp.CurrentMasterDetailPage.NavigateToPage(new LeagueResultsPage(leagueItem));
		}

		#endregion
	}
}
