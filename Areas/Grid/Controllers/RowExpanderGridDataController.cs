using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class RowExpanderGridDataController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/RowExpanderGridData
        public ActionResult Index(int rowId)
        {
            JArray ja = new JArray();

            Random rd = new Random();
            for (int i = 0; i < 3; i++)
            {
                JArray jaItem = new JArray();

                if (i == 0)
                {
                    jaItem.Add("入学");
                }
                else if (i == 1)
                {
                    jaItem.Add("期中");
                }
                else if (i == 2)
                {
                    jaItem.Add("期末");
                }

                int randomMinValue = 80;
                int randomMaxValue = 100;
                if (rowId % 2 == 0)
                {
                    randomMinValue = 40;
                    randomMaxValue = 80;
                }
                jaItem.Add(rd.Next(randomMinValue, randomMaxValue));
                jaItem.Add(rd.Next(randomMinValue, randomMaxValue));
                jaItem.Add(rd.Next(randomMinValue, randomMaxValue));
                jaItem.Add(rd.Next(randomMinValue, randomMaxValue));
                jaItem.Add(rd.Next(randomMinValue, randomMaxValue));

                ja.Add(jaItem);
            }

            return Content(ja.ToString(Newtonsoft.Json.Formatting.None));
        }

    }
}