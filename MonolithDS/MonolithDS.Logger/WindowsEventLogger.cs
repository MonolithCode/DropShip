using System;
using System.Diagnostics;

namespace MonolithDS.Logger
{
    [DebuggerNonUserCode]
    public class WindowsEventLogger : BaseLogger, ILogger
    {
        public void WriteToLog(Exception ex, EventLogEntryType errorType)
        {
            using (var myLog = new EventLog(ex.Source))
            {
                myLog.Source = ex.Source;
                myLog.WriteEntry(GenerateErrorText(ex), errorType);
            }
        }
    }
}
