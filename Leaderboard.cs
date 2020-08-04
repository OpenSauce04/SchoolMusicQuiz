using System;

namespace SchoolCodingThingIDKwhatItsCalled
{
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
			for (int i = 0; i <= Scores.Length - 1; i++)
			{
				if (Scores[i] != null)
				{
					Console.WriteLine((i+1) + " " + Scores[i].name + ": " + Scores[i].score);
				}
			}
		}
	}
}
