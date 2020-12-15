using System;

namespace LabApi.Model
{
    public class UserPayment
    {
        public string Name { get; set; }
        public PaymentInfo PaymentInformation {get;set;}
        public decimal AmountToBeCharged { get; set; }

    }
}
