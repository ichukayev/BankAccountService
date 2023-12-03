using BankAccountService.Application.Entities;

namespace BankAccountService.Application.Interfaces
{
    public interface IAccountService
    {
        Task<List<Account>> GetUserAccountsAsync(Guid userId);
        Task<Account> CreateAccountAsync(Account account, long countryId);
        Task<Account> DisableAccountAsync(long accountId);
    }
}
