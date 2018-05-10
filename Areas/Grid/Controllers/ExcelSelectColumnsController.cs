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
    public class ExcelSelectColumnsController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/ExcelSelectColumns
        public ActionResult Index()
        {
            return View();
        }

        #region SelectColumnsIFrame

        // GET: Grid/SelectColumnsIFrame
        public ActionResult SelectColumnsIFrame()
        {
            return View();
        }

        public ActionResult SelectColumnsIFrame_btnSaveContinue_Click(JArray columns)
        {
            // 关闭弹出窗体，然后执行父页面的JavaScript函数（exportToExcel）并传入参数
            ActiveWindow.HideExecuteScript(String.Format("exportToExcel({0});", columns.ToString(Newtonsoft.Json.Formatting.None)));

            return UIHelper.Result();
        }

        #endregion

        // GET: Grid/ExportToExcel
        public ActionResult ExportToExcel(JArray columns)
        {
            // 需要导出哪些列
            Dictionary<string, bool> columnDic = new Dictionary<string, bool>();
            foreach (string columnName in columns.ToObject<string[]>())
            {
                columnDic[columnName] = true;
            }

            DataTable source = DataSourceUtil.GetDataTable();

            string TH_HTML = "<th>{0}</th>";
            string TD_HTML = "<td>{0}</td>";
            string TD_IMAGE_HTML = "<td><img src=\"{0}\"></td>";

            StringBuilder sb = new StringBuilder();
            sb.Append("<meta http-equiv=\"Content-Type\" content=\"application/vnd.ms-excel;charset=utf-8\"/>");
            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");

            sb.Append("<tr>");
            sb.AppendFormat(TH_HTML, "");
            if (columnDic.ContainsKey("姓名"))
            {
                sb.AppendFormat(TH_HTML, "姓名");
            }
            if (columnDic.ContainsKey("性别"))
            {
                sb.AppendFormat(TH_HTML, "性别");
            }
            if (columnDic.ContainsKey("入学年份"))
            {
                sb.AppendFormat(TH_HTML, "入学年份");
            }
            if (columnDic.ContainsKey("是否在校"))
            {
                sb.AppendFormat(TH_HTML, "是否在校");
            }
            if (columnDic.ContainsKey("所学专业"))
            {
                sb.AppendFormat(TH_HTML, "所学专业");
            }
            if (columnDic.ContainsKey("分组"))
            {
                sb.AppendFormat(TH_HTML, "分组");
            }
            if (columnDic.ContainsKey("注册日期"))
            {
                sb.AppendFormat(TH_HTML, "注册日期");
            }
            sb.Append("</tr>");

            int rowIndex = 1;
            foreach (DataRow row in source.Rows)
            {
                sb.Append("<tr>");
                sb.AppendFormat(TD_HTML, rowIndex++);
                if (columnDic.ContainsKey("姓名"))
                {
                    sb.AppendFormat(TD_HTML, row["Name"]);
                }
                if (columnDic.ContainsKey("性别"))
                {
                    sb.AppendFormat(TD_HTML, row["Gender"].ToString() == "1" ? "男" : "女");
                }
                if (columnDic.ContainsKey("入学年份"))
                {
                    sb.AppendFormat(TD_HTML, row["EntranceYear"]);
                }
                if (columnDic.ContainsKey("是否在校"))
                {
                    sb.AppendFormat(TD_HTML, (bool)row["AtSchool"] ? "√" : "×");
                }
                if (columnDic.ContainsKey("所学专业"))
                {
                    sb.AppendFormat(TD_HTML, row["Major"]);
                }
                if (columnDic.ContainsKey("分组"))
                {
                    sb.AppendFormat(TD_IMAGE_HTML, GetAbsoluteUrl(String.Format("~/res/images/16/{0}.png", row["Group"])));
                }
                if (columnDic.ContainsKey("注册日期"))
                {
                    sb.AppendFormat(TD_HTML, ((DateTime)row["LogTime"]).ToString("yyyy-MM-dd"));
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");


            return File(Encoding.UTF8.GetBytes(sb.ToString()), "application/vnd.ms-excel", "myexcel.xls");
        }

    }
}