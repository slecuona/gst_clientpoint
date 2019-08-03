using System;
using System.Windows.Forms;
using ClientPoint.UI;
using ClientPoint.Utils;

namespace ClientPoint {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try {
                Logger.Init();

                Status.Espf();

                UIManager.Init();

                // Pantalla principal / inicial (publicidades)
                Application.Run(UIManager.Get(Window.Ads));
            }
            catch (Exception ex) {
                Logger.Exception(ex);
                MsgBox.Error(null, $"Error: {ex.Message}");
            }
        }
    }
}
