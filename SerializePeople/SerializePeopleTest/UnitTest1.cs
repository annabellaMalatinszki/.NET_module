using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializePeople;

namespace PersonTest
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void PersonCreationTest()
        {
            Assert.IsNotNull(new Person("John Smith", new DateTime(2000, 01, 01), Gender.Male));
        }

        [TestMethod]
        public void PersonToStringTest()
        {
            Person person = new Person("John Smith", new DateTime(2000, 01, 01), Gender.Male);
            string result = person.ToString();
            string personString = "John Smith was born on 2000. 01. 01. 0:00:00, so John Smith is 17 year old and is a Male";
            Assert.AreEqual(personString, result);
        }
    }
}
