using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using DAL.Interface.Intities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class AccountMapper
    {
        private IBankAccountFactory bankFactory { get; set; }

        public AccountMapper(IBankAccountFactory bankAccount)
        {
            if (bankAccount is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            this.bankFactory = bankFactory;
        }

        public Account DoAccount(AccountDTO accountDTO)
        {
            return new Account()
            {
                Id = accountDTO.Id,
                Name = accountDTO.Name,
                Surname = accountDTO.Surname,
                Amount = accountDTO.Amount,
                Bonus = accountDTO.Bonus,
                AccountType = (int)accountDTO.AccountType
            };
        }

        public AccountDTO DoAccountDTO(Account account)
        {
            return this.bankFactory.GetAccount(account.Id, account.Name, account.Surname, account.Amount, account.Bonus, (AccountType)account.AccountType);
        }
    }
}
