namespace Ertis.NLP.Languages.Turkish.Grammar.Pos
{
	/// <summary>
	/// Bağlaç
	/// </summary>
	public class Conjunction : BasePos
	{
		private Conjunction(string text) : base(text)
		{
			
		}
		
		public static implicit operator Conjunction(string text)
		{
			return new Conjunction(text);
		}
	}
}