using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DropDownList.Controllers
{
    public class MultiSelectSelectedIndexChangedEnableEditController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownList/MultiSelectSelectedIndexChangedEnableEdit
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelection_Click(string[] DropDownList1, string DropDownList1_text)
        {
            ShowResult(DropDownList1, DropDownList1_text);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DropDownList1_SelectedIndexChanged(string[] DropDownList1, string DropDownList1_text)
        {
            ShowResult(DropDownList1, DropDownList1_text);

            return UIHelper.Result();
        }

        private void ShowResult(string[] value, string text)
        {
            var labResult = UIHelper.Label("labResult");

            if (!String.IsNullOrEmpty(text))
            {
                labResult.Text(String.Format("选中项文本：{0}<br/>选中项值：{1}", text, String.Join("&nbsp;&nbsp;", value)),
                    encodeText: false);
            }
            else
            {
                labResult.Text("无选中项");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSelectItem6_Click()
        {
            UIHelper.DropDownList("DropDownList1").SelectedValue("Value6");

            return UIHelper.Result();
        }

    }
}