using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.ThirdParty.Controllers
{
    public class EChartsDynamicBarController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: ThirdParty/EChartsDynamicBar
        public ActionResult Index()
        {
            return View();
        }

        // GET: ThirdParty/EChartsDynamicBar/IFrame
        public ActionResult IFrame()
        {
            var barOptions = String.Empty;
            var paramType = Request.QueryString["type"];
            if (String.IsNullOrEmpty(paramType) || paramType == "sales")
            {
                //{
                //    "title": {
                //        "text": "销量图表"
                //    },
                //    "xAxis": {
                //        "type": "category",
                //        "data": ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"]
                //    },
                //    "yAxis": {
                //        "type": "value"
                //    },
                //    "series": [{
                //        "name": "销量",
                //        "type": "bar",
                //        "data": [5.0, 20.0, 36.0, 10.0, 10.0, 20.0]
                //    }]
                //}
                barOptions = "{\"color\":[\"#5793f3\"],\"title\":{\"text\":\"销量图表\"},\"xAxis\":{\"type\":\"category\",\"data\":[\"衬衫\",\"羊毛衫\",\"雪纺衫\",\"裤子\",\"高跟鞋\",\"袜子\"]},\"yAxis\":{\"type\":\"value\"},\"series\":[{\"name\":\"销量\",\"type\":\"bar\",\"data\":[5.0,20.0,36.0,10.0,10.0,20.0]}]}";
            }
            else
            {
                //{
                //    "title": {
                //        "text": "产量图表"
                //    },
                //    "xAxis": {
                //        "type": "category",
                //        "data": ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"]
                //    },
                //    "yAxis": {
                //        "type": "value"
                //    },
                //    "series": [{
                //        "name": "销量",
                //        "type": "bar",
                //        "data": [6.0, 18.0, 17.0, 30.0, 20.0, 5.0]
                //    }]
                //}
                barOptions = "{\"color\":[\"#d14a61\"],\"title\":{\"text\":\"产量图表\"},\"xAxis\":{\"type\":\"category\",\"data\":[\"衬衫\",\"羊毛衫\",\"雪纺衫\",\"裤子\",\"高跟鞋\",\"袜子\"]},\"yAxis\":{\"type\":\"value\"},\"series\":[{\"name\":\"销量\",\"type\":\"bar\",\"data\":[6.0,18.0,17.0,35.0,20.0,5.0]}]}";
            }

            ViewBag.BarOptions = barOptions;

            return View();
        }


    }
}