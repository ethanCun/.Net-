using System;
using SuperSocketDemo2.SuperSocket;
using NLog;

namespace SuperSocketDemo2
{
    /*
        注意事项：
        
        a) MyServer、自定义命令和MySession的访问权限必须设置为public

        b) MyServer父类为AppServer<MySession>

        c) MySession父类为AppSession<MySession>

        d) HELLO父类为CommandBase<MySession,StringRequestInfo>，
        ExecueteCommand方法传入值类型分别为MySession和StringRequestInfo

        e) 多服务器中需注意AppSession、AppServer、自定义命令中的AppSession不要搞错

        AppSession 代表一个和客户端的逻辑连接，基于连接的操作应该定于在该类之中。
        你可以用该类的实例发送数据到客户端，接收客户端发送的数据或者关闭连接。

        AppServer 代表了监听客户端连接，承载TCP连接的服务器实例。
        理想情况下，我们可以通过AppServer实例获取任何你想要的客户端连接，
        服务器级别的操作和逻辑应该定义在此类之中。

        命令行协议是一种被广泛应用的协议。一些成熟的协议如 Telnet, SMTP, POP3 和 FTP 都是基于命令行协议的。
        在SuperSocket 中， 如果你没有定义自己的协议，SuperSocket 将会使用命令行协议, 这会使这样的协议的开发变得很简单。
        命令行协议定义了每个请求必须以回车换行结尾 "\r\n"。

        如果你在 SuperSocket 中使用命令行协议，所有接收到的数据将会翻译成 StringRequestInfo 实例.

        SuperSocket 中内置的命令行协议用空格来分割请求的Key和参:
        因此当客户端发送如下数据到服务器端时: "LOGIN kerry 123456" + NewLine
        SuperSocket 服务器将会收到一个 StringRequestInfo 实例，这个实例的属性为:

        Key: "LOGIN"
        Body: "kerry 123456";
        Parameters: ["kerry", "123456"]

        如果你定义了名为 "LOGIN" 的命令, 这个命令的 ExecuteCommand 方法将会被执行，
        服务器所接收到的StringRequestInfo实例也将作为参数传给这个方法:

        public class LOGIN : CommandBase<AppSession, StringRequestInfo>
        {
            public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
            {
                //Implement your business logic
            }
        }
        */

    class Program
    {
        private static Logger log = LogManager.GetLogger("SuperSocket");

        static void Main(string[] args)
        {
            log.Debug("打印的方法信息:{0}", Program.GetMethodInfo());

            TestServer testServer = new TestServer();

            if (!testServer.Setup(5005))
            {
                log.Debug("初始化失败,查看日志");

                return;
            }

            if (!testServer.Start())
            {
                log.Debug("服务器启动失败");

                return;
            }

            //log.Debug("服务器启动成功");

            Console.Read();

            //testServer.Stop();
        }

        public static string GetMethodInfo()
        {
            string str = "";

            //取得当前方法命名空间    
            str += "命名空间名:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "\n";

            //取得当前方法类全名 包括命名空间    
            str += "类名:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "\n";

            //取得当前方法名    
            str += "方法名:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n"; str += "\n";

            //父方法
            System.Diagnostics.StackTrace ss = new System.Diagnostics.StackTrace(true);
            System.Reflection.MethodBase mb = ss.GetFrame(1).GetMethod();

            //取得父方法命名空间    
            str += "父方法命名空间 " + mb.DeclaringType.Namespace + "\n";

            //取得父方法类名    
            str += "父方法类名 " + mb.DeclaringType.Name + "\n";

            //取得父方法类全名    
            str += "父方法类全名" + mb.DeclaringType.FullName + "\n";

            //取得父方法名    
            str += "父方法名" + mb.Name + "\n";

            return str;
        }
    }


}
