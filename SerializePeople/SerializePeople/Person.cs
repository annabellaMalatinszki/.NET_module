using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SerializePeople
{
    [Serializable]
    public class Person
    {
        public string name;
        public DateTime birthDate;
        public Gender gender;
        public int age;

        public Person(String name, DateTime birthDate, Gender gender)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.gender = gender;
            TimeSpan span = DateTime.Now - birthDate;
            this.age = (new DateTime(1, 1, 1) + span).Year - 1;
        }

        public override string ToString()
        {
            string StringToPrint = name + " was born on " + birthDate + ", so "+ name + " is " + age + " year old" + " and is a " + gender;
            return StringToPrint;
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
