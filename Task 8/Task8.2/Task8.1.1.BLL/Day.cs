using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8._1._1.BLL
{
    public static class Day
    {
        public static int GetDay(string s)
        {
            int day;
            int.TryParse(s, out day);
            return day;
        }
    }
}
