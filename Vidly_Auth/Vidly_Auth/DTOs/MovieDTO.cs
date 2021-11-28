using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Auth.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GenreDTO Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
        public decimal Price { get; set; }
    }
}