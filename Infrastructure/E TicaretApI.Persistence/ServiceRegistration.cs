using E_TicaretApI.Application.Repositories;
using E_TicaretApI.Domain.Entities;
using E_TicaretApI.Domain.Entities.Identity;
using E_TicaretApI.Persistence.Contexts;
using E_TicaretApI.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Persistence
{
   public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<E_TicaretApiDbContext>(options => options.UseSqlServer("Server=ABASOV-194\\SQLEKREM;Database=ETicaretApIDb;User Id=sa;Password=edik12;Trusted_Connection=True;TrustServerCertificate=True;"));
            services.AddScoped(typeof(IRepository<>), typeof(Repostory<>));
            services.AddIdentity<AppUser, AppRole>(option =>
            {
                option.Password.RequiredLength = 3;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
            })

             .AddEntityFrameworkStores<E_TicaretApiDbContext>();
             

        }
    }
}
