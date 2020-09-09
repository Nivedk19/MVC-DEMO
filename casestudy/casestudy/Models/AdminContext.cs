using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace casestudy.Models
{
    public class AdminContext:DbContext
    {
        public AdminContext():base("name=Dbconfig")
        {

        }
        public DbSet<Admin> admins { get; set; }

    }
}