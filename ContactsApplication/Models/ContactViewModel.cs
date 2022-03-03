using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactsApplication.Models
{
    public class ContactViewModel
    {
        [Key]
        public int ContactKey { get; set; }
        public Contact contact { get; set; }

        public IEnumerable<Contact> LContacts { get; set; }
    }
}