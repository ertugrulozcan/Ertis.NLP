using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using Ertis.NLP.Languages.Turkish.Extensions;

namespace Ertis.NLP.Languages.Turkish.Grammar
{
	public static class SyllableSpeller
	{
		private const char SEPERATOR = '-';
		private static string[] SyllablePatterns =
		{
			"A", "ZA", "ZAZ", "AZ", "ZAZZ", "ZZAZ"
		};
		
		/// <summary>
		/// Kelimeyi hecelerine ayırır
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public static string[] SpellOut(string word)
		{
			if (string.IsNullOrEmpty(word))
			{
				throw new ArgumentException("The word can not null or empty for spelling out!");
			}

			var words = word.Split(" ");
			if (words.Length != 1)
			{
				throw new ArgumentException("The argument must be single word for spelling out!");
			}

			word = word.Trim();

			try
			{
				var syllableCodes = GenerateSyllableCodes(word);
				var combinations = SyllableCombination.GenerateSpellOutStrings(syllableCodes);
				var test = CleanUpCombinations(combinations);

				return SpellOut(word, test);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}

		private static string[] SpellOut(string word, string spellOutFormat)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int c = 0;
			for (int i = 0; i < spellOutFormat.Length; i++)
			{
				if (spellOutFormat[i] == 'A')
				{
					if (!word[c].IsVowel())
					{
						throw new ArgumentException("The word and format is incompatible!");
					}

					stringBuilder.Append(word[c]);
					c++;
				}
				else if (spellOutFormat[i] == 'Z')
				{
					if (!word[c].IsConsonant())
					{
						throw new ArgumentException("The word and format is incompatible!");
					}

					stringBuilder.Append(word[c]);
					c++;
				}
				else if (spellOutFormat[i] == SEPERATOR)
				{
					stringBuilder.Append(SEPERATOR);
				}
				else
				{
					throw new ArgumentException("Unknown spell out format string!");
				}
			}
			
			string spelledOutString = stringBuilder.ToString();
			Console.WriteLine(spelledOutString);

			return spelledOutString.Split(SEPERATOR);
		}

		private static string CleanUpCombinations(string[] combinations)
		{
			int maxZaCount = 0;
			int i = 0;
			int index = -1;
			foreach (var combination in combinations)
			{
				var syllables = combination.Split(SEPERATOR);
				
				// Rule 1 : Z ile biten bir heceden sonra A ile baslayan bir hece gelemez
				bool isvalidCombination = true;
				for (int j = 0; j < syllables.Length - 1; j++)
				{
					if (syllables[j].Last() == 'Z' && syllables[j + 1].First() == 'A')
					{
						isvalidCombination = false;
					}
				}
				
				if (!isvalidCombination)
					continue;

				// Rule 2 : Kombinasyonlar icerisinde ZA hece tipinin cogunlukta oldugu ornege oncelik ver
				int zaCount = syllables.Count(x => x == "ZA");
				maxZaCount = Math.Max(zaCount, maxZaCount);
				if (maxZaCount == zaCount)
					index = i;
				i++;
			}

			return combinations[index];
		}
		
		private static string GenerateSyllableCodes(string word)
		{
			StringBuilder syllableCodes = new StringBuilder();
			foreach (var c in word)
			{
				if (c.IsVowel())
				{
					syllableCodes.Append('A');
				}
				else
				{
					syllableCodes.Append('Z');
				}
			}

			return syllableCodes.ToString();
		}

		private static string[] FirstSyllableCodes(string syllableCodes)
		{
			List<string> results = new List<string>();
			
			string stash = string.Empty;
			foreach (var c in syllableCodes)
			{
				stash += c;
				if (SyllablePatterns.Contains(stash))
				{
					results.Add(stash);
				}
			}

			return results.ToArray();
		}

		public class SyllableCombination
		{
			public string Key { get; private set; }
			
			public string BackString { get; private set; }
			
			public List<SyllableCombination> SubCombinations { get; private set; }
			
			public SyllableCombination(string key, string backString)
			{
				this.Key = key;
				this.BackString = backString;
				this.SubCombinations = GetCombinations(backString);
			}

			public override string ToString()
			{
				return $"{this.Key} - {this.BackString}";
			}

			private static List<SyllableCombination> GetCombinations(string word)
			{
				var combinations = new List<SyllableCombination>();
				
				var probablyCombinationKeys = FirstSyllableCodes(word);
				foreach (var pkey in probablyCombinationKeys)
				{
					combinations.Add(new SyllableCombination(pkey, word.Substring(pkey.Length)));
				}

				return combinations;
			}

			public static string[] GenerateSpellOutStrings(string word)
			{
				int syllableCount = word.Count(x => x.IsVowel());
				var combinations = GetCombinations(word);
				var spellouts = GenerateSpellOutStrings(combinations);
				
				// Rule 1
				spellouts = spellouts.Where(x => x.Split(SEPERATOR).Length == syllableCount).ToArray();

				// Rule 2
				spellouts = spellouts.Where(IsValidForZAZZ).ToArray();
				
				// Rule 3
				spellouts = spellouts.Where(IsValidForZZAZ).ToArray();
				
				return spellouts;
			}
			
			private static string[] GenerateSpellOutStrings(IList<SyllableCombination> combinations)
			{
				List<string> spellOutCombinations = new List<string>();
				foreach (var combination in combinations)
				{
					var subCombinations = GenerateSpellOutStrings(combination.SubCombinations);
					if (subCombinations != null && subCombinations.Any())
						spellOutCombinations.AddRange(subCombinations.Select(x => $"{combination.Key}{SEPERATOR}{x}").ToArray());
					else if (string.IsNullOrEmpty(combination.BackString))
						spellOutCombinations.Add(combination.Key);
					else
						spellOutCombinations.Add($"{combination.Key}{SEPERATOR}{combination.BackString}");
				}

				return spellOutCombinations.ToArray();
			}

			private static bool IsValidForZAZZ(string spellOutString)
			{
				var syllableArray = spellOutString.Split(SEPERATOR);
				return !(syllableArray.Contains("ZAZZ") && syllableArray.Length > 1);
			}
			
			private static bool IsValidForZZAZ(string spellOutString)
			{
				var syllableArray = spellOutString.Split(SEPERATOR);
				return !(syllableArray.Contains("ZZAZ") && syllableArray.Length > 1);
			}
		}
	}
}