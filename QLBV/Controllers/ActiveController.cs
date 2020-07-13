using QLBV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBV.Controllers
{
    public class ActiveController : Controller
    {
        //
        // GET: /Active/
        Entities dt = new Entities();
        public ActionResult list()
        {
            ViewData["data"] = list_active_byemployee();
            return View();
        }
        public string Checked(string status)// check hien thi
        {
            if (status == "1")
            {
                return "checked";
            }
            else
            {
                return "";
            }
        }
        public string list_active_byemployee()
        {
            string str = "";
            int stt = 0;
            var list = dt.tblUsers.Where(v => v.iDelete == 0).ToList();
            foreach (var d in list)
            {
                if (dt.tblUserGroups.Where(v => v.iUser == (int)d.iD && v.iGroup == 3).Count() > 0)
                {
                    stt++;
                    str += "<tr id='tr_" + d.iD + "'><td class=tcenter>" + stt + "</td><td>" + d.cName + "</td><td class=tcenter>" + dt.tblContents.Where(v => v.iCreateBy == (int)d.iD && v.iStatus == 5 && v.iDelete == 0).Count() + "</td><td class=tcenter><a href='/active/detail/?id=" + d.iD + "'><i class= icon-external-link></i></a></td></tr>";
                }
            }
            return str;
        }
        public ActionResult detail(int id)
        {
            ViewData["cName"] = dt.tblUsers.Single(v => v.iD.Equals(id)).cName;
            ViewData["data"] = list_active("", id);
            return View();
        }
        public string list_active(string key,int employee)
        {
            string str = "";
            int stt = 0;
            var list = dt.SP_List_Active_ByEmployee(key, employee);
            foreach (var d in list)
            {
                stt++;
                string check = "<input " + Checked(d.iStatus.ToString()) + " type='checkbox' onclick=\"UpdateStatus('" + d.iD + "','id=" + d.iD + "&type=hienthi','/active/active')\" />";
                str += "<tr id='tr_" + d.iD + "'><td class=tcenter>" + stt + "</td><td class=tcenter>" + d.dCreateDate + "</td><td> <a href='/content/detail/?id=" + d.iD + "'>" + d.cTopic + "</a></td><td class=tcenter>" + check + "</td></tr>";
     
            }
            return str;
        }
        public ActionResult active(int id)
        {
            tblContent u = dt.tblContents.Single(v => v.iD.Equals(id));
            u.iStatus = 3;// Đã xử lý
            dt.SaveChanges();
            Response.Write(1);
            return null;
        }
        public ActionResult search(string key,int iemployee)
        {
            string data = "";
            data = list_active(key, iemployee);
            Response.Write(data);
            return null;
        }
    }
}
