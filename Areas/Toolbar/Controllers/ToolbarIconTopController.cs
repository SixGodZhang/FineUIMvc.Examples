using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Toolbar.Controllers
{
    public class ToolbarIconTopController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Toolbar/ToolbarIconTop
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult filePhoto_FileSelected(HttpPostedFileBase filePhoto)
        {
            if (filePhoto != null)
            {
                string fileName = filePhoto.FileName;

                if (!ValidateFileType(fileName))
                {
                    // 清空文件上传组件
                    UIHelper.FileUpload("filePhoto").Reset();

                    ShowNotify("无效的文件类型！");
                }
                else
                {
                    fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                    fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                    filePhoto.SaveAs(Server.MapPath("~/upload/" + fileName));

                    UIHelper.Image("imgPhoto").ImageUrl("~/upload/" + fileName);

                    // 清空文件上传组件（上传后要记着清空，否则点击提交表单时会再次上传！！）
                    UIHelper.FileUpload("filePhoto").Reset();
                }
            }

            return UIHelper.Result();
        }

    }
}