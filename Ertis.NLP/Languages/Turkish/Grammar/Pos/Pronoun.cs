namespace Ertis.NLP.Languages.Turkish.Grammar.Pos
{
	/// <summary>
	/// Zamir
	/// </summary>
	public class Pronoun : BasePos
	{
		private Pronoun(string text) : base(text)
		{
			
		}
		
		public static implicit operator Pronoun(string text)
		{
			return new Pronoun(text);
		}
	}
}