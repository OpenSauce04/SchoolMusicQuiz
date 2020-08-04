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
				if (Login.Prompt())
				{
					Console.WriteLine("Login successful.");
					LoggedIn = true; // Disable login loop, start main program.
				}
			}
			Thread.Sleep(500);
			Console.Clear();
			Game.Run();
			Console.ReadKey();
		}
	}
}
