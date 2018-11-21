using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class AccountService : IBankService
    {
        private readonly IEnumerable<AccountDTO> listAccount;
        private readonly IRepository repository;
        private readonly AccountMapper accountMapper;

        public AccountService(IRepository repository, AccountMapper accountMapper)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (accountMapper is null)
            {
                throw new ArgumentNullException(nameof(accountMapper));
            }

            this.repository = repository;
            this.accountMapper = accountMapper;
            this.listAccount = this.repository.GetAllList().Select(list => this.accountMapper.DoAccountDTO(list));
        }

        public void Add(AccountDTO account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            this.repository.CreateAccount(this.accountMapper.DoAccount(account));
        }

        public void Remove(AccountDTO account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            this.repository.RemoveAccount(account.Id);
        }

        public void Save()
        {
            this.repository.SaveAccount();
        }
    }
}
