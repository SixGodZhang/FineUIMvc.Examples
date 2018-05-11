#自动化工具(持续更新)#

在项目开发中通常我们会做**项目集成来节省时间成本**，这是站在公司的角度;如果映射到个人，我们也会经常写一些小脚本来辅助开发，但是这些小脚本基本零散在电脑各处，不方便寻找，复用性其实也不高。所以，写这个个人项目的主要原因**就是把四散在电脑各处的脚本整合起来，看着舒服~~~**

其实，编写这个项目还有一些理由，

- 接受某人的建议，站在更高维度来看项目中的问题；
- 提高个人能力（勉强算得上一个理由吧，有点虚）,尤其是在C#方面的;
- 为之后的伟大事业（当然是自己开发游戏啦）奠定技术基础；

## 架构规划(目前) ##
- Web：主要支持.asp .html .css .js .cshtml .vbhtml
- 服务端:支持C#语言,基于.net MVC
- 数据库:sqlserver(可变化)

[自动化工具架构图]

## 项目地址 ##
github(项目文件未剔除干净，暂时不建议下载): [git@github.com:SixGodZhang/FineUIMvc.Examples.git](git@github.com:SixGodZhang/FineUIMvc.Examples.git "自动化工具")

## 更新日志 ##
### 2018.5.10 ##
- 测试功能:复制文件
- Web功能:Log日志收集
- 登录验证功能：需用户登录

【功能显示图】

## Bug收集 ##

### 1.AJAX 请求超时 ##
**问题描述:**
从Web端向服务器发送消息时，因服务器等待批处理完成，时限过长，请求终止

**解决方案:**

1. web.config可设置AJAX会话时间
1. 前端设置一个发送状态请求的定时器，此时间和AJAX超时时间一致，后端不断坚持批处理的状态即可

### 2.C# 代码调用批处理，批处理执行一半中断 ##
**问题描述:**
在C#调用Process类来处理批处理,重定向输出缓冲区之后，批处理中断

**原因分析:**
重定向输出缓冲区之后，缓冲区有固定大小，需及时从输出缓冲区取走内容来清空输出缓冲区，否则cmd.exe会一直等待

**解决方案:**
开辟多线程读取输出缓冲区内容即可

## 参考资料 ##

- 菜鸟学院ASP.NET教程:[http://www.runoob.com/aspnet/razor-intro.html](http://www.runoob.com/aspnet/razor-intro.html "菜鸟学院ASP.NET教程")
- FineUIMVC教程:[https://www.cnblogs.com/sanshi/p/6210695.html](https://www.cnblogs.com/sanshi/p/6210695.html "FineUIMVC教程")
- Microsoft ASP.NET 教程[https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started)