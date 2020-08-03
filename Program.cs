using System;

namespace SchoolCodingThingIDKwhatItsCalled
{
	class Program
	{
		static void Main(string[] args)
		{
			if (Login.Prompt()) { Console.WriteLine("Works :D"); }
			System.Threading.Thread.Sleep(2000);
		}
	}
}
