using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;
using Tasks;

namespace AccountConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AddAccount();
            Console.ReadLine();
        }
               

        public static void AddAccount()
        {
            var bankAccount = new BankAccount();
            var bankAccountFact = new BankAccountFact();
            var accountService = new AccountService(bankAccountFact);

            Account acc1 = bankAccount.GetAccount(1, "Kirill", "Korzun", 12, 0, AccountType.Base);
            Account acc2 = bankAccount.GetAccount(2, "Oleg", "Olegovich", 200, 0, AccountType.Gold);
            Account acc3 = bankAccount.GetAccount(3, "Vasya", "Vasich", 0, 0, AccountType.Platinum);

            acc1.ReplenishmentMoney(2000);
            acc2.ReplenishmentMoney(123);

            accountService.Add(acc1);
            accountService.Add(acc2);
            accountService.Add(acc3);

            accountService.Save();
        }
    }
}
