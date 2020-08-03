using System;
using System.IO;
using System.Security.Cryptography;

namespace SchoolCodingThingIDKwhatItsCalled
{
	public class Login
	{
		public static void Prompt()
		{
			Console.Write("Enter your username: ");
			if (File.Exists("userdb/"+SHA256.calc(Console.ReadLine()))) {
				Console.WriteLine("Works");
			}
			System.Threading.Thread.Sleep(2000);
		}
	}
}
