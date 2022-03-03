using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ContactsApplication.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "SecretCode is Required")]
        [DataType(DataType.Password)]
        public string Secret { get; set; }
    }
}