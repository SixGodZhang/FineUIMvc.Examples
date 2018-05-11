using System.Collections.Generic;

namespace SimpleTool.Common
{
    public class GlobalConstant
    {
        public static string CMD_EXCUTE_SUCCESS = "success";
        public static string CMD_EXCUTE_FAIL = "fail";

        public static string BAT_ROOT_PATH = @"D:\VSWorkSpace\UIDemo\FineUIMvc.Examples\CommonComponents\BatCommand\";

        public static Dictionary<string, string> BAT_PATH_DIC = new Dictionary<string, string>
        {
            { "copy",BAT_ROOT_PATH + "copy.bat"},
            { "GetArt2Game_SW_PC",BAT_ROOT_PATH + "GetArt2Game_SW_PC.bat"}
        };
    }
}