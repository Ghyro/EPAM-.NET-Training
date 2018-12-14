using AutoMapper;
using BLL.Interface.DTO;
using DAL.Interface.Intities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessModels
{
    public class CustomMapper
    {
        public Account MapAccountToDTO(BankAccountDTO accountDTO)
        {
            var mapper = new MapperConfiguration(c => c.CreateMap<BankAccountDTO, Account>()

                .ForMember(x => x.AccountType, s => s.MapFrom(t => t.AccountType))

                .ForMember(x => x.Owner, s => s.MapFrom(t => t.Owner))

                .ForMember(x => x.AccountStatus, s => s.MapFrom(t => t.AccountStatus))).CreateMapper();

            return mapper.Map<BankAccountDTO, Account>(accountDTO);
        }

        public IEnumerable<BankAccountDTO> MapAccounts(IEnumerable<Account> accountDtos)
        {
            var mapper = new MapperConfiguration(c => c.CreateMap<Account, BankAccountDTO>()

                .ForMember(x => x.AccountType, s => s.MapFrom(t => t.AccountType))

                .ForMember(x => x.Owner, s => s.MapFrom(t => t.Owner))

                .ForMember(x => x.AccountStatus, s => s.MapFrom(t => t.AccountStatus))).CreateMapper();

            return mapper.Map<IEnumerable<Account>, IEnumerable<BankAccountDTO>>(accountDtos);
        }
    }
}
