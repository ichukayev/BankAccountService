using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountService.Shared.Models.Dtos
{
    public class CreateAccountDto
    {
        public AccountTypeDto Type { get; set; }
        public long CountryId { get; set; } = 5; //for testing
    }
}
