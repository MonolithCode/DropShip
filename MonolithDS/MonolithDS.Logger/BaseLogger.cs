using System;

namespace MonolithDS.Logger
{
    public class BaseLogger
    {
        protected string GenerateErrorText(Exception ex)
        {
            var entry = ex.Message + "\r\n\r\n" + ex.Source + "\r\n\r\n" + ex.StackTrace
                        + "\r\n\r\n" + ex.InnerException;

            return entry;
        }
    }
}
