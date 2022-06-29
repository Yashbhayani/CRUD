using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Form.Models
{
    public class Jumbo
    {
        [Required(ErrorMessage = "Please Enter Decimal Value")]
        [Display(Name = "Decimal :-")]
        public float DEC { get; set; }

        public string Answer2 { get; set; }

        [Display(Name = "Answer :-")]
        public string Answer1 { get; set; }
    }
}