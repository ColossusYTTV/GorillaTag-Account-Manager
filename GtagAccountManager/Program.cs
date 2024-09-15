using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GtagAccountManager
{
    internal static class Program
    {
        [DllImport("Shcore.dll")]
        private static extern int SetProcessDpiAwareness(ProcessDpiAwareness value);

        private enum ProcessDpiAwareness
        {
            ProcessDpiUnaware = 0,
            ProcessSystemDpiAware = 1,
            ProcessPerMonitorDpiAware = 2
        }

        [STAThread]
        static void Main()
        {
            SetProcessDpiAwareness(ProcessDpiAwareness.ProcessSystemDpiAware);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
