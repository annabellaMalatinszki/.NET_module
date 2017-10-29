using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("John Miller", 19890101, Genders.Male);
            System.Console.WriteLine(person.ToString());

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    public class Person
    {
        private string Name;
        private double BirthDate;
        private Genders Gender;

        public Person(String Name, double BirthDate, Genders Gender)
        {
            this.Name = Name;
            this.BirthDate = BirthDate;
            this.Gender = Gender;
        }

        public override string ToString()
        {
            string StringToPrint = Name + " was born on " + BirthDate + " and is a " + Gender;
            return StringToPrint;
        }
    }

    public enum Genders
    {
        Male,
        Female
    }
}
