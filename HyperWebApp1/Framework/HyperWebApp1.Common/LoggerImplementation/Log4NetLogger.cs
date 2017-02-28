// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log4NetLogger.cs" company="EPAM Systems">
// Copyright 2016
// </copyright>
// <summary>
//   Defines the RedisStorageErrorLog type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HyperWebApp1.Common.LoggingImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using HyperWebApp1.Common.Logging;
    using log4net;
    using log4net.Core;
    /// <summary>
    /// Log4NetLogger
    /// </summary>
    /// <seealso cref="HyperWebApp1.Common.Logging.ILoggerHelper" />
    public class Log4NetLogger : ILogHelper
    {
        /// <summary>
        /// The log
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(object message)
        {
            this.log.Debug(message);
        }

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Debug(object message, Exception exception)
        {
            this.log.Debug(message, exception);
        }

        /// <summary>
        /// Debugs the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void DebugFormat(string format, params object[] args)
        {
            this.log.DebugFormat(format, args);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(object message)
        {
            this.log.Error(message);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Error(object message, Exception exception)
        {
            this.log.Error(message, exception);
        }

        /// <summary>
        /// Errors the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void ErrorFormat(string format, params object[] args)
        {
            this.log.ErrorFormat(format, args);
        }

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(object message)
        {
            this.log.Fatal(message);
        }

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Fatal(object message, Exception exception)
        {
            this.log.Fatal(message, exception);
        }

        /// <summary>
        /// Fatals the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void FatalFormat(string format, params object[] args)
        {
            this.log.FatalFormat(format, args);
        }

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(object message)
        {
            this.log.Info(message);
        }

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Info(object message, Exception exception)
        {
            this.log.Info(message, exception);
        }

        /// <summary>
        /// Informations the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void InfoFormat(string format, params object[] args)
        {
            this.log.InfoFormat(format, args);
        }

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warning(object message)
        {
            this.log.Warn(message);
        }

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Warning(object message, Exception exception)
        {
            this.log.Warn(message, exception);
        }
        /// <summary>
        /// Warns the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void WarnFormat(string format, params object[] args)
        {
            this.log.WarnFormat(format, args);
        }

        /// <summary>
        /// Logs the specified logging data.
        /// </summary>
        /// <param name="loggingData">The logging data.</param>
        public void Log(LoggingData loggingData)
        {
            var loggingEventData = new LoggingEventData();

            loggingEventData.Domain = loggingData.Domain;
            loggingEventData.ExceptionString = loggingData.Exception;
            loggingEventData.LoggerName = loggingData.LoggerName;
            loggingEventData.Message = loggingData.Message;
            loggingEventData.ThreadName = loggingData.ThreadName;
            loggingEventData.TimeStamp = loggingData.TimeStamp;
            loggingEventData.UserName = loggingData.UserName;
            this.log.Logger.Log(new LoggingEvent(loggingEventData));
        }
    }
}
