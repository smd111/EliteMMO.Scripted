namespace EliteMMO.Scripted
{
    using System;
    using System.Windows.Forms;
    using Views;
    using API;
    static class Program
    {
        //private static EliteAPI core;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(null));
        }
    }
}
