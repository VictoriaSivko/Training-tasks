using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankAccountService.Domain.Abstract;
using BankAccountService.Domain.Entities;

namespace BankAccountService.WebUI.Controllers
{
    public class BankAccountController : Controller
    {
        private IBankAccountRepository repository;

        public BankAccountController(IBankAccountRepository repo)
        {
            repository = repo;
        }

        public ViewResult List()
        {
            return View(repository.BankAccounts);
        }
    }
}