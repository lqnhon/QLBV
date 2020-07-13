using QLBV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBV.App_Code;
namespace QLBV.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/
        Entities dt = new Entities();
        Function func = new Function();
        public int Get_ID()
        {
            int id_user = 0;
            if (Request.Cookies["user_id"] != null)
            {
                id_user = Convert.ToInt32(Request.Cookies["user_id"].Value);
            }
            return id_user;
        }
        public ActionResult detail(int id)
        {
            ViewData["id"] = id;
            tblContent c = dt.tblContents.Single(v => v.iD.Equals(id));
            ViewData["cTopic"] = c.cTopic;
            ViewData["cDescribe"] = c.cDescribe;
            ViewData["cContent"] = c.cContent;
            ViewData["cKey"] = c.cKey;
            ViewData["cName"] = dt.tblUsers.Single(v => v.iD.Equals((int)c.iCreateBy)).cName;
            ViewData["cmt"] = List_Coment(id);
            return View();
        }
        public string List_Coment(int id)
        {
            string str = "";
            var list = dt.tblComments.Where(v => v.iContent == id).ToList().OrderByDescending(v => v.dCreateDate);
            foreach (var c in list)
            {
                str += "<p id=\"tr_" + c.iD + "\" class=\"user-linda\" style=\"display: block;\"><span class=\"msg-block\"><strong>" + dt.tblUsers.Single(v => v.iD.Equals((int)c.iCreateBy)).cName + "</strong> <span class=\"time\">" + Convert.ToDateTime(c.dCreateDate).Hour + ":" + Convert.ToDateTime(c.dCreateDate).Minute + " (" + func.ConvertDateVN(Convert.ToDateTime(c.dCreateDate).ToShortDateString()) + ") <a href=\"javascript:void()\" onclick=\"DeletePage(" + c.iD + ",'id=" + c.iD + "','/content/dell')\"><i class=icon-trash style=color: red;></i></a></span><span class=\"msg\">" + c.cContent + "</span></span></p>";
            }
            return str;
        }
        public ActionResult list()
        {
            ViewData["data"] = List_Content_ByEmployee();
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
        public string List_Content_ByEmployee()
        {
            string str = "";
            int stt = 0;
            var list = dt.tblUsers.Where(v => v.iDelete == 0).ToList();
            foreach (var d in list)
            {
                if (dt.tblUserGroups.Where(v => v.iUser == (int)d.iD && v.iGroup == 3).Count() > 0)
                {
                    stt++;
                    str += "<tr id='tr_" + d.iD + "'><td class=tcenter>" + stt + "</td><td>" + d.cName + "</td><td class=tcenter>" + dt.tblContents.Where(v => v.iCreateBy == (int)d.iD && v.iStatus == 3 && v.iDelete == 0).Count() + "</td><td class=tcenter><a href='/content/listcontent/?id=" + d.iD + "'><i class= icon-external-link></i></a></td></tr>";
                }
            }
            return str;
        }
        public string List_Content(string key,int employee)
        {
            string str = "";
            int stt = 0;
            var list = dt.SP_List_Content_ByEmployee(key,employee);
            foreach (var d in list)
            {
                stt++;
                string check = "<input " + Checked(d.iStatus.ToString()) + " type='checkbox' onclick=\"UpdateStatus('" + d.iD + "','id=" + d.iD + "&type=hienthi','/content/active')\" />";

                str += "<tr id='tr_" + d.iD + "'><td class=tcenter>" + stt + "</td><td class=tcenter>" + d.dCreateDate + "</td><td> <a href='/content/detail/?id=" + d.iD + "'>" + d.cTopic + "</a></td><td class=tcenter>" + check + "</td></tr>";
            }
            return str;
        }
        public ActionResult listcontent(int id)
        {
            ViewData["cName"] = dt.tblUsers.Single(v => v.iD.Equals(id)).cName;
            ViewData["data"] = List_Content("", id);
            return View();
        }
        public ActionResult active(int id)
        {
            tblContent u = dt.tblContents.Single(v => v.iD.Equals(id));
            u.iStatus = 5;// Đã xử lý
            dt.SaveChanges();
            Response.Write(1);
            return null;
        }
        public ActionResult chat(FormCollection fc)
        {
            tblComment c = new tblComment();
            c.cContent = fc["msg-box"];
            c.iContent = Convert.ToInt32(fc["id"]);
            c.iCreateBy = Get_ID();
            c.dCreateDate = DateTime.Now;
            dt.tblComments.Add(c);
            dt.SaveChanges();
            string data = "<p id=\"tr_" + c.iD + "\" class=\"user-linda\" style=\"display: block;\"><span class=\"msg-block\"><strong>" + dt.tblUsers.Single(v => v.iD.Equals((int)c.iCreateBy)).cName + "</strong> <span class=\"time\">" + Convert.ToDateTime(c.dCreateDate).Hour + ":" + Convert.ToDateTime(c.dCreateDate).Minute + " (" + func.ConvertDateVN(Convert.ToDateTime(c.dCreateDate).ToShortDateString()) + ") <a href=\"javascript:void()\" onclick=\"DeletePage(" + c.iD + ",'id=" + c.iD + "','/content/dell')\"><i class=icon-trash style=color: red;></i></a></span><span class=\"msg\">" + c.cContent + "</span></span></p>";
            Response.Write(data);
            return null;
        }
        public ActionResult dell(int id)
        {
            tblComment c = dt.tblComments.Single(v => v.iD.Equals(id));
            dt.tblComments.Remove(c);
            dt.SaveChanges();
            Response.Write(1);
            return null;
        }
        public ActionResult search(string key,int iemployee)
        {
            string data = "";
            data = List_Content(key,iemployee);
            Response.Write(data);
            return null;
        }
    }
}
