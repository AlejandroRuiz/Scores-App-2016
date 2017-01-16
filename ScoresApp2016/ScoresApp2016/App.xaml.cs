using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ScoresApp2016
{
	public partial class App : Application
	{
		public static App CurrentApp
		{
			get;
			private set;
		}

		public MainMasterDetailPage CurrentMasterDetailPage
		{
			get
			{
				return MainPage as MainMasterDetailPage;
			}
		}

		public App()
		{
			InitializeComponent();

			MainPage = new MainMasterDetailPage();
			CurrentApp = this;
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
