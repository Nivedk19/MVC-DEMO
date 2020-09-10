using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace casestudy.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int feedbackid { get; set; }
        [Required]
        public string productid { get; set; }
        [Required]
        public string productname { get; set; }
        [Required]
        public string feedback { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string userid { get; set; }
        [ForeignKey("productid")]
        public Product product { get; set; }
        [ForeignKey("Userid")]
        public user user { get; set; }


    }

}