using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using casestudy.Models;

namespace casestudy.Controllers
{
    public class MainController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
       
        
        public ActionResult regestration()
        {
            return View();
        }
        private usercontext usercontext = new usercontext();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult regestration(user user)
        {
            var obj = usercontext.userdetails.Where(u => u.Email == user.Email).FirstOrDefault();

            if (obj != null)
            {
                ModelState.AddModelError("", "user already exist");
                goto y;
            }
            else if (ModelState.IsValid)
            {
                usercontext.userdetails.Add(user);
                usercontext.SaveChanges();
                return RedirectToAction("Index");
            }
             else 
            {
              ModelState.AddModelError("", "ERROR HAS OCCURED");
            }

           y: return View(user);

        }

        

        public ActionResult log()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult log(user user)
        {
            using (usercontext db1 = new usercontext())
            {
                var obj = db1.userdetails.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
                if (obj != null)
                {
                    Session["email"] = obj.Email.ToString();
                    Session["password"] = obj.Password.ToString();
                    return RedirectToAction("cview", "C");
                }
                else if (obj == null)
                {
                    using (AdminContext adminContext = new AdminContext())
                    {
                        var obje = adminContext.admins.Where(v => v.email == user.Email && v.password == user.Password).FirstOrDefault();
                        if (obje == null&&obje==null)
                            goto x;
                        else
                        {
                            Session["email"] = obje.email.ToString();
                            Session["password"] = obje.password.ToString();
                            return RedirectToAction("Listofproduct","Administrator");
                        }
                    }
                }
            x: ModelState.AddModelError("", "please regester or check user name & password");
                return View(user);
            }
           
          
        }

       
        
       
       
       
              

    }          

}