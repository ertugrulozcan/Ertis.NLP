using System;
using System.Linq;
using Ertis.NLP.Languages.Turkish.Extensions;

namespace Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation
{
	/// <summary>
	/// Belirtme (-ı, -i, -u, -ü)
	/// </summary>
	public class Indication : Suffix<Indication>
	{
		protected override string AppendToWord(string word)
		{
			if (string.IsNullOrEmpty(word))
				return word;

			char lastChar = word.Last();
			if (lastChar.IsVowel())
			{
				return $"{word}y{GetIndicator(lastChar)}";
			}

			var spells = SyllableSpeller.SpellOut(word);
			char lastVowelChar = spells.Last().Single(x => x.IsVowel());
			if (spells.Length == 1 || word.Length < 2)
				return $"{word}{GetIndicator(lastVowelChar)}";
			
			return $"{word.Substring(0, word.Length - 1)}{GetSoftConsonant(lastChar)}{GetIndicator(lastVowelChar)}";
		}
		
		protected static char GetIndicator(char theLastVowelChar)
		{
			theLastVowelChar = theLastVowelChar.ToString().ToLower().First();
			
			char suffix = Char.MinValue;
			switch (theLastVowelChar)
			{
				case 'a':
				case 'ı':
					suffix = 'ı';
					break;
				case 'o':
				case 'u':
					suffix = 'u';
					break;
				case 'e':
				case 'i':
					suffix = 'i';
					break;
				case 'ö':
				case 'ü':
					suffix = 'ü';
					break;
			}

			return suffix;
		}
	}
}