namespace Ertis.NLP.Languages.Turkish.Grammar.Pos
{
	/// <summary>
	/// Fiil
	/// </summary>
	public class Verb : BasePos
	{
		private Verb(string text) : base(text)
		{
			
		}
		
		public static implicit operator Verb(string text)
		{
			return new Verb(text);
		}
	}
}