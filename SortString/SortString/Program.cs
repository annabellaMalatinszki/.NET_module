using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "'Donald Trump is a waddling outhouse' is a quote from Bill Maher";
            string[] words = str.Split(' ');

            Array.Sort(words);

            String s = string.Join(" ", words);
            Console.WriteLine(s);

            Console.ReadKey();
        }
    }
}
