using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;



namespace LookupCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDictionary listDictionary = new ListDictionary(StringComparer.InvariantCultureIgnoreCase);
            listDictionary.Add("Estados Unidos", "United States");
            listDictionary.Add("Canadá", "Canada");
            listDictionary.Add("España", "Spain");

            Console.WriteLine(listDictionary["españa"]);
            Console.WriteLine(listDictionary["canaDÁ"]);

            Console.ReadKey();
        }
    }
}
