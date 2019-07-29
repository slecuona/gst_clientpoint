using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientPoint.UI;

namespace ClientPoint {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Status.Espf();

            UIManager.Init();

            // Pantalla principal / inicial (publicidades)
            Application.Run(UIManager.Get(Window.Ads));
        }
    }
}
