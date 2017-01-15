using System;
using ScoresApp2016.iOS;
using SQLite.Net.Platform.XamarinIOS;

[assembly: Xamarin.Forms.Dependency(typeof(SQLManager_iOS))]
namespace ScoresApp2016.iOS
{
	public class SQLManager_iOS: ISQLManager
	{
		#region ISQLManager implementation

		public SQLite.Net.Interop.ISQLitePlatform NativeManager
		{
			get
			{
				return new SQLitePlatformIOS();
			}
		}

		public string Path
		{
			get
			{
				return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), SqlManager.DB_NAME);
			}
		}

		#endregion

		public SQLManager_iOS()
		{
		}
	}
}

