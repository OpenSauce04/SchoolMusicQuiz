// FROM https://stackoverflow.com/a/14709940 //
using System.Security.Cryptography;
using System.Text;

namespace MusicQuiz
{
	public class SHA256
	{
		public static string calc(string randomString)
		{
			var crypt = new SHA256Managed();
			var hash = new StringBuilder();
			byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
			foreach (byte theByte in crypto)
			{
				hash.Append(theByte.ToString("x2"));
			}
			return hash.ToString();
		}
	}
}
