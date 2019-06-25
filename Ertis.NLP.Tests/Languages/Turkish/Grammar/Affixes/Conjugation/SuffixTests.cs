using System.Collections.Generic;
using NUnit.Framework;

namespace Ertis.NLP.Tests.Languages.Turkish.Grammar.Affixes.Conjugation
{
	[TestFixture]
	public class SuffixTests
	{
		private Dictionary<string, string> DirectionSuffixSamples { get; set; }
		
		[SetUp]
		public void Setup()
		{
			this.DirectionSuffixSamples = new Dictionary<string, string>()
			{
				{ "ağaç", "ağaca" },
				{ "çocuk", "çocuğa" },
				{ "inek", "ineğe" },
				{ "senet", "senede" },
				{ "dolap", "dolaba" },
				{ "ekmek", "ekmeğe" },
				{ "kitap", "kitaba" },
				{ "tüfek", "tüfeğe" },
				{ "diyalog", "diyaloğa" },
				{ "ada", "adaya" },
				{ "ev", "eve" },
				{ "kedi", "kediye" },
				{ "köpek", "köpeğe" },
				{ "karartı", "karartıya" },
			};
		}

		[Test]
		public void DirectionSuffixTest()
		{
			foreach (var pair in this.DirectionSuffixSamples)
			{
				string expected = pair.Value;
				string generated = Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation.Direction.Apply(pair.Key);
				Assert.AreEqual(generated, expected, $"{pair.Key} ==> {generated}");	
			}

			Assert.Pass();
		}
	}
}