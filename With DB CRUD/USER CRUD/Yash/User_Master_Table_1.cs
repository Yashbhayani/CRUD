//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USER_CRUD.Yash
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User_Master_Table_1
    {
        public int User_MasterID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string User_MasterFName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string User_MasterSName { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string User_MasterEmail { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(10, ErrorMessage = "Mobile Number Not Should be 11 digit!")]
        [MaxLength(10, ErrorMessage = "Mobile Number Not Should be 11 digit!")]
        public string User_Master_MO_BO { get; set; }
    }
}