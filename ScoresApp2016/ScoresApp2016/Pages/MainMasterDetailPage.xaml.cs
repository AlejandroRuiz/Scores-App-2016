using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ScoresApp2016
{
	public partial class MainMasterDetailPage : MasterDetailPage
	{
		public MainMasterDetailPage()
		{
			InitializeComponent();
			NavigateToPage(new WelcomePage());
		}

		string _currentPage { get; set; }

		public void NavigateToPage(Page toPage)
		{
			this.IsPresented = false;

			if (toPage.Title == _currentPage && !string.IsNullOrWhiteSpace(_currentPage))
				return;

			this._currentPage = toPage.Title;
			this.Detail = new NavigationPage(toPage)
			{
				BarBackgroundColor = ScoresAppStyleKit.NavigationBarBackgroundColor,
				BarTextColor = ScoresAppStyleKit.NavigationBarTextColor
			};
		}
	}
}
