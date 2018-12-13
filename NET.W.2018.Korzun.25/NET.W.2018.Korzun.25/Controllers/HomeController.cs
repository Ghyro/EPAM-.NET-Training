using NET.W._2018.Korzun._25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace NET.W._2018.Korzun._25.Controllers
{
    public class HomeController : Controller
    {
        private AccountContext db = new AccountContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var accounts = db.Accounts.Include(a => a.AccountType);

            return View(accounts.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList accountType = new SelectList(db.AccountTypes, "Id", "Type");

            ViewBag.AccountType = accountType;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Account account)
        {
            db.Accounts.Add(account);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id is null)
            {
                return HttpNotFound();
            }

            var account = db.Accounts.Find(id);

            if (account != null)
            {
                SelectList accountType = new SelectList(db.AccountTypes, "Id", "Type", account.AccountTypeId);

                ViewBag.AccountType = accountType;

                return View(account);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Account account)
        {
            db.Entry(account).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var account = db.Accounts.Find(id);

            if (account is null)
            {
                return HttpNotFound();
            }

            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var account = db.Accounts.Find(id);

            if (account is null)
            {
                return HttpNotFound();
            }

            db.Accounts.Remove(account);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id is null)
            {
                return HttpNotFound();
            }

            var account = db.Accounts.Find(id);

            if (account is null)
            {
                return HttpNotFound();
            }

            return View(account);
        }
    }
}