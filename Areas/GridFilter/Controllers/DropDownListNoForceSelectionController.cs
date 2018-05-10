using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridFilter.Controllers
{
    public class DropDownListNoForceSelectionController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridFilter/DropDownListNoForceSelection
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_FilterChanged(string[] Grid1_fields, JArray Grid1_filteredData)
        {
            FilteredTable filteredTable = new FilteredTable();
            filteredTable.FilterDataRowItem = FilterDataRowItemImplement;

            DataTable table = filteredTable.GetFilteredTable(Grid1_filteredData);

            UIHelper.Grid("Grid1").DataSource(table, Grid1_fields);

            UIHelper.Label("labResult").Text(String.Format("过滤参数：<pre>{0}</pre>", Grid1_filteredData.ToString(Newtonsoft.Json.Formatting.Indented)), encodeText: false);

            return UIHelper.Result();
        }


        #region FilterDataRowItem

        private bool FilterDataRowItemImplement(object sourceObj, string fillteredOperator, object fillteredObj, string column)
        {
            bool valid = false;

            if (column == "Major")
            {
                string sourceValue = sourceObj.ToString();

                if (fillteredObj is JArray)
                {
                    JArray fillteredValue = JArray.Parse(fillteredObj.ToString());

                    foreach (string filltereditem in fillteredValue)
                    {
                        if (filltereditem == sourceValue)
                        {
                            valid = true;
                            break;
                        }
                    }
                }
                else
                {
                    // 下拉列表，用户输入值
                    string fillteredValue = fillteredObj.ToString();
                    if (sourceValue.Contains(fillteredValue))
                    {
                        valid = true;
                    }
                }

            }

            return valid;
        }

        #endregion

    }
}