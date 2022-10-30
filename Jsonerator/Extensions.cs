using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsonerator
{
    public static class Extensions
    {
        public static string TrimAfter(this string str, char casval)
        {
            int index = str.IndexOf(casval);
            if (index == -1)
                return str;
            else
                return str.Substring(0, index);
        }
    }
}
