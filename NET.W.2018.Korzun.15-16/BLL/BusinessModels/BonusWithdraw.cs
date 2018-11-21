using BLL.Interface;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessModels
{
    public class BonusWithdraw : IBonus
    {
        public int GetBonusPoints(AccountDTO account, decimal amount)
        {
            return account.BonusPointToWithdraw;
        }
    }
}
