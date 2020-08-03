using System;
using System.IO;

namespace SchoolCodingThingIDKwhatItsCalled
{
	class Game
	{
		public static string[] Songs = File.ReadAllLines("Songs.txt");
		public static Random random = new Random();
		public static int SongId;
		public static void Run()
		{
			SongId = random.Next(0, 188);
			Console.Clear();
			Console.WriteLine(Songs[(SongId * 3) + 1]);
		}
	}
}
