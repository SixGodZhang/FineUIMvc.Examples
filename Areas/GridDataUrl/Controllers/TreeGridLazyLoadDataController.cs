using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class TreeGridLazyLoadDataController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/TreeGridLazyLoadData
        public ActionResult Index(string lazyrowid)
        {
            JArray ja = new JArray();

            DataTable source = new DataTable();

            if (String.IsNullOrEmpty(lazyrowid))
            {
                // 初始数据
                source = GetTreeDataTable();
            }
            else
            {
                // 延迟加载数据
                if (lazyrowid == "50")
                {
                    source = GetBasicFolderDataTable();
                }
                else if (lazyrowid == "54")
                {
                    source = GetCaptchaFolderDataTable();
                }
            }


            foreach (DataRow row in source.Rows)
            {
                JObject jo = new JObject();
                jo.Add("ParentId", (int)row["ParentId"]);
                jo.Add("Id", (int)row["Id"]);
                jo.Add("Name", row["Name"].ToString());
                jo.Add("Type", row["Type"].ToString());
                jo.Add("ModifyDate", (DateTime)row["ModifyDate"]);

                object fileSize = row["Size"];
                if (fileSize == DBNull.Value)
                {
                    jo.Add("Size", "");
                }
                else
                {
                    jo.Add("Size", (int)fileSize);
                }


                ja.Add(jo);
            }

            return Content(ja.ToString(Newtonsoft.Json.Formatting.None));
        }

        /// <summary>
        /// 获取模拟树表格
        /// </summary>
        /// <returns></returns>
        public DataTable GetTreeDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("ParentId", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("Type", typeof(String)));
            table.Columns.Add(new DataColumn("Size", typeof(int)));
            table.Columns.Add(new DataColumn("ModifyDate", typeof(DateTime)));


            DataRow row;

            // basic
            row = table.NewRow();
            row[0] = 50;
            row[1] = -1;
            row[2] = "basic（延迟加载）";
            row[3] = "文件夹";
            row[4] = DBNull.Value;
            row[5] = DateTime.Parse("2014/11/3 11:20");
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 100;
            row[1] = -1;
            row[2] = "default.aspx";
            row[3] = "ASPX文件";
            row[4] = 31;
            row[5] = DateTime.Parse("2014/11/15 18:44");
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 101;
            row[1] = -1;
            row[2] = "default.aspx.cs";
            row[3] = "CS文件";
            row[4] = 13;
            row[5] = DateTime.Parse("2014/10/27 18:44");
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = -1;
            row[2] = "default.aspx.designer.cs";
            row[3] = "CS文件";
            row[4] = 12;
            row[5] = DateTime.Parse("2014/10/12 20:57");
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 105;
            row[1] = -1;
            row[2] = "Web.config";
            row[3] = "CONFIG文件";
            row[4] = 3;
            row[5] = DateTime.Parse("2014/11/6 20:59");
            table.Rows.Add(row);


            return table;
        }

        private DataTable GetBasicFolderDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("ParentId", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("Type", typeof(String)));
            table.Columns.Add(new DataColumn("Size", typeof(int)));
            table.Columns.Add(new DataColumn("ModifyDate", typeof(DateTime)));

            DataRow row;

            // basic -> Captcha
            row = table.NewRow();
            row[0] = 54;
            row[1] = 50;
            row[2] = "Captcha（延迟加载）";
            row[3] = "文件夹";
            row[4] = DBNull.Value;
            row[5] = DateTime.Parse("2014/8/17 20:22");
            table.Rows.Add(row);


            // basic -> hello.aspx
            row = table.NewRow();
            row[0] = 51;
            row[1] = 50;
            row[2] = "hello.aspx";
            row[3] = "ASPX文件";
            row[4] = 1;
            row[5] = DateTime.Parse("2014/7/5 16:31");
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 52;
            row[1] = 50;
            row[2] = "hello.aspx.cs";
            row[3] = "CS文件";
            row[4] = 1;
            row[5] = DateTime.Parse("2014/8/24 11:08");
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 53;
            row[1] = 50;
            row[2] = "hello.aspx.designer.cs";
            row[3] = "CS文件";
            row[4] = 2;
            row[5] = DateTime.Parse("2014/7/5 16:31");
            table.Rows.Add(row);

            return table;
        }


        private DataTable GetCaptchaFolderDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("ParentId", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("Type", typeof(String)));
            table.Columns.Add(new DataColumn("Size", typeof(int)));
            table.Columns.Add(new DataColumn("ModifyDate", typeof(DateTime)));

            DataRow row;

            row = table.NewRow();
            row[0] = 55;
            row[1] = 54;
            row[2] = "captcha.ashx";
            row[3] = "ASHX文件";
            row[4] = 1;
            row[5] = DateTime.Parse("2014/7/5 16:31");
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 56;
            row[1] = 54;
            row[2] = "captcha.ashx.cs";
            row[3] = "CS文件";
            row[4] = 2;
            row[5] = DateTime.Parse("2014/7/5 16:31");
            table.Rows.Add(row);

            return table;
        }


    }
}