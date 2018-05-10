using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridMove.Controllers
{
    public class RowMoveColumnConfigController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridMove/RowMoveColumnConfig
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            ViewBag.Grid1Columns = GetSavedColumns();

            ViewBag.StartupScript = String.Format("window.GRID_COLUMNCONFIG_DEFAULT={0};", GRID_COLUMNCONFIG_DEFAULT);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GridConfig_Change(JArray configedColumns)
        {
            Session[KEY_FOR_DATASOURCE_SESSION] = configedColumns;

            return UIHelper.Result();
        }


        #region Data

        //[{
        //    "columnId": "RowNumber",
        //    "hidden": true,
        //    "text": ""
        //}, {
        //    "columnId": "Name",
        //    "hidden": false,
        //    "text": "姓名"
        //}, {
        //    "columnId": "Gender",
        //    "hidden": false,
        //    "text": "性别"
        //}, {
        //    "columnId": "EntranceYear",
        //    "hidden": false,
        //    "text": "入学年份"
        //}, {
        //    "columnId": "AtSchool",
        //    "hidden": false,
        //    "text": "是否在校"
        //}, {
        //    "columnId": "Major",
        //    "hidden": false,
        //    "text": "所学专业"
        //}, {
        //    "columnId": "LogTime",
        //    "hidden": false,
        //    "text": "注册日期"
        //}]
        private static readonly string GRID_COLUMNCONFIG_DEFAULT = "[{\"columnId\":\"RowNumber\",\"hidden\":false,\"text\":\"\"},{\"columnId\":\"Name\",\"hidden\":false,\"text\":\"姓名\"},{\"columnId\":\"Gender\",\"hidden\":false,\"text\":\"性别\"},{\"columnId\":\"EntranceYear\",\"hidden\":false,\"text\":\"入学年份\"},{\"columnId\":\"AtSchool\",\"hidden\":false,\"text\":\"是否在校\"},{\"columnId\":\"Major\",\"hidden\":false,\"text\":\"所学专业\"},{\"columnId\":\"LogTime\",\"hidden\":false,\"text\":\"注册日期\"}]";

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridMove.RowMoveColumnConfig";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private JArray GetSavedColumns()
        {
            if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
            {
                Session[KEY_FOR_DATASOURCE_SESSION] = JArray.Parse(GRID_COLUMNCONFIG_DEFAULT);
            }
            return (JArray)Session[KEY_FOR_DATASOURCE_SESSION];
        }


        #endregion
    }
}