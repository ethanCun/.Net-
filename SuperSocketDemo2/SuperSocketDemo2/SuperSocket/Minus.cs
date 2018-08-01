using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocketDemo2.SuperSocket;

namespace SuperSocketDemo2.SuperSocket
{
    public class Minus : CommandBase<TestSession, StringRequestInfo>
    {
        public override void ExecuteCommand(TestSession session, StringRequestInfo requestInfo)
        {
            double v1 = Convert.ToDouble(requestInfo.Parameters.First());
            double v2 = Convert.ToDouble(requestInfo.Parameters.Last());

            session.Send(string.Format("minus result = {0}", v2 - v1));
        }
    }
}
