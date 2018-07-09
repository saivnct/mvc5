using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Giangbb.Models;

namespace Giangbb.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Address { get; set; }

        public bool IsSubscribedToNewLetters { get; set; }        

        public byte MembershipTypeId { get; set; }
    }
}