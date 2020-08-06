using System;

namespace SchoolCodingThingIDKwhatItsCalled
{
	class BlankText
	{
		public static string[] Parse(string input)
		{
			string[] outputArrayTop = new string[15]; // Create array with space for 15 words.
			string[] outputArrayBottom = new string[15];
			int index = 0; // Variable used to track how many words have been iterated through.
			string[] words = input.Split(' '); // Splits the song title (input) into individual words.
			foreach (string word in words)
			{
				string first = word.Substring(0, 1); // Stored first letter of current word as the variable first
				outputArrayBottom[index] = " " + new String('¯', word.Length - 1); // Generates the blanked out word, and stores it in the
				outputArrayTop[index] = first + new String(' ', word.Length - 1);
				// output array to be later turned into a single string
				index += 1;
			}
			string[] output = new string[2] { string.Join(" ", outputArrayTop), string.Join(" ", outputArrayBottom) }; // Combine the generated arrays into two strings
			output[0] = output[0].Substring(0, input.Length);
			output[1] = output[1].Substring(0, input.Length);
			return output;                                                                                             // ...and return that string.
		}
	}
}
