using BLL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IBankAccountFactory
    {
        AccountDTO GetAccount(int id, string name, string surname, decimal amount, int bonus, AccountType type);
    }
}
