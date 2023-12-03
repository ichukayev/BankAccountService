using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountService.Application.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
