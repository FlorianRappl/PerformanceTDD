using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Performance.Models
{
    public class AddressDTO
    {
        public AddressDTO()
        {
        }

        public AddressDTO(Address address)
        {
            Id = address.Id;
            Address = address.AddressLine1;
            City = address.City;
            Zip = address.Zip;
            Country = address.Country;
        }

        public Int32 Id
        {
            get;
            set;
        }

        public String Address
        {
            get;
            set;
        }

        public String City
        {
            get;
            set;
        }

        public String Zip
        {
            get;
            set;
        }

        public String Country
        {
            get;
            set;
        }
    }
}