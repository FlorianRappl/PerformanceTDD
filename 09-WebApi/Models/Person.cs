using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Performance.Models
{
    public class Person
    {
        public Person()
        {
            Addresses = new List<Address>();
            PhoneNumbers = new List<PhoneNumber>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 Id
        {
            get;
            set;
        }

        [Required]
        public String FirstName
        {
            get;
            set;
        }

        [Required]
        public String LastName
        {
            get;
            set;
        }

        public virtual List<Address> Addresses
        {
            get;
            private set;
        }

        public virtual List<PhoneNumber> PhoneNumbers
        {
            get;
            private set;
        }
    }
}