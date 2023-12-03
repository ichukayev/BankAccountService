using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountService.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task SaveChangesAsync();

        void SaveChanges();
    }
}