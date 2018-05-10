using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class PagingDatabaseSummaryDataController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/PagingDatabaseSummaryData
        public ActionResult Index(int pageIndex, int pageSize)
        {
            JObject result = new JObject();
            // 总记录数
            result.Add("recordCount", GetTotalCount());


            // 当前分页数据
            JArray ja = new JArray();
            DataTable source = GetPagedDataTable(pageIndex, pageSize);
            foreach (DataRow row in source.Rows)
            {
                int fee = (int)row["Fee"];
                int donate = (int)row["Donate"];

                JObject jo = new JObject();
                jo.Add("Id", (int)row["Id"]);
                jo.Add("Name", row["Name"].ToString());
                jo.Add("Gender", (int)row["Gender"]);
                jo.Add("EntranceYear", (int)row["EntranceYear"]);
                jo.Add("AtSchool", (bool)row["AtSchool"]);
                jo.Add("Major", row["Major"].ToString());
                jo.Add("Fee", fee);
                jo.Add("Donate", donate);

                ja.Add(jo);
            }


            result.Add("data", ja);

            // 只在请求第一页数据时计算合计行数据
            if (pageIndex == 0)
            {
                result.Add("summaryData", GetSummaryData());
            }

            return Content(result.ToString(Newtonsoft.Json.Formatting.None));
        }

        private JObject GetSummaryData()
        {
            DataTable source = DataSourceUtil.GetDataTable2();

            int donateTotal = 0;
            int feeTotal = 0;
            foreach (DataRow row in source.Rows)
            {
                donateTotal += Convert.ToInt32(row["Donate"]);
                feeTotal += Convert.ToInt32(row["Fee"]);
            }


            JObject summary = new JObject();
            summary.Add("Fee", feeTotal);
            summary.Add("Donate", donateTotal);

            return summary;
        }

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            return DataSourceUtil.GetDataTable2().Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页（实际项目中请直接使用SQL语句返回分页数据！）
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {
            DataTable source = DataSourceUtil.GetDataTable2();

            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
        }


    }
}