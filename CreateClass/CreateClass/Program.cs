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
            /*
            Person person = new Person("Donald Trump", new DateTime(1949,01,01), Genders.Male);
            System.Console.WriteLine(person.ToString());

            Person employee1 = new Employee("Sarah Huckabee Sanders", new DateTime(1971.01.01), Genders.Female, 20000, "Spokesperson");
            employee1.room = new Room(23);
            System.Console.WriteLine(employee1.ToString());

            Person employee2 = new Employee("John Kelly", new DateTime(1951,01,01), Genders.Male, 30000, "General");
            employee2.room = new Room(21);
            System.Console.WriteLine(employee2.ToString());
            */

            Employee Kovacs = new Employee("Géza", new DateTime(1991,01,01), Genders.Male, 1000, "léhűtő");
            Kovacs.Room = new Room(111);
            Employee Kovacs2 = (Employee)Kovacs.Clone();
            Kovacs2.Room.Number = 112;
            Console.WriteLine("original: " + Kovacs.ToString());
            Console.WriteLine("clone: " + Kovacs2.ToString());

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    public class Person
    {
        public string name;
        public DateTime birthDate;
        public Genders gender;

        public Person(String name, DateTime birthDate, Genders gender)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.gender = gender;
        }

        public override string ToString()
        {
            string StringToPrint = name + " was born on " + birthDate + " and is a " + gender;
            return StringToPrint;
        } 
    }

    public class Employee : Person, ICloneable
    {
        private double salary;
        private string profession;
        public Room Room;

        public Employee(string name, DateTime birthDate, Genders gender, double salary, string profession)
            : base(name, birthDate, gender)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.gender = gender;
            this.salary = salary;
            this.profession = profession;
        }

        public override string ToString()
        {
            string StringToPrint = name + ", who is a " + gender + ", works as a " + profession + " for " + salary + "$ a month and was born on " + birthDate + ". Works in room " + Room.Number; 
            return StringToPrint;
        }

        public object Clone()
        {
            Employee newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.Room = new Room(Room.Number);
            return newEmployee;
        }

    }

    public class Room
    {
        public int Number;

        public Room(int roomNumber) 
        {
            this.Number = roomNumber;
        }
    }

    public enum Genders
    {
        Male,
        Female
    }
}
