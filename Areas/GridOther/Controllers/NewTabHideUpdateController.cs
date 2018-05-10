using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridOther.Controllers
{
    public class NewTabHideUpdateController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridOther/NewTabHideUpdate
        public ActionResult Index()
        {
            return View();
        }

        // GET: GridOther/NewTabHideUpdate/Window
        public ActionResult Window()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomEvent(string param)
        {
            Alert.Show(String.Format("来自子页面的参数：{0}", param));

            return UIHelper.Result();
        }

    }
}