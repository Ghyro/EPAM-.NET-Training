using AutoMapper;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using DAL.Interface.Intities;
using PLL.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PLL.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBankService service;
        private readonly IBankTypeAccount typeAccount;

        public AccountController(IBankService service, IBankTypeAccount typeAccount)
        {
            if (service is null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (typeAccount is null)
            {
                throw new ArgumentNullException(nameof(typeAccount));
            }

            this.service = service;
            this.typeAccount = typeAccount;
        }

        /// <summary>
        /// Open the list of accounts
        /// </summary>
        /// <returns>The list of accounts</returns>
        public ActionResult List()
        {
            var bankAccounts = this.service.GetAccounts();

            return View(bankAccounts);
        }

        /// <summary>
        /// Create SelectList for DropBox
        /// </summary>
        /// <returns>The list of statuses, the list of types of account</returns>
        [HttpGet]
        public ActionResult Create()
        {
            SelectList listStatuses = new SelectList(new[] { AccountStatus.Opened, AccountStatus.Closed });
            SelectList listTypes = new SelectList(this.typeAccount.GetAccountsTypes(), "Type", "Type");

            ViewBag.AccountStatus = listStatuses;

            ViewBag.AccountType = listTypes;

            return View();
        }

        /// <summary>
        /// Create new account
        /// </summary>
        /// <param name="model">Current model of <see cref="AccountViewModel"/></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        public ActionResult Create(AccountViewModel model)
        {
            var accountOwner = new AccountOwner()
            {
                Name = model.Name,
                Surname = model.Surname
            };

            var accountType = this.typeAccount.GetAccountsTypes().First(t => t.Type == model.AccountType);

            var bankAccount = new BankAccountDTO()
            {
                Owner = accountOwner,
                Balance = model.Balance,
                AccountStatus = model.Status,
                Bonus = model.Bonus,
                AccountType = accountType
            };

            this.service.AddAccount(bankAccount);

            return RedirectToAction("List");
        }

        /// <summary>
        /// Deposit to account
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Deposit()
        {
            return View();
        }

        /// <summary>
        /// Deposit to account
        /// </summary>
        /// <param name="model">Current model of <see cref="DepositWithdrawViewModel"/></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        public ActionResult Deposit(DepositWithdrawViewModel model)
        {
            var bankAccount = this.service.GetAccountDTO(model.Id);

            if (bankAccount is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            this.service.DepositMoney(bankAccount, model.Amount);

            return RedirectToAction("List");
        }

        /// <summary>
        /// Withdraw from account
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Withdraw()
        {
            return View();
        }

        /// <summary>
        /// Withdraw from account
        /// </summary>
        /// <param name="model">Current model of <see cref="DepositWithdrawViewModel"/></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        public ActionResult Withdraw(DepositWithdrawViewModel model)
        {
            var bankAccount = this.service.GetAccountDTO(model.Id);

            if (bankAccount is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            this.service.WithdrawMoney(bankAccount, model.Amount);

            return RedirectToAction("List");
        }

        /// <summary>
        /// Close account
        /// </summary>
        /// <param name="id">The ID of <see cref="AccountViewModel"/></param>
        /// <returns>RedirectToAction</returns>
        [HttpGet]
        public ActionResult Close(int id)
        {
            var bankAccount = this.service.GetAccountDTO(id);

            if (bankAccount is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            this.service.CloseAccount(bankAccount);

            return RedirectToAction("List");
        }

        /// <summary>
        /// Transfer amount of money to another account
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Transaction()
        {
            return View();
        }

        /// <summary>
        /// Transfer amount of money to another account
        /// </summary>
        /// <param name="model">Current model of <see cref="TransactionViewModel"/></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        public ActionResult Transaction(TransactionViewModel model)
        {
            var fromAccount = this.service.GetAccountDTO(model.FromAccount);

            var toAccount = this.service.GetAccountDTO(model.ToAccount);

            if (fromAccount is null)
            {
                throw new ArgumentNullException(nameof(fromAccount));
            }

            if (toAccount is null)
            {
                throw new ArgumentNullException(nameof(toAccount));
            }

            this.service.Transaction(fromAccount, toAccount, model.AmountOfMoney);

            return RedirectToAction("List");
        }
    }
}