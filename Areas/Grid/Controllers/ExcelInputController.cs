using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class ExcelInputController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/ExcelInput
        public ActionResult Index()
        {
            return View();
        }

        // GET/POST 都可以
        public ActionResult ExportToExcel(JObject content)
        {
            Dictionary<string, int> contentDic = content.ToObject<Dictionary<string, int>>();

            DataTable source = DataSourceUtil.GetDataTable();

            string TH_HTML = "<th>{0}</th>";
            string TD_HTML = "<td>{0}</td>";
            string TD_IMAGE_HTML = "<td><img src=\"{0}\"></td>";

            StringBuilder sb = new StringBuilder();
            sb.Append("<meta http-equiv=\"Content-Type\" content=\"application/vnd.ms-excel;charset=utf-8\"/>");
            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");

            sb.Append("<tr>");
            sb.AppendFormat(TH_HTML, "");
            sb.AppendFormat(TH_HTML, "姓名");
            sb.AppendFormat(TH_HTML, "性别");
            sb.AppendFormat(TH_HTML, "入学年份");
            sb.AppendFormat(TH_HTML, "是否在校");
            sb.AppendFormat(TH_HTML, "所学专业");
            sb.AppendFormat(TH_HTML, "分组");
            sb.AppendFormat(TH_HTML, "语文成绩");
            sb.Append("</tr>");

            int rowIndex = 1;
            foreach (DataRow row in source.Rows)
            {
                string rowId = row["Id"].ToString();

                sb.Append("<tr>");
                sb.AppendFormat(TD_HTML, rowIndex++);
                sb.AppendFormat(TD_HTML, row["Name"]);
                sb.AppendFormat(TD_HTML, row["Gender"].ToString() == "1" ? "男" : "女");
                sb.AppendFormat(TD_HTML, row["EntranceYear"]);
                sb.AppendFormat(TD_HTML, (bool)row["AtSchool"] ? "√" : "×");
                sb.AppendFormat(TD_HTML, row["Major"]);
                sb.AppendFormat(TD_IMAGE_HTML, GetAbsoluteUrl(String.Format("~/res/images/16/{0}.png", row["Group"])));
                if (contentDic.ContainsKey(rowId))
                {
                    sb.AppendFormat(TD_HTML, contentDic[rowId]);
                }
                else
                {
                    // 未找到！
                    sb.AppendFormat(TD_HTML, "");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");


            return File(Encoding.UTF8.GetBytes(sb.ToString()), "application/vnd.ms-excel", "myexcel.xls");
        }

    }
}