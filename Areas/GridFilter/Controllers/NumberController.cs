using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridFilter.Controllers
{
    public class NumberController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridFilter/Number
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

            if (column == "EntranceYear")
            {
                int sourceValue = Convert.ToInt32(sourceObj);
                int fillteredValue = Convert.ToInt32(fillteredObj);

                if (fillteredOperator == "greater")
                {
                    if (sourceValue > fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "less")
                {
                    if (sourceValue < fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "equal")
                {
                    if (sourceValue == fillteredValue)
                    {
                        valid = true;
                    }
                }
            }
            else if (column == "LogTime")
            {
                // 时间比较时要去掉数据源中的时分秒！
                DateTime sourceDate = Convert.ToDateTime(sourceObj);
                DateTime sourceValue = new DateTime(sourceDate.Year, sourceDate.Month, sourceDate.Day);
                
                DateTime fillteredValue = Convert.ToDateTime(fillteredObj);

                if (fillteredOperator == "greater")
                {
                    if (sourceValue > fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "less")
                {
                    if (sourceValue < fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "equal")
                {
                    if (sourceValue == fillteredValue)
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