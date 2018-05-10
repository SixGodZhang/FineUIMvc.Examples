using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleTool.Common
{
    public class CMDMSG
    {
        private bool result;
        private string msg;

        public bool Result { get => result; set => result = value; }
        public string Msg { get => msg; set => msg = value; }

        public override string ToString()
        {
            return "cmd excute result: " + Result + ",detail msg : " + Msg;
        }
    }
}