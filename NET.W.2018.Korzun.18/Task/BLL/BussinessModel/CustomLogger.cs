using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Task.BLL.Interfaces;

namespace Task.BLL.BussinessModel
{
    public class CustomLogger : ICustomLogger
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public void Error(Exception exception, string message)
        {
            this.logger.Error(exception, message);
        }

        public void Info(string message)
        {
            this.logger.Info(message);
        }

        public void Warn(string message)
        {
            this.logger.Warn(message);
        }
    }
}
