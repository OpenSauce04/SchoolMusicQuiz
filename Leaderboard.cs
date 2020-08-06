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
			for (int i = 0; i <= Scores.Length - 1; i++)
			{
				if (Scores[i] == null)
				{
					Scores[i] = new Score(inpName, inpScore);
					break;
				}
			}
		}
		public static void Display()
		{
			for (int i = 0; i < 5; i++)
			{
				if (Scores[i] != null)
				{
					Console.WriteLine((i + 1) + " " + Scores[i].name + ": " + Scores[i].score);
				}
			}
		}
		public static void Write()
		{
			File.WriteAllBytes("Leaderboard.bin", Serialize.ObjectToByteArray(Scores));
		}
		public static void Swap(int indexA, int indexB)
		{
			Score temp = Scores[indexA];
			Scores[indexA] = Scores[indexB];
			Scores[indexB] = temp;
		}
		public static void Sort()
		{
			bool Sorted = false;
			while (Sorted == false)
			{
				Sorted = true;
				for (int i = 0; i <= Scores.Length - 2; i++)
				{
					try
					{
						if (Scores[i].score < Scores[i + 1].score)
						{
							Swap(i, i + 1);
							Sorted = false;
						}
					}
					catch (NullReferenceException) { break; }
				}
			}
		}
		public static Byte[] Read(string path)
		{
			return File.ReadAllBytes(path);
		}
	}
}
