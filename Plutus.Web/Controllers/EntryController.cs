using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plutus.Web.Controllers
{
    public class EntryController : Controller
    {
        // GET: Entry
        public ActionResult CreateNew()
        {
            return View("EntryEdit");
        }
    }
}