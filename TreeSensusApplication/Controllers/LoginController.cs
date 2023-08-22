using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web.Mvc;
using TreeSensusApplication.Models;
namespace TreeSensusApplication.Controllers
{
    public class LoginController : Controller
    {
        Tree_Sensus_Report_DBEntities1 db;
        public LoginController()
        {
            db = new Tree_Sensus_Report_DBEntities1();
        }


        private readonly IHttpContextAccessor contx;

        public LoginController(IHttpContextAccessor httpcontextaccessor)
        {
            contx = httpcontextaccessor;
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(System.Web.Mvc.FormCollection form)
        {
            string email = form["txtemail"];
            string pass = form["txtpassword"];


            //Session["eml"] = email;
            //Session["pss"] = pass;

            tbl_User_Details st = db.tbl_User_Details.FirstOrDefault(e => e.Email.Equals(email) & e.password.Equals(pass));
            if (st != null)
            {

                Session["userid"] = st.user_id;
                //Session["student_id"] = st.student_id;
                //Session["email_address"] = st.email_address;
                //Session["student"] = st;
                //Session.Timeout = 1;
                //contx.HttpContext.Session.SetString("studentname", "john");
                //contx.HttpContext.Session.SetInt32("studentid", st.user_id);
                return RedirectToAction("AddData", "AddTree");

            }
            else
            {
                ViewBag.msg = "Invalid Email Address or Password";
                return View();
            }
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            ViewBag.stud = db.tbl_User_Details.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(tbl_User_Details student)
        {

            db.tbl_User_Details.Add(student);
            db.SaveChanges();
            ModelState.Clear();
            ViewBag.msg = "Registered successfully...!";
            ViewBag.stud = db.tbl_User_Details.ToList();
            return View();

        }
        public ActionResult Logout()
        {
            Session["userid"] = null;
            return RedirectToAction("Login");
        }
    }
}