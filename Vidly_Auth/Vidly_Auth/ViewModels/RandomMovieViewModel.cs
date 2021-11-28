using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Auth.Models;

namespace Vidly_Auth.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}