using System;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocketDemo2.SuperSocket
{
    public class TestSession : AppSession<TestSession>
    {
        /// <summary>  
        /// 新连接  
        /// </summary>  
        protected override void OnSessionStarted()
        {
            //输出客户端IP地址  
            //Console.WriteLine(this.LocalEndPoint.Address.ToString());
            this.Send("Hello User,Welcome to SuperSocket Telnet Server!");
        }

        /// <summary>  
        /// 未知的Command (也就是与规定好的Command名称不一致的客户端消息回调)
        /// </summary>  
        /// <param name="requestInfo"></param>  
        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            //在SocketTool中文会显示成多个尾号 ??????
            this.Send("指令发送有误");
        }

        /// <summary>  
        /// 捕捉异常并输出  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void HandleException(Exception e)
        {
            this.Send("error: {0}", e.Message);
        }

        /// <summary>  
        /// 连接关闭  
        /// </summary>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
        }
    }
}
