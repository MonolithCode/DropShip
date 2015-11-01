using System.Diagnostics;
using EbayModule.eBaySvc;

namespace EbayModule.Error
{
    public interface IEbayErrorLogger
    {
        void WriteToLog(ErrorType error, EventLogEntryType errorType);
    }
}