﻿using BLL.BankFactory;
using BLL.BusinessModels;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLL.WEB.Util
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IRepository>().To<BankAccountRepositories>();
            Kernel.Bind<IBankAccountFactory>().To<BankAccountFactory>().WithPropertyValue("Withdraw", new BonusWithdraw()).WithPropertyValue("Replenishment", new BonusReplenishment());
            Kernel.Bind<IBankService>().To<AccountService>();
            Kernel.Bind<IGetID>().To<GeneratorId>();
            Kernel.Bind<IBonus>().To<BonusWithdraw>();
        }
    }
}