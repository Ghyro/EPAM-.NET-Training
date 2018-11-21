using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Intities;

namespace DAL.Context
{
    public class BankContext : DbContext
    {
        public BankContext() : base("DbConnection")
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
