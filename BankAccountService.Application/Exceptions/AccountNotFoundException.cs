using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountService.Application.Exceptions
{
    public class AccountNotFoundException: Exception
    {
        public AccountNotFoundException(long accountId) : base($"No account found with id {accountId}")
        {
        }

        public AccountNotFoundException(string message) : base(message)
        {
        }

        public AccountNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
