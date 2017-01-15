using System;
using SQLite.Net.Interop;

namespace ScoresApp2016
{
	public interface ISQLManager
	{
		ISQLitePlatform NativeManager { get; }

		string Path { get; }
	}
}
