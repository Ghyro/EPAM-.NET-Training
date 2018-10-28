using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tasks
{
    public class BankStorage : IBankAccountStorage
    {
        private string _Path;
        private IBankAccount _BankAccount;

        public BankStorage(string path, IBankAccount bankAccount)
        {
            Path = path;
            BankAccount = bankAccount;
        }

        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException(nameof(value));
                }

                _Path = value;
            }
        }

        public IBankAccount BankAccount
        {
            get
            {
                return _BankAccount;
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _BankAccount = value;
            }
        }

        public List<Account> Load()
        {
            List<Account> listLoadAccount = new List<Account>();

            using (Stream stream = File.Open(this.Path, FileMode.OpenOrCreate))
            {
                using (BinaryReader binaryReader = new BinaryReader(stream))
                {
                    while (binaryReader.PeekChar() > -1)
                    {
                        int id = binaryReader.ReadInt32();
                        string name = binaryReader.ReadString();
                        string surname = binaryReader.ReadString();
                        decimal amount = binaryReader.ReadDecimal();
                        int bonus = binaryReader.ReadInt32();
                        AccountType accountType = (AccountType)binaryReader.ReadInt32();
                        Account account = BankAccount.GetAccount(id, name, surname, amount, bonus, accountType);

                        listLoadAccount.Add(account);
                    }
                }
            }

            return listLoadAccount;
        }

        public void Save(List<Account> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            using (Stream stream = File.Open(this.Path, FileMode.Truncate))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                {
                    foreach (var account in items)
                    {
                        binaryWriter.Write(account.Id);
                        binaryWriter.Write(account.Name);
                        binaryWriter.Write(account.Surname);
                        binaryWriter.Write(account.Amount);
                        binaryWriter.Write(account.Bonus);
                        binaryWriter.Write((int)account.AccountType);
                    }
                }
            }
        }
    }
}
