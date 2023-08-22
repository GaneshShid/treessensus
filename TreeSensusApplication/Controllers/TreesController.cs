using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TreeSensusApplication.Models;

namespace TreeSensusApplication.Controllers
{
    public class TreesController : ApiController
    {
        Tree_Sensus_Report_DBEntities1 db;
        public TreesController()
        {
            db = new Tree_Sensus_Report_DBEntities1();
        }




        //[HttpGet]
        //[Route("api/GetAll")]
        //public List<tbl_Tree_Details> GetAllData()
        //{
        //    List<tbl_Tree_Details> list = db.tbl_Tree_Details.ToList();
        //    return list;
        //}

        //[HttpGet]   
        //[Route("api/getbyid/{id}")]
        //public List<tbl_Tree_Details> getByUserId(int id)
        //{
        //    List<tbl_Tree_Details> data = db.tbl_Tree_Details.Where(e => e.user_id == id).ToList();
        //    return data;
        //}





























    }
}
