using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DropDownList.Controllers
{
    public class SelectedIndexChangedEnableEditNoForceSelectionController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownList/SelectedIndexChangedEnableEditNoForceSelection
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelection_Click(string DropDownList1, string DropDownList1_text, bool DropDownList1_isUserInput)
        {
            ShowResult(DropDownList1, DropDownList1_text, DropDownList1_isUserInput);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DropDownList1_SelectedIndexChanged(string DropDownList1, string DropDownList1_text, bool DropDownList1_isUserInput)
        {
            ShowResult(DropDownList1, DropDownList1_text, DropDownList1_isUserInput);

            return UIHelper.Result();
        }

        private void ShowResult(string value, string text, bool isUserInput)
        {
            var labResult = UIHelper.Label("labResult");

            if (!isUserInput)
            {
                labResult.Text(String.Format("选中项：{0}（值：{1}）", text, value));
            }
            else
            {
                labResult.Text(String.Format("用户输入值：{0}", text));
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