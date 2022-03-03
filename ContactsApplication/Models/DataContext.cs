using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ContactsApplication.Models
{
    public class DataContext :DbContext
    {
        public DbSet<User> user { get; set; }

        public DbSet<Contact> contact { get; set; }

        public System.Data.Entity.DbSet<ContactsApplication.Models.ContactViewModel> ContactViewModels { get; set; }
    }
}