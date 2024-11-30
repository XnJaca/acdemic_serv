using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.Services.Interfaces;
using infrastructure.Db;
using infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, string connectionString)
        {
            // Configurar el DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Registrar el repositorio de roles
            services.AddScoped<IRepositoryRole, RoleRepository>();

            return services;
        }
    }
}