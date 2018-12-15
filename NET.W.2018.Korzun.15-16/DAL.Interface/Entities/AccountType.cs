using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entities
{
    /// <summary>
    /// Three type of account - Base, Gold, Platinum
    /// </summary>
    public class AccountType
    {
        public string Type { get; set; }

        public int CoefDeposit { get; set; }

        public int CoefWithdraw { get; set; }
    }
}
