using AutoMapper;
using BankAccountService.Application.Entities;
using BankAccountService.Shared.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountService.Infrastructure.MapperProfiles
{
    public class AccountTypeMappingProfile : Profile
    {
        private const string AccountTypeNotSupportedExceptionMessage = "Account Type {0} not supported";

        public AccountTypeMappingProfile()
        {
            CreateMap<AccountTypeDto, AccountType>().ConvertUsing((value, _) =>
            {
                return value switch
                {
                    AccountTypeDto.Current => AccountType.Current,
                    AccountTypeDto.Savings => AccountType.Savings,
                    _ => throw new ApplicationException(string.Format(AccountTypeNotSupportedExceptionMessage, value))
                };
            });
        }
    }
}
