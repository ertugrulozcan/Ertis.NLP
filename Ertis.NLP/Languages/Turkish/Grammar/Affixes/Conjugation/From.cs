using System.Linq;
using Ertis.NLP.Languages.Turkish.Extensions;

namespace Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation
{
	/// <summary>
	/// Ayrılma (-den, -dan, -ten, -tan)
	/// </summary>
	public class From : Suffix<From>
	{
		protected override string AppendToWord(string word)
		{
			if (string.IsNullOrEmpty(word))
				return word;

			var spells = SyllableSpeller.SpellOut(word);
			char lastVowelChar = spells.Last().Single(x => x.IsVowel());
			char connective = IsHardConsonant(word.Last()) ? 't' : 'd';
			return $"{word}{connective}{GetEA(lastVowelChar)}n";
		}
	}
}