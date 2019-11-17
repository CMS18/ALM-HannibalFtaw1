using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlaming1_ALM.Models.Services;
using Inlaming1_ALM.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inlaming1_ALM.Controllers
{
    public class TransactionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(TransactionViewModel model = null)
        {
            if (model == null)
            {
                model = new TransactionViewModel();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                BankRepository.Deposit(model.DepositAmount, model.DepositAccountId);
            }
            model.DepositErrorMessage = BankRepository.Errormessage;
            model.DepositSuccessMessage = BankRepository.SuccessMessage;
            BankRepository.SuccessMessage = "";
            BankRepository.Errormessage = "";
            return View("index",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                BankRepository.Withdraw(model.WithdrawalAmount, model.WithdrawalAccountId);
                
            }
            model.WithdrawalErrorMessage = BankRepository.Errormessage;
            model.WithdrawalSuccessMessage = BankRepository.SuccessMessage;
            BankRepository.SuccessMessage = "";
            BankRepository.Errormessage = "";
            return View("index", model);
        }
    }
}
