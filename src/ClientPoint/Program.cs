using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using ClientPoint.UI;
using ClientPoint.Utils;
using Telerik.WinControls;
using View = ClientPoint.UI.View;

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

                Status.Init();
                
                // Inicializa las ventanas que utiliza la app
                UIManager.Init();

                UIManager.StopSplash();

                //Op.TestBase64();

                UIManager.ShowView(View.MainMenu);
                //Thread.Sleep(1000);
                var frm = UIManager.GetActiveForm();
                frm?.Activate();

                // Pantalla principal / inicial (publicidades)
                Application.Run(frm);
            }
            catch (Exception ex) {
                Logger.Exception(ex);
                UIManager.SafeExecOnActiveForm(owner =>
                    RadMessageBox.Show(owner, $"Error: {ex.Message}"));
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
