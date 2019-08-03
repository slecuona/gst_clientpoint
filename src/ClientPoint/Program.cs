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
                // Inicializa logs
                Logger.Init();

                // Estado de servicio Evolis
                Status.Espf();

                // Estado de la conexion con la API
                Status.Api();

                // Inicializa las ventanas que utiliza la app
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
