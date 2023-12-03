using BankAccountService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class AppDbContextSeed  
    {
        public static async Task SeedAsync(AppDbContext dbContext)
        {
            if (dbContext.Database.EnsureCreated())
            {
                await dbContext.Countries.AddAsync(
                        new Country
                        {
                            Id = 5,
                            Code = "KZ",
                            Name = "KAZ"
                        }
                    );

                await dbContext.Accounts.AddAsync(
                        new Account
                        {
                            Id = 5187,
                            Iban = "KZ86125KZT5004100100",
                            OpenedAt = DateTime.Now,
                            UserId = Guid.Parse("11223344-5566-7788-99AA-BBCCDDEEFF00")
                        }
                    );

                await dbContext.Accounts.AddAsync(
                        new Account
                        {
                            Id = 517,
                            Iban = "KZ86100KZT5005100100",
                            OpenedAt = DateTime.Now,
                            UserId = Guid.Parse("11223344-5566-7788-99AA-BBCCDDEEFF00")
                        }
                    );

                dbContext.SaveChangesAsync();
            }
        }
    }
}
