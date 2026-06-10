using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PLCcomMB_Slave_Example_CSharp
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Shared WinForms setup used by all SDK demo apps.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // The full slave app only has one entry form.
            Application.Run(new Main());
        }
    }
}
