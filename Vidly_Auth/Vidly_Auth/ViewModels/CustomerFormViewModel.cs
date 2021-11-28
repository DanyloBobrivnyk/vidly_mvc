using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Auth.Models;

namespace Vidly_Auth.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}