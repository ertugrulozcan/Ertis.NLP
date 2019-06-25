namespace Ertis.NLP.Languages.Turkish.Grammar.Affixes.Conjugation
{
	/// <summary>
	/// Ayrılma (-den, -dan, -ten, -tan)
	/// </summary>
	public class From : Suffix
	{
		protected override string[] Suffixes { get; } = new[]
		{
			"den", "dan", "ten", "tan"
		};
	}
}