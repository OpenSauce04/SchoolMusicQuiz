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
				Decor.IndentedNL();
				Console.Write("Chances: " + chances + " Score: " + score);
				Decor.IndentedNL();
				Console.Write(Songs[(SongId * 3) + 1]); //Display artist
				Decor.IndentedNL();
				Console.Write(BlankText.Parse(Songs[(SongId * 3) + 2])[0]); //Display obfuscated song name
				Decor.IndentedNL();
				Console.Write(BlankText.Parse(Songs[(SongId * 3) + 2])[1]);
				Decor.IndentedNL();
				if (Console.ReadLine().ToLower() == Songs[(SongId * 3) + 2].ToLower())
				{
					Decor.IndentedNL();
					Console.WriteLine("Correct!");
					score += 1;
					chances = 2;
				}
				else
				{
					chances -= 1;
					if (chances == 0)
					{
						Decor.IndentedNL();
						Console.Write("Game Over!");
						Decor.IndentedNL();
						Console.Write("The correct answer was " + Songs[(SongId * 3) + 2]);
						Decor.IndentedNL();
						Console.Write("Final score: " + score);
					}
					else
					{
						Decor.IndentedNL();
						Console.Write("1 chance left...");
					}
				}
				Decor.IndentedNL();
				Console.Write("Press any key to continue...");
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
