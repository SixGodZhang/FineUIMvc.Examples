using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DropDownList.Controllers
{
    public class NoForceSelectionEmptyController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownList/NoForceSelectionEmpty
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelection_Click(string DropDownList1, string DropDownList1_text, bool DropDownList1_isUserInput)
        {
            var labResult = UIHelper.Label("labResult");

            if (!DropDownList1_isUserInput)
            {
                labResult.Text(String.Format("选中项：{0}（值：{1}）", DropDownList1_text, DropDownList1));
            }
            else
            {
                labResult.Text(String.Format("用户输入值：{0}", DropDownList1_text));
            }

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnRebindData_Click(int dataLength)
        {
            var DropDownList1 = UIHelper.DropDownList("DropDownList1");

            if (dataLength == 0)
            {
                List<string> strList = new List<string>();
                strList.Add("可选项1");
                strList.Add("可选项2");
                strList.Add("可选项3");
                strList.Add("可选项4");
                strList.Add("可选项5");
                strList.Add("可选项6");
                strList.Add("可选择项7");
                strList.Add("可选择项8");
                strList.Add("可选择项9");

                DropDownList1.DataSource(strList);
            }
            else
            {
                DropDownList1.DataSource(null);
            }

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSetText_Click()
        {
            UIHelper.DropDownList("DropDownList1").Text("用户输入值");

            return UIHelper.Result();
        }

    }
}