using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DictionaryCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("0", "zero");
            hashTable.Add("1", "one");
            hashTable.Add("2", "two");
            hashTable.Add("3", "three");
            hashTable.Add("4", "four");
            hashTable.Add("5", "five");
            hashTable.Add("6", "six");
            hashTable.Add("7", "seven");
            hashTable.Add("8", "eight");
            hashTable.Add("9", "nine");

            string seriesOfNumbers = "012-345-666-789";

            foreach (char c in seriesOfNumbers)
            {
                string stringNumber = c.ToString();
                if (hashTable.ContainsKey(stringNumber))
                {
                    Console.WriteLine(hashTable[stringNumber]);
                }
            }

            Console.ReadKey();
        }
    }
}
