using System;
using System.IO;
using System.Security.Cryptography;

namespace SchoolCodingThingIDKwhatItsCalled
{
	public class Login
	{
		public static bool Prompt()
		{
			Console.Write("Enter your username: ");
			if (File.Exists("userdb/"+SHA256.calc(Console.ReadLine()))) {
				return true;
			}
			return false;
		}
	}
}
