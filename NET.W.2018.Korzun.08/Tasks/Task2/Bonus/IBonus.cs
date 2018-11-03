using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task2.Bonus
{
    public interface IBonus
    {
        int GetBonusPoints(Account account, decimal amount);
    }
}
