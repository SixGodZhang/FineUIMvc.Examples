using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridMove.Controllers
{
    public class ColumnMoveLockColumnController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridMove/ColumnMoveLockColumn
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            ViewBag.Grid1ColumnIDS = GetSavedColumnIds().ToObject<List<string>>();
            ViewBag.Grid1LockedColumnIDS = GetSavedLockedColumnIds().ToObject<List<string>>();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_ColumnMoveOrLock(JArray columnIds, JArray lockedColumnIds)
        {
            // 模拟操作数据库中的数据
            Session[KEY_FOR_COLUMN_IDS_SESSION] = columnIds;

            Session[KEY_FOR_LOCKED_COLUMN_IDS_SESSION] = lockedColumnIds;

            return UIHelper.Result();
        }


        #region Data

        private static readonly string KEY_FOR_COLUMN_IDS_SESSION = "GridMove.ColumnMove.ColumnIds";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private JArray GetSavedColumnIds()
        {
            if (Session[KEY_FOR_COLUMN_IDS_SESSION] == null)
            {
                Session[KEY_FOR_COLUMN_IDS_SESSION] = new JArray();
            }
            return (JArray)Session[KEY_FOR_COLUMN_IDS_SESSION];
        }

        private static readonly string KEY_FOR_LOCKED_COLUMN_IDS_SESSION = "GridMove.ColumnMove.LockedColumnIds";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private JArray GetSavedLockedColumnIds()
        {
            if (Session[KEY_FOR_LOCKED_COLUMN_IDS_SESSION] == null)
            {
                Session[KEY_FOR_LOCKED_COLUMN_IDS_SESSION] = new JArray();
            }
            return (JArray)Session[KEY_FOR_LOCKED_COLUMN_IDS_SESSION];
        }


        #endregion

    }
}