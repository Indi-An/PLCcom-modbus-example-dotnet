using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PLCComMB_Master_Example_CSharp
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Keep the full sample rendering behaviour explicit for both Demo and
            // Release configurations.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if Demo
            // Demo configuration runs the full demo form (mainDemo).
            Application.Run(new mainDemo());
#else
            // Release configuration runs the standard operator form (main).
            Application.Run(new main());
#endif
        }
    }
}
