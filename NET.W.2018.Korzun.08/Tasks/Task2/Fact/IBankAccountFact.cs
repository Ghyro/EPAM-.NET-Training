using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public interface IBankAccountFact
    {
        IBankAccountStorage GetAccount();
    }
}
