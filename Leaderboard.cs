using System;
using System.IO;

namespace SchoolCodingThingIDKwhatItsCalled
{
	[Serializable]
	class Score
	{
		public string name { get; }
		public int score { get; }
		public Score(string iName, int iScore)
		{
			name = iName;
			score = iScore;
		}
	}

	class Leaderboard
	{
		public static Score[] Scores = new Score[1000];
		public static void Add(string inpName, int inpScore)
		{
			for (int i = 0; i <= Scores.Length - 1; i++) // For all entries in this array...
			{
				if (Scores[i] == null)                   // If there is no score in this slot...
				{
					Scores[i] = new Score(inpName, inpScore);
					break;
				}
			}
		}
		public static void Display()
		{
			for (int i = 0; i < 5; i++) // Only display top 5 scores
			{
				if (Scores[i] != null) // If there is a score in this slot...
				{
					Console.WriteLine((i + 1) + " " + Scores[i].name + ": " + Scores[i].score);
				}
			}
		}
		public static void Write()
		{
			File.WriteAllBytes("Leaderboard.bin", Serialize.ObjectToByteArray(Scores)); // Convert leaderboard object to binary array and write to file
		}
		public static void Swap(int indexA, int indexB)
		{
			Score temp = Scores[indexA];
			Scores[indexA] = Scores[indexB];
			Scores[indexB] = temp;
		}
		public static void Sort()
		{
			bool Sorted = false; // To start off the loop.
			while (Sorted == false)
			{
				Sorted = true; // If the array has finished sorting, this will stay true for one whole while loop.
				for (int i = 0; i <= Scores.Length - 2; i++) // For all entries in array...
				{
					try
					{
						if (Scores[i].score < Scores[i + 1].score) // If this entry is smaller than the next entry down...
						{
							Swap(i, i + 1);                        // Swap them
							Sorted = false;                        // Mark that the array is still not sorted
						}
					}
					catch (NullReferenceException) { break; }
				}
			}
		}
		public static Byte[] Read(string path)
		{
			return File.ReadAllBytes(path); // Read binary data of file into a Byte array
		}
	}
}
