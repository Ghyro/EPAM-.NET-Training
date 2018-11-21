using BLL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IBonus
    {
        int GetBonusPoints(AccountDTO account, decimal amount);
    }
}
