using System;
using System.Linq;
using Ertis.NLP.Languages.Turkish.Extensions;

namespace Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation
{
	/// <summary>
	/// Yönelme (-a, -e)
	/// </summary>
	public class Direction : Suffix<Direction>
	{
		protected override string AppendToWord(string word)
		{
			if (string.IsNullOrEmpty(word))
				return word;

			char lastChar = word.Last();
			if (lastChar.IsVowel())
			{
				return $"{word}y{GetEA(lastChar)}";
			}

			var spells = SyllableSpeller.SpellOut(word);
			char lastVowelChar = spells.Last().Single(x => x.IsVowel());
			if (spells.Length == 1 || word.Length < 2)
				return $"{word}{GetEA(lastVowelChar)}";
			
			return $"{word.Substring(0, word.Length - 1)}{GetSoftConsonant(lastChar)}{GetEA(lastVowelChar)}";
		}
	}
}