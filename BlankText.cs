using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCodingThingIDKwhatItsCalled
{
	class BlankText
	{
		public static string Parse(string input)
		{
			string[] outputArray = new string[15]; // Create array with space for 15 words.
			string output;
			int index = 0; // Variable used to track how many words have been iterated through.
			string[] words = input.Split(' '); // Splits the song title (input) into individual words.
			foreach (string word in words) {
				string first = word.Substring(0, 1); // Stored first letter of current word as the variable first
				outputArray[index] = first + new String('_', word.Length-1); // Generates the blanked out word, and stores it in the
				                                                             // output array to be later turned into a single string
				index += 1;
			}
			output = string.Join(" ", outputArray); // Combine the generated array into a single string
			return output;                          // ...and return that string.
		}
	}
}
