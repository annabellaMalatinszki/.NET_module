using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializePeople;

namespace PersonTest
{
    [TestClass]
    public class PersonTests
    {
        Person person = new Person("John Smith", new DateTime(2000, 01, 01), Gender.Male);
        string fileName = "PersonFile.xml";

        [TestMethod]
        public void PersonCreationTest()
        {
            Assert.IsNotNull(person);
        }

        [TestMethod]
        public void PersonToStringTest()
        {
            string result = person.ToString();
            string personString = "John Smith was born on 2000. 01. 01. 0:00:00, so John Smith is 17 year old and is a Male";
            Assert.AreEqual(personString, result);
        }

        [TestMethod]
        public void SerializationTest()
        {
            person.Serialize();
            Assert.IsTrue(File.Exists(fileName));
        }

        [TestMethod]
        public void DeserializationTest()
        {
            person.Serialize();
            Person deserializedPerson = person.Deserialize();
            Assert.AreEqual(person.ToString(), deserializedPerson.ToString());

        }
    }
}
