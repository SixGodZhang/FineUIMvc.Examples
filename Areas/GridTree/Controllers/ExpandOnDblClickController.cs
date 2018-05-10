using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridTree.Controllers
{
    public class ExpandOnDblClickController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridTree/ExpandOnDblClick
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_RowDoubleClick(JObject rowInfo)
        {
            ShowNotify(String.Format("你双击了第 {0} 行，行ID：{1}，名称：{2}",
                rowInfo.Value<int>("index"),
                rowInfo.Value<string>("id"),
                rowInfo.Value<string>("text")));

            return UIHelper.Result();
        }

    }
}