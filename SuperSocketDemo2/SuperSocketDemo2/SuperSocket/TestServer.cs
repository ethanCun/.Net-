using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using NLog;

namespace SuperSocketDemo2.SuperSocket
{
   public class TestServer : AppServer<TestSession>
    {
        private readonly static Logger log = LogManager.GetLogger("SuperSocket");

        //自定义命令行协议 key与body用：分开 body里面用，分开 如：TestCommand:1,1 
        public TestServer() : base(new CommandLineReceiveFilterFactory(Encoding.Default, new BasicRequestInfoParser(":", ",")))
        {
          
        }

        protected override void OnStarted()
        {
            base.OnStarted();

            log.Debug("服务器启动:OnStarted");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }

        /// <summary>
        /// 有新连接建立
        /// </summary>
        /// <param name="session"></param>
        protected override void OnNewSessionConnected(TestSession session)
        {
            base.OnNewSessionConnected(session);

            log.Debug(session.RemoteEndPoint.Address.ToString());

            foreach(TestSession testSession in this.GetAllSessions())
            {
                session.Send(string.Format("当前在线用户数：{0}", this.SessionCount.ToString()));

                log.Debug(string.Format("当前在线用户数 : {0}", this.SessionCount.ToString()));
            }
        }

        /// <summary>
        /// 连接关闭
        /// </summary>
        /// <param name="session"></param>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(TestSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);

            log.Debug(string.Format("远程=ip：{0}， port:{1}",
                session.RemoteEndPoint.Address.MapToIPv4().ToString(),
                session.RemoteEndPoint.Port.ToString())
                );

            log.Debug(string.Format("本地=ip:{0}, port:{1}",
                session.LocalEndPoint.Address.MapToIPv4().ToString(),
                session.LocalEndPoint.Port.ToString())
                );

            foreach(TestSession testSession in this.GetAllSessions())
            {
                log.Debug(string.Format("当前连接数量:{0}", this.SessionCount.ToString()));
            }
        }
    }
}
