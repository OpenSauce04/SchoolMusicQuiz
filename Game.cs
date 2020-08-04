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
		public static int score = 0;
		public static void Wipe()
		{
			lives = 3;
			score = 0;
		}
		public static void Run()
		{
			while (lives != 0)
			{
				SongId = random.Next(0, 182);
				Console.Clear();
				Console.WriteLine("Lives: " + lives + " Score: " + score + "\n");
				Console.WriteLine(Songs[(SongId * 3) + 1]); //Display artist
				Console.WriteLine(BlankText.Parse(Songs[(SongId * 3) + 2])); //Display obfuscated song name
				if (Console.ReadLine() == Songs[(SongId * 3) + 2])
				{
					Console.WriteLine("Correct!");
					score += 1;
				}
				else
				{
					lives -= 1;
					Console.WriteLine("The correct answer was " + Songs[(SongId * 3) + 2]);
					if (lives == 0)
					{
						Console.WriteLine("Game Over!");
						Console.WriteLine("Final score: " + score);
					}
					else
					{
						Console.WriteLine(lives + " lives left.");
					}
				}
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
			}
			Console.Clear();
			Console.Write("Please enter your name: ");
			Leaderboard.Add(Console.ReadLine(), score);
			Leaderboard.Write();
			Leaderboard.Display();
			Console.WriteLine("\nPress any key to restart");
			Console.ReadKey();
		}
	}
}
