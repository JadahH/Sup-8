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











}