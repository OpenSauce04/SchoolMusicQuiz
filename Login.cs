using System;
using System.IO;
using System.Threading;

namespace SchoolCodingThingIDKwhatItsCalled
{
	public class Login
	{
		public static bool Prompt()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Decor.WriteCentered("Enter your username:\n");
			Console.CursorLeft = 15;
			Console.ForegroundColor = ConsoleColor.White;
			string user = SHA256.calc(Console.ReadLine()); // Take user input for username and store SHA256 hash of input
			Console.ForegroundColor = ConsoleColor.Yellow;
			Decor.WriteCentered(" Enter your password: \n");
			Console.CursorLeft = 15;
			Console.ForegroundColor = ConsoleColor.White;
			string pass = SHA256.calc(Console.ReadLine());
			if (File.Exists("userdb/" + user)
				&& File.ReadAllText("userdb/" + user) == pass) // Checks to see if the user's entry in the user database exists,
															   // and if it does checks to see if the user's password hash matches
															   // with the user's input.
			{
				return true;                                                              // If it does, return true
			}
			Console.ForegroundColor = ConsoleColor.Red;
			Decor.WriteCentered("Login failed.");
			Console.ForegroundColor = ConsoleColor.White;
			Thread.Sleep(500);
			Console.Clear();
			return false;                                                                 // ... and if not, return false.
		}
	}
}
