using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridEditor.Controllers
{
    public class DecimalController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridEditor/Decimal
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            ViewBag.Grid1DataSource = GetSourceData();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(string[] Grid1_fields, JArray Grid1_modifiedData)
        {
            DataTable source = GetSourceData();

            foreach (JObject modifiedRow in Grid1_modifiedData)
            {
                string status = modifiedRow.Value<string>("status");
                int rowId = Convert.ToInt32(modifiedRow.Value<string>("id"));

                if (status == "modified")
                {
                    UpdateDataRow(modifiedRow, rowId, source);
                }
            }

            UIHelper.Grid("Grid1").DataSource(source, Grid1_fields);
            UIHelper.Label("labResult").Text(String.Format("用户修改的数据：<pre>{0}</pre>", Grid1_modifiedData.ToString(Newtonsoft.Json.Formatting.Indented)), false);

            ShowNotify("数据保存成功！（表格数据已重新绑定）");

            return UIHelper.Result();
        }

        #region UpdateDataRow

        private void UpdateDataRow(JObject modifiedRow, int rowId, DataTable source)
        {
            Dictionary<string, object> rowDict = modifiedRow.Value<JObject>("values").ToObject<Dictionary<string, object>>();
            DataRow rowData = FindRowByID(source, rowId);

            UpdateDataRow("Name", rowDict, rowData);
            UpdateDataRow("Gender", rowDict, rowData);
            UpdateDataRow("Major", rowDict, rowData);
            UpdateDataRow("ChineseScore", rowDict, rowData);
            UpdateDataRow("MathScore", rowDict, rowData);
        }

        private void UpdateDataRow(string columnName, Dictionary<string, object> rowDict, DataRow rowData)
        {
            if (rowDict.ContainsKey(columnName))
            {
                object value = rowDict[columnName];

                // 如果客户端值为空字符串，但是列类型不是字符串，则设置为空对象 DBNull.Value
                if (value is String && String.IsNullOrEmpty(value.ToString()) && !(rowData[columnName] is String))
                {
                    rowData[columnName] = DBNull.Value;
                }
                else
                {
                    rowData[columnName] = value;
                }
            }
        }

        private DataRow FindRowByID(DataTable table, int rowId)
        {
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == rowId)
                {
                    return row;
                }
            }
            return null;
        }

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridEditor.Decimal";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private DataTable GetSourceData()
        {
            if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
            {
                Session[KEY_FOR_DATASOURCE_SESSION] = GetDataTable();
            }
            return (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
        }

        private DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("EntranceYear", typeof(int)));
            table.Columns.Add(new DataColumn("AtSchool", typeof(bool)));
            table.Columns.Add(new DataColumn("Major", typeof(String)));
            table.Columns.Add(new DataColumn("Group", typeof(int)));
            table.Columns.Add(new DataColumn("Gender", typeof(int)));
            table.Columns.Add(new DataColumn("LogTime", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Desc", typeof(string)));
            table.Columns.Add(new DataColumn("Guid", typeof(Guid)));

            // Hobby：reading,basketball,travel,movie,music
            // 爱好：读书, 篮球, 旅游, 电影, 音乐
            table.Columns.Add(new DataColumn("Hobby", typeof(String)));
            table.Columns.Add(new DataColumn("EntranceDate", typeof(String)));

            // 考试成绩
            table.Columns.Add(new DataColumn("ChineseScore", typeof(float)));
            table.Columns.Add(new DataColumn("MathScore", typeof(float)));
            table.Columns.Add(new DataColumn("TotalScore", typeof(float)));

            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = "张萍萍";
            row[2] = 2000;
            row[3] = true;
            row[4] = "材料科学与工程系";
            row[5] = 1;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-100); // DBNull.Value;
            row[8] = "张萍萍，女，20岁，出生于中国南方的一个小山村，毕业于中国科学技术大学。<br/>毕业后就职于某大型国有企业，任部门经理，连续三年获得企业优秀员工称号。<br/>aaaaaaaaaaabbbbbbbbbbbbcccccccccccdddddddddddddeeeeeeeeeeeeffffffffffff";
            row[9] = Guid.NewGuid();
            row[10] = "reading,travel,music";
            row[11] = "2000-09-01";
            row[12] = 80;
            row[13] = 90;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = "陈飞";
            row[2] = 2000;
            row[3] = false;
            row[4] = "化学系";
            row[5] = 1;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-100);
            row[8] = "陈飞，男，20岁，出生于中国北方的一个小山村，毕业于南方科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "basketball,travel,movie,reading,music";
            row[11] = "2001-09-01";
            row[12] = 85.8;
            row[13] = 90.2;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 103;
            row[1] = "董婷婷";
            row[2] = 2000;
            row[3] = true;
            row[4] = "化学系";
            row[5] = 2;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-100);
            row[8] = "董婷婷，女，18岁，出生于中国海南岛的一个小山村，毕业于中国科学技术大学。<br/>董婷婷是在学校认识丈夫刘国的，有一天晚上下自习后，董婷婷发短信给刘国说“做我男朋友吧！”，然后他们就走到了一起。";
            row[9] = Guid.NewGuid();
            row[10] = "basketball,movie,music";
            row[11] = "2008-09-01";
            row[12] = 90.5;
            row[13] = 90.5;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 104;
            row[1] = "刘国";
            row[2] = 2002;
            row[3] = false;
            row[4] = "化学系";
            row[5] = 2;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-100);
            row[8] = "刘国，男，22岁，出生于中国澳门的一个小山村，毕业于中国科学技术大学。<br/>刘国是作为交换生来中科大学习，在校期间认识了妻子董婷婷，虽然是被追到手了，不过在人前却总是说“老婆是我千辛万苦追来的！”。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,basketball,movie";
            row[11] = "2002-09-01";
            // 默认为空
            row[12] = DBNull.Value;
            row[13] = DBNull.Value;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 105;
            row[1] = "康颖颖";
            row[2] = 2008;
            row[3] = true;
            row[4] = "数学系";
            row[5] = 3;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-60);
            row[8] = "康颖颖，女，26岁，出生于中国福建的一个小山村，毕业于香港科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,travel,movie,music";
            row[11] = "2008-09-01";
            // 默认为空
            row[12] = DBNull.Value;
            row[13] = DBNull.Value;
            table.Rows.Add(row);

            return table;
        }

        #endregion

    }
}