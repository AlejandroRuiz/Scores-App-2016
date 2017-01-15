using System;
using System.Collections.Generic;

namespace ScoresApp2016.Common.Models
{
	public class FixtureTeam
	{
		public string TeamName { get; set; }
		public string ShortName { get; set; }
		public int TeamGoals { get; set; }
		public string TeamImage { get; set; }
		public List<TeamPlayer> Players { get; set; } = new List<TeamPlayer>();
	}
}

