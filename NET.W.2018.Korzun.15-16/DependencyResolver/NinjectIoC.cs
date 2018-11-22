using BLL.BankFactory;
using BLL.BusinessModels;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public class NinjectIoC
    {
        public readonly IKernel Kernel;

        public NinjectIoC()
        {
            Kernel = new StandardKernel();
            Kernel.Bind<IRepository>().To<BankAccountRepositories>();
            Kernel.Bind<IBankAccountFactory>().To<BankAccountFactory>().WithPropertyValue("Withdraw", new BonusWithdraw()).WithPropertyValue("Replenishment", new BonusReplenishment());
            Kernel.Bind<IBankService>().To<AccountService>();
            Kernel.Bind<IGetID>().To<GeneratorId>();
            Kernel.Bind<IBonus>().To<BonusWithdraw>();
        }
    }
}
