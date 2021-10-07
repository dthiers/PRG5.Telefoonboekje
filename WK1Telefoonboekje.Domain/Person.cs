using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace WK1Telefoonboekje.Domain
{
    public class Person
    {
        #region fields
        private string _firstName;
        private string _lastName;
        private string _telephoneNumber;
        #endregion

        public Person()
        {

        }
        public Person(string firstName, string lastName)
        {
            this._firstName = firstName;
            this._lastName = lastName;
        }

        #region methods.
        public override string ToString()
        {
            return $" {_firstName} {_lastName} \n tel: {TelephoneNumber} \n ___________";
        }
        #endregion

        #region properties.
        /// <summary>
        /// ReadAndWrite property using Lambda
        /// </summary>
        [JsonPropertyName("firstname")]
        public string FirstName { get => _firstName; set => _firstName = value; }
        /// <summary>
        /// ReadAndWrite property using FullProperty
        /// </summary>
        [JsonPropertyName("lastname")]
        public string LastName 
        { 
            get
            {
                return _lastName;
            }
            set
            {
                this._lastName = value;
            }
        }
        /// <summary>
        /// Full Property with room for validation, using Lambda for the GETTER.
        /// For simplicity it's merely a regex on a 10-digit phonenumber
        /// </summary>
        [JsonPropertyName("phone")]
        public string TelephoneNumber 
        {
            get => _telephoneNumber;
            set
            {
                if (Regex.Match(value, @"^(\s*\d\s*){10}$").Success)
                {
                    _telephoneNumber = value.Trim();
                }
            }
        }
        /// <summary>
        /// ReadOnly property with Lambda
        /// </summary>
        public string FullName => $"{_firstName} {_lastName}";
        #endregion
    }
}
