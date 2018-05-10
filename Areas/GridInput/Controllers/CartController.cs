using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridInput.Controllers
{
    public class CartController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridInput/Cart
        public ActionResult Index()
        {
            LoadData();

            return View();
        }


        private void LoadData()
        {
            ViewBag.Grid1DataSource = GetCartDataTable();
            ViewBag.Grid1SelectedRowIndexArray = new int[] { 0, 1 };
        }


        /// <summary>
        /// 获取模拟表格
        /// </summary>
        /// <returns></returns>
        protected DataTable GetCartDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Code", typeof(String)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("Desc", typeof(String)));
            table.Columns.Add(new DataColumn("Price", typeof(float)));
            table.Columns.Add(new DataColumn("Number", typeof(int)));

            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = "100022";
            row[2] = "商品一";
            row[3] = "这是商品一的介绍，巴拉巴拉巴拉巴拉巴拉巴拉巴拉巴拉，巴拉巴拉巴拉巴拉巴拉巴拉，巴拉巴拉巴拉巴拉，巴拉巴拉，巴拉巴拉巴拉巴拉巴拉。";
            row[4] = 35.5;
            row[5] = 1;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = "100023";
            row[2] = "商品二";
            row[3] = "这是商品二的介绍，巴拉巴拉巴拉巴拉巴拉巴拉巴拉巴拉，巴拉巴拉巴拉巴拉巴拉巴拉，巴拉巴拉巴拉巴拉，巴拉巴拉，巴拉巴拉巴拉巴拉巴拉。";
            row[4] = 18.99;
            row[5] = 2;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 103;
            row[1] = "100024";
            row[2] = "商品三";
            row[3] = "这是商品三的介绍，巴拉巴拉巴拉巴拉巴拉巴拉巴拉巴拉，巴拉巴拉巴拉巴拉巴拉巴拉，巴拉巴拉巴拉巴拉，巴拉巴拉，巴拉巴拉巴拉巴拉巴拉。";
            row[4] = 18.99;
            row[5] = 2;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 104;
            row[1] = "100025";
            row[2] = "商品四";
            row[3] = "这是商品四的介绍，巴拉巴拉巴拉巴拉巴拉巴拉巴拉巴拉，巴拉巴拉巴拉巴拉巴拉巴拉，巴拉巴拉巴拉巴拉，巴拉巴拉，巴拉巴拉巴拉巴拉巴拉。";
            row[4] = 22.00;
            row[5] = 1;
            table.Rows.Add(row);

            return table;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGotoPay_Click(JArray inputs)
        {
            // 实际项目中，应该从服务器端获取商品单价（防止客户端用户篡改数据！！）
            float totalPrice = 0.0f;
            int totalNumber = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("<ol>");
            foreach (JArray item in inputs)
            {
                int number = Convert.ToInt32(item[3]);
                float price = Convert.ToSingle(item[2]);
                totalPrice += price * number;
                totalNumber += number;

                sb.AppendFormat("<li>{0}（单价：¥{1}，数量：{2}）</li>", item[1], price.ToString("F2"), number);
            }
            sb.Append("</ol><hr/>");

            sb.AppendFormat("<div style=\"text-align:center;\">共 {0} 件商品，总计 ¥{1}</div>", totalNumber, totalPrice.ToString("F2"));

            ShowNotify(sb.ToString(), MessageBoxIcon.Information);

            return UIHelper.Result();
        }

    }
}