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
				if (chances != 1)
				{
					SongId = random.Next(0, 182);
				}
				Console.Clear();
				Decor.DrawBorder();
				Console.CursorTop++;
				Decor.WriteCentered("Chances: " + chances + " Score: " + score);
				Console.CursorTop++;
				Decor.WriteCentered(Songs[(SongId * 3) + 1]); //Display artist
				Decor.WriteCentered(BlankText.Parse(Songs[(SongId * 3) + 2])[0]); //Display obfuscated song name
				Decor.WriteCentered(BlankText.Parse(Songs[(SongId * 3) + 2])[1]);
				Console.CursorLeft = Console.WindowWidth / 2 - Songs[(SongId * 3) + 2].Length / 2;
				Console.CursorTop += 1;
				if (Console.ReadLine().ToLower() == Songs[(SongId * 3) + 2].ToLower())
				{
					Decor.WriteCentered("Correct!");
					score += 1;
					chances = 2;
				}
				else
				{
					chances -= 1;
					if (chances == 0)
					{
						Decor.WriteCentered("Game Over!");
						Decor.WriteCentered("Correct answer: " + Songs[(SongId * 3) + 2]);
						Decor.WriteCentered("Final score: " + score);
					}
					else
					{
						Decor.WriteCentered("1 chance left...");
					}
				}
				Decor.WriteCentered("Press any key to continue...");
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
