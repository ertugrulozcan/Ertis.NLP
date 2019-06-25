using System.Collections.Generic;
using NUnit.Framework;

namespace Ertis.NLP.Tests.Languages.Turkish.Grammar
{
	[TestFixture]
	public class SyllableSpellerTest
	{
		private Dictionary<string, string[]> Samples { get; set; }
		
		[SetUp]
		public void Setup()
		{
			this.Samples = new Dictionary<string, string[]>()
			{
				{ "ağaç", new [] { "a", "ğaç" }},
				{ "çocuk", new [] { "ço", "cuk" }},
				{ "senet", new [] { "se", "net" }},
				{ "dolap", new [] { "do", "lap" }},
				{ "elemek", new [] { "e", "le", "mek" }},
				{ "diyalog", new [] { "di", "ya", "log" }},
				{ "bilgisayar", new [] { "bil", "gi", "sa", "yar" }},
				{ "müteahhit", new [] { "mü", "te", "ah", "hit" }},
				{ "borç", new [] { "borç" }},
				{ "kırık", new [] { "kı", "rık" }},
				{ "tespit", new [] { "tes", "pit" }},
				{ "Anıtkabir", new [] { "A", "nıt", "ka", "bir" }},
				{ "İlkokul", new [] { "İl", "ko", "kul" }},
				{ "Dut", new [] { "Dut" }},
				{ "Hortum", new [] { "Hor", "tum" }},
				{ "Amasya", new [] { "A", "mas", "ya" }},
				{ "Afyonkarahisar", new [] { "Af", "yon", "ka", "ra", "hi", "sar" }},
				{ "Reşadiye", new [] { "Re", "şa", "di", "ye" }},
				{ "Taahhüt", new [] { "Ta", "ah", "hüt" }},
				{ "Mutedil", new [] { "Mu", "te", "dil" }},
				{ "Mükafat", new [] { "Mü", "ka", "fat" }},
				{ "Melankoli", new [] { "Me", "lan", "ko", "li" }},
				{ "Müştemilat", new [] { "Müş", "te", "mi", "lat" }},
				{ "Muhafazakar", new [] { "Mu", "ha", "fa", "za", "kar" }},
				{ "Mutaassıp", new [] { "Mu", "ta", "as", "sıp" }},
				{ "Tevekkeli", new [] { "Te", "vek", "ke", "li" }},
				{ "Mütemadiyen", new [] { "Mü", "te", "ma", "di", "yen" }},
				{ "Çekoslavakyalılaştıramadıklarımızdanmışsınızcasına", new [] { "Çe", "kos", "la", "vak", "ya", "lı", "laş", "tı", "ra", "ma", "dık", "la", "rı", "mız", "dan", "mış", "sı", "nız", "ca", "sı", "na" }},
			};
		}

		[Test]
		public void SpellOutTest()
		{
			var test = Ertis.NLP.Languages.Turkish.Grammar.SyllableSpeller.SpellOut("Bilgisayar");
			
			Assert.Pass();
		}
		
		[Test]
		public void SpellOutTestWithSamples()
		{
			foreach (var pair in this.Samples)
			{
				string word = pair.Key;
				var syllables = Ertis.NLP.Languages.Turkish.Grammar.SyllableSpeller.SpellOut(word);
				
				Assert.IsNotNull(syllables, word);
				Assert.AreEqual(syllables.Length, pair.Value.Length, word);

				for (int i = 0; i < syllables.Length; i++)
				{
					Assert.AreEqual(syllables[i], pair.Value[i], word);
				}
			}
			
			Assert.Pass();
		}
	}
}