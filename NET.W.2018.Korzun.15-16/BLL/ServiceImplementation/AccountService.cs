using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;

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
            this.listAccount = this.repository.GetAllAccounts().Select(s => this.accountMapper.ToAccountDTO(s));
        }

        public void Add(AccountDTO account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            this.repository.CreateAccount(this.accountMapper.ToAccount(account));
        }

        public IEnumerable<AccountDTO> GetAccounts()
        {
            return listAccount.ToList();
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
