using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentProcessApi.Entity.Dtos.Validation
{
   
    public class NoPreviousDateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now; 

        }
    }
}
