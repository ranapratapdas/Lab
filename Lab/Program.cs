using LabApi.Model;
using RestSharp;
using System;
using System.Transactions;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello Lab!");
                Console.WriteLine("You can use this application to place an order for a single product. Do you want to procceed? ");
                var input = Console.ReadLine();
                if (string.Equals(input, "Y", StringComparison.CurrentCultureIgnoreCase)
                    || string.Equals(input, "Yes", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Lets start. What product id you want?");
                    var productid = Console.ReadLine();

                    //Check inventory
                    Console.WriteLine("Thanks. Checking inventory...");

                    bool isProductAvailableToSell = CheckProductAvailability(productid);

                    //Payment gateway
                    if (isProductAvailableToSell)
                    {
                        Console.WriteLine("Good news ! Product is available. We need you payment information to procced further.");
                        UserPayment user = GetUserInformation();

                        Console.WriteLine("Ready? Press Y to proceed. This will charge your account and ship the product to you.");
                        if (string.Equals(input, "Y", StringComparison.CurrentCultureIgnoreCase))
                        {
                            Order order = CreateOrder(user, productid);
                            bool charged = ProcessOrder(order);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Product is not available anymore or  web service is not runninng ( in that case, Please run web service first.)");
                        Console.ReadLine();
                    }


                }
                Console.WriteLine("Have a great day ! Type anything to exit.");
                Console.ReadLine();
            }
            catch(SystemException ex)
            {
                Console.WriteLine("Something went wrong. Check if web service is running.");
                Console.ReadLine();
            }
            
            


        }

        private static Order CreateOrder(UserPayment user, string productid)
        {
            return new Order() {
                Item = new Product(){ ProductId = productid },
                Payment = new UserPayment(){ AmountToBeCharged =Convert.ToDecimal( "0.02"), Name = user.Name },
                ShippingAddress = new ShippingInfo(){ Address = "no mans land" }
               };
        }

        private static bool ChargePayment(UserPayment user)
        {
            //TODO: this will come from config
            RestClient client = new RestClient("http://thirdparty:9075/api/");
            // request
            RestRequest request = new RestRequest("Products", Method.POST);
            //response
            IRestResponse<bool> response = client.Execute<bool>(request);
            return response.Data;
        }

        //This is a very sensitive step
        //use transaction scope to make sure all transactions are either committed / rolledback
        //Ideally this should be part of a service 
        // But I am writing it here to save sometime
        private static bool ProcessOrder(Order order)
        {
            bool processed = false;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {

                processed = CheckProductAvailability(order.Item.ProductId) &&
                    ChargePayment(order.Payment) &&
                    SendEmailToShippingDepartment(order.ShippingAddress);
                if (processed)
                    scope.Complete();
                return processed;
            }
        }

        //This needs to go to a API
        //Wehere Email manager will be injected
        private static bool SendEmailToShippingDepartment(ShippingInfo shippingAddress)
        {
            //Send email
            return true;
        }

        

        private static UserPayment GetUserInformation()
        {
            return new UserPayment() { Name = "Lab test", PaymentInformation = new PaymentInfo() { CardNumber = "not a valid number" } };
        }

        private static bool CheckProductAvailability(string productid)
        {
            //TODO: this will come from config
            //example URL : http://localhost:3001/inventories/1/1
            RestClient client = new RestClient("http://localhost:3001/inventories/");
            // request
            RestRequest request = new RestRequest("productid/1", Method.GET);
            //response
            IRestResponse<bool> response = client.Execute<bool>(request);
            return response.Data;
        }
    }
}
