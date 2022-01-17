using System;
using System.Linq;

namespace Utility
{
    //statische Klasse kann nicht instanziiert werden, d.h. es können keine Objekte davon erzeugt werden, es gibt nur Methoden.
    public static class Stringutils
    {
        public static string Reverse (string s)
        {
            return new string(s.Reverse().ToArray());
        } 

        public static bool IsPalindrome(string s)
        {
            return s.Equals(Reverse(s), StringComparison.CurrentCultureIgnoreCase);
        }

        public static int CountVocals (string s)
        {
            int anzahl = 0;
            for (int i = 0;i<s.Length; i++)
            {
                if ( s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')
                {
                    anzahl += 1;
                }
            }
            return anzahl;
        }

        //public static string ReplaceUmlaute(string s)
        //{
            
        //}
    }
}

