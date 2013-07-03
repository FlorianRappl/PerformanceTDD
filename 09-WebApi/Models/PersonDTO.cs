using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Performance.Models
{
    public class PersonDTO
    {
        public PersonDTO()
        {
            Addresses = new List<AddressDTO>();
            PhoneNumbers = new List<PhoneNumberDTO>();
        }

        public PersonDTO(Person person)
            : this()
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;

            for (int i = 0; i < person.PhoneNumbers.Count; i++)
                PhoneNumbers.Add(new PhoneNumberDTO(person.PhoneNumbers[i]));

            for (int i = 0; i < person.Addresses.Count; i++)
                Addresses.Add(new AddressDTO(person.Addresses[i]));
        }

        public Int32 Id
        {
            get;
            set;
        }

        public String FirstName
        {
            get;
            set;
        }

        public String LastName
        {
            get;
            set;
        }

        public List<AddressDTO> Addresses
        {
            get;
            set;
        }

        public List<PhoneNumberDTO> PhoneNumbers
        {
            get;
            set;
        }
    }
}