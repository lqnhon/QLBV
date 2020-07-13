using QLBV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBV.Controllers
{
    public class NoacceptController : Controller
    {
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
            var list = dt.SP_List_Noaccept(Get_ID(), key);
            foreach (var d in list)
            {
                stt++;
                string del = " <a href=\"javascript:void()\" onclick=\"DeletePage(" + d.iD + ",'id=" + d.iD + "','/editor/dell')\" class='btn btn-danger btn-mini'><i class='icon-remove'></i>&nbsp;Xóa&nbsp;</a> ";
                string edit = "<a href='/editor/edit/?id=" + d.iD + "' class='btn btn-primary btn-mini'><i class='icon-pencil'></i>&nbsp;Sửa&nbsp;</a> ";
              
                str += "<tr id='tr_"+d.iD+"'><td class=tcenter>" + stt + "</td><td class=tcenter>" + d.dCreateDate + "</td><td> <a href='/content/detail/?id=" + d.iD + "'>" + d.cTopic + "</a></td><td class=tcenter>" + edit + del + "</td></tr>";
            }
            return str;
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
