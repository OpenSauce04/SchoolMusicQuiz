using System;
using System.IO;
using System.Linq;
using System.Threading;

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
		public static void ChanceWarning()
		{
			int pCursorLeft;
			int pCursorTop;
			while (true)
			{
				Thread.Sleep(500);
				pCursorTop = Console.CursorTop;
				Console.CursorTop = 1;
				pCursorLeft = Console.CursorLeft;
				Console.ForegroundColor = ConsoleColor.Red;
				Decor.WriteCentered("Chances: " + chances + new String(' ', (" Score: "+score).Length));
				Console.ForegroundColor = ConsoleColor.White;
				Console.CursorLeft -= ("Chances: " + chances).Length - 1;
				Console.Write(" Score: " + score);
				Console.CursorLeft = pCursorLeft;
				Console.CursorTop = pCursorTop;
				Thread.Sleep(500);
				pCursorTop = Console.CursorTop;
				Console.CursorTop = 1;
				pCursorLeft = Console.CursorLeft;
				Decor.WriteCentered("Chances: " + chances + " Score: " + score);
				Console.CursorLeft = Console.WindowWidth / 2 - Songs[(SongId * 3) + 2].Length / 2;
				Console.CursorLeft = pCursorLeft;
				Console.CursorTop = pCursorTop;
			}
		}
		public static void Run()
		{
			while (chances != 0)
			{
				if (chances != 1)
				{
					SongId = random.Next(0, 182);
				}
				else
				{
					Thread ChanceWarningThread = new Thread(ChanceWarning);
					ChanceWarningThread.Start();
				}
				Console.Clear();
				Decor.DrawBorder();
				Console.CursorTop++;
				Decor.WriteCentered("Chances: " + chances + " Score: " + score);
				Console.CursorTop++;
				Decor.WriteCentered(Songs[(SongId * 3) + 1]); //Display artist.
				Decor.WriteCentered(BlankText.Parse(Songs[(SongId * 3) + 2])[0]); //Display obfuscated song name's letter.
				Decor.WriteCentered(BlankText.Parse(Songs[(SongId * 3) + 2])[1]); //Display correlating underscores.
				Console.CursorLeft = Console.WindowWidth / 2 - Songs[(SongId * 3) + 2].Length / 2; // Adjust the cursor so that it lines up with the hidden song name
				Console.CursorTop += 1;
				if (Console.ReadLine().ToLower() == Songs[(SongId * 3) + 2].ToLower()) // If the inputted song name and selected song name are the same...
				{
					Decor.WriteCentered("Correct!");
					score += 1;
					chances = 2; // Reset number of chances for next question.
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
