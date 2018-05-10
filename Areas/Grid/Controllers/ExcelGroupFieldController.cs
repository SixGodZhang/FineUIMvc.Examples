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
    public class ExcelGroupFieldController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/ExcelGroupField
        public ActionResult Index()
        {
            return View();
        }


        // GET: Grid/ExcelGroupField/ExportToExcel
        public ActionResult ExportToExcel(JArray content)
        {
            DataTable source = DataSourceUtil.GetDataTable();

            //string TH_HTML = "<th>{0}</th>";
            string TD_HTML = "<td>{0}</td>";
            //string TD_IMAGE_HTML = "<td><img src=\"{0}\"></td>";

            StringBuilder sb = new StringBuilder();
            sb.Append("<meta http-equiv=\"Content-Type\" content=\"application/vnd.ms-excel;charset=utf-8\"/>");
            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");


            MultiHeaderTable mht = new MultiHeaderTable();
            mht.ResolveMultiHeaderTable(content);

            foreach (List<object[]> rows in mht.MultiTable)
            {
                sb.Append("<tr>");
                foreach (object[] cell in rows)
                {
                    int rowspan = Convert.ToInt32(cell[0]);
                    int colspan = Convert.ToInt32(cell[1]);
                    JObject column = cell[2] as JObject;

                    sb.AppendFormat("<th{0}{1}{2}>{3}</th>",
                        rowspan != 1 ? " rowspan=\"" + rowspan + "\"" : "",
                        colspan != 1 ? " colspan=\"" + colspan + "\"" : "",
                        colspan != 1 ? " style=\"text-align:center;\"" : "",
                        column.Value<string>("text"));
                }
                sb.Append("</tr>");
            }


            int rowIndex = 1;
            foreach (DataRow row in source.Rows)
            {
                sb.Append("<tr>");
                sb.AppendFormat(TD_HTML, rowIndex++);
                sb.AppendFormat(TD_HTML, row["Name"]);
                sb.AppendFormat(TD_HTML, row["Gender"].ToString() == "1" ? "男" : "女");
                sb.AppendFormat(TD_HTML, row["ChineseScore"]);
                sb.AppendFormat(TD_HTML, row["MathScore"]);
                sb.AppendFormat(TD_HTML, row["TotalScore"]);
                sb.AppendFormat(TD_HTML, row["Major"]);
                sb.AppendFormat(TD_HTML, ((DateTime)row["LogTime"]).ToString("yyyy-MM-dd"));
                sb.Append("</tr>");
            }
            sb.Append("</table>");


            return File(Encoding.UTF8.GetBytes(sb.ToString()), "application/vnd.ms-excel", "myexcel.xls");
        }


        #region 多表头处理

        /// <summary>
        /// 处理多表头的类
        /// </summary>
        public class MultiHeaderTable
        {
            // 包含 rowspan，colspan 的多表头，方便生成 HTML 的 table 标签
            public List<List<object[]>> MultiTable = new List<List<object[]>>();
            // 最终渲染的列数组
            public List<JObject> Columns = new List<JObject>();


            public void ResolveMultiHeaderTable(JArray columns)
            {
                List<object[]> row = new List<object[]>();
                foreach (JObject column in columns)
                {
                    object[] cell = new object[4];
                    cell[0] = 1;    // rowspan
                    cell[1] = 1;    // colspan
                    cell[2] = column;
                    cell[3] = null;

                    row.Add(cell);
                }

                ResolveMultiTable(row, 0);

                ResolveColumns(row);
            }

            private void ResolveColumns(List<object[]> row)
            {
                foreach (object[] cell in row)
                {
                    JObject groupField = cell[2] as JObject;
                    if (groupField != null && groupField.Property("columns") != null)
                    {
                        JArray groupFieldColumns = groupField.Value<JArray>("columns");
                        List<object[]> subrow = new List<object[]>();
                        foreach (JObject column in groupFieldColumns)
                        {
                            subrow.Add(new object[]
                            {
                                1,
                                1,
                                column,
                                groupField
                            });
                        }

                        ResolveColumns(subrow);
                    }
                    else
                    {
                        Columns.Add(cell[2] as JObject);
                    }
                }

            }

            private void ResolveMultiTable(List<object[]> row, int level)
            {
                List<object[]> nextrow = new List<object[]>();

                foreach (object[] cell in row)
                {
                    JObject groupField = cell[2] as JObject;
                    if (groupField != null && groupField.Property("columns") != null)
                    {
                        JArray groupFieldColumns = groupField.Value<JArray>("columns");
                        // 如果当前列包含子列，则更改当前列的 colspan，以及增加父列（向上递归）的colspan
                        cell[1] = Convert.ToInt32(groupFieldColumns.Count);
                        PlusColspan(level - 1, cell[3] as JObject, groupFieldColumns.Count - 1);

                        foreach (JObject column in groupFieldColumns)
                        {
                            nextrow.Add(new object[]
                            {
                                1,
                                1,
                                column,
                                groupField
                            });
                        }
                    }
                }

                MultiTable.Add(row);

                // 如果当前下一行，则增加上一行（向上递归）中没有子列的列的 rowspan
                if (nextrow.Count > 0)
                {
                    PlusRowspan(level);

                    ResolveMultiTable(nextrow, level + 1);
                }
            }

            private void PlusRowspan(int level)
            {
                if (level < 0)
                {
                    return;
                }

                foreach (object[] cells in MultiTable[level])
                {
                    JObject groupField = cells[2] as JObject;
                    if (groupField != null && groupField.Property("columns") != null)
                    {
                        // ...
                    }
                    else
                    {
                        cells[0] = Convert.ToInt32(cells[0]) + 1;
                    }
                }

                PlusRowspan(level - 1);
            }

            private void PlusColspan(int level, JObject parent, int plusCount)
            {
                if (level < 0)
                {
                    return;
                }

                foreach (object[] cells in MultiTable[level])
                {
                    JObject column = cells[2] as JObject;
                    if (column == parent)
                    {
                        cells[1] = Convert.ToInt32(cells[1]) + plusCount;

                        PlusColspan(level - 1, cells[3] as JObject, plusCount);
                    }
                }
            }

        }
        #endregion
    }
}