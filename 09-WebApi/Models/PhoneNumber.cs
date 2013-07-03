using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Performance.Models
{
    public class PhoneNumber
    {
        public PhoneNumber()
        {
            Type = NumberType.Unknown;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 Id
        {
            get;
            set;
        }

        public NumberType Type
        {
            get;
            set;
        }

        [Required]
        public String Number
        {
            get;
            set;
        }
    }
}