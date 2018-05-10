using FineUIMvc.Examples.Areas.DataModel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DataModel.Controllers
{
    public class CheckBoxListController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DataModel/CheckBoxList
        public ActionResult Index()
        {
            var model = new CheckBoxListModel();
            model.IsChecked = true;
            model.CheckBoxList1 = new string[] { "Value1", "Value3" };
            model.CheckBoxList1Items = new List<CheckItem>
            {
                new CheckItem {
                    Text = "可选项 1",
                    Value = "Value1"
                },
                new CheckItem {
                    Text = "可选项 2",
                    Value = "Value2"
                },
                new CheckItem {
                    Text = "可选项 3",
                    Value = "Value3"
                }
            };

            model.RadioButtonList1 = "Value1";
            model.RadioButton1Items = new List<RadioItem>
            {
                new RadioItem {
                    Text = "可选项 1",
                    Value = "Value1"
                },
                new RadioItem {
                    Text = "可选项 2",
                    Value = "Value2"
                },
                new RadioItem {
                    Text = "可选项 3",
                    Value = "Value2"
                }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click([Bind(Include = "IsChecked,CheckBoxList1,RadioButtonList1")]CheckBoxListModel model)
        {
            if (ModelState.IsValid)
            {
                ShowNotify(String.Format("用户提交的数据：<br/><pre>{0}</pre>", JsonConvert.SerializeObject(model, Formatting.Indented)));
            }

            return UIHelper.Result();
        }

    }
}