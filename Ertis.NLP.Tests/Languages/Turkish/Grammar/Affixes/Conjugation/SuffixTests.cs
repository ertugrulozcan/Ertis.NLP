using System.Collections.Generic;
using NUnit.Framework;

namespace Ertis.NLP.Tests.Languages.Turkish.Grammar.Affixes.Conjugation
{
	[TestFixture]
	public class SuffixTests
	{
		private Dictionary<string, string> DirectionSuffixSamples { get; set; }
		
		private Dictionary<string, string> PrecenceSuffixSamples { get; set; }
		
		private Dictionary<string, string> EquationSuffixSamples { get; set; }
		
		private Dictionary<string, string> FromSuffixSamples { get; set; }
		
		private Dictionary<string, string> IndicationSuffixSamples { get; set; }

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
				{ "kategori", "kategoriye" },
			};
			
			this.PrecenceSuffixSamples = new Dictionary<string, string>()
			{
				{ "ağaç", "ağaçta" },
				{ "çocuk", "çocukta" },
				{ "inek", "inekte" },
				{ "senet", "senette" },
				{ "dolap", "dolapta" },
				{ "ekmek", "ekmekte" },
				{ "kitap", "kitapta" },
				{ "tüfek", "tüfekte" },
				{ "diyalog", "diyalogda" },
				{ "ada", "adada" },
				{ "ev", "evde" },
				{ "kedi", "kedide" },
				{ "köpek", "köpekte" },
				{ "karartı", "karartıda" },
				{ "kategori", "kategoride" },
			};
			
			this.EquationSuffixSamples = new Dictionary<string, string>()
			{
				{ "ağaç", "ağaçça" },
				{ "çocuk", "çocukça" },
				{ "inek", "inekçe" },
				{ "senet", "senetçe" },
				{ "dolap", "dolapça" },
				{ "ekmek", "ekmekçe" },
				{ "kitap", "kitapça" },
				{ "tüfek", "tüfekçe" },
				{ "diyalog", "diyalogca" },
				{ "ada", "adaca" },
				{ "ev", "evce" },
				{ "kedi", "kedice" },
				{ "köpek", "köpekçe" },
				{ "karartı", "karartıca" },
				{ "kategori", "kategorice" },
			};
			
			this.FromSuffixSamples = new Dictionary<string, string>()
			{
				{ "ağaç", "ağaçtan" },
				{ "çocuk", "çocuktan" },
				{ "inek", "inekten" },
				{ "senet", "senetten" },
				{ "dolap", "dolaptan" },
				{ "ekmek", "ekmekten" },
				{ "kitap", "kitaptan" },
				{ "tüfek", "tüfekten" },
				{ "diyalog", "diyalogdan" },
				{ "ada", "adadan" },
				{ "ev", "evden" },
				{ "kedi", "kediden" },
				{ "köpek", "köpekten" },
				{ "karartı", "karartıdan" },
				{ "kategori", "kategoriden" },
			};
			
			this.IndicationSuffixSamples = new Dictionary<string, string>()
			{
				{ "ağaç", "ağacı" },
				{ "çocuk", "çocuğu" },
				{ "inek", "ineği" },
				{ "senet", "senedi" },
				{ "dolap", "dolabı" },
				{ "ekmek", "ekmeği" },
				{ "kitap", "kitabı" },
				{ "tüfek", "tüfeği" },
				{ "diyalog", "diyaloğu" },
				{ "ada", "adayı" },
				{ "ev", "evi" },
				{ "kedi", "kediyi" },
				{ "köpek", "köpeği" },
				{ "karartı", "karartıyı" },
				{ "kategori", "kategoriyi" },
			};
		}
		
		[Test]
		public void DirectionSuffixTest()
		{
			foreach (var pair in this.DirectionSuffixSamples)
			{
				string expected = pair.Value;
				string generated = Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation.Direction.Apply(pair.Key);
				Assert.AreEqual(expected, generated, $"{pair.Key} ==> {generated}");	
			}

			Assert.Pass();
		}

		[Test]
		public void PrecenceSuffixTest()
		{
			foreach (var pair in this.PrecenceSuffixSamples)
			{
				string expected = pair.Value;
				string generated = Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation.Precence.Apply(pair.Key);
				Assert.AreEqual(expected, generated, $"{pair.Key} ==> {generated}");	
			}

			Assert.Pass();
		}

		[Test]
		public void EquationSuffixTest()
		{
			foreach (var pair in this.EquationSuffixSamples)
			{
				string expected = pair.Value;
				string generated = Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation.Equation.Apply(pair.Key);
				Assert.AreEqual(expected, generated, $"{pair.Key} ==> {generated}");	
			}

			Assert.Pass();
		}

		[Test]
		public void FromSuffixTest()
		{
			foreach (var pair in this.FromSuffixSamples)
			{
				string expected = pair.Value;
				string generated = Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation.From.Apply(pair.Key);
				Assert.AreEqual(expected, generated, $"{pair.Key} ==> {generated}");	
			}

			Assert.Pass();
		}
		
		[Test]
		public void IndicationSuffixTest()
		{
			foreach (var pair in this.IndicationSuffixSamples)
			{
				string expected = pair.Value;
				string generated = Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation.Indication.Apply(pair.Key);
				Assert.AreEqual(expected, generated, $"{pair.Key} ==> {generated}");	
			}

			Assert.Pass();
		}
	}
}