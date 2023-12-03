using BankAccountService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountService.Application.Interfaces
{
    public interface IAccountRepository: IRepository<Account>
    {
        Task<List<Account>> GetUserAccounts(Guid userId);
    }
}
