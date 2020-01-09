using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFProject.Biz
{
    public class BaseService
    {
        protected LogWriter m_logWritter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();

        protected void LogCritical(string message)
        {
            if (m_logWritter.IsLoggingEnabled())
            {
                m_logWritter.Write(message, "General", 1, 2013, TraceEventType.Critical, "WSOMS.Criticals");
            }
        }

        protected void LogCritical(Exception ex)
        {
            LogCritical(WrapException(ex));
        }

        protected void LogError(string message)
        {
            if (m_logWritter.IsLoggingEnabled())
            {
                m_logWritter.Write(message, "General", 2, 2013, TraceEventType.Error, "WSOMS.Errors");
            }
        }

        protected void LogError(Exception ex)
        {
            LogError(WrapException(ex));
        }

        protected void LogWarning(string message)
        {
            if (m_logWritter.IsLoggingEnabled())
            {
                m_logWritter.Write(message, "General", 3, 2013, TraceEventType.Warning, "WSOMS.Warnings");
            }
        }

        protected void LogWarning(Exception ex)
        {
            LogWarning(WrapException(ex));
        }

        protected void LogInfo(string message)
        {
            if (m_logWritter.IsLoggingEnabled())
            {
                m_logWritter.Write(message, "General", 4, 2013, TraceEventType.Information, "WSOMS.Information");
            }
        }

        protected void LogInfo(Exception ex)
        {
            LogInfo(WrapException(ex));
        }

        private static string WrapException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Message:" + ex.Message).AppendLine();
            sb.Append("StackTrace:" + ex.StackTrace).AppendLine();
            if (ex.InnerException != null)
            {
                sb.Append(WrapException(ex.InnerException));
            }

            return sb.ToString();
        }
    }
}
