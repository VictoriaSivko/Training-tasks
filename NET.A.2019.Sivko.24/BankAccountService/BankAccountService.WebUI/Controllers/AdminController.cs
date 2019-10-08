using System.Web.Mvc;
using BankAccountService.Domain.Abstract;
using BankAccountService.Domain.Entities;
using System.Linq;

namespace BankAccountService.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IBankAccountRepository repository;

        public AdminController (IBankAccountRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.BankAccounts);
        }

        public ViewResult Edit(int id = 3)
        {
            BankAccount bankAccount = repository.BankAccounts
                .FirstOrDefault(acc => acc.BankAccountId == id);
            return View(bankAccount);
        }

        [HttpPost]
        public ActionResult Edit (BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                repository.SaveAccount(bankAccount);
                TempData["message"] = string.Format($"Changes in account number {bankAccount.BankAccountId} where saved.");
                return RedirectToAction("Index");
            }
            else
            {
                return View(bankAccount);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new BankAccount());
        }

        [HttpPost]
        public ActionResult Delete(int ID = 8)
        {
            BankAccount deletedBankAccount = repository.DeleteAccount(ID);

            if (deletedBankAccount != null)
            {
                TempData["message"] = string.Format($"Account number {ID} was deleted.");
            }
            return RedirectToAction("Index");
        }
    }
}