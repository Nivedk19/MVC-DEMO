using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace casestudy.Models
{
    public class Product
    {
        [Key]
        [Required]
        [Display(Name = "product code")]
        public int productid { get; set; }



        [Required(ErrorMessage = "Product Name is required")]
        [Display(Name = "Product Name")]
        public string productname { get; set; }



        [Required(ErrorMessage = "Category Name is required")]
        [Display(Name = "Category Name")]
        public string Categoryname { get; set; }



        [Required(ErrorMessage = "Only Numeric values should be inserted")]
        [Display(Name = "Units")]
        public int units { get; set; }



        [Required(ErrorMessage = "Only Numeric values should be inserted")]
        [Display(Name = "Price")]
        public double price { get; set; }



        [Required(ErrorMessage = "yes or no should be selected")]
        [Display(Name = "Discount")]
        public double discount { get; set; }

        public int money { get; set; }


    }
}