using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Performance.Models
{
    public class AddressBook : DbContext
    {
        static AddressBook()
        {
            Database.SetInitializer<AddressBook>(AddressBookInitializer.Create());
        }

        public DbSet<Address> Addresses 
        { 
            get; 
            set; 
        }

        public DbSet<PhoneNumber> PhoneNumbers
        {
            get;
            set;
        }

        public DbSet<Person> Persons
        {
            get;
            set;
        }
    }
}