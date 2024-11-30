using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using domain.Entities;

namespace infrastructure.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        public DbSet<User> User { get; set; } = null!;

        public DbSet<Role> Role { get; set; } = null!;

        public DbSet<Institution> Institution { get; set; } = null!;

        public DbSet<InstitutionType> InstitutionType { get; set; } = null!;
    }
}