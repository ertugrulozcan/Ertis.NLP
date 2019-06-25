namespace Ertis.NLP.Languages.Turkish.Extensions
{
	public static class CharacterExtensions
	{
		/// <summary>
		/// Ünlü harf mi?
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static bool IsVowel(this char c)
		{
			return c == 'a' || c == 'A' ||
				   c == 'e' || c == 'E' ||
				   c == 'ı' || c == 'I' ||
				   c == 'i' || c == 'İ' ||
				   c == 'o' || c == 'O' ||
				   c == 'ö' || c == 'Ö' ||
				   c == 'u' || c == 'U' ||
				   c == 'ü' || c == 'Ü';
		}

		/// <summary>
		/// Ünsüz harf mi?
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static bool IsConsonant(this char c)
		{
			return !c.IsVowel();
		}
	}
}