using System.Linq;
using Ertis.NLP.Languages.Turkish.Extensions;

namespace Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation
{
	/// <summary>
	/// Eşitlik (-ce, -ca, -çe, -ça)
	/// </summary>
	public class Equation : Suffix<Equation>
	{
		protected override string AppendToWord(string word)
		{
			if (string.IsNullOrEmpty(word))
				return word;

			var spells = SyllableSpeller.SpellOut(word);
			char lastVowelChar = spells.Last().Single(x => x.IsVowel());
			char connective = IsHardConsonant(word.Last()) ? 'ç' : 'c';
			return $"{word}{connective}{GetEA(lastVowelChar)}";
		}
	}
}