using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task2.Bonus
{
    public class BonusReplenishment : IBonus
    {
        public int GetBonusPoints(Account account, decimal amount)
        {
            return account.BonusPointToReplenishment;
        }
    }
}
