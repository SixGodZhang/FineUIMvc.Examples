using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class ImageController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/Image
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click(int imageWidth)
        {
            var Image3 = UIHelper.Image("Image3");

            if (imageWidth == 32)
            {
                Image3.ImageWidth(64);
                Image3.ImageHeight(64);
            }
            else
            {
                Image3.ImageWidth(32);
                Image3.ImageHeight(32);
            }

            return UIHelper.Result();
        }

    }
}