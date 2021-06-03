using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        
        [Required]
        public byte GenreId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int NumberInStock { get; set; }
        public decimal Price { get; set; }
    }
}