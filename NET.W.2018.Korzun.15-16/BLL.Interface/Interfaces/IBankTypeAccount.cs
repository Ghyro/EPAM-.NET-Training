using BLL.Interface.DTO;
using DAL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Get all list of accounts type for DropBox
    /// </summary>
    public interface IBankTypeAccount
    {
        IEnumerable<AccountTypeDTO> GetAccountsTypes();
    }
}
