using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task3._3._2
{
    static class SuperString
    {
        delegate int Operation(string word);
        public static bool IsRussian(this string word)
        {
            Regex regex = new Regex(@"([а-яё]*)");
            MatchCollection matches = regex.Matches(word.ToLower());
            if(matches.Count-matches.Count(c=>c.Value.ToString()=="")==1)
			return true;
            return false;
        }
        public static bool IsEnglish(this string word)
        {
            Regex regex = new Regex(@"([a-z]*)");
            MatchCollection matches = regex.Matches(word.ToLower());
            if (matches.Count - matches.Count(c => c.Value.ToString() == "") == 1)
                return true;
            return false;
        }
        public static bool IsNumber(this string word)
        {
            Regex regex = new Regex(@"(-?)([0-9]*)");
            MatchCollection matches = regex.Matches(word.ToLower());
            if (matches.Count - matches.Count(c => c.Value.ToString() == "") == 1)
                return true;
            return false;
        }
        public static bool IsMix(this string word)
        {
            return !word.IsRussian()&&!word.IsEnglish()&&!word.IsNumber();
        }
    }
}
