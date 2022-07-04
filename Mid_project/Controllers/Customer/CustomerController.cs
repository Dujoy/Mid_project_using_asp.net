using Mid_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Mid_project.Controllers.Customer
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(login l)
        {
            if (ModelState.IsValid)
            {
                var db = new MIDEntities();
                var customer = (from e in db.customers
                            where e.email.Equals(l.email)
                            select e).SingleOrDefault();
                if (customer == null)
                {
                    TempData["Msg"] = "Invalid email";
                    return View(l);
                }
                if (customer.password != l.password)
                {
                    TempData["Msg"] = "Incorrect Password";
                    return View(l);
                }

                Session["username"] = customer.username;
                Session["email"] = customer.email;
                
                return RedirectToAction("Home");
            }
            return View(l);
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Profile()
        {
            var uname = (string)Session["username"];

            var db = new MIDEntities();

            var customer = (from e in db.customers
                        where e.username.Equals(uname)
                        select e).SingleOrDefault();
            return View(customer);
            
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Password p)
        {
            var uname = (string)Session["username"];

            var db = new MIDEntities();

            var customer = (from e in db.customers
                            where e.username.Equals(uname)
                            select e).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if(!p.password.Equals(customer.password))
                {
                    TempData["msg"] = "Your current password doesnot match";
                    return View();
                }
                if(!p.password1.Equals(p.password2))
                {
                    TempData["msg"] = "New password and confirm  password doesnot match";
                    return View();
                }
                if (p.password.Equals(p.password1))
                {
                    TempData["msg"] = "New password match with current password";
                    return View();
                }
                customer.password = p.password1;
                db.SaveChanges();
                TempData["msg"] = "Password reset successfully";
                return View();
            }

              return View();
        }

        public ActionResult AddProduct()
        {
            var db = new MIDEntities();
            var product = db.Products.ToList();
            return View(product);
        }
        public ActionResult Add(int id)
        {
            var db = new MIDEntities();

            var product = (from e in db.Products
                            where e.id==id
                            select e).SingleOrDefault();
            var order = new Order();
            order.customer_name= (string)Session["username"];
            order.address = "Dhaka";
            order.amount = product.price;
            order.product = product.name;
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("ShowOrder");
        }
        public ActionResult ShowOrder()
        {
            var db = new MIDEntities();
            var uname = (string)Session["username"];
            var products = (from e in db.Orders
                           where e.customer_name.Equals(uname)
                           select e).ToList();
            return View(products);


        }
        public ActionResult DeleteProduct()
        {
            var db = new MIDEntities();
            var uname = (string)Session["username"];
            var products = (from e in db.Orders
                            where e.customer_name.Equals(uname)
                            select e).ToList();
            return View(products);
        }
        public ActionResult Delete(int id)
        {
            var db = new MIDEntities();

            var order = (from e in db.Orders
                           where e.id == id
                           select e).SingleOrDefault();

            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("ShowOrder");
        }
    }
}