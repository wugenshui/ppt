using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AngularDemo.server
{
    public partial class Server : System.Web.UI.Page
    {
        User _user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            string result = string.Empty;
            string type = Request.QueryString["type"];
            switch (type)
            {
                case "userAdd":
                    #region 新增用户
                    string name = Request.Form["Name"];
                    string sex = Request.Form["Sex"];
                    string birth = Request.Form["BirthDate"];
                    string height = Request.Form["Height"];
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
                    #endregion
                    break;
                case "userDel":
                    #region 删除用户
                    string id = Request.QueryString["id"];
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        _user.Delete(o => o.ID.ToString() == id);
                    }
                    #endregion
                    break;
                case "userEdit":
                    #region 编辑用户
                    id = Request.Form["ID"];
                    name = Request.Form["Name"];
                    sex = Request.Form["Sex"];
                    birth = Request.Form["BirthDate"];
                    height = Request.Form["Height"];
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        User user = new User()
                        {
                            ID = ParseHelper.GetInt(id),
                            Name = name,
                            Sex = ParseHelper.GetInt(sex),
                            BirthDate = ParseHelper.GetDate(birth),
                            Height = ParseHelper.GetInt(height)
                        };
                        if (user != null)
                        {
                            _user.Edit(user);
                        }
                    }
                    #endregion
                    break;
                case "userList":
                    #region 用户列表
                    result = JsonHelper.ObjectToJson(_user.GetList());
                    #endregion
                    break;
                case "userById":
                    #region
                    id = Request.QueryString["id"];
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        result = JsonHelper.ObjectToJson(_user.GetList(o => o.ID.ToString() == id).FirstOrDefault());
                    }
                    #endregion
                    break;
                case "":
                    #region
                    #endregion
                    break;
                default:
                    break;
            }
            Response.Write(result);
            Response.End();
        }
    }
}