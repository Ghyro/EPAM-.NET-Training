using AutoMapper;
using BLL.Interface.DTO;
using BLL.Interface.Interfaces;
using PLL.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLL.WEB.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }        
    }
}