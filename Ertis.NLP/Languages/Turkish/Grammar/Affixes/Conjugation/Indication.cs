namespace Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation
{
	/// <summary>
	/// Belirtme (-ı, -i, -u, -ü)
	/// </summary>
	public class Indication : Suffix
	{
		protected override string[] Suffixes { get; } = new[]
		{
			"ı", "i", "u", "ü"
		};
	}
}