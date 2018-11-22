﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private IKernel kernel = new NinjectIoC().kernel;
        private IBankAccountFactory factory;
        private IBankService service;

        static void Main()
        {
            new Program().TestMethod();

            Console.ReadLine();
        }

        private void TestMethod()
        {
            this.factory = kernel.Get<IBankAccountFactory>();
            this.service = kernel.Get<IBankService>();            

            this.service.Add(this.CreateAccount());

            
        }

        private AccountDTO CreateAccount()
        {
            var getId = this.kernel.Get<IGetID>();
            

            Console.WriteLine("Enter your name...");
            string name = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter your surname...");
            string surname = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Type of account...");
            string typeAccount = Console.ReadLine();

            int id = getId.GetId(1);

            Enum.TryParse(typeAccount, true, out AccountType accountType);

            return factory.GetAccount(id, name, surname, 0, 0, accountType);
        }
    }
}
