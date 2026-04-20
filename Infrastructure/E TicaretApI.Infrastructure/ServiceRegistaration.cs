using E_TicaretApI.Application.Services;
using E_TicaretApI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Infrastructure
{
    public static class ServiceRegistaration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
        }
    }
}
