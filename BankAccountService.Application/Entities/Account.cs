

namespace BankAccountService.Application.Entities
{
    public class Account: BaseEntity
    {
        public Guid UserId { get; set; }
        public decimal Balance { get; set; } = 0;
        public string Iban { get; set; }
        public AccountType Type { get; set; }
        public bool IsDisable { get; set; } = false;
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public DateTime? DisabledAt { get; set; }

        public Country Country { get; set; }

    }
}
