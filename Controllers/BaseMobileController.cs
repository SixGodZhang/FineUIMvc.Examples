using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;


namespace FineUIMvc.Examples.Controllers
{
    public class BaseMobileController : BaseController
    {
        #region static readonly

        protected static readonly string DATALIST_ITEM_TEMPLATE = "<table class=\"item-table\"><tr><td><img class=\"item-img\" src=\"{0}\"><div class=\"item-text\">{1}</div><div class=\"item-desc\">{2}</div></td></tr></table>";

        protected static readonly string DATALIST_SIMPLE_ITEM_TEMPLATE = "<table class=\"item-table\"><tr><td><img class=\"item-img\" src=\"{0}\"><div class=\"item-text\">{1}</div></td></tr></table>";

        #endregion

        #region OnActionExecuting

        /// <summary>
        /// 动作方法调用之前执行
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }


        #endregion

        #region ShowNotify

        /// <summary>
        /// 显示通知对话框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageIcon"></param>
        public override void ShowNotify(string message, MessageBoxIcon messageIcon)
        {
            Notify notify = new Notify();
            notify.Target = Target.Self;
            notify.ShowHeader = false;
            notify.PositionX = Position.Center;
            notify.PositionY = Position.Center;
            notify.Message = message;
            notify.MessageBoxIcon = messageIcon;
            notify.MessageAlign = TextAlign.Center;
            notify.MinWidth = 200;
            notify.DisplayMilliseconds = 3000;
            notify.IsModal = true;
            notify.HideOnMaskClick = true;
            notify.Show();
        }


        #endregion
    }
}