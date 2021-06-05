using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public byte GenreId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
        public decimal Price { get; set; }
    }
}