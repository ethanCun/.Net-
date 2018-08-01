using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocketDemo2.SuperSocket;
using System;
using System.Linq;

namespace SuperSocketDemo.Commands
{
    public class ADD : CommandBase<TestSession, StringRequestInfo>
    {
        public override void ExecuteCommand(TestSession session, StringRequestInfo requestInfo)
        {
            session.Send(requestInfo.Parameters.Select(p => Convert.ToDouble(p)).Sum().ToString());
        }
    }
}
