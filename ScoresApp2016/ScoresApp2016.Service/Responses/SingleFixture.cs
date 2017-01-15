using System;
using System.Collections.Generic;

namespace ScoresApp2016.Service.Responses
{
	public class SingleFixture
	{
		public SingleFixture()
		{

		}

		public ScoresApp2016.Service.Responses.Fixtures.Fixture fixture { get; set; }

		public List<ScoresApp2016.Service.Responses.Player> homePlayers { get; set; } = new List<ScoresApp2016.Service.Responses.Player>();

		public List<ScoresApp2016.Service.Responses.Player> awayPlayers { get; set; } = new List<ScoresApp2016.Service.Responses.Player>();
	}
}

