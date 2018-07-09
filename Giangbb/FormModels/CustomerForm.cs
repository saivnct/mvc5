using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Giangbb.Models;
using Giangbb.Validations;

namespace Giangbb.FormModels
{
    public class CustomerForm
    {
        public int Id { get; set; }

        [CustomValidationMin18YearsIfAMember]
        public string Birthday { get; set; }

//        [Required]
        [Required(ErrorMessage = "Please enter customer's name")]       //modified error message
        [StringLength(255)]
        public string Name { get; set; }

        public string Address { get; set; }


        public bool IsSubscribedToNewLetters { get; set; }
        
        [Range(1,4)]
        public byte MembershipTypeId { get; set; }


        //some of other attribute
//        [Compare("OtherProperty")]    //ex: compare password
//        [Phone]
//        [EmailAddress]
//        [Url]
//        [RegularExpression("...")]
    }
}