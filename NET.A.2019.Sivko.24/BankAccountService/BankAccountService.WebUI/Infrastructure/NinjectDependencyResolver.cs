using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using BankAccountService.Domain.Abstract;
using BankAccountService.Domain.Entities;
using BankAccountService.Domain.Concrete;

namespace BankAccountService.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //Mock<IBankAccountRepository> mock = new Mock<IBankAccountRepository>();
            //mock.Setup(m => m.BankAccounts).Returns(new List<BankAccount>
            //{
            //    new BankAccount { BankAccountId = 1, Balance = 10, Bonus = 1, OpenAcc = true, Name = "Lisa" },
            //    new BankAccount { BankAccountId = 2, Balance = 12, Bonus = 52, OpenAcc = true, Name = "Hope" },
            //    new BankAccount { BankAccountId = 3, Balance = 0, Bonus = 0, OpenAcc = false, Name = "Anastasia" },
            //});
            //kernel.Bind<IBankAccountRepository>().ToConstant(mock.Object);

            kernel.Bind<IBankAccountRepository>().To<EFBankAccountRepository>();
        }
    }
}