using Newtonsoft.Json.Linq;
using SimpleTool.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Commond.Controllers
{
    [Authorize]
    public class SWRArt2GameController : FineUIMvc.Examples.Controllers.BaseController
    {
        private const string TAG = "服务端的MSG_SWRArt2GameController: ";
        public TastState currentState = TastState.没有;

        // GET: Commond/SWRArt2Game
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckTaskState() {
            switch (currentState)
            {
                case TastState.没有:
                    ShowNotify(TAG + "当前没有任务");
                    break;
                case TastState.正在进行中:
                    ShowNotify(TAG + "任务正在进行中");
                    break;
                case TastState.完成:
                    {
                        ShowNotify(TAG + "任务已完成");
                        PageContext.RegisterStartupScript("OnStateCheck(true);");
                    }
                    break;
            }

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OnClickSWRArt2GameBtn(string type, string gridSourceKey, JArray gridFields, JObject typeParams)
        {
            //ShowNotify("服务器返回消息...");
            currentState = TastState.正在进行中;
            ViewBag.AllMsgs = AutoBindGrid(gridSourceKey, gridFields);

            var panelLeftRegion = UIHelper.Panel("panelCenterRegion");

            string newtitle = String.Format("命令执行时间 更新时间：{0}", DateTime.Now.ToLongTimeString());
            panelLeftRegion.Title(newtitle);
            panelLeftRegion.TitleToolTip(newtitle);

            currentState = TastState.完成;
            return UIHelper.Result();
        }

        private List<string> AutoBindGrid(string gridSourceKey, JArray gridFields)
        {
            var grid1 = UIHelper.Grid("LogGrid");

            CMDMSG resultMsg = ToolPackage.BatTool(GlobalConstant.BAT_PATH_DIC["GetArt2Game_SW_PC"]);
            List<string> allMsgs = new List<string>(resultMsg.Msg.Split('_'));

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Value", typeof(string)));

            DataRow row = null;
            for (int i = 0; i < allMsgs.Count; i++)
            {
                row = table.NewRow();
                row[0] = i;
                row[1] = allMsgs[i];
                table.Rows.Add(row);
            }

            ShowNotify(Environment.CurrentDirectory);
            grid1.DataSource(table, gridFields);
            grid1.Attribute("data-source-key", gridSourceKey);

            return allMsgs;
        }
    }

    public enum TastState
    {
        没有 = 0,
        正在进行中 = 1,
        完成
    }
}