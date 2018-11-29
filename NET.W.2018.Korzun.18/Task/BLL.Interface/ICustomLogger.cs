using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.BLL.Interfaces
{
    /// <summary>
    /// Custom logger 
    /// </summary>
    public interface ICustomLogger
    {
        /// <summary>
        /// Warn message
        /// </summary>
        /// <param name="message">warning message</param>
        void Warn(string message);

        /// <summary>
        /// Info message
        /// </summary>
        /// <param name="message">info message</param>
        void Info(string message);

        /// <summary>
        /// Error message
        /// </summary>
        /// <param name="exception">output ArgumentException</param>
        /// <param name="message">error message</param>
        void Error(Exception exception, string message);
    }
}
