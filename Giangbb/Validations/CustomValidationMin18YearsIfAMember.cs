using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Giangbb.FormModels;
using Giangbb.Models;
using Giangbb.Utils;

namespace Giangbb.Validations
{
    public class CustomValidationMin18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerForm) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unkhown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (string.IsNullOrWhiteSpace(customer.Birthday))
            {
                return new ValidationResult("Birthday is required");
            }

            var age = DateTime.Today.Year - DateUtils.GetDateFromString(customer.Birthday, DateUtils.FORMAT_BIRTHDAY).Year;


            return (age>=18)?
                ValidationResult.Success:
                (new ValidationResult("Customer should be at least 18 years old to be member"));
        }
    }
}