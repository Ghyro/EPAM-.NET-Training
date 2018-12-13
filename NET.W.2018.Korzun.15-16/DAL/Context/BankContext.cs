using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Intities;

namespace DAL.Context
{
    /// <summary>
    /// The bank account data context (ORM)
    /// </summary>
    public class BankContext : DbContext
    {
        /// <summary>
        /// Connection string
        /// </summary>
        public BankContext() : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Data context of <see cref="Account"/>
        /// </summary>
        public DbSet<Account> Accounts { get; set; }
    }
}
