using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;

//注意下面的语句一定要加上，指定log4net使用.config文件来读取配置信息
//如果是WinForm（假定程序为MyDemo.exe，则需要一个MyDemo.exe.config文件）
//如果是WebForm，则从web.config中读取相关信息
//表示直接从 app.config中读取配置即可
//如果你只是一个简单的项目，那么在这个项目的 AssemblyInfo.cs文件上加上
//[assembly: log4net.Config.XmlConfigurator(Watch=true)]即可。
//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Log4NetDemo
{
    /// 说明：本程序演示如何利用log4net记录程序日志信息。log4net是一个功能著名的开源日志记录组件。
    /// 利用log4net可以方便地将日志信息记录到文件、控制台、Windows事件日志和数据库中
    /// （包括MS SQL Server, Access, Oracle9i,Oracle8i,DB2,SQLite）。
    /// 下面的例子展示了如何利用log4net记录日志
    class Program
    {
        static void Main(string[] args)
        {
            //Log4net框架定义了一个叫做LogManager的类，用来管理所有的logger对象。它有一个GetLogger()静态方法，用我们提供的名字参数来检索已经存在的Logger对象。如果框架里不存在该Logger对象，它也会为我们创建一个Logger对象。代码如下所示：
            //log4net.ILog log = log4net.LogManager.GetLogger("logger-name");
            //通常来说，我们会以类（class）的类型（type）为参数来调用GetLogger()
           ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            log.Debug("调试");

            log.Info("信息");

            log.Warn("警告");

            log.Error("错误");

            log.Fatal("致命错误");

            Console.WriteLine("命令执行完毕");
            Console.Read();
        }
    }
}
