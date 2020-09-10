using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace casestudy.Models
{
    public class Contextall:DbContext
    {
        public Contextall() : base("name=Dbconfig")
        {




        }
        public DbSet<Transaction> Transactions { get; set; }
       
        
        public DbSet<Feedback> Feedback { get; set; }

        
    }
}