using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PaymentProcessApi.Entity.Dtos.Validation
{
    public static class CreditCardDetailsValidator
    {
        /// <summary>
        /// function referenced from stackoverflow article https://stackoverflow.com/a/32965555/249895
        

        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="expiryDate"></param>
        /// <param name="cvv"></param>
        /// <returns></returns>
        public static bool IsCreditCardInfoValid(string cardNo, string expiryDate, string cvv)
        {
            var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
            var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
            var yearCheck = new Regex(@"^20[0-9]{2}$");
            var cvvCheck = new Regex(@"^\d{3}$");

            if (!cardCheck.IsMatch(cardNo)) 
                return false;
            if (!cvvCheck.IsMatch(cvv)) 
                return false;

            var dateParts = expiryDate.Split('/');     
            if (!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1])) 
                return false; 

            var year = int.Parse(dateParts[1]);
            var month = int.Parse(dateParts[0]);
            var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month); 
            var cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

            
            return (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(6));
        }
    }
}
