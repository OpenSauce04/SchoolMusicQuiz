using System;
using System.IO;

namespace SchoolCodingThingIDKwhatItsCalled
{
	class Game
	{
		public static string[] Songs = File.ReadAllLines("Songs.txt");
		public static Random random = new Random();
		public static int SongId;
		public static int lives = 3;
		public static void Run()
		{
			while (lives != 0)
			{
				SongId = random.Next(0, 188);
				Console.Clear();
				Console.WriteLine("Lives: "+lives+"\n");
				Console.WriteLine(Songs[(SongId * 3) + 1]); //Display artist
				Console.WriteLine(BlankText.Parse(Songs[(SongId * 3) + 2])); //Display obfuscated song name
				if (Console.ReadLine() == Songs[(SongId * 3) + 2])
				{
					Console.WriteLine("Correct!");
				}
				else
				{
					lives -= 1;
					Console.WriteLine("The correct answer was " + Songs[(SongId * 3) + 2]);
					if (lives == 0)
					{
						Console.WriteLine("Game Over!");
					}
					else
					{
						Console.WriteLine(lives + " lives left.");
					}
				}
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
			}
		}
	}
}
