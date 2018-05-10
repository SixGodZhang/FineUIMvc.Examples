using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.ThirdParty.Controllers
{
    public class AutoCompleteMultiValuesRemoteController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: ThirdParty/AutoCompleteMultiValuesRemote
        public ActionResult Index()
        {
            return View();
        }

        private static readonly string[] LANGUAGES = new string[]{
                "ActionScript",
                "AppleScript",
                "Asp",
                "BASIC",
                "C",
                "C++",
                "Clojure",
                "COBOL",
                "ColdFusion",
                "Erlang",
                "Fortran",
                "Groovy",
                "Haskell",
                "Java",
                "JavaScript",
                "Lisp",
                "Perl",
                "PHP",
                "Python",
                "Ruby",
                "Scala",
                "Scheme"
        };


        [HttpGet]
        public ActionResult SearchResult(string term)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(term))
            {
                term = term.ToLower();

                JArray ja = new JArray();
                foreach (string lang in LANGUAGES)
                {
                    if (lang.ToLower().Contains(term))
                    {
                        ja.Add(lang);
                    }
                }

                result = ja.ToString();
            }

            return Content(result);
        }

    }
}