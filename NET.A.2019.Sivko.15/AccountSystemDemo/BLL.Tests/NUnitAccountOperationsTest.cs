using BLL.Interface.Entities;
using BLL.Interface.Entities.Helper;
using BLL.ServiceImplementation;
using NUnit.Framework;
using System;

namespace BLL.Tests
{
    [TestFixture]
    public class NUnitAccountOperationsTest
    {
        [Test]
        public static void NegativBalanceTest()
        {
            BaseAccount baseAccount;
            var ex = Assert.Catch<Exception>(() => baseAccount = new BaseAccount(new AccountOwner("base1", "Bsurname1"), -43.0, new AccountNumberCreator()));
            StringAssert.Contains("Unable to create account with negative balance", ex.Message);
        }

        [Test]
        public static void IdenticalAccounts()
        {
            BaseAccount baseAccount = new BaseAccount(new AccountOwner("base1", "Bsurname1"), 43.0, new AccountNumberCreator());
            AccountService service = new AccountService();

            service.AddNewAccount(baseAccount);

            try
            {
                var ex = Assert.Catch<Exception>(() => service.AddNewAccount(baseAccount));
            }
            catch (Exception ex)
            {
                StringAssert.Contains("Attempt to add an existing object", ex.Message);
            } 
        }
    }
}
