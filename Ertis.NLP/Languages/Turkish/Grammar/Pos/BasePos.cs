using System;

namespace Ertis.NLP.Languages.Turkish.Grammar.Pos
{
	public abstract class BasePos
	{
		private string Text { get; set; }
		
		public static implicit operator string(BasePos basePos)
		{
			return basePos.Text;
		}

		protected BasePos(string text)
		{
			this.Text = text;
		}

		public override string ToString()
		{
			return this.Text;
		}
	}
}