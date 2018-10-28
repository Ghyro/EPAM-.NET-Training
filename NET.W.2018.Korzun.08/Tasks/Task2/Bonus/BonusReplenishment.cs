using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task2.Bonus
{
    class BonusReplenishment : IBonus
    {
        public int GetBonusPoints(Account account, decimal Amount)
        {
            return account.BonusPointToReplenishment;
        }
    }
}
