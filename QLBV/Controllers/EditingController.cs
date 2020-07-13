using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBV.Models;
namespace QLBV.Controllers
{
    public class EditingController : Controller
    {
        //
        // GET: /Editing/
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
            var list = dt.SP_List_Editing(Get_ID(), key);
            foreach (var d in list)
            {
                stt++;
                string del = " <a href=\"javascript:void()\" onclick=\"DeletePage(" + d.iD + ",'id=" + d.iD + "','/editor/dell')\" class='btn btn-danger btn-mini'><i class='icon-remove'></i>&nbsp;Xóa&nbsp;</a> ";
                string edit = "<a href='/editor/edit/?id=" + d.iD + "' class='btn btn-primary btn-mini'><i class='icon-pencil'></i>&nbsp;Sửa&nbsp;</a> ";
                string next = "<a href=\"javascript:void()\" onclick=\"GuiDuyet('"+d.iD+"','id=" + d.iD + "','/editing/next')\" class='btn btn btn-info btn-mini'><i class=' icon-refresh'></i>&nbsp;Chuyển duyệt &nbsp;</a>";

                str += "<tr id='tr_" + d.iD + "'><td class=tcenter>" + stt + "</td><td class=tcenter>" + d.dCreateDate + "</td><td> <a href='/content/detail/?id=" + d.iD + "'>" + d.cTopic + "</a></td><td class=tcenter>" + edit + del + next + "</td></tr>";
            }
            return str;
        }
        public ActionResult next(int id)
        {
            tblContent c = dt.tblContents.Single(v => v.iD.Equals(id));
            c.iStatus = 2;
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
