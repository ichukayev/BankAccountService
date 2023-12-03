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
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<Account, AccountDto>(MemberList.Destination);
        }
    }
}
