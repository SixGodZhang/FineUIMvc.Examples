using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class FileUploadController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/FileUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(HttpPostedFileBase filePhoto, FormCollection values)
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


                    UIHelper.Label("labResult").Text("<p>文件路径：" + filePhoto.FileName + "</p>" +
                        "<p>用户名：" + values["tbxUserName"] + "</p>" +
                        "<p>头像：<br /><img src=\"" + Url.Content("~/upload/" + fileName) + "\" /></p>",
                        encodeText: false);

                    // 清空表单字段
                    UIHelper.SimpleForm("SimpleForm1").Reset();
                }
            }

            return UIHelper.Result();
        }

    }
}