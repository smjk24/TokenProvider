using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenProvider.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<State> States { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasData(
                new Country() { Id = 1, Name = "India" },
                new Country() { Id = 2, Name = "Aus" },
                new Country() { Id = 3, Name = "Rsa" }
                );

            modelBuilder.Entity<State>()
                .HasOne(x => x.GetCountry)
                .WithMany(x => x.StateCollection)
                .HasForeignKey(x => x.CountryId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<State>()
                .HasData(
                new State() { Id = 1, Name = "Kerala", CountryId = 1 },
                new State() { Id = 2, Name = "TamilNadu", CountryId = 1 },
                new State() { Id = 3, Name = "Goa", CountryId = 1 },
                new State() { Id = 4, Name = "Melbourne", CountryId = 2 },
                new State() { Id = 5, Name = "Sydney", CountryId = 2 },
                new State() { Id = 6, Name = "Johanousberg", CountryId = 3 }
                );

            modelBuilder.Entity<Account>()
                .HasData(
                new Account() { UserId = 1, UserName = "Amit", UserPsswd = "12345", UserRole = "SuperAdmin" },
                new Account() { UserId = 2, UserName = "Adam", UserPsswd = "1234", UserRole = "User" },
                new Account() { UserId = 3, UserName = "Sachin", UserPsswd = "123", UserRole = "Admin" }
                );  
        }
    }
}
