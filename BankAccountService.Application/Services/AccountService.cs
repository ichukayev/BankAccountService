using BankAccountService.Application.Interfaces;
using BankAccountService.Application.Entities;
using System.Net;
using System.Data;
using System.Security.Principal;
using BankAccountService.Application.Exceptions;

namespace BankAccountService.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIbanGeneratorService _ibanGeneratorService;
        public AccountService(IAccountRepository accountRepository,
            ICountryRepository countryRepository,
            IUnitOfWork unitOfWork, 
            IIbanGeneratorService ibanGeneratorService)
        {
            _accountRepository = accountRepository;
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
            _ibanGeneratorService = ibanGeneratorService;
        }
        public async Task<Account> CreateAccountAsync(Account account, long countryId)
        {
            var country = await _countryRepository.SingleOrDefaultByIdAsync(countryId);     
            var iban = _ibanGeneratorService.Generate(country.Code);
            
            account.Iban = iban;
            account.OpenedAt = DateTime.Now;

            await _accountRepository.AddAsync(account);
            await _unitOfWork.SaveChangesAsync();

            return account;
        }

        public async Task<List<Account>> GetUserAccountsAsync(Guid UserId)
        {
            return await _accountRepository.GetUserAccounts(UserId);
        }

        public async Task<Account> DisableAccountAsync(long accountId)
        {
            var account = await _accountRepository.SingleOrDefaultByIdAsync(accountId);

            if (account == null)
            {
                throw new AccountNotFoundException(accountId);
            }

            account.IsDisable = true;
            account.DisabledAt = DateTime.Now;

            _accountRepository.Update(account);
            await _unitOfWork.SaveChangesAsync();

            return account;
        }
    }
}
