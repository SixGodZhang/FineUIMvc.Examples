using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DropDownList.Controllers
{
    public class DataBindSimpleListController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownList/DataBindSimpleList
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
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
            strList.Add("这是一个很长很长很长很长很长很长很长很长很长很长很长很长很长很长很长很长的可选项");

            ViewBag.DropDownList1DataSource = strList;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelection_Click(string DropDownList1, string DropDownList1_text)
        {
            UIHelper.Label("labResult").Text(String.Format("选中项：{0}（值：{1}）", DropDownList1_text, DropDownList1));

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSelectItem6_Click()
        {
            UIHelper.DropDownList("DropDownList1").SelectedValue("可选项6");

            return UIHelper.Result();
        }

    }
}