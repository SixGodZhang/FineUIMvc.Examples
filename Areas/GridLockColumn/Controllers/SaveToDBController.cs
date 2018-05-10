using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridLockColumn.Controllers
{
    public class SaveToDBController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridLockColumn/SaveToDB
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            ViewBag.LockedColumns = GetLockedColumns();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_ColumnLockUnlock(string type, string columnId)
        {
            // 模拟操作数据库中的数据
            List<string> lockedColumns = GetLockedColumns();
            if (type == "lock")
            {
                if (!lockedColumns.Contains(columnId))
                {
                    lockedColumns.Add(columnId);
                }
            }
            else if (type == "unlock")
            {
                if (lockedColumns.Contains(columnId))
                {
                    lockedColumns.Remove(columnId);
                }
            }

            return UIHelper.Result();
        }

        #region Data

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridLockColumn.SaveToDB";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private List<string> GetLockedColumns()
        {
            if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
            {
                Session[KEY_FOR_DATASOURCE_SESSION] = new List<string>() { };
            }
            return (List<string>)Session[KEY_FOR_DATASOURCE_SESSION];
        }


        #endregion

    }
}