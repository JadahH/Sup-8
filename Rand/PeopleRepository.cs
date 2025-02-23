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

    }