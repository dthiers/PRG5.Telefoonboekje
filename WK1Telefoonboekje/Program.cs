using System;
using System.Collections.Generic;
using WK1Telefoonboekje.Domain;

namespace WK1Telefoonboekje
{
    class Program
    {
        static void Main(string[] args)
        {
            var pb = new TelephoneBook();
            Console.WriteLine("Hello World!");
            List<Person> result = null;

            Console.WriteLine("GetAllSortedByLastName");
            result = pb.GetAllSortedByLastName();
            PrintPersonList(result);

            Console.WriteLine("GetAllPersonsStartingWithLetter C");
            result = pb.GetAllPersonsStartingWithLetter('C');
            PrintPersonList(result);

            Console.WriteLine("GetAllPersonsWithLastNameGreaterThan 8");
            result = pb.GetAllPersonsWithLastNameGreaterThan(8);
            PrintPersonList(result);

            Console.WriteLine("GetAllPersonsSortedByLastNameLengthDesc");
            result = pb.GetAllPersonsSortedByLastNameLengthAsc();
            //PrintPersonList(result);
            //result.ForEach((Person p) => { Console.WriteLine(p.ToString()); });
            //result.ForEach(delegate (Person p)
            //{
            //    Console.WriteLine(p.ToString());
            //});
            result.ForEach(p => Console.WriteLine(p.ToString()));

            Console.WriteLine("NumberOfPeopleInPhoneBook");
            Console.WriteLine($"There is {pb.NumberOfPeopleInPhoneBook} people in the phonebook.");
            //Console.WriteLine("Enter your phonenumber (format: xxxxxxxxxx / 10 digits)");

            //person.TelephoneNumber = Console.ReadLine();

            //var personHasPhoneNumberAssigned = person.TelephoneNumber != null;

            //Console.WriteLine($"{person.FullName}'s telephone number is {person.TelephoneNumber}");
        }

        static void PrintPersonList(List<Person> personList)
        {
            personList.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
