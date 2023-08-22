using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using TreeSensusApplication.Models;

namespace TreeSensusApplication.Controllers
{
    public class AddTreeController : Controller
    {
        Tree_Sensus_Report_DBEntities1 db;
        public AddTreeController()
        {
            db = new Tree_Sensus_Report_DBEntities1();
        }

        [HttpGet]
        public ActionResult AddData()
        {
            ViewBag.status = GetStatus();
            ViewBag.ownership = GetOwnership();
            ViewBag.stud = db.tbl_Tree_Details.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddData(tbl_Tree_Details data,HttpPostedFileBase photo)
        {
            int i = 1;
            if(photo.ContentLength>0)
            {               
                string photoname = photo.FileName;
                //string photoname = data.owner_name+""+i+Path.GetExtension(photo.FileName);
                string imgpath = Server.MapPath("~/TreePhotos/" + photoname);
                photo.SaveAs(imgpath);
                data.photo = photoname;
                db.tbl_Tree_Details.Add(data);
                db.SaveChanges();
            }
            i++;
            return RedirectToAction("GetAllTrees","AddTree");
        }

        [HttpGet]
        public ActionResult GetAllTrees()
        {
            string uid = Session["userid"].ToString();
            int mid=Int32.Parse(uid);           
            ViewBag.uid = uid;
            List<tbl_Tree_Details> list = db.tbl_Tree_Details.Where(e => e.user_id==mid).ToList();
            return View(list);
        }










        public List<SelectListItem>GetStatus()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem s1 = new SelectListItem { Text = "Good", Value = "Good" };
            SelectListItem s2 = new SelectListItem { Text = "Avarage", Value = "Avarage" };
            SelectListItem s3 = new SelectListItem { Text = "Bad", Value = "Bad" };
            SelectListItem s4 = new SelectListItem { Text = "Dead", Value = "Dead" };

            list.Add(s1);
            list.Add(s2);
            list.Add(s3);
            list.Add(s4);

            return list;
        }

        public List<SelectListItem>GetOwnership()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem s1 = new SelectListItem { Text = "Private", Value = "Private" };
            SelectListItem s2 = new SelectListItem { Text = "Government", Value = "Private" };
            SelectListItem s3 = new SelectListItem { Text = "Garden", Value = "Private" };
            SelectListItem s4 = new SelectListItem { Text = "Roadside", Value = "Private" };

            list.Add(s1);
            list.Add(s2);
            list.Add(s3);
            list.Add(s4);

            return list;
        }






    }
}