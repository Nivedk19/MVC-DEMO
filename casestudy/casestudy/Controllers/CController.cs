using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult Detials(int ?id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productcontext.productdetails.Find(id);
            var offerprice = product.price - product.discount;
            ViewBag.a = offerprice;
            if(product==null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}