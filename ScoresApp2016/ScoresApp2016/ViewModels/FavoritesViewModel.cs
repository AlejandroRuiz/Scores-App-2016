using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ScoresApp2016.Common.Models;

namespace ScoresApp2016
{
	public class FavoritesViewModel : BaseViewModel
	{
		static FavoritesViewModel _favoritesViewModelManager;
		public static FavoritesViewModel FavoritesViewModelManager
		{
			get
			{
				if (_favoritesViewModelManager == null)
					_favoritesViewModelManager = new FavoritesViewModel();
				return _favoritesViewModelManager;
			}
		}

		static ObservableCollection<ScoresApp2016.Common.Models.LeagueItem> _favoritesLeagues;
		public ObservableCollection<ScoresApp2016.Common.Models.LeagueItem> FavoritesLeagues
		{
			get
			{
				if (_favoritesLeagues == null)
				{
					_favoritesLeagues = new ObservableCollection<ScoresApp2016.Common.Models.LeagueItem>(SqlManager.Cache.Favorites);
				}
				return _favoritesLeagues;
			}
		}

		public void UpdateFavorites()
		{
			var newList = SqlManager.Cache.Favorites;
			// nothing changed => do nothing
			if (this.IsEqualToCollection(newList)) return;

			// handle deleted items
			IList<ScoresApp2016.Common.Models.LeagueItem> deletedItems = this.GetDeletedItems(newList);
			if (deletedItems.Count > 0)
			{
				foreach (var deletedItem in deletedItems)
				{
					FavoritesLeagues.Remove(deletedItem);
				}
			}

			// handle added items
			IList<ScoresApp2016.Common.Models.LeagueItem> addedItems = this.GetAddedItems(newList);
			if (addedItems.Count > 0)
			{
				foreach (var addedItem in addedItems)
				{
					FavoritesLeagues.Add(addedItem);
				}
			}

			// equals now? => return
			if (this.IsEqualToCollection(newList)) return;

			// resort entries
			for (int index = 0; index < newList.Count; index++)
			{
				var item = newList[index];
				int indexOfItem = FavoritesLeagues.IndexOf(item);
				if (indexOfItem != index) FavoritesLeagues.Move(indexOfItem, index);
			}
		}

		private IList<ScoresApp2016.Common.Models.LeagueItem> GetAddedItems(IEnumerable<ScoresApp2016.Common.Models.LeagueItem> newList)
		{
			IList<ScoresApp2016.Common.Models.LeagueItem> addedItems = new List<ScoresApp2016.Common.Models.LeagueItem>();
			foreach (var item in newList)
			{
				if (!this.ContainsItem(item)) addedItems.Add(item);
			}
			return addedItems;
		}

		private IList<ScoresApp2016.Common.Models.LeagueItem> GetDeletedItems(IEnumerable<ScoresApp2016.Common.Models.LeagueItem> newList)
		{
			IList<ScoresApp2016.Common.Models.LeagueItem> deletedItems = new List<ScoresApp2016.Common.Models.LeagueItem>();
			foreach (var item in FavoritesLeagues)
			{
				if (!newList.Contains(item)) deletedItems.Add(item);
			}
			return deletedItems;
		}

		private bool IsEqualToCollection(IList<ScoresApp2016.Common.Models.LeagueItem> newList)
		{
			// diffent number of items => collection differs
			if (FavoritesLeagues.Count != newList.Count) return false;

			for (int i = 0; i < FavoritesLeagues.Count; i++)
			{
				if (!FavoritesLeagues[i].Equals(newList[i])) return false;
			}
			return true;
		}

		private bool ContainsItem(object value)
		{
			foreach (var item in FavoritesLeagues)
			{
				if (value.Equals(item)) return true;
			}
			return false;
		}

		public FavoritesViewModel()
		{
		}
	}
}

