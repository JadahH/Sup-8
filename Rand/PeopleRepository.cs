using System;
using System.Collections.Generic;
using System.Linq;

namespace Rand;

public class PeopleRepository
    {
        private Person[] data;

        /// <summary>
        /// Initializes the 'data' field with 1,000,000 unique Person entries.
        /// Each Person has a unique Id, a generated Name, and a random Birthday.
        /// </summary>
        public void InitializeData()
        {
            // Using Enumerable.Range to generate unique Ids from 1 to 1,000,000.
            data = Enumerable.Range(1, 1000000)
                .Select(i => new Person
                {
                    Id = i,
                    Name = $"Person{i}",
                    Birthday = GenerateRandomBirthday()
                }).ToArray();
        }


        /// <summary>
        /// Returns all people born after the specified date.
        /// </summary>
        /// <param name="date">The date to compare against.</param>
        /// <returns>An IEnumerable of Person objects born after the given date.</returns>
        public IEnumerable<Person> GetPeopleBornAfter(DateTime date)
        {
            return data.Where(person => person.Birthday > date);
        }

        /// <summary>
        /// Returns all people with the specified name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>An IEnumerable of Person objects whose Name matches exactly.</returns>
        public IEnumerable<Person> GetPeopleByName(string name)
        {
            return data.Where(person => person.Name.Equals(name, StringComparison.Ordinal));
        }

        /// <summary>
        /// Returns the person with the specified Id if they exist; otherwise, returns null.
        /// </summary>
        /// <param name="id">The unique identifier of the Person.</param>
        /// <returns>A Person object matching the Id, or null if not found.</returns>
        public Person GetPersonById(int id)
        {
            return data.FirstOrDefault(person => person.Id == id);
        }
     /// <summary>
        /// Helper method to generate a random birthday between the years 1950 and 2010.
        /// </summary>
        /// <returns>A DateTime representing a random birthday.</returns>
        private DateTime GenerateRandomBirthday()
        {
            Random rand = new Random();
            int year = rand.Next(1950, 2011); // 1950 to 2010 inclusive
            int month = rand.Next(1, 13);       // Months 1 to 12
            int day = rand.Next(1, 28);         // Days 1 to 27 (simpler to avoid invalid dates)
            return new DateTime(year, month, day);
        }
    

    }