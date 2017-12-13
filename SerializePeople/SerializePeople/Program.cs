using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Donald Trump", new DateTime(1946, 01, 01), Gender.Male);
            Console.WriteLine(person.ToString());

            person.Serialize();

            person.Deserialize();

            Console.WriteLine(person.ToString());

            Console.ReadKey();

        }
    }
}
