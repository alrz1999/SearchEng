using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class Splitter
    {
        public static string[] SEPARATOR_REGEX = new string[] { "[\\s]+" };
        public static char[] SEPARATOR = { ',', '\"', ' ', '(', ')', '/', '$', '-', ':', '#', '.' , '\\', };

        public static string[] Split(string str)
        {
            return str.Split(SEPARATOR);
        }
    }
}
