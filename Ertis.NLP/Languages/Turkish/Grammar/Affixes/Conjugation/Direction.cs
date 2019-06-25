using System;
using System.Linq;
using Ertis.NLP.Languages.Turkish.Extensions;

namespace Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation
{
	/// <summary>
	/// Yönelme (-a, -e)
	/// </summary>
	public class Direction : Suffix
	{
		protected override string[] Suffixes { get; } = 
		{
			"e", "a", 
		};

		public static string Apply(string word)
		{
			if (string.IsNullOrEmpty(word))
				return word;

			char lastChar = word.Last();
			if (lastChar.IsVowel())
			{
				return $"{word}y{GetSuffix(lastChar)}";
			}

			var spells = SyllableSpeller.SpellOut(word);
			char lastVowelChar = spells.Last().Single(x => x.IsVowel());
			if (spells.Length == 1 || word.Length < 2)
				return $"{word}{GetSuffix(lastVowelChar)}";
			
			return $"{word.Substring(0, word.Length - 1)}{GetSoftConsonant(lastChar)}{GetSuffix(lastVowelChar)}";
		}

		private static char GetSuffix(char theLastVowelChar)
		{
			char suffix = Char.MinValue;
			switch (theLastVowelChar)
			{
				case 'a':
				case 'ı':
				case 'o':
				case 'u':
					suffix = 'a';
					break;
				case 'e':
				case 'i':
				case 'ö':
				case 'ü':
					suffix = 'e';
					break;
			}

			return suffix;
		}

		private static char GetSoftConsonant(char theLastConsonantChar)
		{
			switch (theLastConsonantChar)
			{
				case 'p':
					return 'b';
				case 'ç':
					return 'c';
				case 't':
					return 'd';
				case 'k':
				case 'g':
					return 'ğ';
			}
			
			return theLastConsonantChar;
		}
		
		/*
		 * pazar --> pazara
		 * direk --> direğe
		 * kırık --> kırığa
		 * tekir --> tekire
		 * doktor --> doktora
		 * donör --> donöre
		 * uzun --> uzuna
		 * üzüm --> üzüme
		 */
	}
}