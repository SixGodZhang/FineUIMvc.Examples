using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridOther.Controllers
{
    public class ComplexPropertyController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridOther/ComplexProperty
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            List<MyClass> list = new List<MyClass>();

            list.Add(new MyClass(101, "陈萍萍", "2000", true, new UserInfo("张老师", "111")));
            list.Add(new MyClass(102, "胡飞", "2008", false, new UserInfo("李老师", "222")));
            list.Add(new MyClass(103, "金婷婷", "2001", true, new UserInfo("孙老师", "333")));
            list.Add(new MyClass(104, "潘国", "2008", false, new UserInfo("黄老师", "444")));
            list.Add(new MyClass(105, "吴颖颖", "2002", true, new UserInfo("郭老师", "555")));

            ViewBag.Grid1DataSource = list;
        }


        #region MyClass/UserInfo

        public class UserInfo
        {
            private string _userName;

            public string UserName
            {
                get { return _userName; }
                set { _userName = value; }
            }

            private string _id;

            public string ID
            {
                get { return _id; }
                set { _id = value; }
            }

            public UserInfo(string userName, string id)
            {
                _userName = userName;
                _id = id;
            }
        }

        public class MyClass
        {
            private string _myText;

            public string MyText
            {
                get { return _myText; }
                set { _myText = value; }
            }

            private string _year;

            public string Year
            {
                get { return _year; }
                set { _year = value; }
            }

            private int _id;

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            private bool _myCheckBox;

            public bool MyCheckBox
            {
                get { return _myCheckBox; }
                set { _myCheckBox = value; }
            }

            private UserInfo _info;

            public UserInfo Info
            {
                get { return _info; }
                set { _info = value; }
            }

            public MyClass(int id, string myText, string year, bool myCheckBox, UserInfo info)
            {
                _id = id;
                _myText = myText;
                _year = year;
                _myCheckBox = myCheckBox;
                _info = info;
            }
        }

        #endregion


    }
}