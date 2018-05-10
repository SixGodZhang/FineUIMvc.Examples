using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DropDownList.Controllers
{
    public class EnableEditController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownList/EnableEdit
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelection_Click(string DropDownList1, string DropDownList1_text)
        {
            var labResultUI = UIHelper.Label("labResult");

            if (!String.IsNullOrEmpty(DropDownList1_text))
            {
                labResultUI.Text(String.Format("选中项：{0}（值：{1}）", DropDownList1_text, DropDownList1));
            }
            else
            {
                labResultUI.Text("无选中项");
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