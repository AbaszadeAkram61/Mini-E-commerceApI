using E_TicaretApI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_TicaretApI.Application.Repositories;
using E_TicaretApI.Domain.Entities;
using E_TicaretApI.Persistence.Repositories;

namespace E_TicaretApI.Persistence
{
   public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<E_TicaretApiDbContext>(options => options.UseSqlServer("Server=ABASOV-194\\SQLEKREM;Database=ETicaretApIDb;User Id=sa;Password=edik12;Trusted_Connection=True;TrustServerCertificate=True;"));
            services.AddScoped(typeof(IRepository<>), typeof(Repostory<>));
        }
    }
}
