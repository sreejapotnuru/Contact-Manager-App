using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ContactsApplication.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter Valid Mobile Number")]
        public string PhNo { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Enter a Valid EmailId")]
        public string Email { get; set; }
    }
}