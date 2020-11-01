using BusinessObjectsLayer;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        DataContext dataContext = new DataContext();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            UserBO objUserBO = new UserBO();
            return View(objUserBO);
        }

        [HttpPost]
        public ActionResult Register(UserBO userBO)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                userBO = new UserBO();

                user.FirstName = userBO.FirstName;
                user.LastName = userBO.LastName;
                user.Password = userBO.Password;
                user.Email = userBO.Email;
                user.CreatedOn = DateTime.Now;
                userBO.SuccessMessage = "User has been added successfully.";

                dataContext.Users.Add(user);
                dataContext.SaveChanges();

               
                return View("Register");
            }

            return View();
        }

        public ActionResult Login()
        {
            LoginBO loginBO = new LoginBO();
            return View(loginBO);
        }

        [HttpPost]
        public ActionResult Login(LoginBO loginBO)
        {
            if (ModelState.IsValid)
            {
                if (dataContext.Users.Where(m=>m.Email==loginBO.Email && m.Password==loginBO.Password).FirstOrDefault()==null)
                {
                    ModelState.AddModelError("Error", "Email or Password is not correct.");
                    return View();
                }
                else
                {
                    Session["Email"] = loginBO.Email;

                    RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}