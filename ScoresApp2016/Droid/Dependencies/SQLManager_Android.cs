using System;
using ScoresApp2016.Droid;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLManager_Android))]
namespace ScoresApp2016.Droid
{
	public class SQLManager_Android : ISQLManager
	{
		#region ISQLManager implementation

		public SQLite.Net.Interop.ISQLitePlatform NativeManager
		{
			get
			{
				return new SQLitePlatformAndroid();
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

		public SQLManager_Android()
		{
		}
	}
}
