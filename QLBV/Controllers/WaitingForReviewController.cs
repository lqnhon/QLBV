using QLBV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBV.Controllers
{
    public class WaitingForReviewController : Controller
    {
        //
        // GET: /WaitingForReview/

        Entities dt = new Entities();
        public ActionResult list()
        {
            ViewData["data"] = List_Editing("");
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
        public string List_Editing(string key)
        {
            string str = "";
            int stt = 0;
            var list = dt.SP_List_WaitingForReview(Get_ID(), key);
            foreach (var d in list)
            {
                stt++;
                string next = "<a href=\"javascript:void()\" onclick=\"HuyGuiDuyet('" + d.iD + "','id=" + d.iD + "','/waitingForReview/next')\" class='btn btn btn-warning  btn-mini'><i class=' icon-refresh'></i>&nbsp;Hủy chuyển duyệt &nbsp;</a>";

                str += "<tr id='tr_" + d.iD + "'><td class=tcenter>" + stt + "</td><td class=tcenter>" + d.dCreateDate + "</td><td> <a href='/content/detail/?id=" + d.iD + "'>" + d.cTopic + "</a></td><td class=tcenter>" +  next + "</td></tr>";
            }
            return str;
        }
        public ActionResult next(int id)
        {
            tblContent c = dt.tblContents.Single(v => v.iD.Equals(id));
            c.iStatus = 1;
            dt.SaveChanges();
            Response.Write(1);
            return null;
        }
        public ActionResult search(string key)
        {
            string data = "";
            data = List_Editing(key);
            Response.Write(data);
            return null;
        }
    }
}
