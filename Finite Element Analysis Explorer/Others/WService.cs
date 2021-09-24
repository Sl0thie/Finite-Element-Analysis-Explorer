namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// WService class provides web service methods.
    /// </summary>
    internal static class WService
    {
        private static DateTime sessionStart;

        /// <summary>
        /// Reports when a session starts.
        /// </summary>
        public static void ReportSessionStart()
        {
            sessionStart = DateTime.UtcNow;

            FEAE.FEAESoapClient soap = new FEAE.FEAESoapClient();

            try
            {
                soap.ReportSessionStart2Async(Options.Id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"WebService ReportSessionStart Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Report a session when it finishes.
        /// </summary>
        public static void ReportSession()
        {
            Debug.WriteLine("WService.ReportSession");

            FEAE.FEAESoapClient soap = new FEAE.FEAESoapClient();

            try
            {
                if (Debugger.IsAttached)
                {
                    soap.ReportSession3Async(sessionStart, DateTime.UtcNow, true, Options.Id);
                }
                else
                {
                    soap.ReportSession3Async(sessionStart, DateTime.UtcNow, false, Options.Id);
                }  
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"WebService ReportSession Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Reports exceptions.
        /// </summary>
        /// <param name="exception">The exception that was raised.</param>
        public static void ReportException(Exception exception)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            FEAE.FEAESoapClient soap = new FEAE.FEAESoapClient();

            Debug.WriteLine("Exception");
            Debug.WriteLine($"HResult: {exception.HResult}");
            Debug.WriteLine($"Message: {exception.Message}");
            Debug.WriteLine($"StackTrace: {exception.StackTrace}");
            Debug.WriteLine($"TargetSite: {exception.TargetSite.Name}");
            Debug.WriteLine($"Source: {exception.Source}");

            string source = exception.Source + "," + sf.GetMethod().DeclaringType + "," + sf.GetMethod().Name;

            try
            {
                soap.ReportError2Async(exception.HResult, exception.Message, exception.StackTrace, exception.TargetSite.Name.ToString(), source, Options.Id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"WebService ReportSession Error: {ex.Message}");
            }
        }
    }
}