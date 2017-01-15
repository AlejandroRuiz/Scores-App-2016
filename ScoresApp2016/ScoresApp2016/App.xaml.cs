using Xamarin.Forms;

namespace ScoresApp2016
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new ScoresApp2016Page();

			SqlManager.Init(DependencyService.Get<ISQLManager>().NativeManager, DependencyService.Get<ISQLManager>().Path);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
