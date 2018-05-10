using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class RadioButtonController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/RadioButton
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSelectSingleRadio_Click(bool isChecked)
        {
            UIHelper.RadioButton("rbtnSingleRadio").Checked(!isChecked);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSelectSecondRadio_Click(string checkedRadio)
        {
            String[] radios = new String[] { "rbtnFirst", "rbtnSecond", "rbtnThird" };

            for (int i = 0; i < radios.Length; i++)
            {
                if (radios[i] == checkedRadio)
                {
                    int next = i + 1;
                    if (next >= radios.Length)
                    {
                        next = 0;
                    }

                    UIHelper.RadioButton(radios[next]).Checked(true);

                    break;
                }
            }

            return UIHelper.Result();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult rbtnAuto_CheckedChanged(string checkedRadio)
        {
            ShowNotify("单选框选中项：" + checkedRadio);

            return UIHelper.Result();
        }

        
    }
}