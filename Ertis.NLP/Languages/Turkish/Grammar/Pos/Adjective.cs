namespace Ertis.NLP.Languages.Turkish.Grammar.Pos
{
	/// <summary>
	/// Sıfat
	/// </summary>
	public class Adjective : BasePos
	{
		private Adjective(string text) : base(text)
		{
			
		}
		
		public static implicit operator Adjective(string text)
		{
			return new Adjective(text);
		}
	}
}