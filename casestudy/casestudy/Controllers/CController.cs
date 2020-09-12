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
    public class CController : Controller
    {
        private Contextall cartscontext = new Contextall();
        // GET: C
        private Productcontext productcontext = new Productcontext();
        public ActionResult cview()
        {
            return View(productcontext.productdetails.ToList());
        }
        [HttpPost]
        public ActionResult cview(string key)
        {
            var pr = productcontext.productdetails.Where(u => u.Categoryname.Equals(key)).ToList();
            return View(pr);
        }

        public ActionResult Detials(int ?id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productcontext.productdetails.Find(id);
            var offerprice = product.price - product.discount;
            ViewBag.a = offerprice + "₹";
            if (product==null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        //public ActionResult Tocart(string noofitem, int? productidx)
        //{


        //    string UserIdx = Session["UserId"].ToString();
        //    int noofunits = int.Parse(noofitem);
        //    if (productidx ==null)
        //    {
        //        ViewBag.Error = "Empty";
        //    }
        //    else
        //    {
        //        var p = productcontext.productdetails.Where(pro => pro.productid.Equals(productidx)).FirstOrDefault();
        //        if (noofunits > p.units)
        //        {
        //            ViewBag.Error = "No stock available";
        //        }
        //        else
        //        {
        //            if (cartscontext.Carts.Where(car => car.Productid.Equals(productidx) && car.Userid.Equals(UserIdx)).FirstOrDefault() != null)
        //            {
        //                Cart cart = cartscontext.Carts.Where(car => car.Productid.Equals(productidx) && car.Userid.Equals(UserIdx)).FirstOrDefault();
        //                cart.Noofproducts = cart.Noofproducts + noofunits;
        //                cartscontext.Entry(cart).State = EntityState.Modified;
        //                cartscontext.SaveChanges();
        //            }
        //            else
        //            {
        //                Cart cart = new Cart();
        //                cart.Userid =(int) Session["UserId"];
        //                cart.Productid = p.productid;
        //                cart.Productname = p.productname;
        //                cart.Noofproducts = noofunits;
        //               // cart.am = p.GetAmount(p.Price, p.Discount, noofunits);
        //                cartscontext.Carts.Add(cart);
        //                cartscontext.SaveChanges();
        //            }
        //        }
        //    }
        //    return RedirectToAction("myCart", "C");
        //}
        //public ActionResult myCart()
        //{

        //    return View(cartscontext.Carts.ToList());
        //}
    }

    
}