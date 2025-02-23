using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLinq;

namespace Rand.Tests;

public class PeopleRepositoryTests
{
     [TestInitialize]
        public void Setup()
        {
            repository = new PeopleRepository();
            repository.InitializeData();
        }


        // --- Test for InitializeData ---
        [TestMethod]
        public void TestInitializeData_CreatesOneMillionEntries()
        {
            // Validate that the first and last person have the expected Ids.
            var firstPerson = repository.GetPersonById(1);
            var lastPerson = repository.GetPersonById(1000000);

            Assert.IsNotNull(firstPerson, "First person should not be null.");
            Assert.IsNotNull(lastPerson, "Last person should not be null.");
            Assert.AreEqual(1, firstPerson.Id, "First person Id should be 1.");
            Assert.AreEqual(1000000, lastPerson.Id, "Last person Id should be 1,000,000.");
        }


        // --- Test for GetPeopleBornAfter ---
        [TestMethod]
        public void TestGetPeopleBornAfter_ReturnsOnlyValidEntries()
        {
            DateTime testDate = new DateTime(2000, 1, 1);
            var people = repository.GetPeopleBornAfter(testDate);
            Assert.IsTrue(people.All(p => p.Birthday > testDate), "All returned birthdays should be after January 1, 2000.");
        }


        // --- Test for GetPeopleByName ---
        [TestMethod]
        public void TestGetPeopleByName_ReturnsCorrectPerson()
        {
            // Since names are generated as "Person{Id}", test with a known name.
            string name = "Person500000";
            var people = repository.GetPeopleByName(name);
            Assert.IsTrue(people.All(p => p.Name == name), "Returned people should all have the name Person500000.");
        }


        // --- Test for GetPersonById ---
        [TestMethod]
        public void TestGetPersonById_ValidId_ReturnsPerson()
        {
            int id = 500000;
            var person = repository.GetPersonById(id);
            Assert.IsNotNull(person, "Person with a valid Id should not be null.");
            Assert.AreEqual(id, person.Id, "The returned person's Id should match the requested Id.");
        }

     [TestMethod]
        public void TestGetPersonById_InvalidId_ReturnsNull()
        {
            int id = 1000001; // Out of range, since we only have 1,000,000 people.
            var person = repository.GetPersonById(id);
            Assert.IsNull(person, "A person with an invalid Id should return null.");
        }

//

}