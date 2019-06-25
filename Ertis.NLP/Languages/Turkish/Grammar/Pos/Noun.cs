namespace Ertis.NLP.Languages.Turkish.Grammar.Pos
{
	/// <summary>
	/// İsim
	/// </summary>
	public class Noun : BasePos
	{
		private Noun(string text) : base(text)
		{
			
		}
		
		public static implicit operator Noun(string text)
		{
			return new Noun(text);
		}
	}
}