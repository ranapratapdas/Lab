using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabAPI.Repositories
{
    public static class SetupDependency
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IInventoryRepository,InventoryRepository>();

            return services;
        }
    }
}
