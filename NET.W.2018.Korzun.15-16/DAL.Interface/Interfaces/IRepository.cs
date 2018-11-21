using DAL.Interface.Intities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IRepository
    {
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void RemoveAccount(int id);
        void SaveAccount();

        Account GetAccount(int id);

        IEnumerable<Account> GetAccountList();
        IEnumerable<Account> GetAllList();
    }
}
