using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace WK1Telefoonboekje.Domain
{
    public class TelephoneBook
    {
        #region fields
        private readonly string _filename = "peopleseed.json";
        private List<Person> _people;
        #endregion

        public TelephoneBook()
        {
            this.SeedTelephoneBook();
        }

        #region methods.
        /// <summary>
        /// Returns a list of Person, sorted by property LastName (asc) 
        /// </summary>
        /// <returns>List<Person></returns>
        public List<Person> GetAllSortedByLastName() => _people.OrderBy(p => p.LastName).ToList();
        /// <summary>
        /// Returns a list of Person where firstname starts with provided startingChar.
        /// </summary>
        /// <param name="startingChar">Character A-Z</param>
        /// <returns>List<Person></returns>
        public List<Person> GetAllPersonsStartingWithLetter(char startingChar) => _people.Where(p => p.FirstName.StartsWith(startingChar)).ToList();
        /// <summary>
        /// Returns a list of Person where lastname is equal to or greater than int lastNameLength.
        /// </summary>
        /// <param name="lastNameLength">int length for lastName</param>
        /// <returns>List<Person></returns>
        public List<Person> GetAllPersonsWithLastNameGreaterThan(int lastNameLength) => _people.Where(p => p.LastName.Length >= lastNameLength).ToList();
        /// <summary>
        /// Returns list of Person ordered by lastName's length ascending.
        /// </summary>
        /// <returns>List<Person></returns>
        public List<Person> GetAllPersonsSortedByLastNameLengthAsc() => _people.OrderBy(p => p.LastName.Length).ToList();
        #endregion

        #region private methods.
        /// <summary>
        /// Read JSON from string _filename
        /// Deserializes as List<Person>
        /// </summary>
        private void SeedTelephoneBook()
        {
            try
            {
                string json = File.ReadAllText(_filename);
                _people = JsonSerializer.Deserialize<List<Person>>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error");
            }
        }
        #endregion

        #region properties.
        public int NumberOfPeopleInPhoneBook => _people.Count();
        #endregion
    }
}
