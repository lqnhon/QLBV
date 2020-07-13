using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace QLBV.App_Code
{
    public class Function
    {
        public string sitemate = ConfigurationManager.AppSettings["sitemate"].ToString();
        public void SetCookies(string cookie, string value)
        {
            HttpCookie cookieset = new HttpCookie(cookie);
            cookieset.Value = value;
            cookieset.Expires = DateTime.Now.AddHours(2);
            HttpContext.Current.Response.Cookies.Add(cookieset);
        }
        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }
        public string ConvertDateVN(string date)
        {
            string str = "";
            str = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(date));
            return str;
        }
    }
}