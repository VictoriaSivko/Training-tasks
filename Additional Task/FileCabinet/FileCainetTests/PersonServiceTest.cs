using System;
using NUnit.Framework;
using FileCabinetLib;

namespace FileCainetTests
{
    [TestFixture]
    public class PersonServiceTest
    {
        [Test]
        public static void AddExistPersonTest()
        {
            //arrange
            Person person1 = new Person("name1", "surname1", DateTime.Now);
            Person person2 = new Person("name2", "surname2", DateTime.Now);
            PersonService people = new PersonService();

            //act
            people.Add(person1);
            people.Add(person1);
            people.Add(person2);

            //assert
            Assert.AreEqual(2, people.People.Count);
        }

        [Test]
        public static void RemovePersonTest()
        {
            //arrange
            Person person1 = new Person("name1", "surname1", DateTime.Now);
            Person person2 = new Person("name2", "surname2", DateTime.Now);
            PersonService people = new PersonService();
            people.Add(person1);
            people.Add(person2);

            //act
            people.Remove(2);

            //assert
            Assert.AreEqual(true, people[0].Equals(person1));
        }

        [Test]
        public static void EditPersonTest()
        {
            //arrange
            Person person1 = new Person("name1", "surname1", DateTime.Now);
            Person person2 = new Person("name2", "surname2", DateTime.Now);
            PersonService people = new PersonService();

            //act
            people.Add(person1);
            people.Edit(1, person2);

            //assert
            Assert.AreEqual(true, people[0].Equals(person2));
        }
    }
}
