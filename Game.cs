using System;
using System.IO;

namespace SchoolCodingThingIDKwhatItsCalled
{
	class Game
	{
		public static string[] Songs = File.ReadAllLines("Songs.txt");
		public static Random random = new Random();
		public static int SongId;
		public static int chances = 2;
		public static int score = 0;
		public static void Wipe()
		{
			chances = 2;
			score = 0;
		}
		public static void Run()
		{
			while (chances != 0)
			{
				SongId = random.Next(0, 182);
				Console.Clear();
				Console.WriteLine("Chances: " + chances + " Score: " + score + "\n");
				Console.WriteLine(Songs[(SongId * 3) + 1]); //Display artist
				Console.WriteLine(BlankText.Parse(Songs[(SongId * 3) + 2])[0]); //Display obfuscated song name
				Console.WriteLine(BlankText.Parse(Songs[(SongId * 3) + 2])[1]);
				if (Console.ReadLine() == Songs[(SongId * 3) + 2])
				{
					Console.WriteLine("Correct!");
					score += 1;
					chances = 2;
				}
				else
				{
					chances -= 1;
					Console.WriteLine("The correct answer was " + Songs[(SongId * 3) + 2]);
					if (chances == 0)
					{
						Console.WriteLine("Game Over!");
						Console.WriteLine("Final score: " + score);
					}
					else
					{
						Console.WriteLine("1 chance left...");
					}
				}
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
			}
			Console.Clear();
			Console.Write("Please enter your name: ");
			Leaderboard.Add(Console.ReadLine(), score);
			Leaderboard.Sort();
			Leaderboard.Write();
			Console.Clear();
			Console.WriteLine("TOP 5 SCORES:");
			Leaderboard.Display();
			Console.WriteLine("\nPress any key to restart");
			Console.ReadKey();
		}
	}
}
