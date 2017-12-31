using Angular.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angular.page
{
    /// <summary>
    /// checkUserExist 的摘要说明
    /// </summary>
    public class checkUserExist : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            AjaxResult result = new AjaxResult();
            context.Response.ContentType = "text/plain";
            string username = context.Request.QueryString["username"];
            //if (username.Length > 1)
            //{
            //    result.state = true;
            //}
            string a = context.Request.Form["a"];
            string b = context.Request.Form["b"];
            HttpPostedFile file = context.Request.Files[0];
            // file.SaveAs("");

            context.Response.Write("");
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