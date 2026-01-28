using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetroRides.Services;
using RetroRides.Data;
using RetroRides.Models.DbConfiguration;
using RetroRides.Services;
using RetroRides.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddHotelServices(this IServiceCollection services)
        {
            services.AddDbContext<MuseumContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IUserService, UserService>();


            return services;
        }
    }
}
