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
            Person person = new Person("Donald Trump", 19490101, Genders.Male);
            System.Console.WriteLine(person.ToString());

            Room room1 = new Room(23);
            Person employee1 = new Employee("Sarah Huckabee Sanders", 19710101, Genders.Female, 20000, "Spokesperson", room1);
            System.Console.WriteLine(employee1.ToString());

            Room room2 = new Room(21);
            Person employee2 = new Employee("John Kelly", 19510101, Genders.Male, 30000, "General", room2);
            System.Console.WriteLine(employee2.ToString());

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    public class Person
    {
        public string name;
        public int birthDate;
        public Genders gender;

        public Person(String name, int birthDate, Genders gender)
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

    public class Employee : Person
    {
        private double salary;
        private string profession;
        private Room room;

        public Employee(string name, int birthDate, Genders gender, double salary, string profession, Room room)
            : base(name, birthDate, gender)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.gender = gender;
            this.salary = salary;
            this.profession = profession;
            this.room = room;
        }

        public override string ToString()
        {
            string StringToPrint = name + ", who is a " + gender + ", works as a " + profession + " for " + salary + "$ a month and was born on " + birthDate + ". Works in room " + room.GetRoomNumber(); 
            return StringToPrint;
        }
    }

    public class Room
    {
        private int roomNumber;

        public Room(int roomNumber) 
        {
            this.roomNumber = roomNumber;
        }

        public int GetRoomNumber() 
        {
            return roomNumber;
        }
    }

    public enum Genders
    {
        Male,
        Female
    }
}
