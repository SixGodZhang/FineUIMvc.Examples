using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FineUIMvc.Examples.Areas.Tree.Controllers
{
    public class DataBindDocumentController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Tree/DataBindDocument
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            ViewBag.Tree1DataSource = GetDataSource();

        }

        private XmlDocument GetDataSource()
        {
            string xmlPath = Server.MapPath("~/Areas/Tree/Content/website.xml");

            string xmlContent = String.Empty;
            using (StreamReader sr = new StreamReader(xmlPath))
            {
                xmlContent = sr.ReadToEnd();
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlContent);

            return xdoc;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnClear_Click()
        {
            UIHelper.Tree("Tree1").DataSource(null);
            
            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnReBind_Click()
        {
            UIHelper.Tree("Tree1").DataSource(GetDataSource());

            return UIHelper.Result();
        }

        

    }
}