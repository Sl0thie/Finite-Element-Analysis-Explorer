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
                soap.ReportSessionStartAsync();
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
                soap.ReportSessionAsync(sessionStart, DateTime.UtcNow);
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
            FEAE.FEAESoapClient soap = new FEAE.FEAESoapClient();

            Debug.WriteLine("Exception");
            Debug.WriteLine($"HResult: {exception.HResult}");
            Debug.WriteLine($"Message: {exception.Message}");
            Debug.WriteLine($"StackTrace: {exception.StackTrace}");
            Debug.WriteLine($"TargetSite: {exception.TargetSite.Name.ToString()}");
            Debug.WriteLine($"Source: {exception.Source}");

            try
            {
                soap.ReportErrorAsync(exception.HResult, exception.Message, exception.StackTrace, exception.TargetSite.Name.ToString(), exception.Source);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"WebService ReportSession Error: {ex.Message}");
            }
        }
    }
}