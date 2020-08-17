using System;

namespace MusicQuiz
{
	class Decor
	{
		public static void DrawBorder()
		{
			Console.Write("╔" + new String('═', Console.WindowWidth - 2) + "╗"); // Top
			for (int i = 0; i < Console.WindowHeight - 3; i++)
			{
				Console.Write("║");
				Console.CursorLeft += Console.WindowWidth - 2;                   // Middle
				Console.Write("║");
				Console.CursorLeft = 0;
			}
			Console.Write("╚" + new String('═', Console.WindowWidth - 2) + "╝"); // Bottom
			Console.CursorTop = 0;
			Console.CursorLeft = 0;
		}
		public static void WriteCentered(string input)
		{
			Console.CursorLeft = Console.WindowWidth / 2 - input.Length / 2;
			Console.CursorTop += 1;
			Console.Write(input);
		}
	}
}
