using BankAccountService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankAccountService.Infrastructure.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Country> Countries { get; set; }

        public AppDbContext(DbContextOptions opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<Account>().HasIndex(a => a.Iban).IsUnique();
            modelBuilder.Entity<Account>().Property(a => a.Iban).IsRequired();
            modelBuilder.Entity<Account>().Property(a => a.Balance);

            modelBuilder.Entity<Country>().HasKey(c => c.Id);
            modelBuilder.Entity<Country>().HasMany(c => c.Accounts).WithOne(a => a.Country);
            modelBuilder.Entity<Country>().Property(c => c.Code).IsRequired();
            modelBuilder.Entity<Country>().HasIndex(c => new { c.Code }).IsUnique();
            modelBuilder.Entity<Country>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Country>().HasIndex(c => new { c.Name }).IsUnique();
        }
    }
}
