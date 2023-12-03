
using AutoMapper;
using BankAccountService.Application.Entities;
using BankAccountService.Application.Interfaces;
using BankAccountService.Shared.Models.Dtos;

using Microsoft.AspNetCore.Mvc;

namespace BankAccountService.API.Controllers
{
    /// <summary>
    /// Controller to manage accounts within a bank
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        /// <summary>
        /// Retriving user's accounts, suppose that userId we get from external system
        /// </summary>
        /// <param name="userId">User Guid</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(List<AccountDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserAccountsAsync(Guid userId)
        
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var userAccounts = await _accountService.GetUserAccountsAsync(userId);

            if (!userAccounts.Any())
            {
                return NotFound();
            }             

            return Ok(userAccounts);
        }
        /// <summary>
        /// Create user's bank account
        /// </summary>
        /// <param name="accountTypeDto">account type</param>
        /// <param name="userId">User Guid</param>
        /// <returns></returns>
        [HttpPost("{userId}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AccountDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUserAccountAsync([FromBody] CreateAccountDto createAccountDto, Guid userId)
        {
            if (ModelState.IsValid)
            {
                var account = new Account
                {
                    UserId = userId,
                    Type = _mapper.Map<AccountType>(createAccountDto.Type)
                };

                account = await _accountService.CreateAccountAsync(account, createAccountDto.CountryId);

                var accountDto = _mapper.Map<AccountDto>(account);

                return CreatedAtAction("CreateUserAccount", accountDto);
            }
            
            return BadRequest();
        }
        /// <summary>
        /// Disable (freeze) an account
        /// </summary>
        /// <param name="accountId">Id an account</param>
        /// <returns></returns>
        [HttpPatch("{accountId}/disable")]
        [ProducesResponseType(typeof(AccountDto), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DisableAccountAsync(long accountId)
        {
            var account = await _accountService.DisableAccountAsync(accountId);

            return Ok(_mapper.Map<AccountDto>(account));
        }
    }
}
