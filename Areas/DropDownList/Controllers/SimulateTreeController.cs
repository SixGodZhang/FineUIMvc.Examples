using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DropDownList.Controllers
{
    public class SimulateTreeController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownList/SimulateTree
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        #region LoadData

        public class JQueryFeature
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

            private int _level;

            public int Level
            {
                get { return _level; }
                set { _level = value; }
            }

            private bool _enableSelect;

            public bool EnableSelect
            {
                get { return _enableSelect; }
                set { _enableSelect = value; }
            }

            public JQueryFeature(string id, string name, int level, bool enableSelect)
            {
                _id = id;
                _name = name;
                _level = level;
                _enableSelect = enableSelect;
            }

            public override string ToString()
            {
                return String.Format("Name:{0}+Id:{1}", Name, Id);
            }
        }

        private void LoadData()
        {
            List<JQueryFeature> myList = new List<JQueryFeature>();
            myList.Add(new JQueryFeature("0", "jQuery", 0, false));
            myList.Add(new JQueryFeature("1", "核心", 1, false));
            myList.Add(new JQueryFeature("2", "选择符", 1, false));
            myList.Add(new JQueryFeature("3", "基本选择符", 2, true));
            myList.Add(new JQueryFeature("4", "内容选择符", 2, true));
            myList.Add(new JQueryFeature("5", "属性选择符", 2, true));
            myList.Add(new JQueryFeature("6", "筛选", 1, false));
            myList.Add(new JQueryFeature("7", "过滤", 2, true));
            myList.Add(new JQueryFeature("8", "查找", 2, true));
            myList.Add(new JQueryFeature("9", "事件", 1, false));
            myList.Add(new JQueryFeature("10", "页面载入", 2, true));
            myList.Add(new JQueryFeature("11", "事件处理", 2, true));
            myList.Add(new JQueryFeature("12", "事件委托", 2, true));

            ViewBag.ddlBoxDataSource = myList;
            ViewBag.ddlBoxSelectedValue = "3";
        }

        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelection_Click(string DropDownList1, string DropDownList1_text)
        {
            UIHelper.Label("labResult").Text(String.Format("选中项：{0}（值：{1}）", DropDownList1_text, DropDownList1));

            return UIHelper.Result();
        }

        #region btnDataBind_Click

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnDataBind_Click(string DropDownList1, string DropDownList1_text)
        {
            var dropDownList1UI = UIHelper.DropDownList("DropDownList1");

            // 通过 Source 设置控件属性
            dropDownList1UI.Source.EnableSimulateTree = true;
            dropDownList1UI.Source.DataSimulateTreeLevelField = "Level";
            dropDownList1UI.Source.DataEnableSelectField = "EnableSelect";
            // 绑定数据
            dropDownList1UI.DataSource(GetData2(), "Id", "Name");
            // 设置选中项
            dropDownList1UI.SelectedValue("11");

            return UIHelper.Result();
        }


        private List<JQueryFeature> GetData2()
        {
            List<JQueryFeature> myList = new List<JQueryFeature>();
            myList.Add(new JQueryFeature("0", "jQuery - 2", 0, false));
            myList.Add(new JQueryFeature("1", "核心 - 2", 1, false));
            myList.Add(new JQueryFeature("6", "筛选 - 2", 1, false));
            myList.Add(new JQueryFeature("7", "过滤 - 2", 2, true));
            myList.Add(new JQueryFeature("8", "查找 - 2", 2, true));
            myList.Add(new JQueryFeature("9", "事件 - 2", 1, false));
            myList.Add(new JQueryFeature("10", "页面载入 - 2", 2, true));
            myList.Add(new JQueryFeature("11", "事件处理 - 2", 2, true));
            myList.Add(new JQueryFeature("12", "事件委托 - 2", 2, true));

            return myList;
        } 

        #endregion

    }
}