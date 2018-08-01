using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using NLog;

namespace SuperSocketDemo2.SuperSocket
{
    public class TestCommand : CommandBase<TestSession, StringRequestInfo>
    {
        private static readonly Logger log = LogManager.GetLogger("SuperSocket");

        /*
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

        /// <summary>
        /// 我们可以看到在Command类中实现的方法ExecuteCommand中包含两个参数，
        /// 一个为Session，一个为StringRequestInfo。两个参数分别对应的定义为：
        /// [前者表示当前发起命令的会话，后者表示发起命令的具体内容，
        /// 我们使用这两个方法就可以完全对客户端传递的命令进行处理，逻辑导航如下：
        //
        //发起命令 > SuperSocket处理解析 > 触发Session内部事件 > 触发ExecuteCommand事件 
        //> 自定义命令解析处理 > 触发Send事件返回服务器处理数据
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(TestSession session, StringRequestInfo requestInfo)
        {
            session.Send(requestInfo.Body.ToString());

            //log.Debug(System.Reflection.MethodBase.GetCurrentMethod().Name);
            
            //session.CustomId = new Random().Next(1000, 9999);
            //session.CustomName = "hello world";

            //在requestInfo对象中key表示命令头，param表示命令参数，body表示请求内容
            //（注：在默认协议中，key、param、body的区分都是依靠空格实现，
            //列如add 1 1，解析的意思就是key=add、param=[1,1]、body=1 1），
            //依靠内置的默认换行符协议就可以实现大部分想要的功能内容，
            //也是在简单应用上面推荐的一种通信协议。
            //session.Send(session.CustomId.ToString());

            //log.Debug(session.CustomName);
            //log.Debug(session.CustomId);
        }
    }
}
