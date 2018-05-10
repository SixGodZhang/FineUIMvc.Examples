using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.DropDownBox.Controllers
{
    public class GridUpdateValueController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownBox/GridUpdateValue
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnUpdateValue_Click()
        {
            // 1. 对于未分页的表格，可以不设置 Text 属性，以便客户端重新计算
            // 2. 对于分页的表格，一定要手工设置 Text 属性，否则客户端无法取到 Value 对应的 Text 属性
            UIHelper.DropDownBox("DropDownBox1").Value("112");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelection_Click(string[] DropDownBox1, string DropDownBox1_text)
        {
            var labResult = UIHelper.Label("labResult");
            if (DropDownBox1.Length > 0)
            {
                labResult.Text(String.Format("下拉框文本：{0}（值：{1}）", DropDownBox1_text, String.Join(",", DropDownBox1)));
            }
            else
            {
                labResult.Text("下拉框为空");
            }

            return UIHelper.Result();
        }

    }
}