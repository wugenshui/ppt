using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularDemo.server
{
    /// <summary>
    /// UserAdd 的摘要说明
    /// </summary>
    public class UserAdd : IHttpHandler
    {
        User _user = new User();
        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request.Form["Name"];
            string sex = context.Request.Form["Sex"];
            string birth = context.Request.Form["BirthDate"];
            string height = context.Request.Form["Height"];
            if (!string.IsNullOrWhiteSpace(name))
            {
                User user = new User()
                {
                    Name = name,
                    Sex = ParseHelper.GetInt(sex),
                    BirthDate = ParseHelper.GetDate(birth),
                    Height = ParseHelper.GetInt(height)
                };
                if (user != null)
                {
                    _user.Add(user);
                }
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}