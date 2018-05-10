using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DropDownList.Controllers
{
    public class ShengShiXianController : FineUIMvc.Examples.Controllers.BaseController
    {
        
        // GET: DropDownList/ShengShiXian
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            List<ListItem> items = new List<ListItem>();
            ListItem item = new ListItem();
            items.Add(new ListItem("选择省份", "-1"));
            foreach (string sheng in DataSourceUtil.SHENG_JSON)
            {
                item = new ListItem();
                item.Text = sheng;
                item.Value = sheng;
                items.Add(item);
            }

            ViewBag.ShengItems = items.ToArray();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ddlSheng_SelectedIndexChanged(FormCollection values)
        {
            BindShi(values["ddlSheng"]);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ddlShi_SelectedIndexChanged(FormCollection values)
        {
            BindXian(values["ddlShi"]);

            return UIHelper.Result();
        }


        private void BindShi(string sheng)
        {
            var ddlShi = UIHelper.DropDownList("ddlShi");

            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("选择地区市", "-1", true));
            if (sheng != "-1")
            {
                foreach (string shi in DataSourceUtil.SHI_JSON.Value<JArray>(sheng))
                {
                    ListItem item = new ListItem();
                    item.Text = shi;
                    item.Value = shi;
                    items.Add(item);
                }
            }
            // 更新前台数据
            ddlShi.LoadData(items.ToArray());

            // 是否禁用
            ddlShi.Enabled(!(ddlShi.Source.Items.Count == 1));

            BindXian("-1");
        }

        private void BindXian(string shi)
        {
            var ddlXian = UIHelper.DropDownList("ddlXian");

            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("选择县区市", "-1", true));

            if (shi != "-1")
            {
                foreach (string xian in DataSourceUtil.XIAN_JSON.Value<JArray>(shi))
                {
                    ListItem item = new ListItem();
                    item.Text = xian;
                    item.Value = xian;
                    items.Add(item);
                }
            }
            // 更新前台数据
            ddlXian.LoadData(items.ToArray());

            // 是否禁用
            ddlXian.Enabled(!(ddlXian.Source.Items.Count == 1));

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(FormCollection values)
        {
            string sheng = values["ddlSheng"];
            string shi = values["ddlShi"];
            string xian = values["ddlXian"];

            // 香港、澳门 - 县区市为空
            string xianstr = " | " + xian;
            if(xian == "-1") {
                xianstr = "";
            }

            UIHelper.Label("labResult").Text("您选择的省市县：" + sheng + " | " + shi + xianstr);

            return UIHelper.Result();
        }
        
    }
}