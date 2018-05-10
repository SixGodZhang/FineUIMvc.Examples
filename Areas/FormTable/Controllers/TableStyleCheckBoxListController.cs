using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.FormTable.Controllers
{
    public class TableStyleCheckBoxListController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: FormTable/TableStyleCheckBoxList
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        // 准备 CheckBoxList2 用到的数据
        private void LoadData()
        {
            List<TestClass> myList = new List<TestClass>();
            myList.Add(new TestClass("1", "数据绑定值 1"));
            myList.Add(new TestClass("2", "数据绑定值 2"));
            myList.Add(new TestClass("3", "数据绑定值 3"));
            myList.Add(new TestClass("4", "数据绑定值 4"));

            ViewBag.CheckBoxList2DataSource = myList;
            ViewBag.CheckBoxList2SelectedValueArray = new string[] { "1", "3" };
        }

        #region TestClass

        public class TestClass
        {
            private string _id;

            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public TestClass(string id, string name)
            {
                _id = id;
                _name = name;
            }

        }

        #endregion


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(FormCollection values)
        {
            ShowNotify(values);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckBoxList3_SelectedIndexChanged(string selected)
        {
            ShowNotify(String.Format("列表三选中项的值：{0}", selected));

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnServerSetSelectedValue_Click()
        {
            UIHelper.CheckBoxList("CheckBoxList1").SelectedValueArray(new string[] { "value1", "value3" });

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnServerGetSelectedValue_Click(JArray selected)
        {
            if (selected.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("列表一的选中项：");
                sb.Append("<ul>");
                foreach (JObject selectedItem in selected)
                {
                    sb.AppendFormat("<li>{0}（{1}）</li>", selectedItem["label"], selectedItem["value"]);
                }
                sb.Append("</ul>");
                ShowNotify(sb.ToString());
            }
            else
            {
                ShowNotify("列表一没有选中项！");
            }

            return UIHelper.Result();
        }
    }
}