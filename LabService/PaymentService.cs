using LabApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAPI.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<bool> Charge(UserPayment userpayment)
        {
            //Validate user , payment info.etc
            //We dont want to place false call the third part web service

            // Provide proper secuurity / authrization details and call third party service
            if(IsValidPaymentInfo(userpayment))
            {
               return await ChargePayment(userpayment.PaymentInformation.CardNumber, userpayment.AmountToBeCharged);
            }
            return false;
        }


        private async Task<bool> ChargePayment(string cardNumber, decimal amount)
        {
            //call third party
            return true;
        }

        private bool IsValidPaymentInfo(UserPayment user)
        {
            return true;
        }
    }
}
