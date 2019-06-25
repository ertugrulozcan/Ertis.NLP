using System;
using System.Linq;
using System.Runtime.CompilerServices;

/*
	Ekler
	- Yapım Ekleri
		- İsimden isim
		- İsimden fiil
			- Fiilden isim
			- Fiilden fiil
		- Çekim Ekleri
			- İsim Çekim Ekleri
				- Çoğul eki
				- Hal ekleri
					- Belirtme eki (-ı, -i, -u, -ü)
					- Yönelme eki (-a, -e)
					- Bulunma eki (-de, -da)
					- Ayrılma eki (-den, -dan, -ten, -tan)
				- İlgi (Tamlama) eki (-ın / -in / -un / -ün)
				- İyelik (Aidiyet) eki (-m, -n, -i, -miz, -niz, -leri)
				- Eşitlik eki (-ca / -ce / -ça / -çe)
			- Fiil Çekim Ekleri
				- Kip ekleri
					- Haber kipleri
					- Dilek kipleri
				- Şahıs ekleri
*/

namespace Ertis.NLP.Languages.Turkish.Grammar.Affixes
{
	/// <summary>
	/// Suffix
	/// </summary>
	/// <typeparam name="T">Subtype</typeparam>
	public abstract class Suffix<T> where T : Suffix<T>, new()
	{
		private static T _self = null;

		protected static T Current
		{
			get
			{
				if (_self == null)
					_self = CreateInstance();

				return _self;
			}
		}
		
		private static T CreateInstance()
		{
			T newInstance = new T();
			return newInstance;
		}

		protected abstract string AppendToWord(string word);

		public static string Apply(string word)
		{
			return Current.AppendToWord(word);
		}
		
		protected static char GetEA(char theLastVowelChar)
		{
			theLastVowelChar = theLastVowelChar.ToString().ToLower().First();
			
			char suffix = Char.MinValue;
			switch (theLastVowelChar)
			{
				case 'a':
				case 'ı':
				case 'o':
				case 'u':
					suffix = 'a';
					break;
				case 'e':
				case 'i':
				case 'ö':
				case 'ü':
					suffix = 'e';
					break;
			}

			return suffix;
		}

		protected static bool IsHardConsonant(char c)
		{
			c = c.ToString().ToLower().First();
			return c == 'p' || c == 'ç' || c == 't' || c == 'k';
		}
		
		protected static char GetSoftConsonant(char theLastConsonantChar)
		{
			theLastConsonantChar = theLastConsonantChar.ToString().ToLower().First();
			switch (theLastConsonantChar)
			{
				case 'p':
					return 'b';
				case 'ç':
					return 'c';
				case 't':
					return 'd';
				case 'k':
				case 'g':
					return 'ğ';
			}
			
			return theLastConsonantChar;
		}
	}
}