using BankAccountService.Application.Entities;
using BankAccountService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAccountService.Infrastructure.DataAccess.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<List<Account>> GetUserAccounts(Guid userId)
        {
            return await _dbSet.Where( a => a.UserId == userId).ToListAsync();
        }
    }
}
