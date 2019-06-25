namespace Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation
{
	/// <summary>
	/// Eşitlik (-ce, -ca, -çe, -ça)
	/// </summary>
	public class Equation : Suffix
	{
		protected override string[] Suffixes { get; } = new[]
		{
			"ce", "ca", "çe", "ça"
		};
	}
}