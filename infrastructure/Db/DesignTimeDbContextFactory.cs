// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;

// namespace infrastructure.Db
// {
//     public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//     {
//         public ApplicationDbContext CreateDbContext(string[] args)
//         {
//             // Configura la cadena de conexión
//             var connectionString = "server=mysql-139445-0.cloudclusters.net;port=16997;database=acdemic_client;user id=acdemic_db;password=Acdemic2024;";

//             // Configura las opciones del DbContext
//             var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//             optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

//             return new ApplicationDbContext(optionsBuilder.Options);
//         }
//     }
// }