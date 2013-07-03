using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Performance.Models
{
    public class AddressBookInitializer : DropCreateDatabaseIfModelChanges<AddressBook>
    {
        public static AddressBookInitializer Create()
        {
            return new AddressBookInitializer();
        }

        protected override void Seed(AddressBook book)
        {
            AddTo(book, "Peter", "Michel", "Beispielstr. 8", "93051", "Regensburg", "Deutschland", "0941-1234567", NumberType.Home);
            AddTo(book, "Hans", "Meier", "Ringstr. 18", "94032", "Passau", "Deutschland", "0160-45362798", NumberType.Mobile);
            AddTo(book, "Asad", "Zuhu", "Peter-Rosegger-Str. 27", "93053", "Regensburg", "Deutschland", "0941-6378291", NumberType.Work);
            AddTo(book, "Alexander", "Böhm", "Zur schönen Gelegenheit 2", "93152", "Nittendorf", "Deutschland", "09404-242819", NumberType.Work);
            AddTo(book, "Florian", "Meindl", "Brennesstr. 29", "10721", "Berlin", "Deutschland", "0179-12782029", NumberType.Mobile);
            AddTo(book, "Karsten", "Mages", "Von-der-Tann-Straße 3", "51923", "Hausen", "Deutschland", "0555-8724291", NumberType.Work);
            AddTo(book, "Frederik", "Simmel", "Eintrachtstr. 74", "63048", "Niederbach", "Deutschland", "0617-517839", NumberType.Home);
            AddTo(book, "Anja", "Lischke", "Molkeplatz 19", "80995", "München", "Deutschland", "089-292371934", NumberType.Work);
            AddTo(book, "Peter", "Könner", "Schuhmannstr. 1", "60311", "Frankfurt", "Deutschland", "0172-23938271", NumberType.Mobile);
            book.SaveChanges();
        }

        Person AddTo(AddressBook book, String firstName, String lastName, String street, String zip, String city, String country, String phone, NumberType numberType)
        {
            var address = new Address
            { 
                AddressLine1 = street,
                City = city,
                Country = country,
                Zip = zip
            };
            var phoneNumber = new PhoneNumber
            {
                Number = phone,
                Type = numberType
            };
            var person = new Person
            {
                FirstName = firstName,
                LastName = lastName
            };
            person.Addresses.Add(address);
            person.PhoneNumbers.Add(phoneNumber);
            book.Addresses.Add(address);
            book.PhoneNumbers.Add(phoneNumber);
            book.Persons.Add(person);
            return person;
        }
    }
}