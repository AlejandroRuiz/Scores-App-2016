using System;
using CoreSpotlight;
using Foundation;
using ScoresApp2016.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(WelcomePage), typeof(FavoritesPageRenderer))]
namespace ScoresApp2016.iOS
{
	public class FavoritesPageRenderer : PageRenderer
	{
		public FavoritesPageRenderer()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			UserActivity = CreateActivity();
		}

		const string activityName = "com.alejandroruiz.scores-app.favorites";

		NSUserActivity CreateActivity()
		{
			var activity = new NSUserActivity(activityName);
			activity.EligibleForSearch = true;
			activity.EligibleForPublicIndexing = true;
			activity.EligibleForHandoff = false;

			activity.Title = "Favorites";
			activity.AddUserInfoEntries(NSDictionary.FromObjectAndKey(new NSString("Favorites"), new NSString("Name")));

			//var keywords = new string[] {  };
			activity.Keywords = new NSSet<NSString>(new NSString("Favorites"), new NSString("Soccer"), new NSString("Favorites"));
			activity.ContentAttributeSet = new CSSearchableItemAttributeSet("Open favorites");

			return activity;
		}
	}
}

