using QLBV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBV.Controllers
{
    public class AcceptController : Controller
    {
        Entities dt = new Entities();
        public int Get_ID()
        {
            int id_user = 0;
            if (Request.Cookies["user_id"] != null)
            {
                id_user = Convert.ToInt32(Request.Cookies["user_id"].Value);
            }
            return id_user;
        }
        public ActionResult list()
        {
            ViewData["data"] = List_Editing();
            return View();
        }
        public string List_Editing()
        {
            string str = "";
            int stt = 0;
            var list = dt.tblUsers.Where(v => v.iDelete == 0).ToList();
            foreach (var d in list)
            {
                if (dt.tblUserGroups.Where(v => v.iUser == (int)d.iD && v.iGroup == 3).Count() > 0)
                {
                    stt++;
                    str += "<tr id='tr_" + d.iD + "'><td class=tcenter>" + stt + "</td><td>" + d.cName + "</td><td class=tcenter>" + dt.tblContents.Where(v => v.iCreateBy == (int)d.iD && v.iStatus == 2 && v.iDelete == 0).Count() + "</td><td class=tcenter><a href='/accept/detail/?id=" + d.iD + "'><i class= icon-external-link></i></a></td></tr>";
                }
            }
            return str;
        }
        public ActionResult detail(int id)
        {
            ViewData["cName"] = dt.tblUsers.Single(v => v.iD.Equals(id)).cName;
            ViewData["data"] = List_Editing("", id);
            return View();
        }
        public string List_Editing(string key, int iemployee)
        {
            string str = "";
            int stt = 0;
            var list = dt.SP_List_Accept_ByEmployee(key,iemployee);
            foreach (var d in list)
            {
                stt++;
                string duyet = "<a href=\"javascript:void()\" onclick=\"Duyet('" + d.iD + "','id=" + d.iD + "','/accept/next')\" class='btn btn btn-success   btn-mini'><i class=' icon-refresh'></i>&nbsp;Duyệt &nbsp;</a> ";
                string khongduyet = "<a href=\"javascript:void()\" onclick=\"BoDuyet('" + d.iD + "','id=" + d.iD + "','/accept/back')\" class='btn btn btn-danger   btn-mini'><i class=' icon-refresh'></i>&nbsp;Không duyệt &nbsp;</a>";

                str += "<tr id='tr_" + d.iD + "'><td class=tcenter>" + stt + "</td><td class=tcenter>" + d.dCreateDate + "</td><td> <a href='/content/detail/?id=" + d.iD + "'>" + d.cTopic + "</a></td><td class=tcenter>" + duyet + khongduyet + "</td></tr>";
            }
            return str;
            
        }
     
        public ActionResult next(int id)
        {
            tblContent c = dt.tblContents.Single(v => v.iD.Equals(id));
            c.iStatus = 3;
            dt.SaveChanges();
            Response.Write(1);
            return null;
        }
        public ActionResult back(int id)
        {
            tblContent c = dt.tblContents.Single(v => v.iD.Equals(id));
            c.iStatus = 4;
            dt.SaveChanges();
            Response.Write(1);
            return null;
        }
        public ActionResult search(string key,int iem)
        {
            string data = "";
            data = List_Editing(key,iem);
            Response.Write(data);
            return null;
        }
    }
}
