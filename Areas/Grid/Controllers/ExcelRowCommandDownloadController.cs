using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class ExcelRowCommandDownloadController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/ExcelRowCommandDownload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExportToExcel(JObject content)
        {
            string rowId = content.Value<string>("id");
            int rowIndex = content.Value<int>("index");
            JObject rowValues = content.Value<JObject>("values");

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("你点击了第 {0} 行，数据如下：", rowIndex + 1);
            sb.AppendLine();
            sb.AppendFormat("ID：{0}", rowId);
            sb.AppendLine();
            sb.AppendFormat("姓名：{0}", rowValues.Value<string>("Name"));
            sb.AppendLine();
            sb.AppendFormat("性别：{0}", rowValues.Value<string>("Gender") == "1" ? "男" : "女");
            sb.AppendLine();
            sb.AppendFormat("入学年份：{0}", rowValues.Value<string>("EntranceYear"));
            sb.AppendLine();
            sb.AppendFormat("是否在校：{0}", rowValues.Value<bool>("AtSchool") ? "是" : "否");
            sb.AppendLine();
            sb.AppendFormat("所学专业：{0}", rowValues.Value<string>("Major"));
            sb.AppendLine();
            sb.AppendFormat("分组：{0}", rowValues.Value<string>("Group"));

            
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/plain", "row_" + rowId + ".txt");
        }

    }
}