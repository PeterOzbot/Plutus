using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Plutus.Portable.Data;

namespace Plutus.Web.Controllers {
    public class EntryController : Controller {
        /// <summary>
        /// TODO
        /// </summary>
        [Dependency]
        public IEntryContext EntryContext { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateNew() {
            return View("EntryEdit");
        }

        /// <summary>
        /// TODO
        /// </summary>
        [Authorize]
        public JsonResult CreateEntry(double value, string description) {
            try {
                // create
                IEntry createdEntry = EntryContext.Create(value, description);

                // return
                return Json(new { Success = true, Entry = createdEntry }, JsonRequestBehavior.AllowGet);
            }
            catch {
                // TODO: error logging
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}