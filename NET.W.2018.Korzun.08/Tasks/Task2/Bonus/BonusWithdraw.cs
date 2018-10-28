using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task2.Bonus
{
    public class BonusWithdraw : IBonus
    {
        public int GetBonusPoints(Account account, decimal Amount)
        {
            return account.BonusPointToWithdraw;
        }
    }
}
