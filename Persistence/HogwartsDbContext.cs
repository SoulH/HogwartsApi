using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFPersistence
{
    public class HogwartsDbContext : DbContext
    {
        public DbSet<Registration> Registrations { get; set; }

        public HogwartsDbContext() 
        {
            Database.EnsureCreated();
            Seed();
        }

        public HogwartsDbContext(DbContextOptions<HogwartsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            Seed();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Registration>().HasIndex(r => r.Identification).IsUnique();
            base.OnModelCreating(builder);
        }

        public void Seed()
        {
            if (!Registrations.Any()) Registrations.AddRange(new Registration[]
            {
                new Registration { Name = "Saúl", LastName = "Hernández", House = "Slytherin", Identification = 20808098, Age = 29 }
            });
            SaveChanges();
        }
    }
}
