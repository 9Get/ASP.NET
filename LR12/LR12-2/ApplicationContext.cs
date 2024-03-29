using LR12_2.Models;
using Microsoft.EntityFrameworkCore;

namespace LR12_2
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                    new Company { Id = 1, Name = "Microsoft Corporation", NumberOfEmployees = 181000, Info = "info1" },
                    new Company { Id = 2, Name = "Google (Alphabet Inc.)", NumberOfEmployees = 139000, Info = "info2" },
                    new Company { Id = 3, Name = "Apple Inc.", NumberOfEmployees = 154000, Info = "info3" },
                    new Company { Id = 4, Name = "Facebook, Inc. (Meta Platforms, Inc.)", NumberOfEmployees = 63000, Info = "info4" },
                    new Company { Id = 5, Name = "Samsung Electronics Co., Ltd.", NumberOfEmployees = 286000, Info = "info5" }
            );
        }
    }
}
