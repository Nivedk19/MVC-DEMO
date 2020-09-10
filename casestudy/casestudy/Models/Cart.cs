using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace casestudy.Models
{
    public class Cart
    {
        [Key,Column(Order =1)]
        [DataType(DataType.EmailAddress)]
        public int Userid { get; set; }
        [Key, Column(Order = 2)]
        public int Productid { get; set; }
        public string Productname { get; set; }
        public int Noofproducts { get; set; }
        [ForeignKey("productid")]
        public Product product { get; set; }
        [ForeignKey("Usertid")]
        public user user { get; set; }
        




    }

}