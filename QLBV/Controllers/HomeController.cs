using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBV.App_Code;
using QLBV.Models;

namespace QLBV.Controllers
{
    public class HomeController : Controller
    {
        Function func = new Function();
        Entities dt = new Entities();

        public ActionResult Index()
        {
            if (Request.Cookies["user_id"] == null)
            {
                Response.Redirect(func.sitemate + "/home/login");
                return null;
            }
            else
            {
                int id = Convert.ToInt32(Request.Cookies["user_id"].Value);
                func.SetCookies("user_id", Request.Cookies["user_id"].Value);
            }
            ViewData["top"] = TopThanhVien();
            ViewData["content"] = BaiViet();
            ViewData["topcontent"] = TopBaiVietMoiNhat();
            ViewData["topcomment"] = TopBinhLuanMoiNhat();
            return View();
        }
        public string TopThanhVien()
        {
            string str = "";
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            var list = dt.SP_Rpt_Top(month, year);
            int stt = 0;
            foreach (var d in list)
            {
                stt++;
                str += "<li><div class=\"article-post\"><span class=\"user-info\">" + stt + ". " + d.cName + " </span>" +
                        " <p><a href=\"#\">Tổng số bài viết đã được duyệt: " + d.iCount + "</a> </p></div></li>";
            }
            return str;
        }
        public string TopBaiVietMoiNhat()
        {
            string str = "";
            int stt = 0;
            var list = dt.SP_List_Accepted(Get_ID(), "").ToList().Take(5);
            foreach (var d in list)
            {
                stt++;
                str += "<div class=\"new-update clearfix\"><span class=\"update-notice\"><a title=\"\" href=\"/content/detail/?id=" + d.iD + "\"><strong>" + stt + ". " + d.cTopic + " </strong></a></div>";//<span>Ngày viết: " + func.ConvertDateVN(Convert.ToDateTime(d.dCreateDate).ToShortDateString()) + "</span>
            }
            return str;
        }
        public string TopBinhLuanMoiNhat()
        {
            string str = "";
            //int stt = 0;
            //var list = dt.SP_List_Comment(Get_ID()).ToList().Take(5);
            //foreach (var d in list)
            //{
            //    stt++;
            //    str += "<div class=\"new-update clearfix\"><span class=\"update-notice\"><a title=\"\" href=\"/content/detail/?id=" + d.iContent + "\"><strong>" + stt + ". " + d.cContent + " </strong></a><span>Thời gian: " + func.ConvertDateVN(Convert.ToDateTime(d.dCreateDate).ToShortDateString()) + "</span></div>";
            //}
            return str;
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
        public string BaiViet()
        {
            string str = "";
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            var list = dt.SP_Rpt_CountContent(Get_ID(), month, year);
            int icount = dt.SP_Rpt_CountContent(Get_ID(), month, year).ToList().Count();
            foreach (var d in list)
            {

                string trangthai = "";
                string mau = "";
                if (d.iStatus == 4)
                {
                    trangthai = "Đã duyệt";
                    mau = "info";
                }
                else if (d.iStatus == 3)
                {
                    trangthai = "Không được duyệt";
                    mau = "success";
                }
                else if (d.iStatus == 2)
                {
                    trangthai = "Đang chờ duyệt";
                    mau = "warning";
                }
                else
                {
                    trangthai = "Đang soạn thảo";
                    mau = "danger";
                }
                int phantram = Convert.ToInt32(d.iCount) * 100 / icount;
                str += "<li><span class=\"icon24 icomoon-icon-arrow-up-2 green\"></span>" + phantram + "% " + trangthai + " <span class=\"pull-right strong\">" + d.iCount + "</span>" +
                            " <div class=\"progress progress-" + mau + " progress-striped \"><div style=\"width: " + phantram + "%;\" class=\"bar\"></div></div></li>";
            }
            int id_user = Get_ID();
            int daduocduyet = dt.tblContents.Where(v => v.iCreateBy == id_user && v.iStatus == 3).Count();
            int toanbo = dt.tblContents.Where(v => v.iStatus == 3).Count();
            string pt = "";
            if (toanbo > 0) { pt = (daduocduyet * 100 / toanbo).ToString(); }
            else
            {
                pt = "0";
            }
            str += "<li><span class=\"icon24 icomoon-icon-arrow-up-2 green\"></span>" + pt + "% Trong hệ thống <span class=\"pull-right strong\">" + toanbo + "</span>" +
                            " <div class=\"progress progress-important progress-striped \"><div style=\"width: " + pt + "%;\" class=\"bar\"></div></div></li>";


            return str;
        }
        public ActionResult login()
        {
            return View();
        }
        public ActionResult register()
        {
            return View();
        }
        public ActionResult CheckLogin(FormCollection fc)
        {
            string user = fc["cUser"];
            string pass = func.md5(fc["cPass"]);
            if (dt.tblUsers.Where(t => t.cUserName == user && t.cPassWord == pass).Count() > 0)
            {
                tblUser tk = dt.tblUsers.Where(t => t.cUserName == user && t.cPassWord == pass).Single();
                func.SetCookies("user_id", tk.iD.ToString());
                Response.Write(1);
            }
            else
            {
                Response.Write("Sai tên đăng nhập hoặc mật khẩu!");
            }
            return null;
        }
        public ActionResult Logout()
        {
            Response.Cookies["user_id"].Expires = DateTime.Now.AddDays(-5);
            Response.Redirect(func.sitemate + "/home/login");
            return null;
        }
    }
}
