using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class LargeDataPagingDatabaseDataController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/LargeDataPagingDatabaseData
        public ActionResult Index(int total, int pageIndex, int pageSize)
        {
            string result = GetPagedLargeData(total, pageIndex, pageSize);

            return Content(result);
        }

        private string[] USER_NAMES = { "男", "童光喜", "男", "方原柏", "女", "祝春亚", "男", "涂辉", "男", "舒兆国", "男", "熊忠文", "男", "徐吉琳", "男", "方金海", "男", "包卫峰", "女", "靖小燕", "男", "杨习斌", "男", "徐长旺", "男", "聂建雄", "男", "周敦友", "男", "陈友庭", "女", "陆静芳", "男", "袁国柱", "女", "骆新桂", "男", "许治国", "男", "马先加", "男", "赵恢川", "男", "柯常胜", "男", "黄国鹏", "男", "柯尊北", "男", "刘海云", "男", "罗清波", "男", "张业权", "女", "丁溯鋆", "男", "吴俊", "男", "郑江", "男", "李亚华", "男", "石光富", "男", "谭志洪", "男", "胡中生", "男", "董龙剑", "男", "陈红", "男", "汪海平", "男", "彭道洲", "女", "尹莉君", "男", "占耀玲", "男", "付杰", "男", "王红艳", "男", "邝兴", "男", "饶玮", "男", "王方胜", "男", "陈劲松", "男", "邓庆华", "男", "王石林", "男", "胡俊明", "男", "索相龙", "男", "陈海军", "男", "吴文涛", "女", "熊望梅", "女", "段丽华", "女", "胡莎莎", "男", "徐友安", "男", "肖诗涛", "男", "王闯", "男", "余兴龙", "男", "芦荫杰", "男", "丁金富", "男", "谭军令", "女", "鄢旭燕", "男", "田坤", "男", "夏德胜", "男", "喻显发", "男", "马兴宝", "男", "孙学涛", "男", "陶云成", "男", "马远健", "男", "田华", "男", "聂子森", "男", "郑永军", "男", "余昌平", "男", "陶俊华", "男", "李小林", "男", "李荣宝", "男", "梅盈凯", "男", "张元群", "男", "郝新华", "男", "刘红涛", "男", "向志强", "男", "伍小峰", "男", "胡勇民", "男", "黄定祥", "女", "高红香", "男", "刘军", "男", "叶松", "男", "易俊林", "男", "张威", "男", "刘卫华", "男", "李浩", "男", "李寿庚", "男", "涂洋", "男", "曹晶", "男", "陈辉", "女", "彭博", "男", "严雪冰", "男", "刘青", "女", "印媛", "男", "吴道雄", "男", "邓旻", "男", "陈骏", "男", "崔波", "男", "韩静颐", "男", "严安勇", "男", "刘攀", "女", "刘艳", "女", "孙昕", "女", "郑新", "女", "徐睿", "女", "李月杰", "男", "吕焱鑫", "女", "刘沈", "男", "朱绍军", "女", "马茜", "女", "唐蕾", "女", "刘姣", "女", "于芳", "男", "吴健", "女", "张丹梅", "女", "王燕", "女", "贾兆梅", "男", "程柏漠", "男", "程辉", "女", "任明慧", "女", "焦莹", "女", "马淑娟", "男", "徐涛", "男", "孙庆国", "男", "刘胜", "女", "傅广凤", "男", "袁弘", "男", "高令旭", "男", "栾树权", "女", "申霞", "女", "韩文萍", "女", "隋艳", "男", "邢海洲", "女", "王宁", "女", "陈晶", "女", "吕翠", "女", "刘少敏", "女", "刘少君", "男", "孔鹏", "女", "张冰", "女", "王芳", "男", "万世忠", "女", "徐凡", "女", "张玉梅", "女", "何莉", "女", "时会云", "女", "王玉杰", "女", "谭素英", "女", "李艳红", "女", "刘素莉", "男", "王旭海", "女", "安丽梅", "女", "姚露", "女", "贾颖", "女", "曹微", "男", "黄经华", "女", "陈玉华", "女", "姜媛", "女", "魏立平", "女", "张萍", "男", "来辉", "女", "陈秀玫", "男", "石岩", "男", "王洪捍", "男", "张树军", "女", "李亚琴", "女", "王凤", "女", "王珊华", "女", "杨丹丹", "女", "教黎明", "女", "修晶", "女", "丁晓霞", "女", "张丽", "女", "郭素兰", "女", "徐艳丽", "女", "任子英", "女", "胡雁", "女", "彭洪亮", "女", "高玉珍", "女", "王玉姝", "男", "郑伟", "女", "姜春玲", "女", "张伟", "女", "王颖", "女", "金萍", "男", "孙望", "男", "闫宝东", "男", "周相永", "女", "杨美娜", "女", "欧立新", "女", "刘宝霞", "女", "刘艳杰", "女", "宋艳平", "男", "李克", "女", "梁翠", "女", "宗宏伟", "女", "刘国伟", "女", "敖志敏", "女", "尹玲" };
        private string[] MAJORS = { "数学系", "计算与应用数学系", "概率统计系", "物理系", "近代物理系", "光学与光学工程系", "天文学系", "化学物理系", "材料科学与工程系", "化学系", "高分子科学与工程系", "近代力学系", "精密机械与精密仪器系", "热科学和能源工程系", "安全科学与工程系", "电子工程与信息科学系", "自动化系", "电子科学与技术系", "外语系", "工商管理系", "管理科学系", "统计与金融系" };


        private string GetPagedLargeData(int total, int pageIndex, int pageSize)
        {
            JObject jo = new JObject();

            // 总记录数
            jo.Add("recordCount", total);

            JArray jaFields = JArray.Parse("[\"Id\",\"Name\",\"Gender\",\"EntranceYear\",\"AtSchool\",\"Major\",\"Group\"]");
            jo.Add("fields", jaFields);

            int USER_NAMES_LENGTH = USER_NAMES.Length;

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > total)
            {
                rowend = total;
            }


            JArray ja = new JArray();
            Random rd = new Random();
            for (int i = rowbegin; i < rowend; i++)
            {
                // 入学年份、专业、分组，都是随机赋值
                int entranceYear = rd.Next(2000, 2016);
                bool atSchool = false;
                if (entranceYear >= 2008)
                {
                    atSchool = true;
                }

                // 姓名则按照在 USER_NAMES 中的出现顺序
                int userNameIndex = (i * 2) % USER_NAMES_LENGTH;
                string userName = USER_NAMES[userNameIndex + 1];
                int gender = USER_NAMES[userNameIndex] == "男" ? 1 : 0;
                // 防止相同的名字重复出现
                int userNameLoop = (i * 2) / USER_NAMES_LENGTH;
                if (userNameLoop > 0)
                {
                    userName += String.Format("（{0}）", userNameLoop);
                }

                JArray jaItem = new JArray();
                jaItem.Add(i + 1);
                jaItem.Add(userName);
                jaItem.Add(gender);
                jaItem.Add(entranceYear);
                jaItem.Add(atSchool ? 1 : 0);
                jaItem.Add(MAJORS[rd.Next(0, MAJORS.Length)]);
                jaItem.Add(rd.Next(1, 6));

                ja.Add(jaItem);
            }
            jo.Add("data", ja);


            return jo.ToString(Newtonsoft.Json.Formatting.None);
        }

    }
}