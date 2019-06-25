namespace Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation
{
	/// <summary>
	/// Bulunma (-de, -da)
	/// </summary>
	public class Precence : Suffix
	{
		protected override string[] Suffixes { get; } = new[]
		{
			"de", "da"
		};
	}
}