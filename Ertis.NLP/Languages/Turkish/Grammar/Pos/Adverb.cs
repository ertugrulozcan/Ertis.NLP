namespace Ertis.NLP.Languages.Turkish.Grammar.Pos
{
	/// <summary>
	/// Zarf
	/// </summary>
	public class Adverb : BasePos
	{
		private Adverb(string text) : base(text)
		{
			
		}
		
		public static implicit operator Adverb(string text)
		{
			return new Adverb(text);
		}
	}
}