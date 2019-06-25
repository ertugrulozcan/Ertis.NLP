namespace Ertis.NLP.Languages.Turkish.Grammar.Pos
{
	/// <summary>
	/// Edat
	/// </summary>
	public class Preposition : BasePos
	{
		private Preposition(string text) : base(text)
		{
			
		}
		
		public static implicit operator Preposition(string text)
		{
			return new Preposition(text);
		}
	}
}