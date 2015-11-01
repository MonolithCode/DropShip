using System;
using System.Diagnostics;

namespace MonolithDS.Logger
{
    public interface ILogger
    {
        void WriteToLog(Exception error, EventLogEntryType errorType);
    }
}
