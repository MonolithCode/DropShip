using System.Diagnostics;

namespace MonolithDS.Logger
{
    public class Class1
    {
        public void test(string message, string logName, string source, EventLogEntryType typeOfMessage)
        {
            using (EventLog myLog = new EventLog(source))
            {
                myLog.Source = source;
                myLog.WriteEntry(message, typeOfMessage);
            }
        }
        
                
    }
}
