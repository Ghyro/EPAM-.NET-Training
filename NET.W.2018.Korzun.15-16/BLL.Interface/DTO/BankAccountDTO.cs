using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface.DTO
{
    public class BankAccountDTO : IEquatable<BankAccountDTO>
    {
        #region Entities
        public int Id { get; set; }
        public AccountOwner Owner { get; set; }
        public decimal Balance { get; set; }
        public int Bonus { get; set; }
        public AccountTypeDTO AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; }
        #endregion      

        #region Methods

        /// <summary>
        /// Override object method ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {this.Id}, name: {this.Owner.Name}, surname: {this.Owner.Surname}, amount: {this.Balance}, bonus points: {this.Bonus}, account type: {this.AccountType}, status: {this.AccountStatus} ";
        }

        /// <summary>
        /// Get hash code ToString()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Equivalence relation
        /// </summary>
        /// <param name="account">Object of <see cref="Account"/></param>
        /// <returns>true or false</returns>
        public bool Equals(BankAccountDTO account)
        {
            if (account is null)
            {
                return false;
            }

            if (ReferenceEquals(this, account))
            {
                return true;
            }

            if (this.GetType() != account.GetType())
            {
                return false;
            }

            if (this.Id == account.Id)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
