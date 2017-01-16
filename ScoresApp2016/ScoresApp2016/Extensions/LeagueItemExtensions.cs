using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScoresApp2016.Common.Models;
using SQLite.Net;
using SQLite.Net.Interop;

namespace ScoresApp2016
{
	public static class LeagueItemExtensions
	{
		public static bool IsFavorite(this Common.Models.LeagueItem item)
		{
			return SqlManager.Cache.IsFavorite(item);
		}
	}
}
