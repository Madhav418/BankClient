using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankClient.Controllers
{
    [TypeAuthorization("User")]
    public class UserTransactionsController : Controller
    {
        // GET: UserTransactions
        public ActionResult Operations()
        {
            return View();
        }
    }
}