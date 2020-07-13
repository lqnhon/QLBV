using QLBV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBV.App_Code;
namespace QLBV.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        Entities dt = new Entities();
        Function func = new Function();
        public ActionResult list()
        {
            ViewData["data"] = List_User("");
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
        public string List_User(string key)
        {
            string str = "";
            int stt = 0;
            var list = dt.SP_List_User(key);
            foreach (var d in list)
            {
                stt++;
                string update = "<a href=\"javascript:void()\" onclick=\"ShowPopUp('id=" + d.iD + "','/employee/user')\" class='btn btn btn-info btn-mini'><i class=' icon-refresh'></i>&nbsp;Thay đổi &nbsp;</a>";
                str += "<tr id='tr_" + d.iD + "'><td class=tcenter>" + stt + "</td><td >" + d.cName + "</td><td class=tcenter>" + d.cUserName + "</td><td class=tcenter>" + update + "</td></tr>";
            }
            return str;
        }
        public ActionResult detail(int id)
        {
            ViewData["id"] = id;
            tblUser u = dt.tblUsers.Single(v => v.iD.Equals(id));
            ViewData["cName"] = u.cName.Trim();
            ViewData["cAddress"] = u.cAddress.Trim();
            ViewData["cPhone"] = u.cPhone.Trim();
            ViewData["cNameFace"] = u.cNameFace.Trim();
            ViewData["cLinkFace"] = u.cLinkFace.Trim();
            ViewData["cCardBank"] = u.cCardBank.Trim();
            ViewData["cUserName"] = u.cUserName.Trim();
            ViewData["Quyen"] = ListQuyen(id);
            return View();
        }
        public string ListQuyen(int id)
        {
            string str = "";
            var list = dt.tblUserGroups.Where(v => v.iUser == id).ToList();
            foreach (var d in list)
            {
                tblGroup g = dt.tblGroups.Single(v => v.iD.Equals((int)d.iGroup));
                str += g.cName + "<br/>";
            }
            return str;
        }
        public ActionResult update(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["id"]);
            tblUser u = dt.tblUsers.Single(v => v.iD.Equals(id));
            u.cName = fc["cName"];
            u.cAddress = fc["cAddress"];
            u.cPhone = fc["cPhone"];
            u.cNameFace = fc["cNameFace"];
            u.cLinkFace = fc["cLinkFace"];
            u.cCardBank = fc["cCardBank"];
            u.cUserName = fc["cUserName"];
            dt.SaveChanges();
            Response.Write(1);
            return null;
        }
        public ActionResult changepass()
        {
            int id = Get_ID();
            ViewData["id"] = id;

            ViewData["cUser"] = dt.tblUsers.Single(v => v.iD.Equals(id)).cUserName;
            return View("../user/changepass");
        }
        public ActionResult CheckPass(string pass)
        {
            int id = Get_ID();
            string password = func.md5(pass);
            if (dt.tblUsers.Where(v => v.cPassWord == password && v.iD == id).Count() > 0)
            {
                Response.Write(1);
            }
            else
            {
                Response.Write(0);
            }
            return null;
        }
        public ActionResult updatepass(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["id"]);
            tblUser d = dt.tblUsers.Single(v => v.iD.Equals(id));
            string pass = fc["cPassRepNew"];
            d.cPassWord = func.md5(fc["cPassRepNew"]);
            dt.SaveChanges();
            Response.Write(1);
            return null;
        }

    }
}
