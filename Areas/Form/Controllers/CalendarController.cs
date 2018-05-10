using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class CalendarController : FineUIMvc.Examples.Controllers.BaseController
    {
        public static readonly string Calendar1DateFormatString = "yyyy-MM-dd";

        // GET: Form/Calendar
        public ActionResult Index()
        {
            ViewBag.Calendar1DateFormatString = Calendar1DateFormatString;
            ViewBag.Calendar1SelectedDate = DateTime.Now.AddDays(10);
            ViewBag.Button1Text = String.Format("选中{0}", DateTime.Now.AddDays(2).ToString(Calendar1DateFormatString));

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calendar1_DateSelect(string selectedDate)
        {
            UpdateResult(DateTime.Parse(selectedDate));
            
            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click()
        {
            var selectedDate = DateTime.Now.AddDays(2);
            UIHelper.Calendar("Calendar1").SelectedDate(selectedDate);
            

            UpdateResult(selectedDate);

            return UIHelper.Result();
        }


        private void UpdateResult(DateTime date)
        {
            UIHelper.Label("labResult").Text(String.Format("选择的日期：{0}", date.ToString(Calendar1DateFormatString)));
        }
    }
}