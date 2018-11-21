using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Intities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get;set; }
        public decimal Amount { get; set; }
        public int Bonus { get; set; }
        public int AccountType { get; set; }
    }
}
