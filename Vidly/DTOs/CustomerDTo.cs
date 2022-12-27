using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDTo
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter valid customer's name.")]
        [StringLength(255)]
        public string name { get; set; }

        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeid { get; set; }//Foreign key
    }
}