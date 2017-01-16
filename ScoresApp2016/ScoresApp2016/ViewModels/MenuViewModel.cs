using System;
using System.Collections.ObjectModel;
using ScoresApp2016.Common.Models;
using Xamarin.Forms;

namespace ScoresApp2016
{
	public class MenuViewModel: BaseViewModel
	{
		ObservableCollection<ScoresApp2016.Common.Models.LeagueItem> _menuItems;
		public ObservableCollection<ScoresApp2016.Common.Models.LeagueItem> MenuItems
		{
			get
			{
				if (_menuItems == null)
				{
					_menuItems = new ObservableCollection<ScoresApp2016.Common.Models.LeagueItem>(){
						ScoresApp2016.Common.Models.LeagueItem.Favorites,
						ScoresApp2016.Common.Models.LeagueItem.Bundesliga,
						ScoresApp2016.Common.Models.LeagueItem.PremiereLeague,
						ScoresApp2016.Common.Models.LeagueItem.SerieA,
						ScoresApp2016.Common.Models.LeagueItem.PrimeraDivision,
						ScoresApp2016.Common.Models.LeagueItem.Ligue1,
						ScoresApp2016.Common.Models.LeagueItem.Eredivisie
					};
				}
				return _menuItems;
			}
		}

		public int MenuItemsHeightRequest
		{
			get
			{
				return 50 * _menuItems.Count;
			}
		}

		public string PageTitle
		{
			get
			{
				return "Menu";
			}
		}

		public string PageIcon
		{
			get
			{
				return "ic_menu_white";
			}
		}

		public Color PageBackgroundColor
		{
			get
			{
				return ScoresAppStyleKit.MenuBackgroundColor;
			}
		}

		public MenuViewModel()
		{
		}
	}
}

