using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using casestudy.Models;

namespace casestudy.Controllers
{
    public class CController : Controller
    {
        // GET: C
        private Productcontext productcontext = new Productcontext();
        public ActionResult cview()
        {
            return View(productcontext.productdetails.ToList());
        }
    }
}