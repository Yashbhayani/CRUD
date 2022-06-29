using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USER_CRUD.Yash
{
    public class Login
    {
        [Required(ErrorMessage = "Not enter Email Id")]
        [Display(Name = "Email")]
        public string email1 { get; set; }

        [Required(ErrorMessage = "PassWord is Required")]
        [Display(Name = "Password & M.No")]
        public string mobo { get; set; }
    }
}