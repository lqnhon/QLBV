using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBV.Models;
using System.IO;
using System.Globalization;
namespace QLBV.Controllers
{
    public class EditorController : Controller
    {
        //
        // GET: /Editor/
        Entities dt = new Entities();
        public ActionResult add()
        {
            return View();
        }
        public int Get_ID()
        {
            int id_user = 0;
            if (Request.Cookies["user_id"] != null)
            {
                id_user = Convert.ToInt32(Request.Cookies["user_id"].Value);
            }
            return id_user;
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult add(FormCollection fc)
        {

            tblContent c = new tblContent();
            //1 là lưu tạm thời
            // 2 lưu chuyển duyệt
            string url = "";
            if (fc["chosen"] == "1")
            {
                c.cTopic = fc["cTopic"];
                c.cDescribe = fc["cDescribe"];
                c.cContent = fc["cContent"];
                c.cKey = fc["cKey"];
                c.dCreateDate = DateTime.Now;
                c.iCreateBy = Get_ID();
                c.iStatus = 1;
                c.iDelete = 0;
                url = "/editing/list";
            }
            else
            {
                c.cTopic = fc["cTopic"];
                c.cDescribe = fc["cDescribe"];
                c.cContent = fc["cContent"];
                c.cKey = fc["cKey"];
                c.dCreateDate = DateTime.Now;
                c.iCreateBy = Get_ID();
                c.iStatus = 2;
                c.iDelete = 0;
                url = "/waitingforreview/list";
            }
            dt.tblContents.Add(c);
            dt.SaveChanges();
            Response.Redirect(url);
            return null;
        }
        public ActionResult edit(int id)
        {
            ViewData["id"] = id;
            tblContent c = dt.tblContents.Single(v => v.iD.Equals(id));
            ViewData["cTopic"] = c.cTopic;
            ViewData["cContent"] = c.cContent;
            ViewData["cDescribe"] = c.cDescribe;
            ViewData["cKey"] = c.cKey;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult edit(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["id"]);
            tblContent c = dt.tblContents.Single(v => v.iD.Equals(id));
            //1 là lưu tạm thời
            // 2 lưu chuyển duyệt
            string url = "";
            if (c.iStatus == 1)
            {
                url = "/editing/list";
            }
            else if (c.iStatus == 2)
            {
                url = "/waitingforreview/list";
            }
            else
            {
                c.iStatus = 2;
                url = "/noaccept/list";
            }
            c.cTopic = fc["cTopic"];
            c.cDescribe = fc["cDescribe"];
            c.cContent = fc["cContent"];
            c.cKey = fc["cKey"];
            dt.SaveChanges();
            Response.Redirect(url);
            return null;
        }
        public ActionResult dell(int id)
        {
            tblContent u = dt.tblContents.Single(v => v.iD.Equals(id));
            dt.tblContents.Remove(u);
            dt.SaveChanges();
            Response.Write(1);
            return null;
            
        }
    }
}
