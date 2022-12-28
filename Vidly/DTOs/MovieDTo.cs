using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class MovieDTo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20, ErrorMessage = "The field Number In Stock must be between 1 and 20.")]
        public int NumberInStock { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}