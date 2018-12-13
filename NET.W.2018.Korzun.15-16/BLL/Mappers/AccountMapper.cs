using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using DAL.Interface.Intities;

namespace BLL.Mappers
{
    public class AccountMapper
    {     
        public AccountMapper(IBankAccountFactory bankAccount)
        {
            if (bankAccount is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            this.BankFactory = bankAccount;
        }

        private IBankAccountFactory BankFactory { get; set; }

        public Account ToAccount(AccountDTO accountDTO)
        {
            return new Account()
            {
                Id = accountDTO.Id,
                Name = accountDTO.Name,
                Surname = accountDTO.Surname,
                Balance = accountDTO.Balance,
                Bonus = accountDTO.Bonus,
                AccountType = (int)accountDTO.AccountType
            };
        }

        public AccountDTO ToAccountDTO(Account account)
        {
            return this.BankFactory.GetAccount(account.Id, account.Name, account.Surname, account.Balance, account.Bonus, (AccountType)account.AccountType);
        }
    }
}
