using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace DAL.Interface.Intities
{
    /// <summary>
    /// The entities for work with <see cref="IRepository"/>
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The ID of the personal accoun t
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The account owner
        /// </summary>
        public AccountOwner Owner { get; set; }

        /// <summary>
        /// The account current amount
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// The account bonus points 
        /// </summary>
        public int Bonus { get; set; }

        /// <summary>
        /// The account type (base, gold, platinum)
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        /// The account status (opened, closed)
        /// </summary>
        public AccountStatus AccountStatus { get; set; }

        /// <summary>
        /// Override object method ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {this.Id}, name: {this.Owner.Name}, surname: {this.Owner.Surname}, amount: {this.Balance}, bonus points: {this.Bonus}, account type: {this.AccountType}, status: {this.AccountStatus}";
        }

        /// <summary>
        /// Get hash code ToString()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
