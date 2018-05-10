using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DropDownList.Controllers
{
    public class ShengShiXian2Controller : FineUIMvc.Examples.Controllers.BaseController
    {
        
        // GET: DropDownList/ShengShiXian2
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            ViewBag.ShengDataSource = DataSourceUtil.SHENG_JSON;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ddlSheng_SelectedIndexChanged(string sheng)
        {
            BindShi(sheng);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ddlShi_SelectedIndexChanged(string sheng, string shi)
        {
            BindXian(shi);

            return UIHelper.Result();
        }

        

        private void BindShi(string sheng)
        {
            var ddlShi = UIHelper.DropDownList("ddlShi");

            if (sheng != "-1")
            {
                JArray ja = DataSourceUtil.SHI_JSON.Value<JArray>(sheng);

                // 手工调用 Source.DataSource 属性时，需要调用 DataBind 方法
                ddlShi.Source.DataSource = ja;
                ddlShi.Source.DataBind();
            }
            // 手工调用 Source.Items
            ddlShi.Source.Items.Insert(0, new ListItem("选择地区市", "-1", true));

            // 更新前台数据
            ddlShi.LoadData();

            // 是否禁用
            ddlShi.Enabled(!(ddlShi.Source.Items.Count == 1));

            BindXian("-1");
        }

        private void BindXian(string shi)
        {
            var ddlXian = UIHelper.DropDownList("ddlXian");

            if (shi != "-1")
            {
                JArray ja = DataSourceUtil.XIAN_JSON.Value<JArray>(shi);

                // 手工调用 Source.DataSource 属性时，需要调用 DataBind 方法
                ddlXian.Source.DataSource = ja;
                ddlXian.Source.DataBind();
            }
            // 手工调用 Source.Items
            ddlXian.Source.Items.Insert(0, new ListItem("选择县区市", "-1", true));

            // 更新前台数据
            ddlXian.LoadData();

            // 是否禁用
            ddlXian.Enabled(!(ddlXian.Source.Items.Count == 1));

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(string sheng, string shi, string xian)
        {
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