using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.DTO
{
    /// <summary>
    /// Three type of account - Base, Gold, Platinum
    /// </summary>
    public class AccountTypeDTO
    {
        public string Type { get; set; }

        public int CoefDeposit { get; set; }

        public int CoefWithdraw { get; set; }

        public AccountTypeDTO BaseAccount
        {
            get
            {
                return BaseAccount;
            }

            set
            {
                Type = "Base";
                CoefDeposit = 2;
                CoefWithdraw = 3;
            }
        }

        public AccountTypeDTO GoldAccount
        {
            get
            {
                return GoldAccount;
            }

            set
            {
                Type = "Gold";
                CoefDeposit = 10;
                CoefWithdraw = 11;
            }
        }

        public AccountTypeDTO PlatinumAccount
        {
            get
            {
                return PlatinumAccount;
            }

            set
            {
                Type = "Platinum";
                CoefDeposit = 5;
                CoefWithdraw = 8;
            }
        }
    }
}
