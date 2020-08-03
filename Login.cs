using System;
using System.IO;
using System.Threading;

namespace SchoolCodingThingIDKwhatItsCalled
{
	public class Login
	{
		public static bool Prompt()
		{
			Console.Write("Enter your username: ");
			string user = SHA256.calc(Console.ReadLine()); // Take user input for username and store SHA256 hash of input
			Console.Write("Enter you password: ");
			if (File.Exists("userdb/" + user)
				&& File.ReadAllText("userdb/" + user) == SHA256.calc(Console.ReadLine())) // Checks to see if the user's entry in the user database exists,
																						  // and if it does checks to see if the user's password hash matches
																						  // with the user's input.
			{
				return true;															  // If it does, return true
			}
			Console.WriteLine("Login failed.");
			Thread.Sleep(1500);
			Console.Clear();
			return false;																  // ... and if not, return false.
		}
	}
}
