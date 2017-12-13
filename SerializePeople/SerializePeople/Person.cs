using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace SerializePeople
{
    [Serializable]
    public class Person: ISerializable
    {
        public string name;

        [NonSerialized]
        public int age;
        public DateTime birthDate;
        public Gender gender;

        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        string fileName = "PersonFile.xml";

        public Person()
        { }

        public Person(String name, DateTime birthDate, Gender gender)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.gender = gender;
            TimeSpan span = DateTime.Now - birthDate;
            this.age = (new DateTime(1, 1, 1) + span).Year - 1;
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            name = (string)info.GetValue("props", typeof(string));
            birthDate = (DateTime)info.GetValue("props", typeof(DateTime));
            gender = (Gender)info.GetValue("props", typeof(Gender));
        }

        public override string ToString()
        {
            string StringToPrint = name + " was born on " + birthDate + ", so "+ name + " is " + age + " year old" + " and is a " + gender;
            return StringToPrint;
        }

        public void Serialize()
        {
            TextWriter writer = new StreamWriter(fileName, false);
            serializer.Serialize(writer, this);
            writer.Close();
        }

        public Person Deserialize()
        {
            Person person = new Person();
            TextReader reader = new StreamReader(fileName);
            person = (Person)serializer.Deserialize(reader);
            reader.Close();

            return person;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("props", name, typeof(string));
            info.AddValue("props", birthDate, typeof(DateTime));
            info.AddValue("props", gender, typeof(Gender));
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
