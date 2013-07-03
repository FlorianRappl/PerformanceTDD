using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Performance.Models
{
    public class PhoneNumberDTO
    {
        public PhoneNumberDTO()
        {
        }

        public PhoneNumberDTO(PhoneNumber phone)
        {
            Id = phone.Id;
            Number = phone.Number;
            Type = phone.Type.ToString();
        }

        public Int32 Id
        {
            get;
            set;
        }

        public String Type
        {
            get;
            set;
        }

        public String Number
        {
            get;
            set;
        }
    }
}