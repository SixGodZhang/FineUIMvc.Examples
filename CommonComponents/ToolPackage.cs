using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SimpleTool.Common
{
    public class ToolPackage
    {
        public static CMDMSG BatTool(string batPath)
        {
            string outPutString = string.Empty;
            string errMsg = string.Empty;
            StringBuilder returnMsg = new StringBuilder();

            CMDMSG resultMsg = new CMDMSG();

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
                pro.WaitForExit();

                resultMsg.Result = false;

                //逐行读取标准输出
                while ((outPutString = pro.StandardOutput.ReadLine())!=null)
                {
                    if (outPutString.Contains(GlobalConstant.CMD_EXCUTE_SUCCESS))
                    {
                        resultMsg.Result = true;
                    }

                    returnMsg.Append(outPutString + '_');
                }

                resultMsg.Msg = returnMsg.ToString();

                if (!resultMsg.Result)
                {
                    resultMsg.Msg = string.Empty;
                    resultMsg.Msg = pro.StandardError.ReadToEnd();
                }
            }
            return resultMsg;
        }

        
    }
}