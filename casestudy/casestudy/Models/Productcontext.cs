using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace casestudy.Models
{
    public class Productcontext:DbContext
    {
        public Productcontext() : base("name=Dbconfig")
        {




        }
        public DbSet<Product> productdetails { get; set; }
    }
}
