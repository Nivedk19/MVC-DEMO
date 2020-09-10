using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace casestudy.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TID { get; set; }
        [DataType(DataType.EmailAddress)]
        public string userid { get; set; }
        public string productid { get; set; }
        public int noofproducts { get; set; }
        public double Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime TDate { get; set; }
        [ForeignKey("Userid")]
        public user user { get; set; }
        [ForeignKey("productid")]
        public Product product { get; set; }
    }
}