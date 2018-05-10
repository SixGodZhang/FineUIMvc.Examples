using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridTree.Controllers
{
    public class CustomClassController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridTree/CustomClass
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            ViewBag.Grid1DataSource = GetTreeDataList();
        }

        #region GetTreeDataList

        private List<TheFileInfo> GetTreeDataList()
        {
            List<TheFileInfo> infos = new List<TheFileInfo>();

            TheFileInfo info = null;

            // basic
            TheFileInfo basicInfo = new TheFileInfo();
            basicInfo.Id = 50;
            basicInfo.Parent = null;
            basicInfo.Name = "basic";
            basicInfo.Type = "文件夹";
            basicInfo.Size = null;
            basicInfo.ModifyDate = DateTime.Parse("2014/11/3 11:20");
            infos.Add(basicInfo);


            // basic -> Captcha
            TheFileInfo captchaInfo = new TheFileInfo();
            captchaInfo.Id = 54;
            captchaInfo.Parent = basicInfo;
            captchaInfo.Name = "Captcha";
            captchaInfo.Type = "文件夹";
            captchaInfo.Size = null;
            captchaInfo.ModifyDate = DateTime.Parse("2014/8/17 20:22");
            infos.Add(captchaInfo);


            info = new TheFileInfo();
            info.Id = 55;
            info.Parent = captchaInfo;
            info.Name = "captcha.ashx";
            info.Type = "ASHX文件";
            info.Size = 1;
            info.ModifyDate = DateTime.Parse("2014/7/5 16:31");
            infos.Add(info);

            info = new TheFileInfo();
            info.Id = 56;
            info.Parent = captchaInfo;
            info.Name = "captcha.ashx.cs";
            info.Type = "CS文件";
            info.Size = 2;
            info.ModifyDate = DateTime.Parse("2014/7/5 16:31");
            infos.Add(info);


            // basic -> hello.aspx
            info = new TheFileInfo();
            info.Id = 51;
            info.Parent = basicInfo;
            info.Name = "hello.aspx";
            info.Type = "ASPX文件";
            info.Size = 1;
            info.ModifyDate = DateTime.Parse("2014/7/5 16:31");
            infos.Add(info);

            info = new TheFileInfo();
            info.Id = 52;
            info.Parent = basicInfo;
            info.Name = "hello.aspx.cs";
            info.Type = "CS文件";
            info.Size = 1;
            info.ModifyDate = DateTime.Parse("2014/8/24 11:08");
            infos.Add(info);

            info = new TheFileInfo();
            info.Id = 53;
            info.Parent = basicInfo;
            info.Name = "hello.aspx.designer.cs";
            info.Type = "CS文件";
            info.Size = 2;
            info.ModifyDate = DateTime.Parse("2014/7/5 16:31");
            infos.Add(info);

            info = new TheFileInfo();
            info.Id = 100;
            info.Parent = null;
            info.Name = "default.aspx";
            info.Type = "ASPX文件";
            info.Size = 31;
            info.ModifyDate = DateTime.Parse("2014/11/15 18:44");
            infos.Add(info);

            info = new TheFileInfo();
            info.Id = 101;
            info.Parent = null;
            info.Name = "default.aspx.cs";
            info.Type = "CS文件";
            info.Size = 13;
            info.ModifyDate = DateTime.Parse("2014/10/27 18:44");
            infos.Add(info);

            info = new TheFileInfo();
            info.Id = 102;
            info.Parent = null;
            info.Name = "default.aspx.designer.cs";
            info.Type = "CS文件";
            info.Size = 12;
            info.ModifyDate = DateTime.Parse("2014/10/12 20:57");
            infos.Add(info);


            info = new TheFileInfo();
            info.Id = 105;
            info.Parent = null;
            info.Name = "Web.config";
            info.Type = "CONFIG文件";
            info.Size = 3;
            info.ModifyDate = DateTime.Parse("2014/11/6 20:59");
            infos.Add(info);


            return infos;
        }

        private class TheFileInfo
        {
            private int _id;

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private string _type;

            public string Type
            {
                get { return _type; }
                set { _type = value; }
            }

            private int? _size;

            public int? Size
            {
                get { return _size; }
                set { _size = value; }
            }

            private DateTime _modifyDate;

            public DateTime ModifyDate
            {
                get { return _modifyDate; }
                set { _modifyDate = value; }
            }


            private TheFileInfo _parent;

            public TheFileInfo Parent
            {
                get { return _parent; }
                set { _parent = value; }
            }


        }


        #endregion

    }
}