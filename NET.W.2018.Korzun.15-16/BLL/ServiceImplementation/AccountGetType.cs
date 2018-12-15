using BLL.BusinessModels;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class AccountGetType : IBankTypeAccount
    {
        private readonly IRepository repository;
        private readonly CustomMapper customMapper;

        public AccountGetType(IRepository repository, CustomMapper customMapper)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (customMapper is null)
            {
                throw new ArgumentNullException(nameof(customMapper));
            }

            this.repository = repository;
            this.customMapper = customMapper;
        }

        public IEnumerable<AccountTypeDTO> GetAccountsTypes()
        {
            var types = this.repository.GetTypesAccount();

            return customMapper.MapTypes(types);
        }
    }
}
