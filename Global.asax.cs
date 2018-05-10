using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FineUIMvc.Examples
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(JArray), new JArrayModelBinder());
            ModelBinders.Binders.Add(typeof(JObject), new JObjectModelBinder());

            Application["OnlineUserCount"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // 这种统计在线人数的做法会有一定的误差
            Application.Lock();
            Application["OnlineUserCount"] = (int)Application["OnlineUserCount"] + 1;
            Application.UnLock();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["OnlineUserCount"] = (int)Application["OnlineUserCount"] - 1;
            Application.UnLock();
        }

    }
}
