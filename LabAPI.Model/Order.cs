using System;
using System.Collections.Generic;
using System.Text;

namespace LabApi.Model
{
    public class Order
    {
        public UserPayment Payment { get; set; }
        public Product Item { get; set; }
        public ShippingInfo ShippingAddress { get; set; }

    }
}
