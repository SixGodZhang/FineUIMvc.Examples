using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Tree.Controllers
{
    public class DataBindDataTableController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Tree/DataBindDataTable
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            List<TreeNode> nodes = new List<TreeNode>();

            // 模拟从数据库返回数据表
            DataTable table = CreateDataTable();

            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            ds.Relations.Add("TreeRelation", ds.Tables[0].Columns["Id"], ds.Tables[0].Columns["ParentId"]);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.IsNull("ParentId"))
                {
                    TreeNode node = new TreeNode();
                    node.Text = row["Text"].ToString();
                    nodes.Add(node);

                    ResolveSubTree(row, node);
                }
            }

            // 视图数据
            ViewBag.Tree1Nodes = nodes.ToArray();
        }

        private void ResolveSubTree(DataRow dataRow, TreeNode treeNode)
        {
            DataRow[] rows = dataRow.GetChildRows("TreeRelation");
            if (rows.Length > 0)
            {
                // 如果是目录，则默认展开
                treeNode.Expanded = true;
                foreach (DataRow row in rows)
                {
                    TreeNode node = new TreeNode();
                    node.Text = row["Text"].ToString();
                    treeNode.Nodes.Add(node);

                    ResolveSubTree(row, node);
                }
            }
        }

        

        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            DataColumn column1 = new DataColumn("Id", typeof(string));
            DataColumn column2 = new DataColumn("Text", typeof(String));
            DataColumn column3 = new DataColumn("ParentId", typeof(string));
            table.Columns.Add(column1);
            table.Columns.Add(column2);
            table.Columns.Add(column3);

            DataRow row = table.NewRow();
            row[0] = "china";
            row[1] = "中国";
            row[2] = DBNull.Value;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "henan";
            row[1] = "河南省";
            row[2] = "china";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "zhumadian";
            row[1] = "驻马店市";
            row[2] = "henan";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "luohe";
            row[1] = "漯河市";
            row[2] = "henan";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "anhui";
            row[1] = "安徽省";
            row[2] = "china";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "hefei";
            row[1] = "合肥市";
            row[2] = "anhui";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "golden";
            row[1] = "金色池塘小区";
            row[2] = "hefei";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "ustc";
            row[1] = "中国科学技术大学";
            row[2] = "hefei";
            table.Rows.Add(row);

            return table;
        }


    }
}