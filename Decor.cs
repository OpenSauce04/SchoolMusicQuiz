using System;

namespace SchoolCodingThingIDKwhatItsCalled
{
	class Decor
	{
		public static void DrawBorder()
		{
			Console.Write("╔" + new String('═', Console.WindowWidth - 2) + "╗");
			for (int i = 0; i < Console.WindowHeight - 3; i++)
			{
				Console.Write("║");
				Console.CursorLeft += Console.WindowWidth - 2;
				Console.Write("║");
				Console.CursorLeft = 0;
			}
			Console.Write("╚" + new String('═', Console.WindowWidth - 2) + "╝");
			Console.CursorTop = 0;
			Console.CursorLeft = 0;
		}
		public static void IndentedNL()
		{
			Console.CursorLeft = 1;
			Console.CursorTop += 1;
		}
	}
}
