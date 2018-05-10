using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class FileUploadToolbarController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/FileUploadToolbar
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult filePhoto_FileSelected(HttpPostedFileBase filePhoto, FormCollection values)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(FormCollection values)
        {
            var filePhoto = UIHelper.FileUpload("filePhoto");

            var imgPhotoUrl = values["imgPhotoUrl"];

            if (imgPhotoUrl.EndsWith("/res/images/blank.png"))
            {
                filePhoto.MarkInvalid("请先上传个人头像！");
                ShowNotify("请先上传个人头像！");
            }
            else
            {
                UIHelper.Label("labResult").Text("用户名：" + values["tbxUserName"] + "<br/>" +
                        "邮箱：" + values["tbxEmail"] + "<br/>" +
                        "<p>头像：<br /><img src=\"" + imgPhotoUrl + "\" /></p>",
                        encodeText: false);

                // 清空表单字段
                UIHelper.Image("imgPhoto").ImageUrl(Url.Content("~/res/images/blank.png"));
                filePhoto.Reset();
                UIHelper.TextBox("tbxEmail").Reset();
                UIHelper.TextBox("tbxUserName").Reset();
            }

            return UIHelper.Result();
        }

    }
}