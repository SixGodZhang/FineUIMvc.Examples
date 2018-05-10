using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class CheckBoxController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/CheckBox
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSelectCheckBox_Click(bool isChecked)
        {
            UIHelper.CheckBox("CheckBox1").Checked(!isChecked);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangeText_Click()
        {
            UIHelper.CheckBox("CheckBox1").Text(String.Format("复选框（{0}）", DateTime.Now.ToLongTimeString()));
            
            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckBox2_CheckedChanged(bool isChecked)
        {
            UIHelper.Label("labResult").Text("复选框的状态：" + (isChecked ? "选中" : "未选中"));

            return UIHelper.Result();
        }
    }
}