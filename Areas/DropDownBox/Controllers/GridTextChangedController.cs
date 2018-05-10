using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.DropDownBox.Controllers
{
    public class GridTextChangedController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownBox/GridTextChanged
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DropDownBox1_TextChanged(string[] DropDownBox1, string DropDownBox1_text)
        {
            ShowResult(DropDownBox1, DropDownBox1_text);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelection_Click(string[] DropDownBox1, string DropDownBox1_text)
        {
            ShowResult(DropDownBox1, DropDownBox1_text);

            return UIHelper.Result();
        }


        private static void ShowResult(string[] DropDownBox1, string DropDownBox1_text)
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
        }

    }
}