using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class ChangeConfirmFormController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/ChangeConfirmForm
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnClosePostBack_Click(FormCollection values)
        {
            ShowNotify(values);

            // 保存数据后，清空面板内表单字段的改变状态
            UIHelper.SimpleForm("SimpleForm1").ClearDirty();

            return UIHelper.Result();
        }

    }
}