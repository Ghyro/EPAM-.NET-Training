using BLL.BankAccountFactory;
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
        public NinjectIoC()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IRepository>().To<BankAccountRepositories>().WithConstructorArgument("day15-16.txt");
            kernel.Bind<IBankAccountFactory>().To<BankAccountFactory>().WithPropertyValue("Withdraw", new BonusWithdraw()).WithPropertyValue("Replenishment", new BonusReplenishment());
            kernel.Bind<IBankService>().To<AccountService>();
            kernel.Bind<IGetID>().To<GeneratorId>();
            kernel.Bind<IBonus>().To<BonusWithdraw>();

        }
    }
}
