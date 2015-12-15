using System;

namespace EbayModule.Error
{
    public class EbayErrorLogger : IEbayErrorLogger
    {
        public void WriteToLog(eBaySvc.ErrorType error, System.Diagnostics.EventLogEntryType errorType)
        {
            throw new NotImplementedException();
        }

        protected string GenerateErrorText(Exception ex)
        {
            var entry = ex.Message + "\r\n\r\n" + ex.Source + "\r\n\r\n" + ex.StackTrace
                        + "\r\n\r\n" + ex.InnerException;

            return entry;
        }
    }
}
