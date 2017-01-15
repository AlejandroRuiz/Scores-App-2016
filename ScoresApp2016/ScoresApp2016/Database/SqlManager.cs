using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScoresApp2016.Common.Models;
using SQLite.Net;
using SQLite.Net.Interop;

namespace ScoresApp2016
{
	public class SqlManager
	{

		public static void Init(ISQLitePlatform SQLitePlatform, string path)
		{
			_cache = new SqlManager(SQLitePlatform, path);
		}

		private SqlManager(ISQLitePlatform SQLitePlatform, string path)
		{
			Connection = new SQLiteConnection(SQLitePlatform, path);
			CreateTables();
		}

		public const string DB_NAME = "ScoresAppDatabase.db";

		static SqlManager _cache { get; set; }

		public static void DeleteSingleton()
		{
			_cache = null;
		}

		public SQLiteConnection Connection { get; private set; }

		void CreateTables()
		{
			if (Connection != null)
			{
				Connection.CreateTable<LeagueItem>();
			}
			else
			{
				throw new FileNotFoundException("Database File Not Found");
			}
		}

		public List<LeagueItem> Favorites
		{
			get
			{
				return Connection.Table<LeagueItem>().ToList();
			}
		}

		public bool IsFavorite(LeagueItem item)
		{
			var source = Favorites.FirstOrDefault(i => i.Id == item.Id);
			return source != null;
		}

		public void AddToFavorite(LeagueItem item)
		{
			if (Favorites.FirstOrDefault(i => i.Id == item.Id) == null)
				Connection.Insert(item);
			FavoritesViewModel.FavoritesViewModelManager.UpdateFavorites();
		}

		public void RemeveFromFavorite(LeagueItem item)
		{
			if (Favorites.FirstOrDefault(i => i.Id == item.Id) != null)
				Connection.Delete<LeagueItem>(item.Id);
			FavoritesViewModel.FavoritesViewModelManager.UpdateFavorites();
		}

		public static SqlManager Cache
		{
			get
			{
				if (_cache == null)
				{
					throw new NotImplementedException("You Must Call static method Init(ISQLitePlatform SQLitePlatform) " +
					"before to use database");
				}

				return _cache;
			}
		}
	}
}
