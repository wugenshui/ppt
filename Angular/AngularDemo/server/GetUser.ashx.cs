using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularDemo.server
{
    /// <summary>
    /// GetUser 的摘要说明
    /// </summary>
    public class GetUser : IHttpHandler
    {
        User _user = new User();

        public void ProcessRequest(HttpContext context)
        {
            string users = JsonHelper.ObjectToJson(_user.GetList());
            context.Response.ContentType = "text/plain";
            context.Response.Write(users);
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