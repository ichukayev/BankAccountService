using BankAccountService.Application.Interfaces;
using IbanNet.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountService.Infrastructure.Services
{
    public class IbanGeneratorService : IIbanGeneratorService
    {
        private readonly IIbanGenerator _ibanGenerator;
        public IbanGeneratorService(IIbanGenerator ibanGenerator)
        {

            _ibanGenerator = ibanGenerator;
        }
        public string Generate(string countryCode)
        {
            return _ibanGenerator.Generate(countryCode).ToString();
        }
    }
}
