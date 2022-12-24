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

        [Required(ErrorMessage ="Please enter valid customer's name.")]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name ="Date of Birth")]   
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; } //Navigation Property- as it allows to navigate from one type to another

        [Display(Name = "Membership Type")]
        public byte MembershipTypeid { get; set; }//Foreign key
    }
}