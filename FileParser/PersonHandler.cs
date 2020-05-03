using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ObjectLibrary;

namespace FileParser
{
    //public class Person { }  // temp class delete this when Person is referenced from dll

    public class PersonHandler
    {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            people.RemoveAt(0);
            People = new List<Person>();

            foreach (var person in people)
            {
                People.Add(new Person(int.Parse(person[0]), person[1], person[2], new DateTime(long.Parse(person[3]))));
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {
            DateTime oldest = People[0].Dob;

            foreach (var person in People)
            {
                if (DateTime.Compare(oldest, person.Dob) == 1) {
                    oldest = person.Dob;
                }
            }

            return new List<Person>(People.FindAll((p) => DateTime.Compare(oldest, p.Dob) == 0)); //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id)
        {
            return People.Find((e) => e.Id == id).ToString();  //-- return result here
        }

        public List<Person> GetOrderBySurname()
        {
            List<Person> sorted = new List<Person>(People);

            sorted.Sort((a, b) => a.Surname.CompareTo(b.Surname));

            return sorted;  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive)
        {
            int count = 0;
            if (caseSensitive)
            {
                foreach (var person in People)
                {
                    if (person.Surname.StartsWith(searchTerm))
                    {
                        count += 1;
                    }
                }
            } else
            {
                searchTerm = searchTerm.ToLower();

                foreach (var person in People)
                {
                    if (person.Surname.ToLower().StartsWith(searchTerm))
                    {
                        count += 1;
                    }
                }
            }

            return count;  //-- return result here
        }

        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate()
        {
            List<string> result = new List<string>();

            return result;  //-- return result here
        }
    }
}