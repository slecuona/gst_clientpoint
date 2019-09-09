using System;
using System.Diagnostics;
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
                // Arranco el splash
                UIManager.StartSplash();

                // Inicializa logs
                Logger.Init();

                KillEvolisCenter();

                // Estado de servicio Evolis
                Status.Espf();

                // Estado de la conexion con la API
                Status.Api();

                // Inicializa las ventanas que utiliza la app
                UIManager.Init();

                UIManager.StopSplash();

                UIManager.ShowWindow(Window.Ads);
                
                // Pantalla principal / inicial (publicidades)
                Application.Run(UIManager.Get(Window.Ads));
            }
            catch (Exception ex) {
                Logger.Exception(ex);
                MsgBox.Error($"Error: {ex.Message}");
            }
        }

        // Cerramos el Evolis Print Center
        // Asi evitamos los popups con el estado de impresion
        private static void KillEvolisCenter() {
            foreach (var process in Process.GetProcessesByName("EvoPCUI")) {
                process.Kill();
            }
        }
    }
}
