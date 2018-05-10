using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class NumberBoxDecimalPrecisionController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/NumberBoxDecimalPrecision
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(string number)
        {
            ShowNotify("数字输入框的值：" + number);

            return UIHelper.Result();
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click()
        {
            var NumberBox1 = UIHelper.NumberBox("NumberBox1");

            NumberBox1.DecimalPrecision(1);
            NumberBox1.Increment(0.1);
            
            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click()
        {
            var NumberBox1 = UIHelper.NumberBox("NumberBox1");

            NumberBox1.DecimalPrecision(2);
            NumberBox1.Increment(0.01);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button3_Click()
        {
            var NumberBox1 = UIHelper.NumberBox("NumberBox1");

            NumberBox1.DecimalPrecision(3);
            NumberBox1.Increment(0.001);

            return UIHelper.Result();
        }

    }
}