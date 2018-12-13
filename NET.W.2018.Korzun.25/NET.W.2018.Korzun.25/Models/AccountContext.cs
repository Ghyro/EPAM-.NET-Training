using NET.W._2018.Korzun._25.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NET.W._2018.Korzun._25.Models
{
    public class AccountContext : DbContext
    {
        public AccountContext() : base("DefaultConnection")
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }
    }
}