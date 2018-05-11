using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace SimpleTool.Common
{
    public class ToolPackage
    {

        public static void ReadError(object data)
        {
            Process temp = (Process)data;
            if (temp == null)
            {
                return;
            }

            string outputStr = string.Empty;
            while ((outputStr = temp.StandardError.ReadLine()) != null)
            {
                resultMsg.Result = false;
                returnMsg.Append(outputStr + '_');
            }
        }

        public static void ReadOutput(object data)
        {
            Process temp = (Process)data;
            if (temp == null)
            {
                return;
            }

            string outputStr = string.Empty;
            while ((outputStr = temp.StandardOutput.ReadLine()) != null)
            {
                if (outputStr.Contains("success"))
                {
                    resultMsg.Result = true;
                }
                returnMsg.Append(outputStr + '_');
            }
        }

        private static CMDMSG resultMsg = new CMDMSG();
        private static StringBuilder returnMsg = new StringBuilder();

        public static CMDMSG BatTool(string batPath)
        {
            resultMsg = new CMDMSG();
            returnMsg.Clear();

            Thread t1 = new Thread(new ParameterizedThreadStart(ReadOutput));
            t1.IsBackground = true;
            Thread t2 = new Thread(new ParameterizedThreadStart(ReadError));
            t1.IsBackground = true;

            using (Process pro = new Process())
            {
                FileInfo file = new FileInfo(batPath);
                pro.StartInfo.WorkingDirectory = file.Directory.FullName;
                pro.StartInfo.FileName = batPath;
                pro.StartInfo.CreateNoWindow = false;
                pro.StartInfo.RedirectStandardOutput = true;
                pro.StartInfo.RedirectStandardError = true;
                pro.StartInfo.UseShellExecute = false;

                pro.Start();
                t1.Start(pro);
                t2.Start(pro);
                pro.WaitForExit();
                resultMsg.Msg = returnMsg.ToString();
            }
            return resultMsg;
        }


    }
}