using System;
using System.Threading;

namespace SchoolCodingThingIDKwhatItsCalled
{
	class Program
	{
		static void Main(string[] args)
		{
			bool LoggedIn = false;
			while (LoggedIn == false) // Loop this code until logged in
			{
				Console.WriteLine("Written by Daniel Bradbury :)\n");
				if (Login.Prompt())
				{
					Console.WriteLine("Login successful.");
					LoggedIn = true; // Disable login loop, start main program.
				}
			}
			Thread.Sleep(500);
			while (true)
			{
				Console.Clear();
				try
				{
					Leaderboard.Scores = (Score[])Serialize.ByteArrayToObject(Leaderboard.Read("Leaderboard.bin"));
				}
				catch { } // If there is no Leaderboard.bin file, keep running anyway.
				Game.Wipe(); // Clear game variables
				Game.Run();
			}
		}
	}
}
