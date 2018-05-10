using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DropDownList.Controllers
{
    public class MultiSelectNoForceSelectionController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownList/MultiSelectNoForceSelection
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelection_Click(string[] DropDownList1, string DropDownList1_text, bool DropDownList1_isUserInput)
        {
            var labResult = UIHelper.Label("labResult");

            if (!DropDownList1_isUserInput)
            {
                labResult.Text(String.Format("选中项文本：{0}<br/>选中项值：{1}", DropDownList1_text, String.Join("&nbsp;&nbsp;", DropDownList1)),
                    encodeText: false);
            }
            else
            {
                labResult.Text(String.Format("用户输入值：{0}", DropDownList1_text));
            }


            return UIHelper.Result();
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