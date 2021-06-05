using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }

        //TODO: Must be added validation for DTO
        //[Min18YearsIfAMember]
        public DateTime? BirthdayDate { get; set; }
    }
}