using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plutus.Web.Controllers {
    /// <summary>
    /// TODO
    /// </summary>
    public class HomeController : Controller {


        /// <summary>
        /// TODO
        /// </summary>
        public ActionResult Index() {
            if (Request.IsAuthenticated) {
                return RedirectToAction("AuthenticatedIndex", "Home");
            }
            return View();
        }
        /// <summary>
        /// TODO
        /// </summary>
        public ActionResult AuthenticatedIndex() {
            return View();
        }
    }
}