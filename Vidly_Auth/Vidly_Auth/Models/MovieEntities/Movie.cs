using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly_Auth.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        
        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock ")]
        public int NumberInStock { get; set; }

        [Required]
        [Range(0, 20)]
        [Display(Name = "Number of available disks")]
        public int NumberOfAvailable { get; set; }
        public decimal Price { get; set; }
    }
}