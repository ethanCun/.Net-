using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;

namespace NLogTest.Controllers
{
    public class NLogController : ApiController
    {
        private static readonly Logger logger = LogManager.GetLogger("NLogTest");

        /// <summary>
        /// NLog的使用方式基本上和其它的Log库差不多，分为Trace、Debug、Info、Error、Fatal五个等级
        /// </summary>
        public string TestLogger()
        {
            logger.Trace("NLogController 跟踪");
            logger.Debug("NLogController  调试");
            logger.Info("NLogController 信息");
            logger.Error("NLogController 错误");
            logger.Fatal("NLogController 致命错误");

            return logger.Name;
        }

        public string SaySomething(string something)
        {
            logger.Debug(something);

            return something;
        }
    }
}
