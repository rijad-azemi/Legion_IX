using MongoDB.Bson;

namespace Legion_IX
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Form formToShow = new frm_LoginScreen();

            Application.Run(formToShow);
        }
    }
}