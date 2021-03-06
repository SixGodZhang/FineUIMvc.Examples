﻿
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class RadioButtonListAutoColumnWidthController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/RadioButtonListAutoColumnWidth
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            List<TestClass> myList = new List<TestClass>();
            myList.Add(new TestClass("1", "数据绑定值 1"));
            myList.Add(new TestClass("2", "数据绑定值 2"));
            myList.Add(new TestClass("3", "数据绑定值 3"));
            myList.Add(new TestClass("4", "数据绑定值 4"));

            ViewBag.RadioButtonList2DataSource = myList;
            ViewBag.RadioButtonList2SelectedValue = "3";
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
        public ActionResult btnServerGetSelectedValue_Click(JObject selected)
        {
            if (selected.Count > 0)
            {
                ShowNotify(String.Format("列表一的选中项：{0}（{1}）", selected["label"], selected["value"]));
            }
            else
            {
                ShowNotify("列表一没有选中项！");
            }

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnServerSetSelectedValue_Click()
        {
            UIHelper.RadioButtonList("RadioButtonList1").SelectedValue("value1");

            return UIHelper.Result();
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RadioButtonList3_SelectedIndexChanged(string selected)
        {
            ShowNotify(String.Format("列表三选中项的值：{0}", selected));

            return UIHelper.Result();
        }

        
        
    }
}