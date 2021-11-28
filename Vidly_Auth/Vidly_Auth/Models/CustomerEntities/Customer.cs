using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly_Auth.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsLetter { get; set; }

        [ForeignKey("MembershipTypeId")]
        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        
        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthdayDate { get; set; }
    }
}