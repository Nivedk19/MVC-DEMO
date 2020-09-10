using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using casestudy.Models;

namespace casestudy.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Admin
        private Productcontext productcontext = new Productcontext();

        public ActionResult Listofproduct()
        {
            return View(productcontext.productdetails.ToList());
        }
        public ActionResult Adding()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adding(Product product)
        {
            if(ModelState.IsValid)
            {
                productcontext.productdetails.Add(product);
                productcontext.SaveChanges();
                return RedirectToAction("Listofproduct");
            }
            else
            {
                ModelState.AddModelError("", "please check the feilds and entered values");
                return View(product);
            }

            
        }
          public ActionResult edit(int ?id)
          {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productcontext.productdetails.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
          }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit([Bind(Include = "productid,productname,Categoryname,Units,Price,discount")] Product product)
        {   if (ModelState.IsValid)
            {
                productcontext.Entry(product).State = EntityState.Modified;
                productcontext.SaveChanges();
                return RedirectToAction("Listofproduct");
            }
           else
            return View(product);
        }
        public ActionResult detials(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productcontext.productdetails.Find(id);
            if ( product== null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = productcontext.productdetails.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product products = productcontext.productdetails.Find(id);
            productcontext.productdetails.Remove(products);
            productcontext.SaveChanges();
            return RedirectToAction("Index");
        }



    }  
}