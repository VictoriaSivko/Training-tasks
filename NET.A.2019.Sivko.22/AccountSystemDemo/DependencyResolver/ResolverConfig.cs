using BLL.Interface.Entities;
using BLL.Interface.Entities.Helper;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService<BankAccount>>().To<AccountService>();
            kernel.Bind<IRepository<BankAccount>>().To<AccountBinaryRepository>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();
        }
    }
}
