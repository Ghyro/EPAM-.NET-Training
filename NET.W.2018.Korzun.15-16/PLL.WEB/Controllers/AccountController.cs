using AutoMapper;
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

        public AccountController(IBankService service)
        {
            this.service = service;
        }

        public ActionResult List()
        {
            IEnumerable<AccountDTO> accountDTOs = service.GetAccounts();

            var mapper = new MapperConfiguration(m => m.CreateMap<AccountDTO, AccountViewModel>()).CreateMapper();

            var accounts = mapper.Map<IEnumerable<AccountDTO>, List<AccountViewModel>>(accountDTOs);

            return View(accounts);
        }
    }
}