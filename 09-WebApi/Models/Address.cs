using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Performance.Models
{
    public class Address
    {
        public Address()
        {
            AddressLine2 = String.Empty;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 Id
        {
            get;
            set;
        }

        [Required]
        public String City
        {
            get;
            set;
        }

        [Required]
        public String Country
        {
            get;
            set;
        }

        [Required]
        public String Zip
        {
            get;
            set;
        }

        [Required]
        public String AddressLine1
        {
            get;
            set;
        }

        public String AddressLine2
        {
            get;
            set;
        }
    }
}