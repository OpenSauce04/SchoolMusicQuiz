using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace SchoolCodingThingIDKwhatItsCalled
{
	class Program
	{
		// From https://social.msdn.microsoft.com/Forums/vstudio/en-US/1aa43c6c-71b9-42d4-aa00-60058a85f0eb/c-console-window-disable-resize
		// Used to disable resizing of console window
		// BEGIN
		private const int MF_BYCOMMAND = 0x00000000;
		public const int SC_CLOSE = 0xF060;
		public const int SC_MINIMIZE = 0xF020;
		public const int SC_MAXIMIZE = 0xF030;
		public const int SC_SIZE = 0xF000;

		[DllImport("user32.dll")]
		public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

		[DllImport("user32.dll")]
		private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		[DllImport("kernel32.dll", ExactSpelling = true)]
		private static extern IntPtr GetConsoleWindow();

		static void Main(string[] args)
		{
			IntPtr handle = GetConsoleWindow();
			IntPtr sysMenu = GetSystemMenu(handle, false);

			if (handle != IntPtr.Zero)
			{
				DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND); // Disable maximize button
				DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);     // Disable screen resize
			}
			// END
			Console.WindowWidth = 50;
			Console.WindowHeight = 16;
			Console.BufferHeight = 16;
			Console.BufferWidth = 50;
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			bool LoggedIn = false;
			Game.Init();
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
