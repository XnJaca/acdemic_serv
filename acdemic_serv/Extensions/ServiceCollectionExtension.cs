using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.Services.Implementations;
using domain.Services.Interfaces;

namespace acdemic_serv.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
 services.AddScoped<IServiceUser, UserService>();
            
            services.AddScoped<IServiceRole, RoleService>();
            services.AddScoped<IServiceInstitution, InstitutionService>();
            services.AddScoped<IServiceInstitutionType, InstitutionTypeService>(); 
            // Agrega aquí otros servicios de aplicación
            // services.AddScoped<IDbConnectionService, DbConnectionService>();
            // services.AddHttpContextAccessor();
            // services.AddDbContext<DataContext>();
            return services;
        }
    }
}