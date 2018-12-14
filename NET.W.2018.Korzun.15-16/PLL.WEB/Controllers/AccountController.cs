using AutoMapper;
using BLL.BankFactory;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
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
        private readonly IBankAccountFactory factory;

        public AccountController(IBankService service, IBankAccountFactory factory)
        {
            this.factory = factory;
            this.service = service;
        }

        public ActionResult List()
        {
            IEnumerable<BankAccountDTO> accountDTOs = service.GetAccounts();

            var mapper = new MapperConfiguration(m => m.CreateMap<BankAccountDTO, AccountViewModel>()).CreateMapper();

            var accounts = mapper.Map<IEnumerable<BankAccountDTO>, List<AccountViewModel>>(accountDTOs);

            return View(accounts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                BankAccountDTO account = new BankAccountDTO(model.Id, model.Name, model.Surname, model.Balance, model.Bonus);

                service.Add(account);

                return RedirectToAction("List");
            }
            else
            {
                throw new Exception(nameof(model));
            }
        }
    }
}