using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactsApplication.Models;
namespace ContactsApplication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            var model = new ContactViewModel();
            model.LContacts = (from products in db.contact
                                       select products).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ContactViewModel model)
        {
            if(model.contact != null)
            {
                var contact = new Contact()
                {
                    Name = model.contact.Name,
                    PhNo = model.contact.PhNo,
                    Email = model.contact.Email
                };
                
                db.contact.Add(contact);
                db.SaveChanges();
                ModelState.Clear();
                
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User account)
        {
            if(ModelState.IsValid)
            {
                using(DataContext db = new DataContext())
                {
                    db.user.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Email + "Successfully Registered";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user1)
        {
            using (DataContext db = new DataContext())
            {
                var usr = db.user.Single(u => u.Email == user1.Email && u.PassWord == user1.PassWord);
                if (usr != null)
                {
                    Session["Email"] = usr.Email.ToString();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is incorrect");
                }
            }
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        
    }
}