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
			string[] outputArray = new string[15];
			string output;
			int index = 0;
			string[] words = input.Split(' ');
			foreach (string word in words) {
				string first = word.Substring(0, 1);
				outputArray[index] = first + new String('_', word.Length-1);
				index += 1;
			}
			output = string.Join(" ", outputArray);
			return output;
		}
	}
}
