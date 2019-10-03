using System;
using System.Diagnostics;
using System.Windows.Forms;
using ClientPoint.UI;
using ClientPoint.Utils;
using Telerik.WinControls;

namespace ClientPoint {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var splash = true;
            try {
                // Arranco el splash
                UIManager.StartSplash();
                
                // Inicializa logs
                Logger.Init();

                KillEvolisCenter();

                // Estado de servicio Evolis
                Status.EspfInit();

                // Estado de la conexion con la API
                Status.Api();

                // Inicializa las ventanas que utiliza la app
                UIManager.Init();

                UIManager.StopSplash();
                splash = false;

                //Op.TestBase64();

                UIManager.ShowWindow(Window.Ads);
                
                // Pantalla principal / inicial (publicidades)
                Application.Run(UIManager.Get(Window.Ads));
            }
            catch (Exception ex) {
                Logger.Exception(ex);
                Form owner = splash ? UIManager.Splash : null;
                if (owner == null && UIManager.CurrWindow != Window.None)
                    owner = UIManager.GetCurrent();
                if (owner != null)
                    owner.InvokeIfRequired(() => 
                        RadMessageBox.Show(owner, $"Error: {ex.Message}"));
                else
                    RadMessageBox.Show(owner, $"Error: {ex.Message}");
                Application.Exit();
            }
        }

        // Cerramos el Evolis Print Center
        // Asi evitamos los popups con el estado de impresion
        private static void KillEvolisCenter() {
            foreach (var process in Process.GetProcessesByName("PrinterManager")) {
                process.Kill();
            }
        }
    }
}
