using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace MusicQuiz
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
				if (chances == 1)
				{
					pCursorTop = Console.CursorTop;
					Console.CursorTop = 1;
					pCursorLeft = Console.CursorLeft;
					Console.ForegroundColor = ConsoleColor.Red;
					Decor.WriteCentered("Chances: " + chances + new String(' ', (" Score: " + score).Length)); // Draw flashing part of text
					Console.ForegroundColor = ConsoleColor.White;
					Console.CursorLeft -= ("Chances: " + chances).Length - 1;
					Console.Write(" Score: " + score);
					Console.CursorLeft = pCursorLeft; // Store previous Cursor position
					Console.CursorTop = pCursorTop;   // ^
					Thread.Sleep(500);
					pCursorTop = Console.CursorTop;
					Console.CursorTop = 1;
					pCursorLeft = Console.CursorLeft;
					Decor.WriteCentered("Chances: " + chances + " Score: " + score);
					Console.CursorLeft = pCursorLeft;
					Console.CursorTop = pCursorTop;
				}
			}
		}
		public static void Init()
		{
			Thread ChanceWarningThread = new Thread(ChanceWarning);
			ChanceWarningThread.Start();
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
					
				}
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Blue;
				Decor.DrawBorder();
				Console.ForegroundColor = ConsoleColor.White;
				Console.CursorTop++;
				Decor.WriteCentered("Chances: " + chances + " Score: " + score);
				Console.CursorTop++;
				Console.ForegroundColor = ConsoleColor.Cyan;
				Decor.WriteCentered(Songs[(SongId * 3) + 1]); //Display artist.
				Console.ForegroundColor = ConsoleColor.White;
				Decor.WriteCentered(BlankText.Parse(Songs[(SongId * 3) + 2])[0]); //Display obfuscated song name's letter.
				Decor.WriteCentered(BlankText.Parse(Songs[(SongId * 3) + 2])[1]); //Display correlating underscores.
				Console.CursorLeft = Console.WindowWidth / 2 - Songs[(SongId * 3) + 2].Length / 2; // Adjust the cursor so that it lines up with the hidden song name
				Console.CursorTop += 1;
				if (Console.ReadLine().ToLower() == Songs[(SongId * 3) + 2].ToLower()) // If the inputted song name and selected song name are the same...
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Decor.WriteCentered("Correct!");
					Console.ForegroundColor = ConsoleColor.White;
					if (chances == 2)
					{
						score += 3;
					} else
					{
						score += 1;
					}
					chances = 2; // Reset number of chances for next question.
				}
				else
				{
					chances -= 1;
					if (chances == 0)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Decor.WriteCentered("Game Over!");
						Console.ForegroundColor = ConsoleColor.White;
						Decor.WriteCentered("Correct answer: " + Songs[(SongId * 3) + 2]);
						Console.ForegroundColor = ConsoleColor.Green;
						Decor.WriteCentered("Final score: " + score);
						Console.ForegroundColor = ConsoleColor.White;
					}
					else
					{
						Decor.WriteCentered("1 chance left...");
					}
				}
				Console.ForegroundColor = ConsoleColor.Yellow;
				Decor.WriteCentered("Press any key to continue...");
				Console.ForegroundColor = ConsoleColor.White;
				Console.ReadKey();
			}
			Thread.Sleep(500); // This is to stop the chance warning from occasionally appearing over the enter name screen
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Decor.DrawBorder();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.CursorTop = Console.WindowHeight / 3;
			Decor.WriteCentered("Please enter your name:\n");
			Console.ForegroundColor = ConsoleColor.White;
			Console.CursorLeft = 13;
			Leaderboard.Add(Console.ReadLine(), score);
			Leaderboard.Sort();
			Leaderboard.Write();
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Decor.DrawBorder();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.CursorTop++;
			Decor.WriteCentered("Top 5 Scores:\n");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Leaderboard.Display();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Decor.WriteCentered("Press any key to restart");
			Console.ReadKey();
		}
	}
}
