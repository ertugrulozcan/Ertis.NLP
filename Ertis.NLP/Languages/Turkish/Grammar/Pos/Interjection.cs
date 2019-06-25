namespace Ertis.NLP.Languages.Turkish.Grammar.Pos
{
	/// <summary>
	/// Ünlem
	/// </summary>
	public class Interjection : BasePos
	{
		private Interjection(string text) : base(text)
		{
			
		}
		
		public static implicit operator Interjection(string text)
		{
			return new Interjection(text);
		}
	}
}