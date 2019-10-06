using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Entities.Helper;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IAccountService<BankAccount> service = resolver.Get<IAccountService<BankAccount>>();
            IAccountNumberCreateService creator = resolver.Get<IAccountNumberCreateService>();

            service.AddNewAccount(new BaseAccount(new AccountOwner("base1", "Bsurname1"), 4, new AccountNumberCreator()));
            service.AddNewAccount(new GoldAccount(new AccountOwner("gold1", "Gsurname1"), 4, new AccountNumberCreator()));
            service.AddNewAccount(new PlatinumAccount(new AccountOwner("platinum1", "Psurname1"), 4, new AccountNumberCreator()));
            service.AddNewAccount(new BaseAccount(new AccountOwner("base2", "Bsurname2"), 4, new AccountNumberCreator()));

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.ID).ToArray();

            foreach (var t in creditNumbers)
            {
                service.DepositAccount(t, 100.0);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var t in creditNumbers)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
