using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBV.Models;
using PagedList;
using QLBV.App_Code;
namespace QLBV.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        Entities dt = new Entities();
        Function func = new Function();
        public ActionResult list(int page = 1)
        {
            ViewData["data"] = List_Employee(page, "");
            return View();
        }
        public string List_Employee(int page, string key)
        {
            string str = "";
            int stt = 0;
            var list = dt.SP_List_Employee(key).ToList().ToPagedList(page, 20);
            foreach (var d in list)
            {
                stt++;
                string del = " <a href=\"javascript:void()\" onclick=\"DeletePage(" + d.iD + ",'id=" + d.iD + "','/employee/dell')\" class='btn btn-danger btn-mini'><i class='icon-remove'></i>&nbsp;Xóa&nbsp;</a> ";
                string edit = "<a href=\"javascript:void()\" onclick=\"ShowPopUp('id=" + d.iD + "','/employee/edit')\" class='btn btn-primary btn-mini'><i class='icon-pencil'></i>&nbsp;Sửa&nbsp;</a> ";
                string update = "<a href=\"javascript:void()\" onclick=\"ShowPopUp('id=" + d.iD + "','/employee/user')\" class='btn btn btn-info btn-mini'><i class=' icon-refresh'></i>&nbsp;Tài khoản &nbsp;</a>";
                str += "<tr id=tr_" + d.iD + "><td class=tcenter>" + stt + "</td><td><a href=\"javascript:void()\" onclick=\"ShowPopUp('id=" + d.iD + "','/employee/detail')\">" + d.cName + "</a></td><td class=tcenter>" + d.cPhone + "</td><td class=tcenter>" + d.cCardBank + "</td><td>" + d.cAddress + "</td><td ><a href='" + d.cLinkFace + "' target=\"_blank\">" + d.cNameFace + "</a></td><td class=tcenter>" + edit + del + update + "</td></tr>";
            } return str;
        }
        public ActionResult detail(int id)
        {
            ViewData["id"] = id;
            tblUser u = dt.tblUsers.Single(v => v.iD.Equals(id));
            ViewData["cName"] = u.cName.Trim();
            ViewData["cPhone"] = u.cPhone.Trim();
            ViewData["cAddress"] = u.cAddress.Trim();
            ViewData["iBank"] = u.iBank;
            ViewData["cCardBank"] = u.cCardBank.Trim();
            ViewData["cNameFace"] = u.cNameFace.Trim();
            ViewData["cLinkFace"] = u.cLinkFace.Trim();
            return View("../employee/detail");

        }
        public ActionResult add()
        {
            return View("../employee/add");
        }
        public ActionResult edit(int id)
        {
            ViewData["id"] = id;
            tblUser u = dt.tblUsers.Single(v => v.iD.Equals(id));
            ViewData["cName"] = u.cName.Trim();
            ViewData["cPhone"] = u.cPhone.Trim();
            ViewData["cAddress"] = u.cAddress.Trim();
            ViewData["iBank"] = u.iBank;
            ViewData["cCardBank"] = u.cCardBank.Trim();
            ViewData["cNameFace"] = u.cNameFace.Trim();
            ViewData["cLinkFace"] = u.cLinkFace.Trim();
            return View("../employee/edit");
        }
        public ActionResult insert(FormCollection fc)
        {
            tblUser u = new tblUser();
            u.cName = fc["cName"].Trim();
            u.cPhone = fc["cPhone"].Trim();
            u.cAddress = fc["cAddress"].Trim();
            u.iBank = Convert.ToInt32(fc["iBank"]);
            u.cCardBank = fc["cCardBank"].Trim();
            u.cNameFace = fc["cNameFace"].Trim();
            u.cLinkFace = fc["cLinkFace"].Trim();
            u.cUserName = fc["cPhone"].Trim();
            u.iActive = 1;
            u.dCeateDate = DateTime.Now;
            u.iDelete = 0;
            dt.tblUsers.Add(u);
            dt.SaveChanges();
            Response.Write(1);
            return null;
        }
        public ActionResult update(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["id"]);
            tblUser u = dt.tblUsers.Single(v => v.iD.Equals(id));
            u.cName = fc["cName"].Trim();
            u.cPhone = fc["cPhone"].Trim();
            u.cAddress = fc["cAddress"].Trim();
            u.iBank = Convert.ToInt32(fc["iBank"]);
            u.cCardBank = fc["cCardBank"].Trim();
            u.cNameFace = fc["cNameFace"].Trim();
            u.cLinkFace = fc["cLinkFace"].Trim();
            dt.SaveChanges();
            Response.Write(1);
            return null;
        }
        public ActionResult search(string key)
        {
            string data = "";
            data = List_Employee(1, key);
            Response.Write(data);
            return null;
        }
        public ActionResult dell(int id)
        {
            tblUser u = dt.tblUsers.Single(v => v.iD.Equals(id));
            u.iDelete = 1;
            Response.Write(1);
            dt.SaveChanges();
            return null;
        }
        public ActionResult user(int id)
        {
            ViewData["id"] = id;
            tblUser u = dt.tblUsers.Single(v => v.iD.Equals(id));
            if (u.cPassWord != null)
            {
                ViewData["cWarning"] = "Nhân viên này hiện đã có tài khoản, Bạn có thể ncập nhật lại tài khoản và mật khẩu của nhân viên này";
            }
            else
            {
                ViewData["cWarning"] = "Nhân viên này chưa có tài khoản, Vui lòng cấp tài khoản để nhân viên này có thể sử dụng hệ thống";
            }
            ViewData["quyen"] = ListCheck_Quyen(id);
            ViewData["cUserName"] = u.cUserName.Trim();
            return View("../employee/user");
        }
        public string ListCheck_Quyen(int id = 0)
        {
            string str = "";
            var list = dt.tblGroups.ToList();
            foreach (var d in list)
            {
                string check = ""; if (dt.tblUserGroups.Where(v => v.iGroup == d.iD && v.iUser == id).Count() > 0) check = "checked";
                str += "<label><input type=\"checkbox\" " + check + " name=\"nhcc\" value=" + d.iD + " />" + d.cName + "</label>";
            }
            return str;
        }
        public ActionResult updateuser(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["id"]);
            tblUser u = dt.tblUsers.Single(v => v.iD.Equals(id));
            u.cUserName = fc["cUserName"].Trim();
            if (fc["cPassWord"].Trim() != "")
            {
                u.cPassWord = func.md5(fc["cPassWord"].Trim());
            }
            dt.Database.ExecuteSqlCommand("delete from tblUserGroup where iUser=" + id);
            tblUserGroup quyen = new tblUserGroup();
            string danhmuc = fc["nhcc"];
            if (danhmuc.Length > 0)
            {
                foreach (var x in fc["nhcc"].Split(','))
                {
                    if (x != null)
                    {
                        quyen.iGroup = Convert.ToInt32(x);
                        quyen.iUser = id;
                        dt.tblUserGroups.Add(quyen);
                        dt.SaveChanges();
                    }
                }
            }
            dt.SaveChanges();
            Response.Write(1);
            return null;
        }
    }
}
