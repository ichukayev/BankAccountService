using System;

namespace BankAccountService.Shared.Models.Dtos
{
    public class AccountDto
    {
        public int Id { get;  set; }
        public decimal Balance { get; set; }

        public AccountTypeDto Type { get; set; }

        public string Iban { get; set; }

        public bool IsDisable { get; set; }

        public DateTime OpenedAt { get; set; }

        public DateTime? ClosedAt { get; set; }

        public DateTime? DisabledAt { get; set; }
        public Guid UserId { get; set; }
    }
}
