using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// The account holder name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The account holder surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The account current amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The account bonus points 
        /// </summary>
        public int Bonus { get; set; }

        /// <summary>
        /// The account type (base, gold, platinum)
        /// </summary>
        public int AccountType { get; set; }
    }
}
