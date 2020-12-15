using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabApi.Model;
using LabAPI.Services;

namespace LabAPI
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddRequiredServices(this IServiceCollection services)
        {
            services.AddScoped<IInvenotySerivce, InvenotySerivce>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IEmailManager, Emailmanager>();
            

            return services;

        }
    }
}
