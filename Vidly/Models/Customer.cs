using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; } //Navigation Property- as it allows to navigate from one type to another

        public byte MembershipTypeid { get; set; }//Foreign key
    }
}