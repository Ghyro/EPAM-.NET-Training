using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public interface IBonus
    {
        int GetBonusPoints(Account account, decimal Amount);
    }
}
