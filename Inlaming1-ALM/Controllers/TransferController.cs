using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlaming1_ALM.Models.Services;
using Inlaming1_ALM.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inlaming1_ALM.Controllers
{
    public class TransferController : Controller
    {
        public IActionResult Index(TransferViewModel model)
        {
            if (model == null)
            {
                model = new TransferViewModel();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Transfer(TransferViewModel model = null)
        {
            if (ModelState.IsValid)
            {
                var accounts = BankRepository.GetAccounts();
                var fromAccount = accounts.Find(a => a.AccountID == model.FromAccountId);
                var toAccount = accounts.Find(a => a.AccountID == model.FromAccountId);
                accounts[0].Transfer(model.Amount, fromAccount, toAccount);
                model.ErrorMessage = accounts[0].ErrorMessage;
                model.SuccessMessage = accounts[0].SuccessMessage;
            }
            return View("Index", model);
        }
    }
}