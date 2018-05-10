using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Message.Controllers
{
    public class AlertController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Message/Alert
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(FormCollection values)
        {
            Alert alert = new Alert();
            alert.Message = values["tbxMessage"];
            alert.Title = values["tbxTitle"];
            alert.MessageBoxIcon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), values["rblMessageBoxIcon"], true);
            alert.Target = (Target)Enum.Parse(typeof(Target), values["rblTarget"], true);

            if (!String.IsNullOrEmpty(values["nbWidth"]))
            {
                alert.Width = Convert.ToInt32(values["nbWidth"]);
            }

            if (!String.IsNullOrEmpty(values["nbMinWidth"]))
            {
                alert.MinWidth = Convert.ToInt32(values["nbMinWidth"]);
            }

            if (!String.IsNullOrEmpty(values["nbMaxWidth"]))
            {
                alert.MaxWidth = Convert.ToInt32(values["nbMaxWidth"]);
            }

            if (!String.IsNullOrEmpty(values["tbxID"]))
            {
                alert.ID = values["tbxID"];
            }

            if (!Convert.ToBoolean(values["cbxEnableClose"]))
            {
                alert.EnableClose = false;
            }

            alert.Show();

            return UIHelper.Result();
        }

    }
}