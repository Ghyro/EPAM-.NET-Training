using AutoMapper;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_PL.Models;

namespace WEB_PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBankService service;

        public HomeController(IBankService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            IEnumerable<AccountDTO> accounts = service.GetAccounts();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AccountDTO, Account>()).CreateMapper();

            var phones = mapper.Map<IEnumerable<AccountDTO>, List<Account>>(accounts);

            return View(accounts);
        }

        public ActionResult Create()
        {
            SelectList selects = new SelectList (new[] {service. })
        }
    }
}