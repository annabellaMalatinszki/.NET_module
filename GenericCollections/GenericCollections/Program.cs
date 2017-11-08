using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(36, "Hungary");
            dictionary.Add(44, "United Kingdom");
            dictionary.Add(49, "Germany");
            dictionary.Add(670, "East Timor");
            //dictionary.Add("000", "NoSuchCountry");

            Console.WriteLine("The country code for {0} is 670", dictionary[670]);

            foreach (KeyValuePair<int, string> kvp in dictionary)
            {
                Console.WriteLine("Code: {0}  Country: {1}", kvp.Key, kvp.Value);
            }
            Console.ReadKey();
                 
        }
    }
}
